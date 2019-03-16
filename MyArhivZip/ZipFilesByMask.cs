using ComponentAce.Compression.Archiver;
using ComponentAce.Compression.ZipForge;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArhivZip
{
   public static class ZipFilesByMask
    {

        private static string pathArhivHille = @"c:\1\HiddenFolder";
        private static string pathArhiv = @"c:\1";

        /// <summary>
        /// запуск архивирования
        /// </summary>
        public static void Checet()
        {
            // Create an instance of the ZipForge class
            ZipForge archiver = new ZipForge();

            try
            {
                archiver.FileName = @"C:\test.zip"; //Куда сохранить файл результата сжатия
                archiver.OpenArchive(System.IO.FileMode.Create); //Настраиваем дллку на работу с новым архивом
                archiver.BaseDir = @"C:\123"; //Папка где лежат все файлы для взятия
               // archiver.AddFiles("*.exe"); //Берём все файлы с расширением exe
               // archiver.AddFiles("*.dll");
                //archiver.AddFiles("*.jpg");
                archiver.AddFiles("*.*");

                // archiver.BaseDir = @"D:\";
                // archiver.AddFiles(@"d:\file.txt"); //Добавим один файл
                // archiver.AddFiles(@"d:\Test"); //Запакуем ещё и папку
                archiver.CloseArchive(); //Закрываем архив
            }
            //Ловим ошибки
            catch (ArchiverException ae)
            {
                Console.WriteLine("Message: {0}\t Произошла ошибка: {1}",
                                  ae.Message, ae.ErrorCode);
                Console.ReadLine();
            }
            Console.WriteLine("Процес архивирования завершен....\t\n");
        }

        /// <summary>
        /// Распаковка архива
        /// </summary>
        public static void RaspakovkaArhiva()
        {
            ZipForge archiver = new ZipForge();
            NoVisiblePapka();
            try
            {
                archiver.FileName = @"C:\test.zip"; //Необходимый файл
                archiver.OpenArchive(System.IO.FileMode.Open); //Указываем что хотим сделать
               // archiver.BaseDir = pathArhiv; //Папка куда распаковать
                archiver.BaseDir = pathArhivHille; //Папка куда распаковать
                //archiver.BaseDir = @"C:\1"; //Папка куда распаковать
                // archiver.ExtractFiles("*.exe"); //Распаковываем *.exe
                // archiver.ExtractFiles("*.dll"); //Распаковываем *.dll
                archiver.ExtractFiles("*.*");

                //archiver.BaseDir = @"D:\";
               // archiver.ExtractFiles("*.txt"); //Распаковываем *.txt но можем и просто файл
                archiver.ExtractFiles("test"); //Распаковываем папку
                archiver.CloseArchive();

                Console.WriteLine("Архив разохвивирован");
            }
            // Catch all exceptions of the ArchiverException type
            catch (ArchiverException ae)
            {
                Console.WriteLine("Message: {0}\t Ошибка при архивации: {1}", ae.Message, ae.ErrorCode);
                Console.ReadLine();
            }
        }


        public static void NoVisiblePapka()
        {
            // string path = @"c:\1\HiddenFolder"; // путь где будет находится наша папка
             string path = pathArhivHille; // путь где будет находится наша папка

            //Проверка. Если данный путь существует. Если нет то создается
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden; //создание скрытой папка
            }
        }

    }

}


    



