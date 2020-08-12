//-----------------------------------------------------------------------
// <copyright file="Utility.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using Myntra.CustomException;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace Myntra.Utils
{
    /// <summary>
    /// To store all required functionality 
    /// </summary>
    public class Utility
    {

        public enum Browser
        {
            FIREFOX, CHROME
        }
        /// <summary>
        /// To take screenshot after every test
        /// </summary>
        /// <param name="driver">to control browser</param>
        /// <param name="testStatus">failed or passed test</param>
        /// <returns></returns>
        public static string TakeScreenshot(IWebDriver driver, string testStatus)
        {
            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string finalPath = path.Substring(0, path.LastIndexOf("bin")) + "Screenshots\\" + testStatus + ".png";
                string localPath = new Uri(finalPath).LocalPath;
                screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
                return localPath;
            }
            catch (Exception)
            {
                throw new Exceptions("Screenshot error", Exceptions.ExceptionType.SCRRENSHOT_NOT_CAPTURED);
            }
        }
            /// <summary>
            /// To send report 
            /// </summary>
            public static void SendEmail()
            {
            try
            {
                MailMessage mail = new MailMessage();
                string fromEmail = ConfigurationManager.AppSettings["email"]; ;
                string password = ConfigurationManager.AppSettings["password"]; ;
                string ToEmail = "sidthakur258@gmail.com";
                mail.From = new MailAddress(fromEmail);
                mail.Subject = "Please check the attached report";
                mail.To.Add(ToEmail);
                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment(@"C:\Users\Shivani\source\repos\Myntra\Myntra\ExtentReport\index.html"));
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromEmail, password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception)
            {
                throw new Exceptions("Email error", Exceptions.ExceptionType.EMAIL_NOT_SEND);
            }
        }


        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        //Creating a function that uses the API function...  
        public static bool IsConnectedToInternet()
        {
            try
            {
                int Desc;
                return InternetGetConnectedState(out Desc, 0);
            }
            catch (Exception)
            {
                throw new Exceptions("Internet error", Exceptions.ExceptionType.NO_INTERNET);
            }
        }
    }
}
