using System;

namespace NetJSONExample
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Load data */
            App_Code.CDB OCDB = new App_Code.CDB();
            /* Load Methods */
            App_Code.CJSONMethods OCJSONMethods = new App_Code.CJSONMethods();

            /* Display title message */
            Console.WriteLine("*** Convert DataTable to JSON string ***");
            
            Console.Write("\n");

            /* Load and Display Method 1 */
            Console.WriteLine("Method 1: String Builder");
            Console.Write("\n");
            string Method1 = OCJSONMethods.DataTableToJSONWithStringBuilder(OCDB.getData());
            Console.WriteLine("{0}", Method1);

            Console.Write("\n\n");

            /* Load and Display Method 2 */
            Console.WriteLine("Method 2: JavaScript Serializer");
            Console.Write("\n");
            string Method2 = OCJSONMethods.DataTableToJSONWithJavaScriptSerializer(OCDB.getData());
            Console.WriteLine("{0}", Method2);

            Console.Write("\n\n");

            /* Load and Display Method 3 */
            Console.WriteLine("Method 3: JSON Net");
            Console.Write("\n");
            string Method3 = OCJSONMethods.DataTableToJSONWithJSONNet(OCDB.getData());
            Console.WriteLine("{0}", Method3);

            Console.ReadLine();
        }
    }
}
