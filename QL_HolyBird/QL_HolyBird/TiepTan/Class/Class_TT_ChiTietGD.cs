using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_HolyBird
{
    public class Class_TT_ChiTietGiaoDich
    {
        public string MaCTGD { get; set; }
        public decimal DonGiaPhong { get; set; }
        public int SoNgay { get; set; }

        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }

        public decimal TongPhiPhatSinh { get; set; }

        public decimal ThanhTien { get; set; }

        public List<ChiTietPhi> DanhSachPhiPhatSinh { get; set; } = new List<ChiTietPhi>();

        public decimal TienPhongThucTe
        {
            get { return DonGiaPhong * SoNgay; }
        }
    }
}
