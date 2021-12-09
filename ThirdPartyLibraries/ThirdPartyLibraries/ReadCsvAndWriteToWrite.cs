using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Newtonsoft.Json;

namespace ThirdPartyLibraries
{
    class ReadCsvAndWriteToWrite
    {
        public static void ImplementCSVToJsonHandler()
        {
            string ImportFilepath = @"C:\Users\admin\Desktop\github\ThirdPartyLibraries\ThirdPartyLibraries\Files\JSonData.csv";
            string ExportFilepath = @"C:\Users\admin\Desktop\github\ThirdPartyLibraries\ThirdPartyLibraries\Files\Export.Json";
            using (var reader = new StreamReader(ImportFilepath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddresssData>().ToList();
                Console.WriteLine("read data successfully from address.csv");
                foreach (AddresssData address in records)
                {
                    Console.WriteLine("\t" + address.firstname + "\t" + address.lastname + "\t" + address.address + "\t" + address.city + "\t" + address.state + "\t" + address.code);
                    Console.WriteLine("\n");
                }
                Console.WriteLine("***********Now reading from csv file and write to csv file**********");
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sr = new StreamWriter(ExportFilepath))
                using (JsonWriter writer = new JsonTextWriter(sr))
                {
                    serializer.Serialize(writer, records);
                }
            }
        }
    }
}
