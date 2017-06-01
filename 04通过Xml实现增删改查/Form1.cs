using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _04通过Xml实现增删改查
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1.采集用户输入的信息
            string id = txtId.Text.Trim();
            string loginId = txtUid.Text.Trim();
            string password = txtPwd.Text;
            //2.读取旧的xml文档，并加载
            XDocument document = XDocument.Load("UserData.xml");
            XElement rootElement = document.Root;

            //int n = rootElement.Elements("user").Where(u => u.Attribute("id").Value == id).Count();
            //xpath
            int n = rootElement.Elements("user").Where(u => u.Attribute("id").Value == id || u.Element("name").Value == loginId).Count();
            if (n > 0)
            {
                MessageBox.Show("id已经存在");
            }
            else
            {



                //=============增加新用户的代码==============


                //3.在加载起来的document对象中加入新的节点
                //3.1创建一个user节点，属性id的值是编号id
                XElement userElement = new XElement("user");
                //增加属性
                userElement.SetAttributeValue("id", id);

                //向userElement节点下再增加name和password两个子元素
                userElement.SetElementValue("name", loginId);
                userElement.SetElementValue("password", password);

                //把新增的userElement节点加到根节点下
                rootElement.Add(userElement);


                //4.把这个修改后的document对象再保存回xml文件中
                document.Save("UserData.xml");
                MessageBox.Show("ok");
            }
        }
    }
}
