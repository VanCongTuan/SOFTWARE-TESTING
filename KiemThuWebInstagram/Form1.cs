using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using KTPMWEB;



namespace KTPMWEB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IWebDriver driver; 
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {                  
                LoginInstagram loginPage = new LoginInstagram(driver);
                loginPage.OpenWeb();
                loginPage.OpenInstagram();
                loginPage.User("vancongtuan1232");
                loginPage.Password("vancongtuan1907");
                loginPage.loginTk(); 
                
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Không tìm thấy phần tử.");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                UploadImage image = new UploadImage(driver);
                image.OpenWeb();
                image.OpenInstagram();
                image.User("vancongtuan1232");
                image.Password("vancongtuan1907");
                image.loginTk();
                image.home();
                image.Create();
                image.UploadFile("C:\\Users\\TUAN\\OneDrive\\Hình ảnh\\Lobita\\z4978588598366_077e7d3650bb13581b30938f56f30aa1.jpg");
                image.Next();               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }
    }
}
