using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser
{
    public class TreeNode
    {
        public string name { get; }
        public List<TreeNode> childs { get; set; }

        public TreeNode(string name)
        {
            childs = new List<TreeNode>();
            this.name = name;
        }

        public void AddChild(TreeNode node)
        {
            childs.Add(node);
        }
    }
}
