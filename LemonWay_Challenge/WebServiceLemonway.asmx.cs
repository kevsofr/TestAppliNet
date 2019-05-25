using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;
using log4net;

namespace LemonWay_Challenge
{
    
    /// <summary>
    /// Description résumée de WebServiceLemonway
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceLemonway : System.Web.Services.WebService
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(WebServiceLemonway));
        /// <summary>
        /// The Fibonacci service takes input an integer N, and return the Nth value in the Fibonacci sequence
        /// </summary>
        /// <param name="input"></param>
        /// <returns>integer</returns>
        [WebMethod]
        public long Fibonacci(int input)
        {
            logger.Debug("run Fibonacci");
            
            try
            {
                if(input < 101 && input > 0)
                {
                    int a = 0;
                    int b = 1;
                    // In N steps compute Fibonacci sequence iteratively.
                    for (int i = 0; i < input; i++)
                    {
                        int temp = a;
                        a = b;
                        b = temp + b;
                    }
                    return a;
                }
                else
                {
                    return -1;
                }
            }
            catch (ArgumentNullException e)
            {
                logger.Error("Error Fibonacci");
                throw new ArgumentNullException("Error", e);
            }
        }
        /// <summary>
        /// The XmlToJson service takes input a string xml and returns the json form of the xml string, It will return "Bad Xml format" if the input string is not a well-formed xml
        /// </summary>
        /// <param name="xml"></param>
        /// <returns>string</returns>
        [WebMethod]
        public string XmlToJson(string xml)
        {
            logger.Debug("run XmlToJson");
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                string jsonText = JsonConvert.SerializeXmlNode(doc);
                return jsonText;
            }
            catch (Exception e)
            {
                logger.Error("Error XmlToJason");
                return ("Bad Xml format");
            }
        }
    }
}
