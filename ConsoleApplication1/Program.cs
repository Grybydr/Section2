using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlDatabase;
using DomainModel;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlRepository repository = new MySqlRepository();
            
            foreach(var i in repository.SearchInTitle("fastest"))
            {
                Console.WriteLine(i.Title);
            }
            

        }
    }
}
