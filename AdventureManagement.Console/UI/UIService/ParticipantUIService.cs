using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AdventureManagementConsole.Model;

namespace AdventureManagementConsole.UI.UIService
{
    public class ParticipantUIService
    {
        private readonly HttpClient _httpClient;
        public ParticipantUIService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7191/api/") };
        }

        public async Task GetAll()
        {
            var reponse = await _httpClient.GetAsync("participants");
            if (reponse.IsSuccessStatusCode)
            {
                var participants = await reponse.Content.ReadAsStringAsync();
                Console.WriteLine(participants);
            }
            else
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu");
            }
        }

        public async Task Create()
        {
            Console.WriteLine("Nhập Tên: ");
            string name = Console.ReadLine();
            Console.WriteLine("Nhập Email");
            string email = Console.ReadLine();

            var newParticipant = new ParticipantCreateVM { Email = email, Name = name };
            var json = JsonSerializer.Serialize(newParticipant);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("participants", content);
            if (response.IsSuccessStatusCode) 
                {
                    Console.WriteLine("Tạo thành công");
                }
                else
                {
                Console.WriteLine("CÓ lỗi xảy ra");
                }
            }
        }
    }


