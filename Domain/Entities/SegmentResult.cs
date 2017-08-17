using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravDuro.Domain.Entities
{
    public class SegmentResult
    {
        public string ActivityName { get; set; }
        public Segment Segment { get; set; }
        public Athlete Athlete { get; set; }
        public DateTime DateOfActivity { get; set; }
        public int AchievementBonus { get; set; }
        public float ActivityDuration { get; set; }
    }
}
