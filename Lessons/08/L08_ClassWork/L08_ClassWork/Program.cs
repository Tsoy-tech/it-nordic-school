using System;
using System.IO;
using System.Text;


namespace L08_ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = @"C:\text.txt"; //путь
            const string content = "Never mind 2";

            //Запись

            //MemoryStream ms = new MemoryStream();

            //FileStream stream = File.Create(fileName, 4096); //файловый поток

            //FileStream stream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);//For Creating


            //byte[] bytesOfContent = Encoding.ASCII.GetBytes(content);

            //stream.Seek(0, SeekOrigin.End); //переход в конец


            /*stream.WriteByte(13);
            stream.WriteByte(10);

            stream.Write(bytesOfContent);


            stream.Flush(); //Принудительное очищение буфера и добавление на диск
            stream.Close();*/

            //Чтение

            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);//For reading
            
            const int readBufferSize = 5; //размер буфера
            byte[] bytesOfContent = new byte[readBufferSize]; //солание буфера

            int bytesRead;
            string result = string.Empty;

            do
            {
                bytesRead = stream.Read(bytesOfContent, 0, readBufferSize);
                result += Encoding.ASCII.GetString(bytesOfContent, 0, bytesRead);

            } while (bytesRead > 0);

            stream.Close();
            Console.WriteLine(result);
        }
    }
}
