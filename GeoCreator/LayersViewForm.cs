using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoLibs;

namespace GeoCreator
{
    public partial class LayersViewForm : Form
    {
        public LayersViewForm()
        {
            InitializeComponent();
        }

        private void LayersViewForm_Load(object sender, EventArgs e)
        {

        }

        private void cmLayers_Opening(object sender, CancelEventArgs e)
        {

        }

        private ITreeAccess TestData1()
        {
            MaterialCollection materialCollection = new MaterialCollection();
            AccretionEpoch accretionEpoch = new AccretionEpoch() {
                materialCollection = materialCollection
            };
            const int resX = 128;
            const int resY = 128;
            accretionEpoch.generationsParams.Add( new AccretionEpoch.GenerationParams() {
                name = "Stone layer 1",
                material = "Stone",
                resolutionX = resX,
                resolutionY = resY,
                source = new PerlinNoise( offsetZ: 0 )
            } );
            accretionEpoch.generationsParams.Add( new AccretionEpoch.GenerationParams() {
                name = "Iron layer",
                material = "RawIron",
                resolutionX = resX,
                resolutionY = resY,
                source = new PerlinNoise( offsetZ: 1 )
            } );
            accretionEpoch.generationsParams.Add( new AccretionEpoch.GenerationParams() {
                name = "Stone layer 2",
                material = "Stone",
                resolutionX = resX,
                resolutionY = resY,
                source = new PerlinNoise( offsetZ: 2 )
            } );

            return accretionEpoch;
        }

        private void LoadTree(ITreeAccess root, TreeView treeView, TreeNode rootNode = null)
        {
            foreach (ITreeAccess child in root.Children) {
                TreeNodeCollection nodes;
                if (rootNode == null) {
                    nodes = treeView.Nodes;
                } else {
                    nodes = rootNode.Nodes;
                }
                TreeNode node = nodes.Add( child.Id.ToString(), child.Name );
                LoadTree( child, treeView, node );
            }
        }

        private string GetTreeNodeText(ITreeAccess node)
        {
            return $"[{ node.Id }] { node.Name } - { node.Type }";
        }
    }

    

}
