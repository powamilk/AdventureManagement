using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureManagementConsole.Model
{
    public class AdventureModel
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Location { get; set; }
        public string GuideName { get; set; }
        public int ParticipantCount { get; set; } 
    }

}
