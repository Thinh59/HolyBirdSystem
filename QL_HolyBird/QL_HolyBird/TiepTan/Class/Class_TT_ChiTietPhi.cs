using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_HolyBird
{
    public class ChiTietPhi
    {
        public string TenPhiPhatSinh { get; set; }
        public decimal GiaPhi { get; set; }

        public int SoLuong { get; set; }
        public decimal ThanhTienPPS { get; set; } // = SoLuong * GiaPhi
    }
}
