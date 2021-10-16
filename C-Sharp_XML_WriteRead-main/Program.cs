using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace WriteReadXML
{
    class Program
    {
        static void Main(string[] args)
        {         
            Write.CreateXmlDocumento();

            Read.ReadXML();

        }
    }
}
