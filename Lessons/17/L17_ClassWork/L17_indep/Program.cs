using System;
using System.IO;
using System.IO.Compression;

namespace L17_indep
{
    class Program
    {
        static void Main(string[] args)
        {
            const string binaryFileName = "random_data.bin";
            const int totalNumberOfBytes = 1000;
            const int packSize = 170;

            var generator = new RandomDataGenerator();

            generator.RandomDataGenerated += (bytesDone, totalBytes) =>
            {
                Console.WriteLine($"Generated {bytesDone} of {totalBytes} bytes...");
            };

            generator.RandomDataGenerationDone += (sender, eventArgs) =>
            {
                Console.WriteLine("Work done.");
            };

            byte[] data = generator.GetRandomData(totalNumberOfBytes, packSize);
            Console.WriteLine(Convert.ToBase64String(data));

            //Write to file
            if (File.Exists(binaryFileName))
                File.Delete(binaryFileName);

            File.WriteAllBytes(binaryFileName, data);

            //Write to Zip
            var zipFileName = binaryFileName.Remove(binaryFileName.LastIndexOf('.')) + ".zip";
            if (File.Exists(zipFileName))
                File.Delete(zipFileName);
            using ZipArchive archive = ZipFile.Open(zipFileName, ZipArchiveMode.Create);

            archive.CreateEntryFromFile(binaryFileName, binaryFileName);
        }
    }
}
