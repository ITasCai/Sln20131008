using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace _02读取Order文件并显示
{
    class Program
    {
        static void Main(string[] args)
        {


            #region 读取Orders.xml
            ////1.构建一个XDocument文档对象
            //XDocument document = XDocument.Load("orders.xml");
            ////2.获取根节点
            //XElement rootElement = document.Root;


            ////调用Element()查找指定的元素，如果找到则返回第一个，如果找不到则返回null 
            //XElement custNameElement = rootElement.Element("CustomerName");
            //Console.WriteLine("订购人姓名：{0}", custNameElement.Value);
            //Console.WriteLine("订单编号：{0}", rootElement.Element("OrderNumber").Value);
            //Console.WriteLine("订单详细信息：");
            ////rootElement.Descendants("OrderItem")表示在根节点的所有【后代节点中】，查找标签为OrderItem的所有节点
            //foreach (XElement orderItem in rootElement.Descendants("OrderItem"))
            //{
            //    Console.WriteLine("Name={0},Count={1}", orderItem.Attribute("Name").Value, orderItem.Attribute("Count").Value);
            //}
            //Console.Read();

            #endregion
           

            #region 读取ytbank.xml

            ////1.加载文件到一个document 对象
            //XDocument document = XDocument.Load("ytbank.xml");
            ////2.获取该文档中的根节点、
            //XElement rootElement = document.Root;
            ////3.遍历根元素下的每个MSG节点
            //foreach (XElement msgItem in rootElement.Elements("MSG"))
            //{
            //    //对于每个找到的MSG节点都需要再继续遍历该节点下的所有的子节点
            //    foreach (XElement subItem in msgItem.Elements())
            //    {
            //        Console.WriteLine("{0}:{1}", subItem.Name, subItem.Attribute("val").Value);
            //    }
            //    Console.WriteLine("==============================================");
            //}
            //Console.Read();

            #endregion


           



        }
    }
}
