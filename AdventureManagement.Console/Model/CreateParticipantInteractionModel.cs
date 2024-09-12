using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureManagementConsole.Model
{
    public class CreateParticipantInteractionModel
    {
        public int AdventureId { get; set; }
        public int ParticipantId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }

}
