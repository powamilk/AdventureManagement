using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureManagementConsole.Model
{
    public class ParticipantInteractionModel
    {
        public int Id { get; set; }
        public string AdventureTitle { get; set; } 
        public string ParticipantName { get; set; } 
        public int Rating { get; set; } 
        public string Comment { get; set; } 
        public DateTime CreatedAt { get; set; }
    }

}
