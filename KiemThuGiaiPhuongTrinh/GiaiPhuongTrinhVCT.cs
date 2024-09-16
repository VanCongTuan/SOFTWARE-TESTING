using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanCongTuan_KTPM
{
    public partial class GiaiPhuongTrinhVCT : Form
    {
        public GiaiPhuongTrinhVCT()
        {
            InitializeComponent();
        }

        private void rdbtn_1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtn_1.Checked)
            {
                this.txtC.Enabled = false;
            }
            txt_KQ.Enabled = false;
        }

        private void rdbtn_2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtn_2.Checked)
            {
                this.txtC.Enabled = true;
            }
            txt_KQ.Enabled = false;
        }

        private void btn_GPT_Click(object sender, EventArgs e)
        {
            double a, b, c;
            string kq;
            if (!rdbtn_1.Checked && !rdbtn_2.Checked) MessageBox.Show("Bạn hãy chọn 1 phương thức");
            else if (!double.TryParse(txtA.Text, out a)) MessageBox.Show("Bạn Phải nhập a là số");
            else if (!double.TryParse(txtB.Text, out b)) MessageBox.Show("Bạn Phải nhập b là số");
            else if (rdbtn_1.Checked)
            {
                a = double.Parse(txtA.Text);
                b = double.Parse(txtB.Text);
                GiaiPhuongTrinh x = new GiaiPhuongTrinh(a, b);
                kq = x.PhuongTrinhBacNhat();
                txt_KQ.Text = "Phuong trình có nghiệm \t X=" + kq;

            }
            else
            {
                a = double.Parse(txtA.Text);
                b = double.Parse(txtB.Text);
                c = double.Parse(txtC.Text);
                GiaiPhuongTrinh x = new GiaiPhuongTrinh(a, b, c);
                kq = x.PhuongTrinhBacHai();
                txt_KQ.Text = "Phuong trình có nghiệm \t" + kq;

            }
        }

        private void btn_x_Click(object sender, EventArgs e)
        {
            txtA.Text = "";
            txtC.Text = "";
            txtB.Text = "";
            txt_KQ.Text = "";
        }
    }
}
