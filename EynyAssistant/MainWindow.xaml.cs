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
using System.Threading;
using EynyAssistant.Model;

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
            driver.FindElement(By.Name("submit")).Click();
            driver.FindElement(By.ClassName("nxt")).Click();
            while (true)
            {
                int endCheckTime = 10;
                while (endCheckTime > 0)
                {
                    try
                    {
                        //撈資料
                        GetSinglePageTableTbody(driver);

                        var nxt = driver.FindElements(By.ClassName("nxt"));
                        if (nxt.Count > 0)
                        {
                            nxt[0].Click();
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"未發現元素，重試次數{endCheckTime}");
                        break;
                    }
                    Thread.Sleep(50);
                    endCheckTime--;
                }
                Thread.Sleep(200);
            }
        }

        private void GetSinglePageTableTbody(IWebDriver driver)
        {
            var table = driver.FindElement(By.Id("forum_3691"));
            var tbodys = table.FindElements(By.TagName("tbody"));
            foreach(var tbody in tbodys)
            {
                string id = tbody.GetAttribute("id");
                var commmon = tbody.FindElements(By.ClassName("common"));
                //排除分隔線和公告
                if(id != "separatorline" && commmon.Count == 0)
                {
                    var imageUrl = tbody.FindElement(By.ClassName("p_pre_td")).FindElement(By.ClassName("p_pre")).GetAttribute("src");
                    var title = tbody.FindElement(By.ClassName("new")).FindElement(By.ClassName("xst")).Text;
                    var url = tbody.FindElement(By.ClassName("new")).FindElement(By.ClassName("xst")).GetAttribute("href");
                    var postTime = tbody.FindElements(By.ClassName("by"))[0].FindElement(By.TagName("span")).Text;
                    var replyTime = tbody.FindElements(By.ClassName("by"))[1].FindElement(By.TagName("span")).GetAttribute("title");
                    Post post = new Post
                    {
                        ImageUrl = imageUrl,
                        Title = title,
                        Url = url,
                        PostTime = Convert.ToDateTime(postTime),
                        ReplyTime = Convert.ToDateTime(replyTime)
                    };

                }
            }
        }
    }
}
