namespace AdventureManagement.Winform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgv_participant = new DataGridView();
            btn_them = new Button();
            btn_sua = new Button();
            btn_xoa = new Button();
            txt_name = new TextBox();
            txt_email = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_participant).BeginInit();
            SuspendLayout();
            // 
            // dgv_participant
            // 
            dgv_participant.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_participant.Location = new Point(12, 278);
            dgv_participant.Name = "dgv_participant";
            dgv_participant.Size = new Size(778, 238);
            dgv_participant.TabIndex = 0;
            dgv_participant.CellClick += dgv_participant_CellClick;
            // 
            // btn_them
            // 
            btn_them.Location = new Point(565, 45);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(177, 46);
            btn_them.TabIndex = 1;
            btn_them.Text = "Thêm";
            btn_them.UseVisualStyleBackColor = true;
            btn_them.Click += btn_them_Click;
            // 
            // btn_sua
            // 
            btn_sua.Location = new Point(565, 105);
            btn_sua.Name = "btn_sua";
            btn_sua.Size = new Size(177, 46);
            btn_sua.TabIndex = 2;
            btn_sua.Text = "Sửa";
            btn_sua.UseVisualStyleBackColor = true;
            btn_sua.Click += btn_sua_Click;
            // 
            // btn_xoa
            // 
            btn_xoa.Location = new Point(565, 157);
            btn_xoa.Name = "btn_xoa";
            btn_xoa.Size = new Size(177, 46);
            btn_xoa.TabIndex = 3;
            btn_xoa.Text = "Xóa";
            btn_xoa.UseVisualStyleBackColor = true;
            btn_xoa.Click += btn_xoa_Click;
            // 
            // txt_name
            // 
            txt_name.Location = new Point(200, 79);
            txt_name.Name = "txt_name";
            txt_name.Size = new Size(271, 23);
            txt_name.TabIndex = 4;
            // 
            // txt_email
            // 
            txt_email.Location = new Point(200, 118);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(271, 23);
            txt_email.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(131, 83);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 9;
            label1.Text = "name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 126);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 10;
            label2.Text = "email";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 523);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txt_email);
            Controls.Add(txt_name);
            Controls.Add(btn_xoa);
            Controls.Add(btn_sua);
            Controls.Add(btn_them);
            Controls.Add(dgv_participant);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgv_participant).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_participant;
        private Button btn_them;
        private Button btn_sua;
        private Button btn_xoa;
        private TextBox txt_name;
        private TextBox txt_email;
        private Label label1;
        private Label label2;
    }
}
