using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace XMLread
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<library> librarys = new List<library>();
            var obj = new Database();
            //CreatDatabase(obj);
            ShowDatabase(obj);
            Console.ReadKey();
        }
        public static void CreatDatabase(Database d)
        {

            var xml = XElement.Load("file.xml");
            var librarysnode = xml.Descendants("Info").ToList();


            for (var i = 0; i < librarysnode.Count(); i++)
            {
                var librarynode = librarysnode[i];
            }
            int count = 0;
            foreach (var librarynode in librarysnode)
            {
                ++count;
                var name = librarynode.Attribute("name").Value.Trim();
                var address = librarynode.Attribute("address").Value.Trim();
                var openTime = librarynode.Attribute("openTime").Value.Trim();
                var phone = librarynode.Attribute("phone").Value.Trim();
                var fax = librarynode.Attribute("fax").Value.Trim();
                library librarydata = new library();
                librarydata.name = name;
                librarydata.address = address;
                librarydata.openTime = openTime;
                librarydata.phone = phone;
                librarydata.fax = fax;
                d.CreateLibrary(librarydata);

            }
            librarysnode
                .Where(x => !x.IsEmpty).ToList()
                .ForEach(librarynode => { });

        }
        public static void ShowDatabase(Database d)
        {
            List<library> libraryget = new List<library>();
            libraryget=d.ReadLibrary();
            int count = 1;
            libraryget.ForEach(x => {
                Console.WriteLine("第" + (count++) + "筆" + "資料");
                Console.WriteLine("\t圖書館名:" + x.name);
                Console.WriteLine("\t住址:" + x.address);
                Console.WriteLine("\t開館時間:" + x.openTime);
                Console.WriteLine("\t聯絡電話:" + x.phone);
                Console.WriteLine("\t傳真:" + x.fax);
                Console.WriteLine();
            });
        }
    }
}
