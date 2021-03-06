﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Bai1_QLNhanSu
{
    public partial class frmHuongDan : Form
    {
        public frmHuongDan()
        {
            InitializeComponent();
        }
        private void GetFileAll(string tenfile)
        {
            StreamReader doc = File.OpenText(tenfile);
            string s = doc.ReadToEnd();
            txtGioiThieu.Text = s;
        }

        private void trViewGioiThieu_AfterSelect(object sender, TreeViewEventArgs e)
        {
               try
               {
                    if (e.Node.Name == "gtPhanMem")
                    {
                         GetFileAll("GioiThieuChung.txt");
                         Image img = Image.FromFile(@"Nhansu.jpg");
                         pictureBox1.BackgroundImage = img;
                    }
                    else
                if (e.Node.Name == "gtDangNhap")
                    {
                         GetFileAll("PhanDangNhap.txt");
                         Image img = Image.FromFile(@"anh dang nhap.png");
                         pictureBox1.BackgroundImage = img;
                    }
                    else
                    if (e.Node.Name == "gtManHinhChinh")
                    {
                         GetFileAll("PhanMain.txt");
                         Image img = Image.FromFile(@"anh main.png");
                         pictureBox1.BackgroundImage = img;
                    }
                    else
                        if (e.Node.Name == "gtQLNS")
                    {
                         GetFileAll("PhanQuanLi.txt");
                         Image img = Image.FromFile(@"anh nhan vien.png");
                         pictureBox1.BackgroundImage = img;
                    }
               }
               catch (Exception)
               {

                    MessageBox.Show("Đã upload thành công");
               }
               private void txttk_TenHH_TextChanged(object sender, EventArgs e)
        {
            Reset();
            dataGridView1.DataSource = hanghoa.TKHH_TenHH(txttk_TenHH.Text);

        }
            
        }
        private void bt_go_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txt_dc.Text);
        }

        private void bt_1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void bt_3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }
    }
    
}
