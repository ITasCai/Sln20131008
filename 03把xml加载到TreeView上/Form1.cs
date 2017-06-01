using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _03把xml加载到TreeView上
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1.读取xml文件
            XDocument document = XDocument.Load("rss_sportslq.xml");
            //2.根节点(获取了xml的根节点)
            XElement root = document.Root;
            //将xml的根节点加到了TreeView的根节点下
            TreeNode tnRoot = treeView1.Nodes.Add(root.Name.ToString());
            //3.根节点下的所有子节点集合Elements()
            LoadXmlToTree(root.Elements(), tnRoot.Nodes);

        }
        //将xml的节点集合加到TreeView的根节点下
        private void LoadXmlToTree(IEnumerable<XElement> iEnumerable, TreeNodeCollection treeNodeCollection)
        {
            //遍历iEnumerable，将其中的内容加到treeNodeCollection下
            foreach (XElement xmlElement in iEnumerable)
            {
                //获取刚刚增加的TreeView节点
                TreeNode node = treeNodeCollection.Add(xmlElement.Name.ToString());
                if (xmlElement.Elements().Count() == 0)
                {
                    node.Nodes.Add(xmlElement.Value.ToString());
                }
                else
                {
                    LoadXmlToTree(xmlElement.Elements(), node.Nodes);
                }
            }
        }
    }
}
