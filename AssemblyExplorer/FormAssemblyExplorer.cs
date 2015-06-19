using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace AssemblyExplorer
{
    public partial class FormAssemblyExplorer : Form
    {
        Assembly currentAssembly;
        TreeNode rootNode;

        public FormAssemblyExplorer()
        {
            InitializeComponent();
        }

        private void menuAssembly_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog()==DialogResult.OK)
            {
                
            TreeNode typeNode, categoryNode=null, memberNode;
            currentAssembly = Assembly.Load("mscorlib.dll");
            tree.Nodes.Clear();            
            rootNode = tree.Nodes.Add("mscorlib.dll");
            Type[] assemblyTypes = currentAssembly.GetTypes();
            foreach (Type type in assemblyTypes)
            {
                typeNode = rootNode.Nodes.Add(type.Name);
                MemberInfo[] members = type.GetMembers();
                string memberType = string.Empty;                
                foreach (MemberInfo member in members)
                {
                    if (member.MemberType.ToString() != memberType)
                    {
                        categoryNode = new TreeNode(member.MemberType.ToString());
                        memberType = member.MemberType.ToString();
                        typeNode.Nodes.Add(categoryNode);
                    }
                    categoryNode.Nodes.Add(string.Format("{0}", member.Name));
                }
            }
        }
    }
}
