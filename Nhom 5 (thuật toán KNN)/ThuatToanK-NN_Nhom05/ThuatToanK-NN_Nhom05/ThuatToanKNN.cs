using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuatToanK_NN_Nhom05
{
    internal class ThuatToanKNN
    {
        public class HangXom
        {
            public double[] DacDiem { get; set; }
            public string Nhan { get; set; }


        }

        public List<HangXom> hangXoms;

        public ThuatToanKNN()
        {
            
            hangXoms = new List<HangXom>();
        }

        public void ThemHangXom(double[] DacDiem, string nhan)
        {
            hangXoms.Add(new HangXom { DacDiem = DacDiem, Nhan = nhan });
        }

        public string PhanLoai(double[] DacDiem, int k)
        {
            List<HangXom> hangXomGanNhat = LayHangXomGanNhat(DacDiem, k);
            string nhanDuDoan = LayNhanPhoBienNhat(hangXomGanNhat);
            return nhanDuDoan;
        }

        private List<HangXom> LayHangXomGanNhat(double[] DacDiem, int k)
        {
            List<HangXom> hangXomGanNhat = hangXoms.OrderBy(h => KhoangCach(h.DacDiem, DacDiem))
                                                   .Take(k)
                                                   .ToList();
            return hangXomGanNhat;
        }

        private double KhoangCach(double[] diem1, double[] diem2)
        {
            if (diem1.Length != diem2.Length)
                throw new ArgumentException("Độ dài của tinh năng không khớp.");

            double tongBinhPhuongKhacBiet = 0.0;
            for (int i = 0; i < diem1.Length; i++)
            {
                double khacBiet = diem1[i] - diem2[i];
                tongBinhPhuongKhacBiet += khacBiet * khacBiet;
            }

            return Math.Sqrt(tongBinhPhuongKhacBiet);
        }

        private string LayNhanPhoBienNhat(List<HangXom> hangXoms)
        {
            var demNhan = hangXoms.GroupBy(h => h.Nhan)
                                  .ToDictionary(gr => gr.Key, gr => gr.Count());

            string nhanPhoBienNhat = demNhan.OrderByDescending(pair => pair.Value)
                                            .FirstOrDefault()
                                            .Key;

            return nhanPhoBienNhat;
        }
    }
}
