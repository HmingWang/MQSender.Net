using MQSender.Net.View.WinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MQSender.Net.View
{
    public partial class Main: Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void mQ配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MQConfig().ShowDialog();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            BuildTree(this.treeView1.Nodes,"./Xmls");
        }

        private void BuildTree(TreeNodeCollection root,string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            TreeNode node = new TreeNode();
            node.Text = dir.Name;
            root.Add(node);

            if (!dir.Exists) return;
            //添加目录
            foreach (var d in dir.GetDirectories())
            {
                BuildTree(node.Nodes, d.FullName);
            }
            //添加文件
            foreach (var f in dir.GetFiles())
            {
                TreeNode nodeFile = new TreeNode();
                nodeFile.Text = f.Name;
                nodeFile.Tag = f.FullName;
                node.Nodes.Add(nodeFile);
            }
           
        }

        private void 使用说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Notes().ShowDialog();
        }

        private void 密钥对配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
