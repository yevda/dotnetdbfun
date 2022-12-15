using System.Xml.Linq;
using System.Xml.Serialization;

namespace XML_CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car>MyGarage= new List<Car>();

            MyGarage.Add(new Car()
            { 
                Name = "Mazda RX-8",
                ProductionDate = new DateTime (2006 , 03, 10) }
            );

            MyGarage.Add(new Car()
            {
                Name = "Honda Civic",
                ProductionDate = new DateTime(2018, 01, 25)
            }
            );

            MyGarage.Add(new Car()
            {
                Name = "Таврія",
                ProductionDate = new DateTime(2002, 12, 12)
            }
            );

            XmlSerializer serializer= new XmlSerializer( typeof(List<Car> ) );
            var stringWriter = new StringWriter();
            serializer.Serialize( stringWriter, MyGarage );

            using (XML_Context db = new XML_Context())
            {
                XML_Data data = new XML_Data();
                data.XML_String = stringWriter.ToString();
                data.XML_XElement = XElement.Parse(stringWriter.ToString() );
                db.XML_Data.Add( data );
                db.SaveChanges();

            };

            Console.WriteLine("Done!");
            Console.ReadLine();

        }
    }
}