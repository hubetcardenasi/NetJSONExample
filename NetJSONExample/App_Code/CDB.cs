﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetJSONExample.App_Code
{
    public class CDB
    {
        public DataTable getData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserId", typeof(Int32));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Education", typeof(string));
            dt.Columns.Add("Location", typeof(string));
            dt.Rows.Add(1, "Satinder Singh", "Bsc Com Sci", "Mumbai");
            dt.Rows.Add(2, "Amit Sarna", "Mstr Com Sci", "Mumbai");
            dt.Rows.Add(3, "Andrea Ely", "Bsc Bio-Chemistry", "Queensland");
            dt.Rows.Add(4, "Leslie Mac", "MSC", "Town-ville");
            dt.Rows.Add(5, "Vaibhav Adhyapak", "MBA", "New Delhi");
            return dt;
        }
    }
}
