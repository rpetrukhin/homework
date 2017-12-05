using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Xsl;

namespace Task_14
{
    public class XmlFunctions
    {
        public void Read(string xmlFile)
        {
            if (String.IsNullOrWhiteSpace(xmlFile))
                return;

            var xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlFile);

            var xmlFileRoot = xmlDocument.DocumentElement;

            foreach (XmlNode node in xmlFileRoot)
            {
                var attribute = node.Attributes.GetNamedItem("number");
                Console.WriteLine("Floor: {0}", attribute.Value);

                foreach (XmlNode childNode in node.ChildNodes)
                    foreach (XmlNode childOfChildNode in childNode)
                        Console.WriteLine("Flat: {0}", childOfChildNode.InnerText);

                Console.WriteLine();
            }
        }

        public void Validate(string xmlFile, string xsdFile)
        {
            if (String.IsNullOrWhiteSpace(xmlFile) || String.IsNullOrWhiteSpace(xsdFile))
                return;

            var xDocument = XDocument.Load(xmlFile);

            var xmlSchemaSet = new XmlSchemaSet();
            xmlSchemaSet.Add(null, xsdFile);

            try
            {
                xDocument.Validate(xmlSchemaSet, null);
                Console.WriteLine("Xml is correct");
            }
            catch
            {
                Console.WriteLine("Xml is incorrect");
            }
        }

        public void Transform(string xmlFile, string xsltFile)
        {
            if (String.IsNullOrWhiteSpace(xmlFile) || String.IsNullOrWhiteSpace(xsltFile))
                return;

            var xslCompiledTransform = new XslCompiledTransform();
            xslCompiledTransform.Load(xsltFile);

            string outXml = String.Format("{0}_v2.xml", xmlFile.Split('.')[0]);

            var xmlTextWriter = new XmlTextWriter(outXml, null);

            xslCompiledTransform.Transform(xmlFile, xmlTextWriter);
        }
    }
}