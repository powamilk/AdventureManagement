using AdventureManagementConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureManagementConsole.UI.UIService;

namespace AdventureManagementConsole.UI.UIMenu
{
    public class ParticipantInteractionUI
    {
        private readonly ParticipantInteractionService _service;

        public ParticipantInteractionUI(ParticipantInteractionService service)
        {
            _service = service;
        }

        public async Task DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("=== Quản lý Tương Tác Người Tham Gia ===");
                Console.WriteLine("1. Xem tất cả các tương tác");
                Console.WriteLine("2. Thêm tương tác mới");
                Console.WriteLine("3. Cập nhật tương tác");
                Console.WriteLine("4. Xóa tương tác");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn một tùy chọn: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await DisplayAllInteractions();
                        break;
                    case "2":
                        await AddNewInteraction();
                        break;
                    case "3":
                        await UpdateInteraction();
                        break;
                    case "4":
                        await DeleteInteraction();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
        }

        private async Task DisplayAllInteractions()
        {
            var interactions = await _service.GetAllParticipantInteractionsAsync();
            Console.WriteLine("=== Danh sách các tương tác ===");
            foreach (var interaction in interactions)
            {
                Console.WriteLine($"ID: {interaction.Id}, Chuyến phiêu lưu: {interaction.AdventureTitle}, Người tham gia: {interaction.ParticipantName}, Đánh giá: {interaction.Rating}, Bình luận: {interaction.Comment}");
            }
        }

        private async Task AddNewInteraction()
        {
            var interaction = new CreateParticipantInteractionModel();

            Console.Write("Nhập AdventureId: ");
            interaction.AdventureId = int.Parse(Console.ReadLine());

            Console.Write("Nhập ParticipantId: ");
            interaction.ParticipantId = int.Parse(Console.ReadLine());

            Console.Write("Nhập Rating (1-5): ");
            interaction.Rating = int.Parse(Console.ReadLine());

            Console.Write("Nhập Bình luận: ");
            interaction.Comment = Console.ReadLine();

            await _service.CreateParticipantInteractionAsync(interaction);
            Console.WriteLine("Tương tác mới đã được thêm.");
        }

        private async Task UpdateInteraction()
        {
            Console.Write("Nhập ID của tương tác cần cập nhật: ");
            var id = int.Parse(Console.ReadLine());

            var interaction = new UpdateParticipantInteractionModel();

            Console.Write("Nhập Rating mới (1-5): ");
            interaction.Rating = int.Parse(Console.ReadLine());

            Console.Write("Nhập Bình luận mới: ");
            interaction.Comment = Console.ReadLine();

            await _service.UpdateParticipantInteractionAsync(id, interaction);
            Console.WriteLine("Tương tác đã được cập nhật.");
        }

        private async Task DeleteInteraction()
        {
            Console.Write("Nhập ID của tương tác cần xóa: ");
            var id = int.Parse(Console.ReadLine());

            await _service.DeleteParticipantInteractionAsync(id);
            Console.WriteLine("Tương tác đã được xóa.");
        }
    }

}
