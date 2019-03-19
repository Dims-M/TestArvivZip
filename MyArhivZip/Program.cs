using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyArhivZip
{
    class Program
    {


        //Загрузка выгрузка в нужныное место
        //Создание папок загрузки выргузки
        //Создание лога событий
        //Сделать скрытым папку выгрузки
        //Сделать архив скрытым.
        // отправка архива на фтп 


        // http://www.cyberforum.ru/csharp-beginners/thread92858.html

        ////скрытый отримбцты
        //System.IO.File.SetAttributes(@"H:\test.txt", System.IO.FileAttributes.Hidden);

        ////только для чтения
        //System.IO.File.SetAttributes(@"H:\test.txt", System.IO.FileAttributes.ReadOnly);

        ////системный
        //System.IO.File.SetAttributes(@"H:\test.txt", System.IO.FileAttributes.System);


        //File.SetAttributes("download.exe", FileAttributes.Normal);
        //File.Delete("download.exe");



        static void Main(string[] args)
        {
            Work_FTP work_FTP = new Work_FTP();

            // MinuVibora(); //Запуск меню выбора

            //Тестовой запуск отправки фтп

            // ZipFilesByMask.ArhivPathFail(@"C:\BETRADE2\btrade.db3", @"C:\BETRADE2\");
            //work_FTP.Upload(); 
            work_FTP.arvihBD();
            //work_FTP.arvihBD();  //Выбивает ошибку
            Console.ReadKey();
          
        }


   
        static void Stopee()
        {
            Console.ReadKey();
        }


      /// <summary>
      /// Меню выбора режима работы архиватора
      /// </summary>
       static public void MinuVibora()
        {
            Console.WriteLine($"Здраствуйте. \n\t");
            Console.WriteLine($"Выбирите нужое дествие: \n\t" +
                "1) Если вы хотите архивировать обьект Введите 1 \n\t"+
                "2)Если вы хотите разоархивировать обьект Введите 2 \n\t" +
                "0) Выход из программы");

            try
            {

                //Ждем выбора режима от пользователя
                while (true)
         {

            var vibor = byte.Parse( Console.ReadLine());

                if (vibor == 1)
                {
                    ZipFilesByMask.Checet();
                    Console.WriteLine("Архив создан");
                        break;
                }

                if (vibor == 2)
                {
                    ZipFilesByMask.RaspakovkaArhiva();
                    
                        break;
                    }

                if (vibor == 0)
                {
                  
                    Console.WriteLine("Выход из прораммы");
                        break;
                    }

                else
                {
                    Console.WriteLine("ВВедено не коректное значение...Проверте правильность ввода");
                }

            }

            }

            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка.Что то пошло не так ))))\t\n {ex}\t\n");
            }

            Console.ReadKey();

        }

        /// <summary>
        /// запуск программы от имени дмина. не раб
        /// </summary>
        static void NameAdmin()
        {

            WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);

            if (hasAdministrativeRight == false)
            {
                ProcessStartInfo processInfo = new ProcessStartInfo(); //создаем новый процесс
                processInfo.Verb = "runas"; //в данном случае указываем, что процесс должен быть запущен с правами администратора
                processInfo.FileName = "MinuVibora";   //указываем исполняемый файл (программу) для запуска

                try
                {
                    Process.Start(processInfo); //пытаемся запустить процесс
                }
                catch (Win32Exception)
                {
                    //Ничего не делаем, потому что пользователь, возможно, нажал кнопку "Нет" в ответ на вопрос о запуске программы в окне предупреждения UAC (для Windows 7)
                }
               // Application.Exit(); //закрываем текущую копию программы (в любом случае, даже если пользователь отменил запуск с правами администратора в окне UAC)
            }
            else //имеем права администратора, значит, стартуем
            {
                MinuVibora();
            }
        }


    }
}
