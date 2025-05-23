﻿namespace PhanMemQuanLyKhachSan
{
    partial class frmQuanLyPhong
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
            this.btnCapNhatVatTu = new System.Windows.Forms.Button();
            this.btnCapNhatDVPhong = new System.Windows.Forms.Button();
            this.btnCapNhatLoaiPhong = new System.Windows.Forms.Button();
            this.lblQuanLyPhong = new System.Windows.Forms.Label();
            this.dgvQuanLyPhong = new System.Windows.Forms.DataGridView();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTroVeCuaCTPP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCapNhatVatTu
            // 
            this.btnCapNhatVatTu.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCapNhatVatTu.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatVatTu.Location = new System.Drawing.Point(18, 159);
            this.btnCapNhatVatTu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCapNhatVatTu.Name = "btnCapNhatVatTu";
            this.btnCapNhatVatTu.Size = new System.Drawing.Size(213, 77);
            this.btnCapNhatVatTu.TabIndex = 0;
            this.btnCapNhatVatTu.Text = "Cập nhật vật tư";
            this.btnCapNhatVatTu.UseVisualStyleBackColor = false;
            this.btnCapNhatVatTu.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnCapNhatDVPhong
            // 
            this.btnCapNhatDVPhong.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCapNhatDVPhong.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatDVPhong.Location = new System.Drawing.Point(18, 290);
            this.btnCapNhatDVPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCapNhatDVPhong.Name = "btnCapNhatDVPhong";
            this.btnCapNhatDVPhong.Size = new System.Drawing.Size(213, 78);
            this.btnCapNhatDVPhong.TabIndex = 1;
            this.btnCapNhatDVPhong.Text = "Cập nhật dịch vụ";
            this.btnCapNhatDVPhong.UseVisualStyleBackColor = false;
            this.btnCapNhatDVPhong.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btnCapNhatLoaiPhong
            // 
            this.btnCapNhatLoaiPhong.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCapNhatLoaiPhong.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatLoaiPhong.Location = new System.Drawing.Point(18, 424);
            this.btnCapNhatLoaiPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCapNhatLoaiPhong.Name = "btnCapNhatLoaiPhong";
            this.btnCapNhatLoaiPhong.Size = new System.Drawing.Size(213, 75);
            this.btnCapNhatLoaiPhong.TabIndex = 2;
            this.btnCapNhatLoaiPhong.Text = "Cập nhật loại phòng";
            this.btnCapNhatLoaiPhong.UseVisualStyleBackColor = false;
            this.btnCapNhatLoaiPhong.Click += new System.EventHandler(this.ButtonCapNhapLoaiPhong_Click);
            // 
            // lblQuanLyPhong
            // 
            this.lblQuanLyPhong.BackColor = System.Drawing.Color.Transparent;
            this.lblQuanLyPhong.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuanLyPhong.Location = new System.Drawing.Point(374, 30);
            this.lblQuanLyPhong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuanLyPhong.Name = "lblQuanLyPhong";
            this.lblQuanLyPhong.Size = new System.Drawing.Size(507, 65);
            this.lblQuanLyPhong.TabIndex = 3;
            this.lblQuanLyPhong.Text = "Quản Lý Phòng";
            this.lblQuanLyPhong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvQuanLyPhong
            // 
            this.dgvQuanLyPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuanLyPhong.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvQuanLyPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuanLyPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.TenLoaiPhong,
            this.Gia,
            this.TrangThai});
            this.dgvQuanLyPhong.Location = new System.Drawing.Point(248, 159);
            this.dgvQuanLyPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvQuanLyPhong.Name = "dgvQuanLyPhong";
            this.dgvQuanLyPhong.ReadOnly = true;
            this.dgvQuanLyPhong.RowHeadersWidth = 62;
            this.dgvQuanLyPhong.Size = new System.Drawing.Size(810, 416);
            this.dgvQuanLyPhong.TabIndex = 4;
            this.dgvQuanLyPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuanLyPhong_CellClick);
            // 
            // stt
            // 
            this.stt.FillWeight = 38.07107F;
            this.stt.HeaderText = "STT";
            this.stt.MinimumWidth = 8;
            this.stt.Name = "stt";
            this.stt.ReadOnly = true;
            // 
            // TenLoaiPhong
            // 
            this.TenLoaiPhong.FillWeight = 130.9645F;
            this.TenLoaiPhong.HeaderText = "Tên Loại Phòng";
            this.TenLoaiPhong.MinimumWidth = 8;
            this.TenLoaiPhong.Name = "TenLoaiPhong";
            this.TenLoaiPhong.ReadOnly = true;
            // 
            // Gia
            // 
            this.Gia.FillWeight = 130.9645F;
            this.Gia.HeaderText = "Giá Phòng";
            this.Gia.MinimumWidth = 8;
            this.Gia.Name = "Gia";
            this.Gia.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.FillWeight = 130.9645F;
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.MinimumWidth = 8;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // btnTroVeCuaCTPP
            // 
            this.btnTroVeCuaCTPP.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnTroVeCuaCTPP.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTroVeCuaCTPP.Image = global::PhanMemQuanLyKhachSan.Properties.Resources.iconBack;
            this.btnTroVeCuaCTPP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTroVeCuaCTPP.Location = new System.Drawing.Point(18, 14);
            this.btnTroVeCuaCTPP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTroVeCuaCTPP.Name = "btnTroVeCuaCTPP";
            this.btnTroVeCuaCTPP.Size = new System.Drawing.Size(142, 55);
            this.btnTroVeCuaCTPP.TabIndex = 5;
            this.btnTroVeCuaCTPP.Text = "Trở về";
            this.btnTroVeCuaCTPP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTroVeCuaCTPP.UseVisualStyleBackColor = false;
            this.btnTroVeCuaCTPP.Click += new System.EventHandler(this.BtnTroVeCuaCTPP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(327, 109);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(580, 44);
            this.label1.TabIndex = 6;
            this.label1.Text = "Khách Sạn Hiện Tại Đang Có 8 Phòng";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmQuanLyPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1100, 611);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTroVeCuaCTPP);
            this.Controls.Add(this.dgvQuanLyPhong);
            this.Controls.Add(this.lblQuanLyPhong);
            this.Controls.Add(this.btnCapNhatLoaiPhong);
            this.Controls.Add(this.btnCapNhatDVPhong);
            this.Controls.Add(this.btnCapNhatVatTu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmQuanLyPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Màn Hình Quản Lý Phòng";
            this.Load += new System.EventHandler(this.frmQuanLyPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCapNhatVatTu;
        private System.Windows.Forms.Button btnCapNhatDVPhong;
        private System.Windows.Forms.Button btnCapNhatLoaiPhong;
        private System.Windows.Forms.Label lblQuanLyPhong;
        private System.Windows.Forms.DataGridView dgvQuanLyPhong;
        private System.Windows.Forms.Button btnTroVeCuaCTPP;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.Label label1;
    }
}