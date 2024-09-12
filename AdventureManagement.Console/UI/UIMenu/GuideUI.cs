using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AdventureManagementConsole.UI.UIService;

namespace AdventureManagementConsole.UI.UIMenu
{
    public class GuideUI
    {
        private readonly GuideService _service;

        public GuideUI(GuideService service)
        {
            _service = service;
        }

        public GuideUI()
        {
        }

        public async Task DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("=== Quản lý Hướng Dẫn Viên ===");
                Console.WriteLine("1. Xem tất cả hướng dẫn viên");
                Console.WriteLine("2. Thêm hướng dẫn viên");
                Console.WriteLine("3. Cập nhật hướng dẫn viên");
                Console.WriteLine("4. Xóa hướng dẫn viên");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn một tùy chọn: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await DisplayAllGuides();
                        break;
                    case "2":
                        await AddNewGuide();
                        break;
                    case "3":
                        await UpdateGuide();
                        break;
                    case "4":
                        await DeleteGuide();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
        }

        private async Task DisplayAllGuides()
        {
            var guides = await _service.GetAllGuidesAsync();
            Console.WriteLine("=== Danh sách hướng dẫn viên ===");
            foreach (var guide in guides)
            {
                Console.WriteLine($"ID: {guide.Id}, Tên: {guide.Name}, Chuyên môn: {guide.Expertise}, Kinh nghiệm: {guide.ExperienceYears} năm, Số chuyến phiêu lưu: {guide.AdventureCount}");
            }
        }

        private async Task AddNewGuide()
        {
            Console.Write("Nhập tên hướng dẫn viên: ");
            var name = Console.ReadLine();

            Console.Write("Nhập chuyên môn: ");
            var expertise = Console.ReadLine();

            Console.Write("Nhập số năm kinh nghiệm: ");
            var experienceYears = int.Parse(Console.ReadLine());

            await _service.CreateGuideAsync(new { Name = name, Expertise = expertise, ExperienceYears = experienceYears });
            Console.WriteLine("Hướng dẫn viên mới đã được thêm.");
        }

        private async Task UpdateGuide()
        {
            Console.Write("Nhập ID của hướng dẫn viên cần cập nhật: ");
            var id = int.Parse(Console.ReadLine());

            Console.Write("Nhập tên mới: ");
            var name = Console.ReadLine();

            Console.Write("Nhập chuyên môn mới: ");
            var expertise = Console.ReadLine();

            Console.Write("Nhập số năm kinh nghiệm mới: ");
            var experienceYears = int.Parse(Console.ReadLine());

            await _service.UpdateGuideAsync(id, new { Name = name, Expertise = expertise, ExperienceYears = experienceYears });
            Console.WriteLine("Hướng dẫn viên đã được cập nhật.");
        }

        private async Task DeleteGuide()
        {
            Console.Write("Nhập ID của hướng dẫn viên cần xóa: ");
            var id = int.Parse(Console.ReadLine());

            await _service.DeleteGuideAsync(id);
            Console.WriteLine("Hướng dẫn viên đã được xóa.");
        }
    }
}
