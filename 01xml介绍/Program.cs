using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _01xml介绍
{
    class Program
    {
        static void Main(string[] args)
        {

            #region xml写入

            ////1.创建一个XDocument对象
            ////创建了一个空的文档对象
            //XDocument document = new XDocument();


            ////1.1创建一个文档声明
            //XDeclaration xDec = new XDeclaration("1.0", "gb2312", "yes");

            ////文档定义不能通过Add()这种方式来增加，需要设置Declaration属性。
            //document.Declaration = xDec;


            ////1.2创建一个根节点
            //XElement rootElement = new XElement("Order");
            ////把根节点加到文档中
            //document.Add(rootElement);



            ////1.3增加一个CustomerName节点，内容是“杨中科”
            //XElement cstNameElement = new XElement("CustomerName");
            //cstNameElement.SetValue("杨中科");
            ////把其他的节点要加到根节点下
            //rootElement.Add(cstNameElement);


            ////1.4增加一个OrderNumber节点
            ////通过调用SetElementValue的方式增加一个元素
            //rootElement.SetElementValue("OrderNumber", "BJ200888");


            ////1.5创建一个新对象,Items节点
            //XElement itemElement = new XElement("Item");
            ////创建3个OrderItem节点
            //XElement orderItemElement1 = new XElement("OrderItem");
            //orderItemElement1.SetAttributeValue("Name", "电脑");
            //orderItemElement1.SetAttributeValue("Count", "30");
            //itemElement.Add(orderItemElement1);

            //XElement orderItemElement2 = new XElement("OrderItem");
            //orderItemElement2.SetAttributeValue("Name", "电视");
            //orderItemElement2.SetAttributeValue("Count", "2");
            //itemElement.Add(orderItemElement2);

            //XElement orderItemElement3 = new XElement("OrderItem");
            //orderItemElement3.SetAttributeValue("Name", "水杯");
            //orderItemElement3.SetAttributeValue("Count", "20");
            //itemElement.Add(orderItemElement3);

            ////把Item加到根节点下
            //rootElement.Add(itemElement);




            ////把这个空文档对象写入到xml文件中。
            //document.Save("orders.xml");
            //Console.WriteLine("ok");
            //Console.Read();

            int sum = 0;
            while (true)
            {
                sum += 11;
            }

            #endregion


            #region Xml写入2

            //List<Person> list = new List<Person>() { 
            //new Person(){ Name="刘尚鑫", Age=20, Email="lsx@yahoo.com"},
            //new Person(){ Name="gwm", Age=21, Email="gwm@yahoo.com"},
            //new Person(){ Name="pll", Age=19, Email="pll@yahoo.com"},
            //new Person(){ Name="李晶晶", Age=20, Email="ljj@yahoo.com"}
            //};

            ////1.创建一个document对象
            //XDocument document = new XDocument();

            ////2.设置文档定义
            //document.Declaration = new XDeclaration("1.0", "gb2312", "yes");

            ////3.增加根节点
            //XElement rootElement = new XElement("List");
            //rootElement.SetAttributeValue("Count", list.Count);

            ////遍历list集合，有几个元素对象就创建几个子节点
            //foreach (Person item in list)
            //{
            //    XElement personElement = new XElement("Person");
            //    personElement.SetElementValue("Name", item.Name);
            //    personElement.SetElementValue("Age", item.Age);
            //    personElement.SetElementValue("Email", item.Email);

            //    //把当前的节点personElement，加到根节点下
            //    rootElement.Add(personElement);
            //}



            ////位文档增加根节点
            //document.Add(rootElement);


            ////需要把document,这个文档对象写入到文件中
            //document.Save("list.xml");

            //Console.WriteLine("ok");
            //Console.Read();


            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            //xmlSerializer.Serialize(

            #endregion



            #region 读取List.xml文件

            //1.创建一个Dom对象\
            XDocument document = XDocument.Load("list.xml");
            //2.一定要找到根节点
            XElement rootElement = document.Root;
            //Console.WriteLine(rootElement.Name.ToString());


            //判断是否有属性：
            Console.WriteLine(rootElement.Name);
            //调用输出元素属性的方法
            PrintAttributes(rootElement);

            //2.1获得根节点下的所有的子节点
            //不传参数，表示获取根节点下的所有的子元素
            //如果为Elements()方法传递参数，则表示要获取当前节点下的所有名字为参数中给定的名字的那些子元素

            //只要返回类型是IEnumerable接口类型的，无论是泛型还是非泛型的都可以在foreach中遍历

            //foreach (XElement element in rootElement.Elements("Car"))
            foreach (XElement element in rootElement.Elements())
            {
                //这个循环其实就是遍历根元素下的每个子元素
                //Console.WriteLine(element.Name);
                Console.WriteLine("节点=================={0}", element.Name);
                PrintAttributes(element);
                
                foreach (var subElement in element.Elements())
                {

                    Console.WriteLine("子节点===={0}::{1}", subElement.Name, subElement.Value);
                    PrintAttributes(subElement);
                }
            }
            Console.Read();


            #endregion
        }

        //打印元素的属性
        private static void PrintAttributes(XElement anyElement)
        {
            Console.WriteLine(anyElement.Name + "元素的属性：");
            foreach (XAttribute attr in anyElement.Attributes())
            {
                Console.WriteLine(attr.Name + "   " + attr.Value);
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
