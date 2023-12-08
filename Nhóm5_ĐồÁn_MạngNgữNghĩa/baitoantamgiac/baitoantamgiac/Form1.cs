using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitoantamgiac
{
    public partial class Form1 : Form
    {
        #region Điều Khiển
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbbgiatritinh.SelectedItem = cbbgiatritinh.Items[0];
            Arr();
            HienThiDGV();
        }
        #endregion
        #region Khai Báo Biến

        public string[] YEUTO = { "Góc alpha", "Góc beta", "Góc delta", "Cạnh a", "Cạnh b", "Cạnh c", " Nửa Chu Vi", "Diện Tích", "Chiều Cao(hc)" };
        private float congthuc = 10, yeuto = 9;
        private float[,] a = new float[9, 10];
        private const float goc = 180f;
        private float kq = 0;
        private float[,] ArrLuu = new float[9, 10];
        private int stop;
        bool flag;
        Timer mytime = new Timer();
        Form2 gr_MoHinh = new Form2();

        #endregion

        #region Khởi Tạo Mảng
        private void Arr()
        {
            float temp = -1;
            for (int i = 0; i < yeuto; i++)
                for (int j = 0; j < congthuc; j++)
                {
                    a[i, j] = 0;
                    ArrLuu[i, j] = 0;
                }
            //Mảng xử lý
            a[0, 0] = a[0, 3] = a[0, 6] = temp;
            a[1, 0] = a[1, 1] = a[1, 3] = a[1, 6] = temp;
            a[2, 1] = a[2, 3] = a[2, 6] = a[2,7] = temp;
            a[3, 0] = a[3, 2] = a[3, 5] = a[3,7] = temp;
            a[4, 0] = a[4, 1] = a[4, 2] = a[4, 5] = a[4,7] = temp;
            a[5, 1] = a[5, 2] = a[5, 4] = a[5, 5] = a[5,7] = temp;
            a[6, 2] = a[6, 5] = a[6, 8] = a[6,9] = temp;
            a[7, 2] = a[7, 4] = a[7,8]= temp;
            a[8, 4] = a[8,8]= temp;
            
            //Mảng xuất ra DataGridView
            ArrLuu[0, 0] = ArrLuu[0, 3]= ArrLuu[0, 6] = temp;
            ArrLuu[1, 0] = ArrLuu[1, 1] = ArrLuu[1, 3] = ArrLuu[1, 6] = temp;
            ArrLuu[2, 1] = ArrLuu[2, 3] = ArrLuu[2, 6] = ArrLuu[2,7] = temp;
            ArrLuu[3, 0] = ArrLuu[3, 2] = ArrLuu[3, 5] = ArrLuu[3, 7] = temp;
            ArrLuu[4, 0] = ArrLuu[4, 1] = ArrLuu[4, 2] = ArrLuu[4, 5] = ArrLuu[4, 7] = temp;
            ArrLuu[5, 1] = ArrLuu[5, 2] = ArrLuu[5, 4] = ArrLuu[5, 5] = ArrLuu[5, 7] = temp;
            ArrLuu[6, 2] = ArrLuu[6, 5] = ArrLuu[6,8]= ArrLuu[6,9] =temp;
            ArrLuu[7, 2] = ArrLuu[7, 4] = ArrLuu[7,8]= temp;
            ArrLuu[8, 4] = ArrLuu[8,8]=temp;
        }
        #endregion

        #region Xử Lý

        //Kiểm tra xem giá trị ở combobox đã được tính chưa.
        private bool Tinhgiatri()
        {
            switch (cbbgiatritinh.SelectedIndex)
            {
                case 1:
                    if (a[0, 0] == -1)
                    {
                        break;
                    }
                    return true;

                case 2:
                    if (a[1, 0] == -1)
                    {
                        break;
                    }
                    return true;
                case 3:
                    if (a[2, 1] == -1)
                    {
                        break;
                    }
                    return true;
                case 4:
                    if (a[3, 0] == -1)
                    {
                        break;
                    }
                    return true;
                case 5:
                    if (a[4, 0] == -1)
                    {
                        break;
                    }
                    return true;
                case 6:
                    if (a[5, 1] == -1)
                    {
                        break;
                    }
                    return true;
                case 7:
                    if (a[7, 2] == -1)
                    {
                        break;
                    }
                    return true;
                case 8:
                    if (a[8, 4] == -1)
                    {
                        break;
                    }
                    return true;
                case 9:
                    if (a[6, 2] == -1)
                    {
                        break;
                    }
                    return true;
            }
            return false;
        }
        //Hiển thị lên Textbox kết quả.
        public void HienThiKetQua()
        {
            switch (cbbgiatritinh.SelectedIndex)
            {
                case 1:
                    txtketqua.Text = (a[0, 0].ToString());
                    break;

                case 2:
                   // kq = (float)((a[1, 0] * goc) / Math.PI);
                    txtketqua.Text = (a[1, 0].ToString());
                    break;

                case 3:
                   // kq = (float)((a[2, 1] * goc) / Math.PI);
                    txtketqua.Text = (a[2, 1].ToString());
                    break;

                case 4:
                    txtketqua.Text = a[3, 0].ToString();
                    break;

                case 5:
                    txtketqua.Text = a[4, 0].ToString();
                    break;

                case 6:
                    txtketqua.Text = a[5, 1].ToString();
                    break;

                case 7:
                    txtketqua.Text = a[7, 2].ToString();
                    break;

                case 8:
                    txtketqua.Text = a[8, 4].ToString();
                    break;

                case 9:
                    kq = a[6, 2]*2;
                    txtketqua.Text = kq.ToString();
                    break;
                    
            }
        }
        //Phương thức này sẽ kiểm tra xem yếu tố nào có thể tính.
        private int LayYeuTo(int congthuc1)
        {
            int dem = 0, gt = -1;
            if (congthuc1 == 9 && a[6, congthuc1] != -1)
                return 6;
            for (int i = 0; i < yeuto; i++)
                if (a[i, congthuc1] == -1)
                {
                    dem++;
                    gt = i;
                }
            if (dem == 1)
                return gt;
            return -1;
        }
        //Kích hoạt cơ chế lan truyền.
        private void Cochelantruyen(int congthuc1, int yeuto1)
        {
            float value = -1, lgt = -1;
            switch (congthuc1)
            {
                case 0:
                    switch (yeuto1)
                    {
                        case 0:
                            // α= a*sinβ /b
                            lgt = (float)((a[3, 0] * Math.Sin(a[1, 0] * Math.PI / 180)) / (a[4, 0]));
                            value = (float)(Math.Asin(lgt) * 180 / Math.PI);
                            list.Items.Add("α= a*sinβ /b => α =" + value.ToString());
                            break;
                        case 1:
                            // β = b*sinα /a
                            lgt = (float)((a[4, 0] * Math.Sin(a[0, 0] * Math.PI / 180)) / (a[3, 0]));
                            value = (float)(Math.Asin(lgt) *180 / Math.PI);
                            list.Items.Add("β = b*sinα/a => β =" + value.ToString());
                            break;
                        case 3:
                            // a= b*sinα/ sinβ
                            value = (float)((a[4, 0] * Math.Sin(a[0, 0] * Math.PI / 180)) / Math.Sin(a[1, 0] * Math.PI / 180));
                            list.Items.Add("a= b*sinα/ sinβ => a=" + value.ToString());
                            break;
                        case 4:
                            // b= a*sinβ /sinα
                            value = (float)((a[3, 0] * Math.Sin(a[1, 0] * Math.PI / 180)) / Math.Sin(a[0, 0] * Math.PI / 180));
                            list.Items.Add("b= a*sinβ /sinα => b=" + value.ToString());
                            break;
                    }
                    break;
                case 1:
                    switch (yeuto1)
                    {
                        case 1:
                            // sinβ= b*sinδ/c
                            lgt = (float)((a[4, 0] * Math.Sin(a[2, 1]*Math.PI/180)) / (a[5, 1]));
                            value = (float)(Math.Asin(lgt) *180/Math.PI);
                            list.Items.Add("sinβ= b*sinδ /c => β=" + value.ToString());
                            break;
                        case 2:
                            // sinδ = c*sinβ /b
                            lgt = (float)((a[5, 1] * Math.Sin(a[1, 1] * Math.PI / 180)) / a[4, 1]);
                            value = (float)(Math.Asin(lgt) * 180 / Math.PI);
                            list.Items.Add("sinδ = c*sinβ /b => δ=" + value.ToString());
                            break;
                        case 4:
                            // b=c*sinβ/sinδ
                            value = (float)((a[5, 1] * Math.Sin(a[1, 0] * Math.PI / 180)) / Math.Sin(a[2, 1] * Math.PI / 180));
                            list.Items.Add("b = c*sinβ /sinδ => b=" + value.ToString());
                            break;
                        case 5:
                            // c=b*sinδ /sinβ
                            value = (float)((a[4, 0] * Math.Sin(a[2, 1] * Math.PI / 180)) / Math.Sin(a[1, 0] * Math.PI / 180));
                            list.Items.Add("c = b*sinδ /sinβ => c=" + value.ToString());
                            break;
                    }
                    break;
                case 2:
                    float chuvi = (float)((a[3, 0] + a[4, 0] + a[5, 1]) );
                    // ChuVi=(a+b+c)
                    switch (yeuto1)
                    {
                        case 3:
                            // a=p-(s^2/p*(p-b)(p-c)) ct1
                            value = (float)(chuvi - (Math.Pow(a[7, 2], 2.0) / (chuvi * (chuvi - a[4, 0]) * (chuvi - a[5, 1]))));
                            list.Items.Add("a = p - (S^2 / p*(p-b)(p-c)) => a="+ value.ToString());
                            break;
                        case 4:
                            // c=p-(s^2/p*(p-a)(p-b))
                            value = (float)(chuvi - (Math.Pow(a[7, 2], 2.0) / (chuvi * (chuvi - a[3, 0]) * (chuvi - a[4, 1]))));
                            list.Items.Add("c = p - (S^2 / p*(p-a)(p-b)) => c ="+ value.ToString());
                            break;
                        case 5:
                            // a=p-(s^2/p*(p-b)(p-c)) ct2
                            value = (float)(chuvi - (Math.Pow(a[7, 2], 2.0) / (chuvi * (chuvi - a[4, 1]) * (chuvi - a[5, 1]))));
                            list.Items.Add("a = p - (S^2 / p*(p-b)(p-c)) => a ="+ value.ToString());
                            break;
                        case 6:
                            // p= (a+b+c)/2
                            value = (float)((a[3, 0] + a[4, 0] + a[5, 1]));
                            list.Items.Add("Chu Vi= (a+b+c) => Chu vi =" + value.ToString());
                            break;
                        case 7:
                            // s=sqrt(p(p-a)(p-b)(p-c))
                            value = (float)Math.Sqrt((double)(chuvi/2 * (chuvi/2 - a[3, 0]) * (chuvi/2 - a[4, 0]) * (chuvi/2 - a[5, 1])));
                            list.Items.Add("S = sqrt(p(p-a)(p-b)(p-c)) = > S ="+ value.ToString());
                            break;
                    }
                    break;
                case 3:
                    switch (yeuto1)
                    {
                        case 0:
                            //a=180-b-c
                            value = (float)((goc - a[1, 0] - a[2, 1]));
                            list.Items.Add("α = 180 - β - δ => α =" + value.ToString());
                            break;
                        case 1:
                            // b = 180 -a-c
                            value = (float)((goc - a[0, 0] - a[2, 1]));
                            list.Items.Add("β = 180 - α - δ => β =" + value.ToString());
                            break;
                        case 2:
                            // c= 180-a-b
                            value = (float)((goc - a[0, 0] - a[1, 1]));
                            list.Items.Add("δ = 180 -α -β => δ =" + value.ToString());
                            break;

                    }
                    break;
                
                case 4:
                    switch (yeuto1)
                    {
                        case 5:
                            // c=2*s/h
                            value = (float)(2f * a[7, 2] / a[8, 4]);
                            list.Items.Add("c = 2 * S/h => c ="+ value.ToString());
                            break;
                        case 7:
                            // h=2s/c ct3
                            value = (float)(2f * a[7, 4] / a[5,1]);
                            list.Items.Add("h = 2S/c => h ="+ value.ToString());
                            break;
                        case 8:
                            // h=2s/c ct5
                            value = (float)(2f * a[7, 2] / a[5, 1]);
                            list.Items.Add("h = 2S/c => h ="+ value.ToString());
                            break;
                    }
                    break;
                case 5:
                    switch (yeuto1)
                    {
                        case 3:
                            //"Tinh a = 2p - b - c"
                            value = (float)(2f * a[6, 2] - a[4, 0] - a[5, 1]);
                            list.Items.Add("a = 2p - b - c => a ="+ value.ToString());
                            break;
                        case 4:
                            //'Tinh b = 2p - a - c'
                            value = (float)(2f * a[6, 2] - a[3, 0] - a[5, 1]);
                            list.Items.Add("b = 2p - a - c => a ="+ value.ToString());
                            break;
                        case 5:
                            //'Tinh c = 2p - a - b'
                            value = (float)(2f * a[6, 2] - a[3, 0] - a[4, 0]);
                            list.Items.Add("c = 2p - a - b => c ="+ value.ToString());
                            break;
                        case 6:
                            //"Tinh p = (a + b + c) / 2"
                            value = (float)((a[3, 0] + a[4, 0] + a[5, 1])/2);
                            list.Items.Add("Chu vi = (a + b + c) => Chu vi =" + (value*2).ToString());
                            break;
                    }
                    break;
                case 6:
                    switch (yeuto1)
                    {
                        case 0:
                            // α = pi-β-δ
                            value = (float)((Math.PI - a[1, 0] - a[2, 1]));
                            list.Items.Add("α = pi - β - δ => α =" + value.ToString());
                            break;
                        case 1:
                            // β = pi-α-δ
                            value = (float)((Math.PI - a[0, 0] - a[2, 1]));
                            list.Items.Add("β = pi - α - δ => β =" + value.ToString());
                            break;
                        case 2:
                            // δ=pi-α-β
                            value = (float)((Math.PI - a[0, 0] - a[1, 0]));
                            list.Items.Add("δ = pi - α - β => δ = " + value.ToString());
                            break;
                    }
                    break;
                case 7:
                    switch (yeuto1)
                    {
                        case 2:
                            // Cos(c) = (pow(a,2)+pow(b,2)-pow(c,2))/2*a*b
                            value = (float)(Math.Pow(a[3,0],2)+ Math.Pow(a[4,0], 2)- Math.Pow(a[5, 1], 2))/(2*a[3,0]*a[4,0]);
                            // c = arccos(c)
                            value = (float)( Math.Acos(value) * 180 / Math.PI);
                            list.Items.Add("δ = ArcCos((A^2 +B^2 -C^2)/2*A*B) => δ =" + value.ToString());
                            break;
                        case 3:
                            // A=sqrt(pow(B,2)+pow(C,2)-2BCCos(a))
                            value= (float)Math.Sqrt(Math.Pow(a[4, 0], 2) + Math.Pow(a[5, 1], 2) - 2 * a[4, 0] * a[5, 1] * Math.Cos(a[0,0] * Math.PI / 180));
                            list.Items.Add("A = sqrt( B^2 + C^2 - 2BCCos(α)) => A =" + value.ToString());
                            break;
                        case 4:
                            // B=sqrt(pow(A,2)+pow(B,2)-2BCCos(b))
                            value = (float)Math.Sqrt(Math.Pow(a[3, 0], 2) + Math.Pow(a[5, 1], 2) - 2 * a[3, 0] * a[5, 1] * Math.Cos(a[1,0] * Math.PI / 180));
                            list.Items.Add("B = sqrt( A^2 +C^2 -2ACCos(β)) => B =" + value.ToString());
                            break;
                        case 5:
                            // C= sqrt(pow(A,2)+pow(B,2)-2ABCos(c))
                            value = (float)Math.Sqrt(Math.Pow(a[3, 0], 2) + Math.Pow(a[4, 0], 2) - 2 * a[3, 0] * a[4, 0] * Math.Cos(a[2, 1] * Math.PI / 180));
                            list.Items.Add("C = sqrt( A^2 +B^2 -2ABCos(δ)) => B =" + value.ToString());
                            break;
                    }
                    break;
                case 8:
                    switch (yeuto1)
                    {
                        case 6:
                            // p = 2S/h
                            value = (float)(a[7, 2] * 2 / a[8, 4]);
                            list.Items.Add("p = 2S/h => p =" + value.ToString());
                            list.Items.Add("Chu Vi = 2p => Chu Vi = " + (value*2).ToString());
                            break;
                        case 7:
                            //S =p*h/2
                            value = (float)((a[6, 2] *a[8, 4])/2);
                            list.Items.Add("S = (p*h)/2 => S =" + value.ToString());
                            break;
                        case 8:
                            //h = 2S/p
                            value = (float)(2 * a[7, 2] / a[6,2]);
                            list.Items.Add("h = 2S/h => h =" + value.ToString());
                            break;

                    }

                    break;
                case 9:
                    switch(yeuto1)
                    { 
                        case 6:
                            // ChuVi = 2.p
                            value = (float)(2 * a[6,2]);
                            list.Items.Add("Chu Vi = 2.p => Chu Vi =" + value.ToString());
                            break;
                    }
                    break;

            }
            if (value <= 0)
            {
                MessageBox.Show("Các yếu tố nhập vào không hợp lệ!!. Vui lòng kiểm tra lại.", "Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stop = 1;
            }
            else
            {
                for (int i = 0; i < congthuc; i++)
                    if (a[yeuto1, i] == -1)
                    {
                        a[yeuto1, i] = value;
                        ArrLuu[yeuto1, i] = 1;
                    }
            }
        }
        //Xử lý giá trị truyền vào từ textbox
        private void LayGiaTri()
        {
            Arr();
            if (!string.IsNullOrEmpty(txtgoc_a.Text))
            {
                float num = (float)float.Parse(txtgoc_a.Text);
                for (int i = 0; i < congthuc; i++)
                {
                    if (this.a[0, i] == -1f && this.a[0, i] != 0)
                    {
                        this.a[0, i] = num;
                        this.ArrLuu[0, i] = 1;
                    }
                }
            }
            if (!string.IsNullOrEmpty(txtgoc_b.Text))
            {
                float num1 = (float)float.Parse(txtgoc_b.Text);
                for (int i = 0; i < congthuc; i++)
                {
                    if (this.a[1, i] == -1f && this.a[1, i] != 0)
                    {
                        this.a[1, i] = num1;
                        this.ArrLuu[1, i] = 1;
                    }
                }
            }
            if (!string.IsNullOrEmpty(txtgoc_c.Text))
            {
                float num2 = (float)float.Parse(txtgoc_c.Text);
                for (int i = 0; i < congthuc; i++)
                {
                    if (this.a[2, i] == -1f && this.a[2, i] != 0)
                    {
                        this.a[2, i] = num2;
                        this.ArrLuu[2, i] = 1;
                    }
                }
            }
            if (!string.IsNullOrEmpty(txtcanh_a.Text))
            {
                float num3 = float.Parse(txtcanh_a.Text);
                for (int i = 0; i < congthuc; i++)
                {
                    if (this.a[3, i] == -1f && this.a[3, i] != 0)
                    {
                        this.a[3, i] = num3;
                        this.ArrLuu[3, i] = 1;
                    }
                }
            }
            if (!string.IsNullOrEmpty(txtcanh_b.Text))
            {
                float num4 = float.Parse(txtcanh_b.Text);
                for (int i = 0; i < congthuc; i++)
                {
                    if (this.a[4, i] == -1f && this.a[4, i] != 0)
                    {
                        this.a[4, i] = num4;
                        this.ArrLuu[4, i] = 1;
                    }
                }
            }
            if (!string.IsNullOrEmpty(txtcanh_c.Text))
            {
                float num5 = float.Parse(txtcanh_c.Text);
                for (int i = 0; i < congthuc; i++)
                {
                    if (this.a[5, i] == -1f && this.a[5, i] != 0)
                    {
                        this.a[5, i] = num5;
                        this.ArrLuu[5, i] = 1;
                    }
                }
            }
            if (!string.IsNullOrEmpty(txtdientich.Text))
            {
                float num6 = float.Parse(txtdientich.Text);
                for (int i = 0; i < congthuc; i++)
                {
                    if (this.a[7, i] == -1f && this.a[7, i] != 0)
                    {
                        this.a[7, i] = num6;
                        this.ArrLuu[7, i] = 1;
                    }
                }
            }
            if (!string.IsNullOrEmpty(txtchieucao.Text))
            {
                float num7 = float.Parse(txtchieucao.Text);
                for (int i = 0; i < congthuc; i++)
                {
                    if (this.a[8, i] == -1f && this.a[8, i] != 0)
                    {
                        this.a[8, i] = num7;
                        this.ArrLuu[8, i] = 1;
                    }
                }
            }
            if (!string.IsNullOrEmpty(txtNuachuvi.Text))
            {
                float num8 = float.Parse(txtNuachuvi.Text);
                for (int i = 0; i < congthuc; i++)
                {
                    if (this.a[6, i] == -1f && this.a[6, i] != 0)
                    {
                        this.a[6, i] = num8;
                        this.ArrLuu[6, i] = 1;
                    }
                }
            }
        }
        //Tính toán
        private void Xuly()
        {
            flag = true;
            LayGiaTri();
            while (flag == true)
            {
                flag = false;
                for (int i = 0; i < congthuc; i++)
                {
                    int layyeuto = LayYeuTo(i);
                    if (layyeuto != -1)
                    {
                        if (stop == 1)
                            break;
                        Cochelantruyen(i, layyeuto);
                        flag = true;
                        if (Tinhgiatri())
                        {
                            HienThiKetQua();
                            
                            flag = false;
                            break;
                        }
                    }
                }
            }
            if (!Tinhgiatri() && stop == 0)
                MessageBox.Show("- Không đủ yếu tố !.\n- Không thể tính kết quả trên mạng ngữ nghĩa đã xây dựng !!.\n- Vui Lòng Xem Trợ Giúp !!", "Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            HienThiDGV();
        }
        //Vẽ lên mạng ngữ nghĩa
        public void VeMoiLienHe(object sender, EventArgs e)
        {
            if (a[0, 0] != -1)
            {
                gr_MoHinh.LoaiHinh(0);
            }
            if (a[1, 0] != -1)
            {
                gr_MoHinh.LoaiHinh(1);
            }
            if (a[2, 1] != -1)
            {
                gr_MoHinh.LoaiHinh(2);
            }
            if (a[3, 0] != -1)
            {
                gr_MoHinh.LoaiHinh(3);
            }
            if (a[4, 0] != -1)
            {
                gr_MoHinh.LoaiHinh(4);
            }
            if (a[5, 2] != -1)
            {
                gr_MoHinh.LoaiHinh(5);
            }
            if (a[6, 2] != -1)
            {
                gr_MoHinh.LoaiHinh(6);
            }
            if (a[7, 2] != -1)
            {
                gr_MoHinh.LoaiHinh(7);
            }
            if (a[8, 4] != -1)
            {
                gr_MoHinh.LoaiHinh(8);
            }
        }
        //Hiển thị DataGridView
        private void HienThiDGV()
        {
            dataBangSuyDien.Rows.Clear();
            if (dataBangSuyDien.RowCount == 0)
                dataBangSuyDien.Rows.Add(10);
            for (int i = 0; i < yeuto; i++)
            {
                for (int j = 0; j <= congthuc; j++)
                {
                    if (j == 0)
                    {
                        dataBangSuyDien[j, i].Value = YEUTO[i];
                        dataBangSuyDien[j, i].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        dataBangSuyDien[j, i].Value = ArrLuu[i, j -1];
                        if (ArrLuu[i, j - 1] == -1)
                            dataBangSuyDien[j, i].Style.BackColor = Color.LightSkyBlue;
                        if (ArrLuu[i, j - 1] == 1)
                            dataBangSuyDien[j, i].Style.BackColor = Color.Yellow;
                    }
                }
            }
        }
        
        //Xử lý ngoại lệ. Điều kiện của một tam giác.
        private int NgoaiLe()
        {
            int kiemtra = 0;
            if (!string.IsNullOrEmpty(txtgoc_a.Text) && !string.IsNullOrEmpty(txtgoc_b.Text) && !string.IsNullOrEmpty(txtgoc_c.Text))
                if (float.Parse((txtgoc_a.Text)) + float.Parse((txtgoc_b.Text)) + float.Parse((txtgoc_c.Text)) != 180)
                    kiemtra = 1;

            if (!string.IsNullOrEmpty(txtcanh_a.Text) && !string.IsNullOrEmpty(txtcanh_b.Text) && !string.IsNullOrEmpty(txtcanh_c.Text))
                if ((float.Parse((txtcanh_a.Text)) + float.Parse((txtcanh_b.Text)) <= float.Parse((txtcanh_c.Text))) || (float.Parse((txtcanh_a.Text)) + float.Parse((txtcanh_c.Text)) <= float.Parse((txtcanh_b.Text))) || (float.Parse((txtcanh_b.Text)) + float.Parse((txtcanh_c.Text)) <= float.Parse((txtcanh_a.Text))))
                    kiemtra = 2;

            if (!string.IsNullOrEmpty(txtcanh_a.Text) && !string.IsNullOrEmpty(txtcanh_b.Text) && !string.IsNullOrEmpty(txtcanh_c.Text) && !string.IsNullOrEmpty(txtgoc_a.Text) && !string.IsNullOrEmpty(txtgoc_b.Text) && !string.IsNullOrEmpty(txtgoc_c.Text))
                if (float.Parse((txtcanh_a.Text)) < float.Parse((txtcanh_b.Text)) && float.Parse((txtgoc_a.Text)) > float.Parse((txtgoc_b.Text)) || float.Parse((txtcanh_a.Text)) < float.Parse((txtcanh_c.Text)) && float.Parse((txtgoc_a.Text)) > float.Parse((txtgoc_c.Text)) || float.Parse((txtcanh_b.Text)) < float.Parse((txtcanh_c.Text)) && float.Parse((txtgoc_b.Text)) > float.Parse((txtgoc_c.Text)))
                    kiemtra = 3;
            return kiemtra;
        }

        #endregion

        #region Textbox
        //Chỉ cho phép nhập số vào textbox
        private void Chinhapso(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && ((int)e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    int ma = (int)e.KeyChar;
                    if ((ma == 26) || (ma == 24) || (ma == 3) || (ma == 22) || (ma == 1))
                        e.Handled = true;
                }
            }
        }

        private void goc_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chinhapso(e);
        }

        private void goc_b_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chinhapso(e);
        }

        private void goc_c_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chinhapso(e);
        }

        private void canh_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chinhapso(e);
        }

        private void canh_b_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chinhapso(e);
        }

        private void canh_c_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chinhapso(e);
        }

        private void dientich_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chinhapso(e);
        }

        private void chieucao_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chinhapso(e);
        }
        #endregion

        #region Botton
        private void btnLamlai_Click(object sender, EventArgs e)
        {
            cbbgiatritinh.SelectedItem = cbbgiatritinh.Items[0];
            Arr();
            HienThiDGV();
            txtgoc_a.Text = txtgoc_b.Text = txtgoc_c.Text = string.Empty;
            txtcanh_a.Text = txtcanh_b.Text = txtcanh_c.Text = string.Empty;
            txtdientich.Text = txtchieucao.Text = string.Empty;
            txtketqua.Text = string.Empty;
            txtNuachuvi.Text = string.Empty;
            list.Items.Clear();
           
        }

        private void dataBangSuyDien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Graphic_Click(object sender, EventArgs e)
        {
            mytime.Enabled = true;
            mytime.Interval = 500;
            mytime.Tick += new EventHandler(VeMoiLienHe);
            gr_MoHinh.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_TenDoAn.Text = "Đồ Án Trí Tuệ Nhân Tạo: Giải Bài Toán Trong Tam Giác Bằng Mạng Ngữ Nghĩa";
            txt_TenTV1.Text = "200121092 - Ngô Thị Thùy Linh";
            txt_TenTV2.Text = "2001210235 - Phùng Huỳnh Thanh Ngân";
            txt_TenTV3.Text = "2001210779 - Nguyễn Ngọc Quân";
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnTính_Click(object sender, EventArgs e)
        {
            
            stop = 0;
            txtketqua.Text = string.Empty;
            if (cbbgiatritinh.SelectedItem == cbbgiatritinh.Items[0] || NgoaiLe() == 1 || NgoaiLe() == 2)
            {
                if (cbbgiatritinh.SelectedItem == cbbgiatritinh.Items[0])
                    MessageBox.Show("Chưa chọn giá trị tính!!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (NgoaiLe() == 1 || NgoaiLe() == 2 || NgoaiLe() ==3)
                    MessageBox.Show("- Giá trị nhập vào không thỏa mãn điều kiện của 1 tam giác.\n- Vui lòng nhập lại!.", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                Xuly();
        }

        #endregion
    }
}
