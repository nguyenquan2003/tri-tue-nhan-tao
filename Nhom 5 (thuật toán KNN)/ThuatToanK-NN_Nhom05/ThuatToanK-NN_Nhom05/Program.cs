using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuatToanK_NN_Nhom05
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ThuatToanKNN knn = new ThuatToanKNN();
            // Dùng thư viện này để chuyển vùng sang Mỹ để hiểu dấu chấm là số thực
            var culture = new System.Globalization.CultureInfo("en-US");
            try
            {
                // Đường dẫn tới file dữ liệu
                string filePath = "Data.txt";
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    // Đọc dòng đầu tiên để lấy số lượng hàng xóm
                    line = sr.ReadLine();
                    int soLuongHangXom = int.Parse(line);
                    int dem = int.Parse(line) * 2;
                    int count = 1;
                    double[] tinhNangHangXom = null;
                    string nhanHangXom = "";
                    
                    while ((line = sr.ReadLine()) != null && count <= dem)
                    {
                        if (count % 2 != 0)
                        {
                            string[] giaTriNhap = line.Split(',');
                            tinhNangHangXom = Array.ConvertAll(giaTriNhap, i => double.Parse(i, culture));
                            count++;
                            continue;
                        }

                        if (count % 2 == 0)
                        {
                            nhanHangXom = line.ToString();
                        }
                        count++;
                        knn.ThemHangXom(tinhNangHangXom, nhanHangXom);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            // Yêu cầu người dùng nhập dữ liệu kiểm tra

            Console.WriteLine("Nhap du lieu de kiem tra (cac gia tri phan cach nhau ban dau phay):");
            string[] giaTriKiemTra = Console.ReadLine().Split(',');

            // Chuyển đổi các giá trị nhập thành mảng số thực
            double[] tinhNangKiemTra = Array.ConvertAll(giaTriKiemTra, i => double.Parse(i, culture));

           
            // Yêu cầu người dùng nhập số lượng hàng xóm gần nhất (k)
            Console.WriteLine("Nhap so luong hang xom gan nhat (k > 0):");
            int soLuongHangXomGanNhat = int.Parse(Console.ReadLine());
            
            // Sử dụng thuật toán KNV để phân loại dữ liệu kiểm tra
            string nhanDuDoan = knn.PhanLoai(tinhNangKiemTra, soLuongHangXomGanNhat);

            // In kết quả dự đoán ra màn hình
            Console.WriteLine("Nhan du đoan: " + nhanDuDoan);
            Console.Read();
        }
    }
}
