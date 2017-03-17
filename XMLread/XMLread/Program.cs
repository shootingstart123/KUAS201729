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
        static void Main(string[] args)
        {
            List<library> librarys = new List<library>();

            var xml = XElement.Load("file.xml");
            var librarysnode = xml.Descendants("Info").ToList();

            for(var i = 0; i < librarysnode.Count(); i++)
            {
                var librarynode = librarysnode[i];
            }
            foreach(var librarynode in librarysnode)
            {
                var groupTypeName = librarynode.Attribute("groupTypeName").Value.Trim();
                var email = librarynode.Attribute("email").Value.Trim();
                var fax = librarynode.Attribute("fax").Value.Trim();
                library librarydata = new library();
                librarydata.groupTypeName = groupTypeName;
                librarydata.email = email;
                librarydata.fax = fax;
                Console.WriteLine(groupTypeName);
                Console.WriteLine(email);
                Console.WriteLine(fax);
            }
            librarysnode
                .Where(x => !x.IsEmpty).ToList()
                .ForEach(librarynode => { });
            Console.ReadLine();
        }
    }
}
