using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravDuro.Domain.Entities
{
    public class StravDuro
    {
        /*PUBLIC FIELDS*/
        public Int64 StravDuroId { get; set; }
        public string StravDuroName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Geo Location { get; set; }
        public virtual ICollection<Tag> Tags {get;set;}
        public virtual ICollection<StravDuroTeam> Teams { get; set; }

        /*CONSTRUCTORS*/



        /*PUBLIC METHODS*/
        public string EvaluateDuro()
        {
            return "LEADERBOARD";
        }
    }
}
