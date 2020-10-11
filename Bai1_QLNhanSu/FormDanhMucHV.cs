using QuanLyCSVCDaiDoi.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCSVCDaiDoi
{
    public partial class FormDanhMucHV : Form
    {
        private Model1 db = new Model1();
        public FormDanhMucHV()
        {
            InitializeComponent();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            TrangChu tc = new TrangChu();
            this.Hide();
            tc.Show();
        }

        private void FormDanhMucHV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyCSVCDaiDoiDataSet.HocVien' table. You can move, or remove it, as needed.
            this.hocVienTableAdapter.Fill(this.quanLyCSVCDaiDoiDataSet.HocVien);
        }
        private void Clear()
        {
            txtMaHV.Text = "";
            txtMaLop.Text = "";
            txtTenHV.Text = "";
            cbLop.Text = "";
            txtCapBac.Text = "";
            txtChucVu.Text = "";
            txtMaLop.Text = "";
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCapBac.Text = dgvDanhSach.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtChucVu.Text = dgvDanhSach.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtMaHV.Text = dgvDanhSach.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenHV.Text = dgvDanhSach.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPhong.Text = dgvDanhSach.Rows[e.RowIndex].Cells[4].Value.ToString();
            int malop = int.Parse(dgvDanhSach.Rows[e.RowIndex].Cells[5].Value.ToString());
            cbLop.Text = db.Lops.FirstOrDefault(x => x.MaLop == malop).TenLop;
            txtMaLop.Text = dgvDanhSach.Rows[e.RowIndex].Cells[5].Value.ToString();
            btnXoa.Enabled = true;
            btnXoa.BackColor = Color.Red;
            btnThem.Enabled = false;
            btnThem.BackColor = Color.SteelBlue;
            btnCapNhat.Enabled = false;
            btnCapNhat.BackColor = Color.SteelBlue;
        }

        private void txtCapBac_TextChanged(object sender, EventArgs e)
        {
            txtChucVu_TextChanged(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtChucVu_TextChanged(sender, e);
        }

        private void txtMaHV_TextChanged(object sender, EventArgs e)
        {
            txtChucVu_TextChanged(sender, e);
        }

        private void txtTenHV_TextChanged(object sender, EventArgs e)
        {
            txtChucVu_TextChanged(sender, e);
        }

        private void txtPhong_TextChanged(object sender, EventArgs e)
        {
            txtChucVu_TextChanged(sender, e);
        }

        private void txtChucVu_TextChanged(object sender, EventArgs e)
        {
            btnCapNhat.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnCapNhat.BackColor = Color.Blue;
            btnThem.BackColor = Color.Blue;
            btnXoa.BackColor = Color.LightCoral;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                db.HocViens.Remove(db.HocViens.Find(int.Parse(txtMaHV.Text)));
                db.SaveChanges();
                Clear();
                FormDanhMucHV_Load(sender, e);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtChucVu.Text.Trim() == "" || txtCapBac.Text.Trim() == "" || txtTenHV.Text.Trim() == "" || txtMaLop.Text.Trim() == "" || txtMaHV.Text.Trim() == "" || cbLop.Text.Trim() == "")
            {
                MessageBox.Show("Bạn cần điển đầy đủ thông tin ở tất cả các trường", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Thêm học viên?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    var HV = new HocVien();
                    HV.HoTen = txtTenHV.Text;
                    var idlop = db.Lops.FirstOrDefault(x => x.TenLop == cbLop.Text).MaLop;
                    HV.MaLop = idlop;
                    HV.CapBac = txtCapBac.Text;
                    HV.ChucVu = txtChucVu.Text;
                    HV.Phong = int.Parse(txtPhong.Text);
                    HV.MaHocVien = int.Parse(txtMaHV.Text);
                    db.HocViens.Add(HV);
                    db.SaveChanges();
                    Clear();
                    FormDanhMucHV_Load(sender, e);
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtChucVu.Text.Trim() == "" || txtCapBac.Text.Trim() == "" || txtTenHV.Text.Trim() == "" || txtMaLop.Text.Trim() == "" || txtMaHV.Text.Trim() == "" || cbLop.Text.Trim() == "")
            {
                MessageBox.Show("Bạn cần điển đầy đủ thông tin ở tất cả các trường", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    var HV = db.HocViens.Find(int.Parse(txtMaHV.Text));
                    HV.HoTen = txtTenHV.Text;
                    var idlop = db.Lops.FirstOrDefault(x => x.TenLop == cbLop.Text).MaLop;
                    HV.MaLop = idlop;
                    HV.CapBac = txtCapBac.Text;
                    HV.ChucVu = txtChucVu.Text;
                    HV.Phong = int.Parse(txtPhong.Text);
                    db.SaveChanges();
                    Clear();
                    FormDanhMucHV_Load(sender, e);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
