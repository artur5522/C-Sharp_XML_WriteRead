using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace WriteReadXML
{
    class Write
    {
        public static void CreateXmlDocumento()
        {
            try
            {
                XElement empleados = new XElement("empleados");
                XElement listado = new XElement("listado");


                XElement nombre = new XElement("nombreCompleto", "Rodriguez, Victor");
                XElement id = new XElement("id", "4884");
                XElement cuil = new XElement("cuil","201865321");
                XElement cupoAsignado = new XElement("cupoAsignado","1837.15");
                XElement cupoConsumido= new XElement("cupoConsumido","658.05");

                XElement sector = new XElement("sector","");
                //XElement sector = new XElement("sector");
                //para que cierre etiqueta sin nada dentro como valor, sin etiqueta de cierre
                
                XAttribute denominacion = new XAttribute("denominacion", "Gerencia Recursos Humanos");
                XAttribute atributoID= new XAttribute("id", "137");
                XAttribute atributovalorSemaforo= new XAttribute("valorSemaforo", "130.13");
                XAttribute atributoColorSemaforo= new XAttribute("colorSemaforo", "VERDE");

                XElement empleado = new XElement("empleado");                
                sector.Add(denominacion);
                sector.Add(atributoID);
                sector.Add(atributoColorSemaforo);
                sector.Add(atributovalorSemaforo);
                empleado.Add(id);
                empleado.Add(nombre);
                empleado.Add(cuil);
                empleado.Add(sector);
                empleado.Add(cupoAsignado);
                empleado.Add(cupoConsumido);

                listado.Add(empleado);

                nombre = new XElement("nombreCompleto", "Sanchez, Juan Ignacio");
                id = new XElement("id", "1225");
                sector = new XElement("sector");
                cuil = new XElement("cuil", "201865555");
                cupoAsignado = new XElement("cupoAsignado", "750");
                cupoConsumido = new XElement("cupoConsumido", "625");
                denominacion = new XAttribute("denominacion", "Gerencia Operativa");
                atributoID = new XAttribute("id", "44");
                atributovalorSemaforo = new XAttribute("valorSemaforo", "130.13");
                atributoColorSemaforo = new XAttribute("colorSemaforo", "ROJO");

                empleado = new XElement("empleado");
                sector.Add(denominacion);
                sector.Add(atributoID);
                sector.Add(atributoColorSemaforo);
                sector.Add(atributovalorSemaforo);
                empleado.Add(id);
                empleado.Add(nombre);
                empleado.Add(cuil);
                empleado.Add(sector);
                empleado.Add(cupoAsignado);
                empleado.Add(cupoConsumido);

                listado.Add(empleado);

                XElement subsector = new XElement("subsectores","5");
                XElement totalCupoConsumido= new XElement("totalCupoAsignado","4217.21");
                XElement totalCupoAsignado= new XElement("totalCupoConsumido","1405");
                XElement valorDial= new XElement("valorDial","33.34");

                empleados.Add(listado);
                empleados.Add(subsector);
                empleados.Add(totalCupoConsumido);
                empleados.Add(totalCupoAsignado);
                empleados.Add(valorDial);

                XDeclaration declaration = new XDeclaration("1.0", "utf-8", "yes");
                XComment comentario = new XComment("Lista de empleados");
                XDocument miXML = new XDocument(declaration, comentario, empleados);


                string path = Directory.GetCurrentDirectory();
                path = path.Replace("bin\\Debug\\netcoreapp3.1", "");
                string archivoXML = path + "misEmpleadosXML.xml";
                miXML.Save(@archivoXML);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
