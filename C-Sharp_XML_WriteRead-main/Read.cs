using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace WriteReadXML
{
    class Read
    {      

        public static void ReadXML()
        {           
            string path = Directory.GetCurrentDirectory();
            path = path.Replace("bin\\Debug\\netcoreapp3.1", "");

            try
            {
                XElement elemLinq = XElement.Load(path + "\\misEmpleadosXML.xml");
                IEnumerable<XElement> elementos = elemLinq.Elements();
                //elementos es ahora el nodo raiz, debo acceder a sus hijos
                foreach (var elem in elementos)
                {
                    //si el nodo hijo se llama listado accedo a sus hijos
                    if (elem.Name.ToString().Equals("listado"))
                    {
                        string id;
                        string nombreCompleto;
                        string cuil;
                        string sector;
                        string cupoAsignado;
                        string cupoConsumido;
                        string atributoDenominacion;
                        string atributocolorSemaforo;
                        string atributovalorSemaforo;
                        int contador = 1;
                        IEnumerable<XElement> empleado = elem.Elements();

                        foreach (var item in empleado)
                        {
                             Console.WriteLine("Empleado numero: "+ contador+"\n");
                             id = item.Element("id").Value;
                             nombreCompleto = item.Element("nombreCompleto").Value;
                             cuil = item.Element("cuil").Value;
                             sector = item.Element("sector").Value + "hola";
                             cupoAsignado = item.Element("cupoAsignado").Value;
                             cupoConsumido = item.Element("cupoConsumido").Value;                          
                             Console.WriteLine("Id->" +id + ",NombreCompleto-> "+nombreCompleto+ ", Cuil-> "+ cuil+
                                 ", CupoAsignado-> " +cupoAsignado+ ", CupoConsumido " +cupoConsumido +", Sector=> ");
                                                        
                            //verifico que el nodo se llame sector y que tenga atributos
                            if(item.Element("sector").Name.ToString().Equals("sector") && item.Element("sector").HasAttributes) 
                            {   //accedo al atributo del elemento
                                atributoDenominacion = item.Element("sector").Attribute("denominacion").Value;
                                atributocolorSemaforo = item.Element("sector").Attribute("colorSemaforo").Value;
                                atributovalorSemaforo = item.Element("sector").Attribute("valorSemaforo").Value;
                                Console.WriteLine("Atributos del sector=>\nDenominacion->" +atributoDenominacion+
                                    ", ColorSemaforo->"+atributocolorSemaforo+ ", ValorSemaforo->" + atributovalorSemaforo);
                            }
                            contador++;
                            Console.WriteLine("\n");
                        }
                    }

                    if (elem.Name.ToString().Equals("subsectores")){
                        Console.WriteLine("Subsector: " + elem.Value);

                    }
                    if (elem.Name.ToString().Equals("totalCupoAsignado")){
                        Console.WriteLine("totalCupoAsignado: " + elem.Value);

                    }
                    if (elem.Name.ToString().Equals("totalCupoConsumido")){
                        Console.WriteLine("totalCupoConsumido: " + elem.Value);

                    }
                    if (elem.Name.ToString().Equals("valorDial"))
                    {
                        Console.WriteLine("valorDial: " + elem.Value);

                    }
                }              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
