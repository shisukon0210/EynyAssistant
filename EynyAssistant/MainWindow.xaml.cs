using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using AngleSharp;
using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EynyAssistant
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        async void ParseEynyHtml(object sender, RoutedEventArgs e)
        {
            string chromeDriverPath = @"C:\Users\hhcor\OneDrive\桌面";
            IWebDriver driver = new ChromeDriver(chromeDriverPath);
            driver.Navigate().GoToUrl("https://www.eyny.com/forum-3691-1.html");
            driver.Quit();
        }
    }
}
