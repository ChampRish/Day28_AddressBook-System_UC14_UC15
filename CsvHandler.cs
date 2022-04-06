using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day28_Address_Book_from_CSV_and_JSON
{
    public class CsvHandler
    {
        public static void ImplementCSVDataHandler()
        {
            string importFilePath = @"E:\c# git push\Day28_Address-Book-from-CSV-and-JSON\Day28_Address-Book-from-CSV-and-JSON\CSV Files\Address.CSV";
            string exportFilePath = @"E:\c# git push\Day28_Address-Book-from-CSV-and-JSON\Day28_Address-Book-from-CSV-and-JSON\CSV Files\Export.CSV";
            string exportJsonFilePath = @"E:\c# git push\Day28_Address-Book-from-CSV-and-JSON\Day28_Address-Book-from-CSV-and-JSON\ExportJson.json";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<UC1AddressData>().ToList();
                Console.WriteLine("Read data successfully from Address.CSV");
                foreach (UC1AddressData addressdata in records)
                {
                    Console.WriteLine(addressdata.firstname);
                    Console.WriteLine(addressdata.lastname);
                    Console.WriteLine(addressdata.address);
                    Console.WriteLine(addressdata.city);
                    Console.WriteLine(addressdata.state);
                    Console.WriteLine(addressdata.code);
                    Console.WriteLine(addressdata.phonenumber);
                    Console.WriteLine(addressdata.email);
                }
                Console.WriteLine("********************************************");
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                    Console.WriteLine("Export Successfully CSv file");
                }
                Console.WriteLine("**********************************************");
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportJsonFilePath))
                using (JsonTextWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
            }
        }
    }
}
