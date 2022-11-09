using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser
{
    public enum ItemType
    {
        Field, Property, Method, Ctor
    }
    class TreeGenerator
    {
        private string assemblyName;
        public readonly Dictionary<string, TreeNode> namespaces = new Dictionary<string, TreeNode>();

        public TreeGenerator(string name)
        {
            assemblyName = name;
        }

        public void AddType(string namespaceName, string typeName)
        {
            if (!namespaces.ContainsKey(namespaceName))
            {
                namespaces.Add(namespaceName, new TreeNode(namespaceName));
            }

            var type = new TreeNode(typeName);
            type.AddChild(new TreeNode("Fields"));
            type.AddChild(new TreeNode("Properties"));
            type.AddChild(new TreeNode("Methods"));
            type.AddChild(new TreeNode("Constructors"));
            namespaces[namespaceName].AddChild(type);
        }

        public void AddItemToLastAddedType(string namespaceName, TreeNode itemToAdd, ItemType itemType)
        {
            namespaces[namespaceName].childs.Last().childs[(int)itemType].AddChild(itemToAdd);
        }

        public TreeNode ToNodes()
        {
            var result = new TreeNode(assemblyName) { childs = namespaces.Values.ToList() };
            return result;
        }
    }
}
