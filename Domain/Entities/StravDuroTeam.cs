using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravDuro.Domain.Entities
{
    public class StravDuroTeam
    {
        public string TeamName { get; set; }
        public StravDuro StravDuro { get; set; }
        public virtual ICollection<Athlete> Athlete { get; set; }
        
        public bool AddAthlete()
        {
            return false;
        }


    }
}
