using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab05_ca3
{
    [Serializable]
    public enum KieuLoaiPhong {A,B,C,D}
    public class CPhieuThuePhong
    {
        private string m_maphieu;
        private DateTime m_ngaybd;
        private DateTime m_ngaykt;
        private string m_tenkh;
        private KieuLoaiPhong m_loaiPhong;

        public CPhieuThuePhong()
        {
        }

        public CPhieuThuePhong(string maphieu, DateTime ngaybd, DateTime ngaykt, string tenkh, KieuLoaiPhong loaiPhong)
        {
            m_maphieu = maphieu;
            m_ngaybd = ngaybd;
            m_ngaykt = ngaykt;
            m_tenkh = tenkh;
            m_loaiPhong = loaiPhong;
        }

        public string MaPhieuThue { get => m_maphieu; set => m_maphieu = value; }
        public DateTime NgayBD { get => m_ngaybd; set => m_ngaybd = value; }
        public DateTime NgayKT { get => m_ngaykt; set => m_ngaykt = value; }
        public string TenKH { get => m_tenkh; set => m_tenkh = value; }
        public KieuLoaiPhong LoaiPhong { get => m_loaiPhong; set => m_loaiPhong = value; }

        public int SoNgayThue {
            get {
                return ((m_ngaykt - m_ngaybd).Days + 1);
            }
        }

        public int TienThue {
            get
            {
                if (m_loaiPhong == KieuLoaiPhong.A) {
                    return 250 * SoNgayThue;
                } else if (m_loaiPhong == KieuLoaiPhong.B) {
                    return 400 * SoNgayThue;
                } else if (m_loaiPhong == KieuLoaiPhong.C) {
                    return 600 * SoNgayThue;
                }
                else {
                    return 900 * SoNgayThue;
                }

            }
        }

    }
}
