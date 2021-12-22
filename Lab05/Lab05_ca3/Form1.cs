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
            
            dgvPhieuThu.DataSource = dsPhieuThue;
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
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
         
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }

        public bool writeFile(string namef) {
            return false;
        }

        public bool readFile(string namef) {
            return false;
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dsPhieuThue = new List<CPhieuThuePhong>();

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
            
        }
    }
}
