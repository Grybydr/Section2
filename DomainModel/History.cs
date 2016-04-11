using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class History
    { 




        public int Id { get; set; }
        public string Statement { get; set; }
        public DateTime SearchDate { get; set; }

        public History(int _id, string _statement, DateTime _searchDate)
        {
            Statement = _statement;
            Id = _id;
            SearchDate = _searchDate;
        }

        public History()
        {
            Statement = "";
            Id = 0;
            SearchDate = DateTime.Now;
        }
    }

        
}
