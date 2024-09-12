using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureManagementConsole.UI.UIService;

namespace AdventureManagementConsole.UI.UIMenu
{
    public class OrganismUI
    {
        private readonly OrganismService _service;

        public OrganismUI(OrganismService service)
        {
            _service = service;
        }

        public OrganismUI()
        {
        }

        public async Task DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("=== Quản lý Sinh Vật ===");
                Console.WriteLine("1. Xem tất cả sinh vật");
                Console.WriteLine("2. Thêm sinh vật mới");
                Console.WriteLine("3. Cập nhật sinh vật");
                Console.WriteLine("4. Xóa sinh vật");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn một tùy chọn: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await DisplayAllOrganisms();
                        break;
                    case "2":
                        await AddNewOrganism();
                        break;
                    case "3":
                        await UpdateOrganism();
                        break;
                    case "4":
                        await DeleteOrganism();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
        }

        private async Task DisplayAllOrganisms()
        {
            var organisms = await _service.GetAllOrganismsAsync();
            Console.WriteLine("=== Danh sách sinh vật ===");
            foreach (var organism in organisms)
            {
                Console.WriteLine($"ID: {organism.Id}, Tên: {organism.Name}, Mô tả: {organism.Description}, Môi trường sống: {organism.Habitat}, Số chuyến phiêu lưu: {organism.AdventureCount}");
            }
        }

        private async Task AddNewOrganism()
        {
            Console.Write("Nhập tên sinh vật: ");
            var name = Console.ReadLine();

            Console.Write("Nhập mô tả: ");
            var description = Console.ReadLine();

            Console.Write("Nhập môi trường sống: ");
            var habitat = Console.ReadLine();

            await _service.CreateOrganismAsync(new { Name = name, Description = description, Habitat = habitat });
            Console.WriteLine("Sinh vật mới đã được thêm.");
        }

        private async Task UpdateOrganism()
        {
            Console.Write("Nhập ID của sinh vật cần cập nhật: ");
            var id = int.Parse(Console.ReadLine());

            Console.Write("Nhập tên mới: ");
            var name = Console.ReadLine();

            Console.Write("Nhập mô tả mới: ");
            var description = Console.ReadLine();

            Console.Write("Nhập môi trường sống mới: ");
            var habitat = Console.ReadLine();

            await _service.UpdateOrganismAsync(id, new { Name = name, Description = description, Habitat = habitat });
            Console.WriteLine("Sinh vật đã được cập nhật.");
        }

        private async Task DeleteOrganism()
        {
            Console.Write("Nhập ID của sinh vật cần xóa: ");
            var id = int.Parse(Console.ReadLine());

            await _service.DeleteOrganismAsync(id);
            Console.WriteLine("Sinh vật đã được xóa.");
        }
    }

}
