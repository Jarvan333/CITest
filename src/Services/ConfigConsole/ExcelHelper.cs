using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using ExcelDataReader;

namespace ConfigConsole {
    public static class ExcelHelper {
        public static DataTable Read(string filePath) {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    do
                    {
                        while (reader.Read())
                        {
                            // reader.GetDouble(0);
                        }
                    } while (reader.NextResult());

                    // 2. Use the AsDataSet extension method
                    return reader.AsDataSet().Tables[0];

                    // The result of each spreadsheet is in result.Tables
                }
            }
        }
    }

    public class Test {
        public int AA { get; set; }
        public string BB { get; set; }
    }
}
