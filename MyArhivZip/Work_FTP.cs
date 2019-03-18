using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyArhivZip
{
    /// <summary>
    /// Методы чтения записи текстовых файлов. Отправка текс файлов на фтп
    /// </summary>
    public class Work_FTP
    {
        // обьект локер - Семофор для потоков. Блокирует достут множества потоков одновременно
        public static object loker = new object(); // обьект синхронизаций

        /// <summary>
        /// метод для заsрузки c указанием параметров
        /// </summary>
        /// <param name="Adress">Адресс имя фтп</param>
        /// <param name="filePath">Путь к нужному файлу для отправки</param>
        /// <param name="user">Имя пользователя от фтп</param>
        /// <param name="pass">Пароль от фтп</param>
        void UploadFile(string Adress, string filePath, string user, string pass)
        {

            try
            {
                // создание обьекта для запроса к фтп. С указанием адреса и пути к нужному файлу
                FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(Adress + "/" + Path.GetFileName(filePath));

                // выбор нужного метода(загрузка или отправка)
                req.Method = WebRequestMethods.Ftp.UploadFile;

                // обьект для работы с Фтп. В качестве параметров указываем пользователя и пароль фтп
                req.Credentials = new NetworkCredential(user, pass);

                //клиент должен инициировать подключение по порту данных. Значение по умолчанию
                req.UsePassive = true;

                // какой тип передачи данных
                req.UseBinary = true;

                // зарыть соединение после запроса
                req.KeepAlive = false;

                // создаем поток для работы с данными + передаем файл в поток
                Stream stream = File.OpenRead(filePath);

                // массив байтов c длинной потока
                byte[] buffer = new byte[stream.Length];

                // считования потока, офсет, длина массива
                stream.Read(buffer, 0, buffer.Length);

                // закрытия потока
                stream.Close();

                // поток для выгрузки на фтп
                Stream regstr = req.GetRequestStream();

                //запись в поток массива байтов
                regstr.Write(buffer, 0, buffer.Length);

                regstr.Close();

                string tempMessage = "файл ушел на фтп";
                // MessageBox.Show(tempMessage);
                Console.WriteLine(tempMessage);


            }
            catch (Exception ex)
            {
                //MessageBox.Show("Что то пошло не так " + ex);
                Console.WriteLine("Что то пошло не так " + ex);
                string tempErrorLog = $"Произошла ошибка" + ex;

            }
        }

        // метод загрузки Тестовой 
        /// <summary>
        /// Отправка файла на фтп
        /// </summary>
        public void Upload()
        {
            // запись пользователя винды
            string user = Environment.UserName;
            // запуск метода загрузки на фтп с параметрами. 
            //  UploadFile(textBox1.Text, "/C:/1.txt","etesftpmail","D51215045");
            // юкоз
            UploadFile(@"ftp://tesftpmail.ucoz.net", @"C:\adb\test.txt", @"etesftpmail", @"D51215045");
            // beget.com
            //  UploadFile(@"ftp://b91790o4.beget.tech", textBox3.Text.ToString() , @"b91790o4", @"YhvvI89Y");
        }


        //метод выбора пути
        /// <summary>
        /// Метод выбора нужного файла. В консоле не работет. 
        /// </summary>
        void GetPath()
        {
            // создание обьекта для работы выбора нужного файла
            //  OpenFileDialog ofd = new OpenFileDialog();
            // маска выбора типа файлов
            //    ofd.Filter = " Выбрать все (*.*)|*.*|" + "(*.*) |*.*";
            //    ofd.Title = "Выберете необходимый файл";
            //    //  выбор начальной папки для запуска OpenFileDialog  метод StartupPath получает имя файла зупустившего этот метод 
            //    ofd.InitialDirectory = System.Windows.Forms.Application.StartupPath;

            //    try
            //    {
            //        // если нажата кнопка ОК
            //        if (ofd.ShowDialog() == DialogResult.OK)
            //        {
            //            StreamReader sr = new StreamReader(ofd.FileName);

            //            textBox3.Text = getFileName(sr);
            //        }

            //    }

            //    catch (Exception ex)
            //    {
            //        string tempErrorLogg = "Ошибка в методе выбора пути /r/n" + ex;
            //        MessageBox.Show(tempErrorLogg);
            //        label1.Text = tempErrorLogg;

            //    }

            //}

        }

        /// <summary>
        /// Запись файла с указанием пути нахождения файла
        /// </summary>
        /// <param name=" patch">Путь к файлу.</param>
        public static void ZapisFailaPatch(string patch, string text)
        {
            Console.WriteLine("Тестовой вывод");

            DateTime now = DateTime.Now; // получение тек времени
            string tempDateTime = now.ToString();

            Console.WriteLine($"Тестовой вывод \t\n{tempDateTime}\t\n{text}");

            using (var sw = new StreamWriter(patch, true, System.Text.Encoding.Default)) // создание обьект потока для записи файла
            {
                // sw.Write("\t\n");
                sw.Write($"{tempDateTime}" + "\t\n");
                sw.Write(text);
                sw.Write("\t\n");
                Console.WriteLine("Записанно в файл"); //проверочный вывод
            }
            // Console.WriteLine("Записанно в файл"); //проверочный вывод
            Console.ReadKey(true);

        }

        /// <summary>
        /// Запись в файл рядом с exe и передачей текста в метод
        /// </summary>
        /// <param name="text">Текст что нужно записать в лог по умолчанию</param>
        public static void ZapisFailaText(string text)
        {
            DateTime now = DateTime.Now; // получение тек времени
            string tempDateTime = now.ToString();
            using (var sw = new StreamWriter("Log.txt", true, Encoding.Default)) // создание обьект потока для записи файла
            {
                //System.Text.Encoding.Default
                // sw.Write("\t\n");
                sw.Write($"{tempDateTime}" + "\t\n");
                sw.Write(text);
                sw.Write("\t\n");
            }
        }


        /// <summary>
        /// рандомнон заполнение текстого файла набором цифр
        /// </summary>
        public static void RandomZapisFailaInt()
        {
            lock (loker)
            {

                DateTime now = DateTime.Now; // получение тек времени
                string text = $"Содержимое файла: \t\nДобавлено:{now} ";
                Random random = new Random();

                for (int i = 0; i < 1000; i++)
                {
                    text += random.Next(10000);
                    text += "\t\n";
                }

                ZapisFailaText(text);

            } // обьект локер - Семофор для потоков. Блокирует достут множества потоков одновременно

            Console.WriteLine("Работа цикла по заполнению значениями закончена");
        }


        /// <summary>
        /// Чтене файла(лога) по умолчанию
        /// </summary>
        public static void ChteniefailaLoga()
        {
            string tempLog = "Log.txt";
            string tempText = "Содержимое файла \t\n";

            using (var sr = new StreamReader(tempLog, System.Text.Encoding.Default)) // обьект для чтение потока при чтении файла с жестого диска  
            {
                // var text = sr.ReadLine().ToString();           
                tempText += sr.ReadToEnd().ToString();
            }
            Console.WriteLine(tempText);
            Console.ReadKey(true);
        }

        /// <summary>
        /// чтение файла с указанием пути.
        /// </summary>
        /// <param name="Path"></param>
        public static void ChteniefailaFailaPath(string Path)
        {
            string tempLog = "Log.txt";
            string tempText = "Содержимое файла \t\n";

            using (var sr = new StreamReader(tempLog, Encoding.Unicode)) // обьект для чтение потока при чтении файла с жестого диска  
            {
                //Encoding.Default
                // var text = sr.ReadLine().ToString();  // чтение построчно      
                tempText += sr.ReadToEnd().ToString(); // чтение файла полностью
            }
            Console.WriteLine(tempText); //проверочный вывод
            Console.ReadKey(true);
        }

    }
}
