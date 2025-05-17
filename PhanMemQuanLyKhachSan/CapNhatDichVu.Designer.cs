namespace PhanMemQuanLyKhachSan
{
    partial class frmCapNhatDichVu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDichVuKhachSan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThoatCapNhatDichVu = new System.Windows.Forms.Button();
            this.btnLuuCapNhatDichVu = new System.Windows.Forms.Button();
            this.btnThemDichVu = new System.Windows.Forms.Button();
            this.btnXoaDichVu = new System.Windows.Forms.Button();
            this.dgvCapNhatDichVu = new System.Windows.Forms.DataGridView();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCapNhatDichVu = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapNhatDichVu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDichVuKhachSan
            // 
            this.lblDichVuKhachSan.AutoSize = true;
            this.lblDichVuKhachSan.BackColor = System.Drawing.Color.Transparent;
            this.lblDichVuKhachSan.Font = new System.Drawing.Font("Palatino Linotype", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDichVuKhachSan.Location = new System.Drawing.Point(368, 17);
            this.lblDichVuKhachSan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDichVuKhachSan.Name = "lblDichVuKhachSan";
            this.lblDichVuKhachSan.Size = new System.Drawing.Size(507, 72);
            this.lblDichVuKhachSan.TabIndex = 0;
            this.lblDichVuKhachSan.Text = "Dịch Vụ Khách Sạn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(663, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 1;
            // 
            // btnThoatCapNhatDichVu
            // 
            this.btnThoatCapNhatDichVu.BackColor = System.Drawing.Color.Pink;
            this.btnThoatCapNhatDichVu.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoatCapNhatDichVu.Image = global::PhanMemQuanLyKhachSan.Properties.Resources.iconBack;
            this.btnThoatCapNhatDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoatCapNhatDichVu.Location = new System.Drawing.Point(18, 17);
            this.btnThoatCapNhatDichVu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThoatCapNhatDichVu.Name = "btnThoatCapNhatDichVu";
            this.btnThoatCapNhatDichVu.Size = new System.Drawing.Size(152, 69);
            this.btnThoatCapNhatDichVu.TabIndex = 2;
            this.btnThoatCapNhatDichVu.Text = "Trở Về";
            this.btnThoatCapNhatDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoatCapNhatDichVu.UseVisualStyleBackColor = false;
            this.btnThoatCapNhatDichVu.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnLuuCapNhatDichVu
            // 
            this.btnLuuCapNhatDichVu.BackColor = System.Drawing.Color.Pink;
            this.btnLuuCapNhatDichVu.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuCapNhatDichVu.Image = global::PhanMemQuanLyKhachSan.Properties.Resources.iconLuu;
            this.btnLuuCapNhatDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuCapNhatDichVu.Location = new System.Drawing.Point(1037, 313);
            this.btnLuuCapNhatDichVu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLuuCapNhatDichVu.Name = "btnLuuCapNhatDichVu";
            this.btnLuuCapNhatDichVu.Size = new System.Drawing.Size(117, 69);
            this.btnLuuCapNhatDichVu.TabIndex = 3;
            this.btnLuuCapNhatDichVu.Text = "Lưu";
            this.btnLuuCapNhatDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuCapNhatDichVu.UseVisualStyleBackColor = false;
            this.btnLuuCapNhatDichVu.Click += new System.EventHandler(this.btnLuuCapNhatDichVu_Click);
            // 
            // btnThemDichVu
            // 
            this.btnThemDichVu.BackColor = System.Drawing.Color.Pink;
            this.btnThemDichVu.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDichVu.Image = global::PhanMemQuanLyKhachSan.Properties.Resources.iconThem;
            this.btnThemDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemDichVu.Location = new System.Drawing.Point(715, 313);
            this.btnThemDichVu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThemDichVu.Name = "btnThemDichVu";
            this.btnThemDichVu.Size = new System.Drawing.Size(121, 69);
            this.btnThemDichVu.TabIndex = 4;
            this.btnThemDichVu.Text = "Thêm";
            this.btnThemDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemDichVu.UseVisualStyleBackColor = false;
            this.btnThemDichVu.Click += new System.EventHandler(this.btnThemDichVu_Click);
            // 
            // btnXoaDichVu
            // 
            this.btnXoaDichVu.BackColor = System.Drawing.Color.Pink;
            this.btnXoaDichVu.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDichVu.Image = global::PhanMemQuanLyKhachSan.Properties.Resources.iconDelete;
            this.btnXoaDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaDichVu.Location = new System.Drawing.Point(881, 313);
            this.btnXoaDichVu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXoaDichVu.Name = "btnXoaDichVu";
            this.btnXoaDichVu.Size = new System.Drawing.Size(105, 69);
            this.btnXoaDichVu.TabIndex = 5;
            this.btnXoaDichVu.Text = "Xóa ";
            this.btnXoaDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaDichVu.UseVisualStyleBackColor = false;
            this.btnXoaDichVu.Click += new System.EventHandler(this.btnXoaDichVu_Click);
            // 
            // dgvCapNhatDichVu
            // 
            this.dgvCapNhatDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCapNhatDichVu.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvCapNhatDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCapNhatDichVu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.id,
            this.TenDichVu,
            this.Gia});
            this.dgvCapNhatDichVu.Location = new System.Drawing.Point(13, 139);
            this.dgvCapNhatDichVu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCapNhatDichVu.Name = "dgvCapNhatDichVu";
            this.dgvCapNhatDichVu.ReadOnly = true;
            this.dgvCapNhatDichVu.RowHeadersWidth = 62;
            this.dgvCapNhatDichVu.Size = new System.Drawing.Size(671, 464);
            this.dgvCapNhatDichVu.TabIndex = 6;
            this.dgvCapNhatDichVu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cell_Click);
            // 
            // stt
            // 
            this.stt.FillWeight = 38.07107F;
            this.stt.HeaderText = "STT";
            this.stt.MinimumWidth = 8;
            this.stt.Name = "stt";
            this.stt.ReadOnly = true;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 8;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // TenDichVu
            // 
            this.TenDichVu.FillWeight = 130.9645F;
            this.TenDichVu.HeaderText = "Tên Dịch Vụ";
            this.TenDichVu.MinimumWidth = 8;
            this.TenDichVu.Name = "TenDichVu";
            this.TenDichVu.ReadOnly = true;
            // 
            // Gia
            // 
            this.Gia.FillWeight = 130.9645F;
            this.Gia.HeaderText = "Giá Dịch Vụ";
            this.Gia.MinimumWidth = 8;
            this.Gia.Name = "Gia";
            this.Gia.ReadOnly = true;
            // 
            // txtCapNhatDichVu
            // 
            this.txtCapNhatDichVu.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapNhatDichVu.Location = new System.Drawing.Point(715, 139);
            this.txtCapNhatDichVu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCapNhatDichVu.Multiline = true;
            this.txtCapNhatDichVu.Name = "txtCapNhatDichVu";
            this.txtCapNhatDichVu.Size = new System.Drawing.Size(439, 55);
            this.txtCapNhatDichVu.TabIndex = 7;
            this.txtCapNhatDichVu.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // txtGia
            // 
            this.txtGia.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGia.Location = new System.Drawing.Point(715, 221);
            this.txtGia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGia.Multiline = true;
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(439, 61);
            this.txtGia.TabIndex = 7;
            this.txtGia.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // frmCapNhatDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1160, 771);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.txtCapNhatDichVu);
            this.Controls.Add(this.dgvCapNhatDichVu);
            this.Controls.Add(this.btnXoaDichVu);
            this.Controls.Add(this.btnThemDichVu);
            this.Controls.Add(this.btnLuuCapNhatDichVu);
            this.Controls.Add(this.btnThoatCapNhatDichVu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDichVuKhachSan);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCapNhatDichVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập Nhật Dịch Vụ";
            this.Load += new System.EventHandler(this.frmCapNhatDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapNhatDichVu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDichVuKhachSan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThoatCapNhatDichVu;
        private System.Windows.Forms.Button btnLuuCapNhatDichVu;
        private System.Windows.Forms.Button btnThemDichVu;
        private System.Windows.Forms.Button btnXoaDichVu;
        private System.Windows.Forms.DataGridView dgvCapNhatDichVu;
        private System.Windows.Forms.TextBox txtCapNhatDichVu;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
    }
}