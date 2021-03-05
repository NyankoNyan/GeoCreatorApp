using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoLibs;

namespace GeoCreator
{
    public partial class NoiseViewerForm : Form
    {
        private struct TrackBarSettings
        {
            public double mult;
            public TextBox textBox;

            public TrackBarSettings(double mult, TextBox textBox)
            {
                this.mult = mult;
                this.textBox = textBox;
            }
        }

        private Dictionary<TrackBar, TrackBarSettings> barLinks;
        private Task generateTask;
        private CancellationTokenSource generateToken;
        public NoiseViewerForm()
        {
            InitializeComponent();

            barLinks = new Dictionary<TrackBar, TrackBarSettings>() {
                { trackBarScale, new TrackBarSettings( .1, textBoxScaleValue ) },
                { trackBarXOffset, new TrackBarSettings( .1, textBoxXOffsetValue ) },
                { trackBarYOffset, new TrackBarSettings( .1, textBoxYOffsetValue ) },
                { trackBarZOffset, new TrackBarSettings( .1, textBoxZOffsetValue ) },
                { trackBarOctaves, new TrackBarSettings( 1, textBoxOctavesValue ) },
                { trackBarPersistence, new TrackBarSettings( .01, textBoxPersistenceValue ) }
            };
        }

        private void bGenerate_Click(object sender, EventArgs e)
        {
            Generate();
        }

        private void Generate()
        {
            if (generateTask != null && !generateTask.IsCompleted) {
                generateToken.Cancel();
                generateTask.Wait();
            }
            generateToken = new CancellationTokenSource();
            generateTask = Task.Run( () => {
                try {
                    pbOutput.Image = FillBitmap( pbOutput.Width, pbOutput.Height,
                        Double.Parse( textBoxScaleValue.Text ),
                        Double.Parse( textBoxXOffsetValue.Text ),
                        Double.Parse( textBoxYOffsetValue.Text ),
                        Double.Parse( textBoxZOffsetValue.Text ),
                        Double.Parse( textBoxPersistenceValue.Text ),
                        int.Parse( textBoxOctavesValue.Text ) );
                } catch (TaskCanceledException) { }
            } );
        }

        private void TrackBarsChangeTexts(object sender, EventArgs e)
        {
            TrackBarSettings trackBarSettings = barLinks[sender as TrackBar];
            trackBarSettings.textBox.Text = ValText( (TrackBar)sender, trackBarSettings.mult );
            Generate();
        }

        private string ValText(TrackBar trackBar, double mult)
        {
            return ( trackBar.Value * mult ).ToString();
        }

        private void NoiseViewerForm_Load(object sender, EventArgs e)
        {
            foreach (var kvp in barLinks) {
                kvp.Value.textBox.Text = ValText( kvp.Key, kvp.Value.mult );
            }
            Generate();
        }

        private Bitmap FillBitmap(int width, int height, double scale, double offsetX, double offsetY, double offsetZ, double persistence, int octaves)
        {
            PerlinNoise perlinNoise = new PerlinNoise {
                scale = scale,
                offsetX = offsetX,
                offsetY = offsetY,
                offsetZ = offsetZ,
                octaves = octaves,
                persistence = persistence
            };
            DirectBitmap directBitmap = new DirectBitmap( width, height );
            Parallel.For( 0, width, (x, state) => {
                if (generateToken.IsCancellationRequested) {
                    state.Break();
                }
                for (int y = 0; y < height; y++) {
                    int value = (int)( perlinNoise.Generate( (double)x / width, (double)y / height ) * 255 );
                    directBitmap.SetPixel( x, y, Color.FromArgb( value, value, value ) );
                }
            } );
            if (generateToken.IsCancellationRequested) {
                directBitmap.Dispose();
                throw new TaskCanceledException();
            }
            Bitmap result = directBitmap.Bitmap;
            directBitmap.Dispose();
            return result;
        }
    }
}
