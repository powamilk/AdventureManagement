using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureManagementConsole.UI.UIService;

namespace AdventureManagementConsole.UI.UIMenu
{
    public class AdventureUI
    {
        private readonly AdventureService _service;

        public AdventureUI(AdventureService service)
        {
            _service = service;
        }

        public AdventureUI()
        {
        }

        public async Task DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("=== Quản lý Chuyến Phiêu Lưu ===");
                Console.WriteLine("1. Xem tất cả các chuyến phiêu lưu");
                Console.WriteLine("2. Thêm chuyến phiêu lưu mới");
                Console.WriteLine("3. Cập nhật chuyến phiêu lưu");
                Console.WriteLine("4. Xóa chuyến phiêu lưu");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn một tùy chọn: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await DisplayAllAdventures();
                        break;
                    case "2":
                        await AddNewAdventure();
                        break;
                    case "3":
                        await UpdateAdventure();
                        break;
                    case "4":
                        await DeleteAdventure();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
        }

        private async Task DisplayAllAdventures()
        {
            var adventures = await _service.GetAllAdventuresAsync();
            Console.WriteLine("=== Danh sách chuyến phiêu lưu ===");
            foreach (var adventure in adventures)
            {
                Console.WriteLine($"ID: {adventure.Id}, Tiêu đề: {adventure.Title}, Vị trí: {adventure.Location}, Hướng dẫn viên: {adventure.GuideName}, Số người tham gia: {adventure.ParticipantCount}");
            }
        }

        private async Task AddNewAdventure()
        {
            Console.Write("Nhập tiêu đề chuyến phiêu lưu: ");
            var title = Console.ReadLine();

            Console.Write("Nhập mô tả: ");
            var description = Console.ReadLine();

            Console.Write("Nhập vị trí: ");
            var location = Console.ReadLine();

            Console.Write("Nhập thời gian (số ngày): ");
            var duration = int.Parse(Console.ReadLine());

            Console.Write("Nhập ID hướng dẫn viên: ");
            var guideId = int.Parse(Console.ReadLine());

            await _service.CreateAdventureAsync(new { Title = title, Description = description, Location = location, Duration = duration, GuideId = guideId });
            Console.WriteLine("Chuyến phiêu lưu mới đã được thêm.");
        }

        private async Task UpdateAdventure()
        {
            Console.Write("Nhập ID của chuyến phiêu lưu cần cập nhật: ");
            var id = int.Parse(Console.ReadLine());

            Console.Write("Nhập tiêu đề mới: ");
            var title = Console.ReadLine();

            Console.Write("Nhập mô tả mới: ");
            var description = Console.ReadLine();

            Console.Write("Nhập vị trí mới: ");
            var location = Console.ReadLine();

            Console.Write("Nhập thời gian mới (số ngày): ");
            var duration = int.Parse(Console.ReadLine());

            Console.Write("Nhập ID hướng dẫn viên mới: ");
            var guideId = int.Parse(Console.ReadLine());

            await _service.UpdateAdventureAsync(id, new { Title = title, Description = description, Location = location, Duration = duration, GuideId = guideId });
            Console.WriteLine("Chuyến phiêu lưu đã được cập nhật.");
        }

        private async Task DeleteAdventure()
        {
            Console.Write("Nhập ID của chuyến phiêu lưu cần xóa: ");
            var id = int.Parse(Console.ReadLine());

            await _service.DeleteAdventureAsync(id);
            Console.WriteLine("Chuyến phiêu lưu đã được xóa.");
        }
    }

}
