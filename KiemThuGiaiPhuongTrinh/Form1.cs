using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;


namespace VanCongTuan_KTPM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            add_Click();
            list = new List<string>();
        }


        List<Button> buttons;
        List<string> list;
        private void add_Click()
        {
            buttons = new List<Button>() { btn_0, btn_1, btn_2, btn_3, btn_4, btn_5, btn_6, btn_7, btn_8, btn_9,btn_ThapPhan };
            foreach (var item in buttons)
            {
                item.Click += new EventHandler(button_Click);
            }
           

        }
        private void button_Click(object sender, EventArgs e)
        {
            
            string txtbutton = (sender as Button).Text;
            txt_KetQua.Text += txtbutton;


        }
        private void enableButton()
        {
            btn_Cong.Enabled = true;
            btn_Tru.Enabled = true;
            btn_ChiaDu.Enabled = true;
            btn_Nhan.Enabled = true;
            btn_ChiaNguyen.Enabled = true;
            btn_Mu.Enabled = true;
            btn_ThapPhan.Enabled = true;
        }
        private void disenableButton()
        {
            btn_Cong.Enabled = false;
            btn_Tru.Enabled = false;
            btn_ChiaDu.Enabled = false;
            btn_Nhan.Enabled = false;
            btn_ChiaNguyen.Enabled = false;
            btn_Mu.Enabled = false;

        }
        public void sum()
        {
            if (list.Contains("+"))
            {
                list.Remove("+");
                double tong = Convert.ToDouble(list[0]) + Convert.ToDouble(list[1]);
                txt_KetQua.Text = tong.ToString();
               
                
            }
        }

        private void sub()
        {
            if (list.Contains("-"))
            {
                list.Remove("-");
                double tru = Convert.ToDouble(list[0]) - Convert.ToDouble(list[1]);
                txt_KetQua.Text = tru.ToString();
            }
        }

        private void div()
        {
            if (list.Contains("/"))
            {
                list.Remove("/");
                if (list[1] == "0")
                {

                    txt_KetQua.Text = "ERROR";
                    list.Clear();
                } 
                
                else 
                    {
                    double chia = Convert.ToDouble(list[0]) / Convert.ToDouble(list[1]);
                    txt_KetQua.Text = chia.ToString();
                }
                
               
            }
        }

        private void mul()
        {
            if (list.Contains("x"))
            {
                list.Remove("x");
                double nhan = Convert.ToDouble(list[0]) * Convert.ToDouble(list[1]);
                txt_KetQua.Text = nhan.ToString();
            }
        }
        private void mod()
        {
            if (list.Contains("%"))
            {
                list.Remove("%");
                if (list[1] == "0")
                {

                    txt_KetQua.Text = "ERROR";
                    list.Clear();

                }

                else
                {
                    double chia = Convert.ToDouble(list[0]) % Convert.ToDouble(list[1]);
                    txt_KetQua.Text = chia.ToString();
                }
                
                
            }
        }
        private void pow()
        {
            if (list.Contains("^"))
            {
                list.Remove("^");
                double mu =Math.Pow(Convert.ToDouble(list[0]), Convert.ToDouble(list[1]));
                txt_KetQua.Text = mu.ToString();
            }
        }
        private void btn_Cong_Click(object sender, EventArgs e)
        {
            if (txt_KetQua.Text != "")
            {
                list.Add(txt_KetQua.Text);
                list.Add(btn_Cong.Text);
                txt_KetQua.Text = "";
                disenableButton();
            }
        }

        private void btn_Tru_Click(object sender, EventArgs e)
        {
            if (txt_KetQua.Text != "")
            {
                list.Add(txt_KetQua.Text);
                list.Add(btn_Tru.Text);
                txt_KetQua.Text = "";
                disenableButton();
            }
        }

        private void btn_Nhan_Click(object sender, EventArgs e)
        {
            if (txt_KetQua.Text != "")
            {
                list.Add(txt_KetQua.Text);
                list.Add(btn_Nhan.Text);
                txt_KetQua.Text = "";
                disenableButton();
            }
        }

        private void btn_ChiaNguyen_Click(object sender, EventArgs e)
        {
            if (txt_KetQua.Text != "")
            {
                list.Add(txt_KetQua.Text);
                list.Add(btn_ChiaNguyen.Text);
                txt_KetQua.Text = "";
                disenableButton();
            }
        }

        private void btn_Bang_Click(object sender, EventArgs e)
        {
            if (txt_KetQua.Text != "")
            {
                list.Add(txt_KetQua.Text);
                sum();
                sub();
                div();
                mul();
                pow();
                mod();
                list.Clear();
                
                enableButton();
            }
        }

        private void btn_ChiaDu_Click(object sender, EventArgs e)
        {
            if (txt_KetQua.Text != "")
            {
                list.Add(txt_KetQua.Text);
                list.Add(btn_ChiaDu.Text);
                txt_KetQua.Text = "";
                disenableButton();
            }
        }

        private void btn_AC_Click(object sender, EventArgs e)
        {
            list.Clear();
            txt_KetQua.Text = "";
            enableButton();
        }

        private void btn_DEL_Click(object sender, EventArgs e)
        {
          
           
            if (txt_KetQua.Text != "")
            {

                list.Add(txt_KetQua.Text);
                char[] charArray = list[0].ToCharArray();
                btn_AC_Click(sender, e);
                for (int i=0;i < charArray.Length - 1; i++)
                {
                    txt_KetQua.Text += charArray[i].ToString() ;
                }
                
                
            }
           

        }

        private void btn_Mu_Click(object sender, EventArgs e)
        {
            if (txt_KetQua.Text != "")
            {
                list.Add(txt_KetQua.Text);
                list.Add(btn_Mu.Text);
                txt_KetQua.Text = "";
                disenableButton();
            }
        }
    }
}
