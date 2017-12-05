using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_14
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlFunctions = new XmlFunctions();
            xmlFunctions.Read("building.xml");
            xmlFunctions.Validate("building.xml", "xsdSchema.xsd");
            xmlFunctions.Transform("building.xml", "xsltSchema.xslt");
        }
    }
}