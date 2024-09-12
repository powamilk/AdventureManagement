using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureManagementConsole.Model
{
    public class GuideModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Expertise { get; set; }
        public int ExperienceYears { get; set; }
        public int AdventureCount { get; set; }
    }

}
