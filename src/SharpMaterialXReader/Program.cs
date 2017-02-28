using System;

using SharpMaterialX.Serialization;

namespace SharpMaterialXReader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx require=\"\">\r\n" +
                "</materialx>";

            var result = FileSerializer.Deserialize("test-material.mtlx");

            Console.WriteLine($"Deserialization was {(result.IsSuccessful ? "Successful" : "Not Successful")}");
            Console.ReadLine();
        }
    }
}
