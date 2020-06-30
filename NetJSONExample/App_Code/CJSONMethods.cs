using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.Script.Serialization;

namespace NetJSONExample.App_Code
{
    public class CJSONMethods
    {
        /* Bibliografía (Modelo APA: cva.itesm.mx/biblioteca/pagina_con_formato_version_oct/apa.htm)
           
           1.- Singh, S.. (2019).
               3 Ways to Convert DataTable to JSON String in ASP.NET C#.
               junio 29, 2020, de C# Corner
               Sitio web: https://www.c-sharpcorner.com/UploadFile/9bff34/3-ways-to-convert-datatable-to-json-string-in-Asp-Net-C-Sharp/
         */

        /*
         Method 1

         Convert DataTable to JSON using StringBuilder.
         This is how the JSON sample data looks: {"firstName":"Satinder", "lastName":"Singh"}.
         JSON objects are written inside curly braces and can contain multiple name/values pairs.

         So using StringBuilder we can create a similar JSON Structured String.

         Since we are using StringBuilder we need to import the System.Text namespace in our page as in the following:
         
         Using System.Text;  
        
         The following code will generate a JSON string. Here we are making a for loop over our 
         DataTable rows and columns. Fetch the data (values) and append it to our JSONString
         StringBuilder. 
         
         This is how our code looks:
         */
        public string DataTableToJSONWithStringBuilder(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }

        /*
         Method 2

         Convert the DataTable to JSON using JavaScriptSerializer.
         Since we are using JavaScriptSerializer we first need to import the
         System.Web.Script.Serialization namespace into our page as in the following code:
         
         using System.Web.Script.Serialization;  
         
         The JavaScriptSerializer class is used internally by the asynchronous communication
         layer to serialize and deserialize the data.
         To serialize an object, use the Serialize method. To deserialize a JSON string,
         use the Deserialize or DeserializeObject methods.

         Here we use the serialize method to get the JSON format data. So our code looks as in
         the following:
         */
        public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }

        /*
         Method 3

         Convert DataTable to JSON using JSON.Net DLL (Newtonsoft).

         Now in this method we will convert our C# Datatable to JSON using the Newtonsoft DLL.

         using Newtonsoft.Json;

         For this first we need to download JSON.Net DLL. We can download it from Nuget.org and
         then import the Newtonsoft.JSON namespace into our page as in the following code.
         JSON.NET is a popular high-performance JSON framework for .NET.
         */
        public string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
    }
}
