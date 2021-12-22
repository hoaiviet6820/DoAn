using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab05_ca3
{
    public partial class Form1 : Form
    {
        
        private List<CPhieuThuePhong> dsPhieuThue;

        private void hienDSPhieuThuePhong() {
            
            dgvPhieuThu.DataSource = dsPhieuThue.ToList();
        }

        private CPhieuThuePhong timPTP(string ma) {

            foreach (CPhieuThuePhong item in dsPhieuThue) {
                if (item.MaPhieuThue == ma) {
                    return item;
                }
            }
            return null;
        }

        public Form1()
        {
            InitializeComponent();
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CPhieuThuePhong pt = new CPhieuThuePhong();
            pt.MaPhieuThue = txtMaPT.Text;
            pt.NgayBD = dtpNgayBD.Value;
            pt.NgayKT = dtpNgayKT.Value;
            pt.TenKH = txtTenKH.Text;

            if (pt.NgayBD > pt.NgayKT)
            {
                MessageBox.Show("Nhap lai Ngay Bat Dau!");
            }
            else
            {

                if (radA.Checked == true)
                {
                    pt.LoaiPhong = KieuLoaiPhong.A;
                }
                else if (radB.Checked == true)
                {
                    pt.LoaiPhong = KieuLoaiPhong.B;
                }
                else if (radC.Checked == true)
                {

                    pt.LoaiPhong = KieuLoaiPhong.C;
                }
                else
                {

                    pt.LoaiPhong = KieuLoaiPhong.D;
                }


                if (timPTP(pt.MaPhieuThue) == null)
                {

                    dsPhieuThue.Add(pt);
                    hienDSPhieuThuePhong();
                }
                else
                {
                    MessageBox.Show("Ma Phieu Thue: " + pt.MaPhieuThue + " da ton tai. Khong them duoc!");
                }

                txtMaPT.Text = "";

                txtTenKH.Text = "";
                radA.Checked = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maPT = txtMaPT.Text;
            CPhieuThuePhong pt = timPTP(maPT);
            if (pt == null)
            {
                MessageBox.Show("Khong Co Ma phieu THue!");
            }
            else
            {
                if (MessageBox.Show("Ban muon Xoa MA Phieu Thue nay khong?", "Thong Bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    dsPhieuThue.Remove(pt);
                    hienDSPhieuThuePhong();
                }
            }

            txtMaPT.Text = "";
            txtTenKH.Text = "";
            radA.Checked = true;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CPhieuThuePhong pt = timPTP(txtMaPT.Text);
            if (pt == null)
            {
                MessageBox.Show("Khong Tim thay Ma Phieu Thue!");
            }
            else
            {
                pt.NgayBD = dtpNgayBD.Value;
                pt.NgayKT = dtpNgayKT.Value;
                if (pt.NgayBD > pt.NgayKT)
                {
                    MessageBox.Show("Nhap lai Ngay Bat Dau!");
                }
                else
                {

                    pt.TenKH = txtTenKH.Text;
                    if (radA.Checked == true)
                    {
                        pt.LoaiPhong = KieuLoaiPhong.A;
                    }
                    else if (radB.Checked == true)
                    {
                        pt.LoaiPhong = KieuLoaiPhong.B;
                    }
                    else if (radC.Checked == true)
                    {
                        pt.LoaiPhong = KieuLoaiPhong.C;
                    }
                    else
                    {
                        pt.LoaiPhong = KieuLoaiPhong.D;
                    }


                    hienDSPhieuThuePhong();
                    txtMaPT.Text = "";
                    txtTenKH.Text = "";

                    radA.Checked = true;
                }
            }
        }

        public bool writeFile(string namef) {
            try
            {
                FileStream f = new FileStream(namef, FileMode.Create);


                if (f == null)
                {
                    return false;
                }
                else
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(f, dsPhieuThue);
                    f.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool readFile(string namef) {
            try
            {
                FileStream f = new FileStream(namef, FileMode.Open);
                if (f == null)
                {
                    return false;
                }
                else
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    dsPhieuThue = bf.Deserialize(f) as List<CPhieuThuePhong>;
                    f.Close();
                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            bool check = writeFile("dsPhieuThue.out");


            if (check == true)
            {
                MessageBox.Show("Luu thanh cong!");
            }
            else
            {
                MessageBox.Show("Khong the luu!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //dsPhieuThue = new List<CPhieuThuePhong>();

            if (readFile("dsPhieuThue.out") == true)
            {
                hienDSPhieuThuePhong();
            }
            else
            {
                MessageBox.Show("Khong The Doc File");
            }

        }

        private void dgvPhieuThu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPT.Text = dgvPhieuThu.Rows[e.RowIndex].Cells["MaPhieuThue"].Value.ToString();
            dtpNgayBD.Value = Convert.ToDateTime(dgvPhieuThu.Rows[e.RowIndex].Cells["NgayBD"].Value);
            dtpNgayKT.Value = Convert.ToDateTime(dgvPhieuThu.Rows[e.RowIndex].Cells["NgayKT"].Value);
            txtTenKH.Text = dgvPhieuThu.Rows[e.RowIndex].Cells["TenKH"].Value.ToString();
            switch (dgvPhieuThu.Rows[e.RowIndex].Cells["LoaiPhong"].Value.ToString()) {
                case "A":
                    radA.Checked = true;
                    break;
                case "B":
                    radB.Checked = true;
                    break;
                case "C":
                    radC.Checked = true;
                    break;
                case "D":
                    radD.Checked = true;
                    break;
            }


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co muon thoat chuong trinh khong?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
