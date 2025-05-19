namespace PhanMemQuanLyKhachSan
{
    partial class frmThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnTroVeCuaThongKe = new System.Windows.Forms.Button();
            this.lblTongKhachHang = new System.Windows.Forms.Label();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.lblSoKhachHang = new System.Windows.Forms.Label();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(582, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "THỐNG KÊ DOANH THU";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.LightGray;
            chartArea1.BorderWidth = 1;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Enabled = false;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(16, 200);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1035, 450);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "Thống kê doanh thu";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(206)))), ((int)(((byte)(235)))));
            series1.Legend = "Legend1";
            series1.Name = "Tổng Tiền";
            series1.BorderWidth = 2;
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.chart1.Series.Add(series1);
            // 
            // btnTroVeCuaThongKe
            // 
            this.btnTroVeCuaThongKe.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTroVeCuaThongKe.Image = global::PhanMemQuanLyKhachSan.Properties.Resources.iconBack;
            this.btnTroVeCuaThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTroVeCuaThongKe.Location = new System.Drawing.Point(16, 14);
            this.btnTroVeCuaThongKe.Margin = new System.Windows.Forms.Padding(4);
            this.btnTroVeCuaThongKe.Name = "btnTroVeCuaThongKe";
            this.btnTroVeCuaThongKe.Size = new System.Drawing.Size(135, 46);
            this.btnTroVeCuaThongKe.TabIndex = 10;
            this.btnTroVeCuaThongKe.Text = "Trở về";
            this.btnTroVeCuaThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTroVeCuaThongKe.UseVisualStyleBackColor = true;
            this.btnTroVeCuaThongKe.Click += new System.EventHandler(this.btnTroVeCuaThongKe_Click);
            // 
            // lblTongKhachHang
            // 
            this.lblTongKhachHang.AutoSize = true;
            this.lblTongKhachHang.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTongKhachHang.Location = new System.Drawing.Point(50, 100);
            this.lblTongKhachHang.Name = "lblTongKhachHang";
            this.lblTongKhachHang.Size = new System.Drawing.Size(200, 30);
            this.lblTongKhachHang.TabIndex = 2;
            this.lblTongKhachHang.Text = "Tổng số khách hàng:";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.Location = new System.Drawing.Point(50, 150);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(200, 30);
            this.lblTongDoanhThu.TabIndex = 3;
            this.lblTongDoanhThu.Text = "Tổng doanh thu:";
            // 
            // lblSoKhachHang
            // 
            this.lblSoKhachHang.AutoSize = true;
            this.lblSoKhachHang.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular);
            this.lblSoKhachHang.Location = new System.Drawing.Point(260, 100);
            this.lblSoKhachHang.Name = "lblSoKhachHang";
            this.lblSoKhachHang.Size = new System.Drawing.Size(50, 30);
            this.lblSoKhachHang.TabIndex = 4;
            this.lblSoKhachHang.Text = "0";
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.AutoSize = true;
            this.lblDoanhThu.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular);
            this.lblDoanhThu.Location = new System.Drawing.Point(260, 150);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(50, 30);
            this.lblDoanhThu.TabIndex = 5;
            this.lblDoanhThu.Text = "0";
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 666);
            this.Controls.Add(this.lblDoanhThu);
            this.Controls.Add(this.lblSoKhachHang);
            this.Controls.Add(this.lblTongDoanhThu);
            this.Controls.Add(this.lblTongKhachHang);
            this.Controls.Add(this.btnTroVeCuaThongKe);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống Kê";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnTroVeCuaThongKe;
        private System.Windows.Forms.Label lblTongKhachHang;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label lblSoKhachHang;
        private System.Windows.Forms.Label lblDoanhThu;
    }
}