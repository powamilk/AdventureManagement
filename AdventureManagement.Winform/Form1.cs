using AdventureManagement.BUS.Service.Interface;
using AdventureManagement.BUS.ViewModel.Participant;
using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
namespace AdventureManagement.Winform
{
    public partial class Form1 : Form
    {
        private readonly IParticipantService _participantService;
        public Form1(IParticipantService participantService)
        {
            InitializeComponent();
            _participantService = participantService;
            LoadFormData();
        }

        private async Task LoadFormData()
        {
            dgv_participant.Columns.Clear();
            dgv_participant.Columns.Add("CLm1", "ID");
            dgv_participant.Columns.Add("Clm2", "Name");
            dgv_participant.Columns.Add("Clm3", "Email");
            dgv_participant.Columns.Add("Clm4", "CreateAt");

            var participants = await _participantService.GetAll();
            dgv_participant.Rows.Clear();

            foreach (var participant in participants)
            {
                dgv_participant.Rows.Add(participant.Id, participant.Name, participant.Email, participant.CreatedAt);
            }
        }


        private async void btn_them_Click(object sender, EventArgs e)
        {
            var participant = new ParticipantCreateVM
            {
                Name = txt_name.Text,
                Email = txt_email.Text
            };

            var result = await _participantService.Create(participant);
            if (result)
            {
                MessageBox.Show("Thêm thành công!");
                await LoadFormData();
                ClearInputs(); // Xóa các ô nhập liệu
            }
            else
            {
                MessageBox.Show("Thêm thất bại. Email có thể đã tồn tại.");
            }
        }

        private async void btn_sua_Click(object sender, EventArgs e)
        {
            if (dgv_participant.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_participant.SelectedRows[0];
                var participantId = (int)selectedRow.Cells[0].Value;

                var participant = new ParticipantUpdateVM
                {
                    Name = txt_name.Text,
                    Email = txt_email.Text
                };

                var result = await _participantService.Update(participantId, participant);
                if (result)
                {
                    MessageBox.Show("Sửa thành công!");
                    await LoadFormData();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại. Kiểm tra lại thông tin.");
                }
            }
        }

        private async void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_participant.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_participant.SelectedRows[0];
                var participantId = (int)selectedRow.Cells[0].Value;

                var result = await _participantService.Delete(participantId);
                if (result)
                {
                    MessageBox.Show("Xóa thành công!");
                    await LoadFormData(); 
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Người tham gia không tồn tại.");
                }
            }
        }

        private void dgv_participant_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgv_participant.Rows[e.RowIndex];
                txt_name.Text = selectedRow.Cells[1].Value.ToString();
                txt_email.Text = selectedRow.Cells[2].Value.ToString();
            }
        }

        private void ClearInputs()
        {
            txt_name.Text = string.Empty;
            txt_email.Text = string.Empty;
        }
    }
}
