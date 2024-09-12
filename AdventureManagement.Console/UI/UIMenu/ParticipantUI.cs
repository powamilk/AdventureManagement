using AdventureManagementConsole.UI.UIService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureManagementConsole.UI.UIMenu
{
    public class ParticipantUI
    {
        private readonly ParticipantUIService _service;

        public ParticipantUI()
        {
            _service = new ParticipantUIService();
        }

        public void DisplayMenu()
        {
            Console.WriteLine("1 - HIện thị tất cả người tham gia ");
            Console.WriteLine("2 - Thêm người tham gia");
        }

        public async Task LuaChon()
        {
            bool running = true;
            while(running)
            {
                DisplayMenu();
                Console.WriteLine("Chọn đi");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await _service.GetAll();
                        break;
                    case "2":
                        await _service.Create();
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}
