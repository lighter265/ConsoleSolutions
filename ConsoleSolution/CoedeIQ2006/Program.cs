using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

[DataContract]
class JsonData
{
    [DataMember]
    public int a;
}

class CodeIQ2006
{
    static readonly string warp = 
        @"{ 98: 91,
            97: 93,
            96: 94,
            84: 73,
            75: 61,
            67: 56,
            53: 48,
            3: 8,
            13: 19,
            21: 32,
            33: 46,
            42: 58,
            51: 70,
            68: 89 }";

    static void Main()
    {

        var serializer = new DataContractJsonSerializer(typeof(JsonData));
        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        {
            var data = (JsonData)serializer.ReadObject(ms);
            Console.WriteLine(data.a);
        }
        Console.ReadKey();
    }
}