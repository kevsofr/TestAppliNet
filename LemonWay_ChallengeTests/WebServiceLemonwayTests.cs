using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonWay_Challenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client.localhost;

namespace LemonWay_Challenge.Tests
{
    [TestClass()]
    public class WebServiceLemonwayTests
    {
        [TestMethod()]
        public void FibonacciTest()
        {

            //Arrange
            long expected = 8;
            int input = 6;

            //Act
            WebServiceLemonway obj = new WebServiceLemonway();
            long actuel = obj.Fibonacci(input);

            //Assert
            Assert.AreEqual(expected, actuel);

        }

        [TestMethod()]
        public void XmlToJasonTest()
        {

            //Arrange
            string expected = "{\"foo\":\"bar\"}";
            string input = ("<foo>bar</foo>");

            //Act
            WebServiceLemonway obj = new WebServiceLemonway();
            string actuel = obj.XmlToJson(input);

            //Assert
            Assert.AreEqual(expected, actuel);

        }

        [TestMethod()]
        public void XmlToJasonWarningTest()
        {

            //Arrange
            string expected = "Bad Xml format";
            string input = ("<foo>hello</bar>");

            //Act
            WebServiceLemonway obj = new WebServiceLemonway();
            string actuel = obj.XmlToJson(input);

            //Assert
            Assert.AreEqual(expected, actuel);

        }
    }
}