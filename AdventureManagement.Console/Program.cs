using AdventureManagementConsole.UI.UIMenu;
using AdventureManagementConsole.UI.UIService;
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        var guideService = new GuideService();        
        var organismService = new OrganismService(); 
        var adventureService = new AdventureService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Chương trình quản lý Adventure ===");
            Console.WriteLine("1. Quản lý Người tham gia");
            Console.WriteLine("2. Quản lý Hướng dẫn viên");
            Console.WriteLine("3. Quản lý Sinh vật");
            Console.WriteLine("4. Quản lý Chuyến phiêu lưu");
            Console.WriteLine("5. Thoát");
            Console.Write("Chọn một tùy chọn: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var participantUI = new ParticipantUI();
                    await participantUI.LuaChon(); 
                    break;
                case "2":
                    var guideUI = new GuideUI(guideService);
                    await guideUI.DisplayMainMenu();
                    break;
                case "3":
                    var organismUI = new OrganismUI(organismService);
                    await organismUI.DisplayMainMenu(); 
                    break;
                case "4":
                    var adventureUI = new AdventureUI(adventureService);
                    await adventureUI.DisplayMainMenu(); 
                    break;
                case "5":
                    Console.WriteLine("Thoát khỏi chương trình...");
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                    break;
            }

            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
        }
    }
}

