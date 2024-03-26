using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // подключение потоков
using static System.Console;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            // STREAM - базовый класс

            // 1
            // байтовый класс потоков - FileStream (класс-наследние от 'Srtream')
            // предназначен для работы с различными потоками байт (чтение, запись, открытие, закрытие файла)
            // доступ на уровне байт, позволяет работать с бинарными и текстовыми файлами
            // при работе с текстовыми файлами прийдется использовать специальное преобразование потока
            // текстового файла (потока 'char') из байта в строки и обратно

            // 1.1
            // FileMode - как открывается наш файл (create, append, create_new, open, open_or_creat)
            // create - новый файл, если с таким именем уже есть - перезаписывается
            // open - открыть существующий файл, если его нет - искл-ие (try, catch)
            // openOncreate - если файл есть - откроется, если нет - создан
            // createNew - создан, если новый, если сущ-ет - искл-ие
            // truncate - открывает сущ-ий файл и усекает его размер до 0 (перезапись)

            // 1.2
            // FileAccess - режим доступа к файлу, задается через перечисления (Write, Read, read_and_write)

            // 1.3
            // FileShare -  совместимость (будет ли он доступен кому-то другому из вне) read, delete, read_write, write


            // 2
            // символьный класс потоков StreamReader, StreamWriter


            // 3
            // двоичный класс потоков BinaryReader, BinaryWriter (бинарные потоки строго типизированы)
            // в каком типе данных были записаны, в таком типе данных мы их и считываем


            /////////////////////////////////////////////////////////1//////////////////////////////////////////////////
            ///// вдруг изначально у нас файл байтовый 

            // Получаем путь к файлу
            //Console.WriteLine("Введите путь к файлу:");
            //string filePath = "prim.txt";

            //// 1) путь к файлу, 2) для чего мы создаем файл, 3) для чего открыли, 4) доступен ли он другим обьектам
            //using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            //{
            //    //Получаем данные для записи в файл
            //    Console.WriteLine("Введите строку для записи в файл:");
            //    string writeText = Console.ReadLine();

            //    // 1 записываем в файл

            //    // так как 'FileStream' работает с байтами - создаем массив байт
            //    byte[] writeBytes = Encoding.UTF8.GetBytes(writeText); // преобразовываем строку в байты (0,1)


            //    fs.Write(writeBytes, 0, writeBytes.Length); 
            //    // 1) массив 2) сдвиг (с какой позиции начинаем) 3) кол-во символов

            //    fs.Flush(); 
            //    // желательно вып-ть после записи - освобождение буфера потока - закрытие (чтобы файл мог быть доступен другим обьектам)

            //    fs.Seek(0, SeekOrigin.Begin); // 'Seek' - откуда читать и сколько ('SeekOrigin.Begin' - до конца) // узнаем размер

            //    // 2 считываем обратно
            //    byte[] readBytes = new byte[(int)fs.Length]; // создаем массив по размеру нашего потока для чтения

            //    fs.Read(readBytes, 0, readBytes.Length);

            //    // преобразовываем обратно в 'string'
            //    string readText = Encoding.UTF8.GetString(readBytes);

            //    Console.WriteLine("Данные, прочитанные из файла: {0}", readText);
            //}

            // конструкция 'using' проверяет при создании потоков - если он не null - тогда работаем, также заменяет 'Open' и 'Close'
            // using () {} поверяет, создан ли поток, открывает его для работы и закрывает 

            /////////////////////////////////////////////////////////2//////////////////////////////////////////////////

            //string filePath = "prim_2.txt";

            // 2.1 // без исп-ия 'using'
            // создаем поток
            //FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite); 

            ////// запись
            ////// создаем поток 'StreamWriter'
            ////// 1) наш файл, 2) его кодировка
            //StreamWriter sw = new StreamWriter(fs, Encoding.UTF8); 

            //Console.WriteLine("Введите строку для записи в файл:");
            //string writeText = Console.ReadLine(); 

            ////// записали текст
            //sw.Write(writeText); 

            ////// освобождение всех ресурсов
            //sw.Dispose();

            //// читаем данные в строку из нашего файла
            //StreamReader sr = new StreamReader(filePath, Encoding.UTF8);
            //string readText = sr.ReadToEnd();

            //sr.Dispose();

            //Console.WriteLine("Данные, прочитанные из файла: {0}", readText);

            // 2.2 // с исп-ием 'using'

            // using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            //{
            //    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
            //    {
            //        Console.WriteLine("Введите строку для записи в файл:");
            //        string writeText = Console.ReadLine();

            //        // записали текст
            //        sw.Write(writeText);

            //        // освобождение всех ресурсов
            //        sw.Dispose();
            //    }
            //    // считывание
            //    // создаем поток 'StreamReader'
            //    using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            //    {
            //        string readText = sr.ReadToEnd();

            //        sr.Dispose();

            //        Console.WriteLine("Данные, прочитанные из файла: {0}", readText);
            //    }

            //}

            // 'using' не напишет ошибку, а отработает ее корректно
            // конструкция 'using' заменяет: 
            //try
            //{
            //    if (st != null)
            //        Task();
            //    delete st;
            //}
            //catch (Exception)
            //{
            //    throw;
            //}

            /////////////////////////////////////////////////////////3//////////////////////////////////////////////////

            string filePath = "prim_3.dat"; 

            // создаем поток
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            { 
                BinaryWriter bw = new BinaryWriter(fs); 

                // для записи
                Console.WriteLine("Введите строку для записи в файл:"); 
                string writeText = Console.ReadLine();

                int writeNum;

                // пока пользователь не введет число
                while (true) 
                { 
                    try 
                    { 
                        Console.WriteLine("Введите целое число для записи в файл:"); 
                        writeNum = Convert.ToInt32(Console.ReadLine());
                        break; 
                    } 
                    catch 
                    { 
                        Console.WriteLine("Ошибка! Не удалось преобразовать строку в целое число!");
                    } 
                }

                bw.Write(writeText); // записываем строку
                bw.Write(writeNum); // записываем число

                bw.Flush();

                // для чтения
                fs.Seek(0, SeekOrigin.Begin); // ставим 'seek' на начало

                // чтение
                BinaryReader br = new BinaryReader(fs); 

                Console.WriteLine("Строка, прочитанная из файла:");
                Console.WriteLine(br.ReadString()); // читаем строку
                Console.WriteLine("Целое число, прочитанное из файла:");
                Console.WriteLine(br.ReadInt32()); // читаем число
            }
        }
    }
}

