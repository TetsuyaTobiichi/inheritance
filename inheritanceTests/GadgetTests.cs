using Microsoft.VisualStudio.TestTools.UnitTesting;
using inheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance.Tests
{
    [TestClass()]
    public class GadgetTests
    {
        //Тестирование заполнения
        [TestMethod()]
        public void listLoadTest()
        {
            List<Gadget> techList = new List<Gadget>();
            techList.Clear();
            string test;
            for (byte i = 0; i < 4; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        techList.Add(new Laptop());
                        break;
                    case 1:
                        techList.Add(new Smartphone());
                        break;
                    case 2:
                        techList.Add(new Tablet());
                        break;
                }
            }
            test = techList[3] is Laptop ? "Laptop" : "ошибка";
            Assert.AreEqual(test, "Laptop");
        }
        //тестирование конструктора
        [TestMethod()]
        public void constructorTest()
        {
            Laptop test = new Laptop("test");
            Assert.AreEqual(test.getInfo(), "10 ядер, 2048 GB памяти, bluetooth есть, разрешение экрана 240");
        }
    }
}