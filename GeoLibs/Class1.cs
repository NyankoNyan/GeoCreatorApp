using System.Collections.Generic;

namespace GeoLibs
{
    public class Class1
    {
    }

    public class VolcanicEpoch : Epoch
    {

    }

    public class CoolingOffEpoch : Epoch
    {

    }

    public interface ITreeAccess
    {
        int Id { get; }
        string Name { get; }
        string Type { get; }
        int ChildrenCount { get; }
        IEnumerable<ITreeAccess> Children { get; }
    }

    public abstract class BaseNode : ITreeAccess
    {
        private int id;
        public BaseNode(int id)
        {
            this.id = id;
        }

        public int Id => id;

        public string Name => $"Unknown node { id }";

        public abstract string Type { get; }

        public int ChildrenCount => 0;

        public IEnumerable<ITreeAccess> Children => new ITreeAccess[0];
    }

    public class ValueNode : BaseNode
    {
        public const string NodeType = "Value";
        public ValueNode(int id) : base( id ) { }
        public override string Type => NodeType;
    }

    public class ListNode : BaseNode
    {
        public const string NodeType = "List";
        public ListNode(int id) : base( id ) { }
        public override string Type => NodeType;
    }

    public class EpochNode : BaseNode
    {
        public const string NodeType = "Epoch";
        public EpochNode(int id) : base( id ) { }
        public override string Type => NodeType;
    }

    public class NodeStorage
    {
        private int maxId = 0;
        private Dictionary<int, ITreeAccess> nodeById = new Dictionary<int, ITreeAccess>();

        public ITreeAccess Create(string typeName)
        {
            ITreeAccess node;
            switch (typeName) {
                case ValueNode.NodeType:
                    node = new ValueNode( ++maxId );
                    break;
                case ListNode.NodeType:
                    node = new ListNode( ++maxId );
                    break;
                case EpochNode.NodeType:
                    node = new EpochNode( ++maxId );
                    break;
                default:
                    throw new System.ArgumentException();
            }
            nodeById.Add( maxId, node );
            return node;
        }

        public ITreeAccess GetNode(int id)
        {
            return nodeById[id];
        }
    }
}
