using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace FileMerger
{

    /*
     *Class designed for handling DataTables
     * author @ Robert Moore
     */
    class Handler
    {
        private DataTable dt1 = new DataTable();
        private DataTable dt2 = new DataTable();
        private DataTable dt3 = new DataTable();
        private DataTable dt1mismatch = new DataTable();
        private DataTable dt2mismatch = new DataTable();
        private DataTable dtMergedRecords = new DataTable();

        public void Loader(string path1, string path2)
        {
            dt1.Clear();
            dt1.Rows.Clear();
            dt1.Columns.Clear();
            dt2.Clear();
            dt2.Rows.Clear();
            dt2.Columns.Clear();
            dt1 = Loaderguts(path1);
            dt2 = Loaderguts(path2);
        }

        public DataTable Loaderguts(string path)
        {

            DataTable tempDT = new DataTable(); //temp data table to prep the other

            //load csv into string array
            string[] Lines;
            try
            {
                Lines = File.ReadAllLines(path);
            }
            catch
            {
                Exception FileNotFound = new Exception("File not found. Path: " + path);
                throw FileNotFound;
            }
            //load headers
            string[] Headers = Lines[0].Split(',');
            int headerlength = Headers.Count();

            for (int i = 0; i < Headers.Length; i++)
            {
                tempDT.Columns.Add(Headers[i].ToUpper(), typeof(String));
            }

            //MIGHT NEED TO ADD A DUPLICATE KILLER HERE

            //load rows
            for (int i = 1; i < Lines.Length; i++)
            {

                string[] rowdata = Lines[i].Split(',');

                if (rowdata.Count() == headerlength)
                {
                    tempDT.Rows.Add(rowdata);
                }
                else
                {
                    // why is this here
                }

            }

            return tempDT;
        }

        public void MisMatchLogger(string pkStr, string path1, string path2)
        {
            //path = path.Remove(path.LastIndexOf('\\'));
            int pk = dt1.Columns.IndexOf(pkStr);
            int pk2 = dt2.Columns.IndexOf(pkStr);

            dt1mismatch = dt1.Clone();
            dt2mismatch = dt2.Clone();

            foreach (DataRow dr in dt1.Rows)
            {
                if (dr.ItemArray[pk].Equals(""))
                {
                    dt1mismatch.ImportRow(dr);
                }
            }

            foreach (DataRow dr in dt2.Rows)
            {
                if (dr.ItemArray[pk2].Equals(""))
                {
                    dt2mismatch.ImportRow(dr);
                }
            }

            if (dt1mismatch.Rows.Count != 0)
            {
                Writer(dt1mismatch, path1.Insert(path1.IndexOf('.'), " Mismatches"));
            }
            if (dt2mismatch.Rows.Count != 0)
            {
                Writer(dt2mismatch, path2.Insert(path2.IndexOf('.'), " Mismatches"));
            }
        }

        public void AutoMatchMerge(string pkStr)
        {
            dt3.Clear(); //wipes the merged dt so that the program can run more than once without errors
            dt3.Rows.Clear();
            dt3.Columns.Clear();
            dtMergedRecords.Clear();
            dtMergedRecords.Rows.Clear();
            dtMergedRecords.Columns.Clear();
            int pk = dt1.Columns.IndexOf(pkStr);
            double sanity = 0;
            double dt3Length = 0;
            int percentage = 0;

            //load headers from first datatable
            foreach (DataColumn col in dt1.Columns)
            {
                dt3.Columns.Add(col.ColumnName.ToUpper(), typeof(string));
            }

            //append additional columns
            foreach (DataColumn dc in dt2.Columns)
            {
                if (!dt3.Columns.Contains(dc.ColumnName.ToUpper()))
                {
                    dt3.Columns.Add(dc.ColumnName.ToUpper(), typeof(string));
                }
            }

            //load rows from dt1
            foreach (DataRow dr1 in dt1.Rows)
            {
                if (!dr1.ItemArray[pk].Equals(""))
                {
                    dt3.ImportRow(dr1);
                }
            }

            int pk2 = dt2.Columns.IndexOf(pkStr);
            //load rows from dt2
            foreach (DataRow dr2 in dt2.Rows)
            {
                if (!dr2.ItemArray[pk2].Equals(""))
                {
                    dt3.ImportRow(dr2);
                }
            }

            dtMergedRecords = dt3.Clone();

            ProgressWindow pw = new ProgressWindow();
            pw.Activate();
            pw.Visible = true;
            pw.setProgressBarMax(100);
            pw.setProgressBarMin(0);
            pw.setProgressBarValue(1);
            pw.setLabelText(String.Format("Merging files, {0:P0} completed", percentage));
            int pk3 = dt3.Columns.IndexOf(pkStr);
            
            //Actual data merging
            for (int i = 0; i < dt3.Rows.Count; i++)
            {

                for (int j = 0; j < dt3.Rows.Count; j++)
                {

                    //checks for duplicates by comparing the pk
                    if ((dt3.Rows[i].ItemArray.ElementAt(pk3)).Equals(dt3.Rows[j].ItemArray.ElementAt(pk3)) && (!(i == j)))
                    {
                        //loops through the columns of each record
                        for (int x = 0; x < dt3.Rows[0].ItemArray.ToArray().Length; x++)
                        {
                            //checks whether each element in the duplicate matches, activates if not 
                            if (!dt3.Rows[i].ItemArray.ElementAt(x).Equals(dt3.Rows[j].ItemArray.ElementAt(x)))
                            {
                                //if the element is blank in the master file, we fill it in from the second file
                                bool nullOrEmpty = String.IsNullOrEmpty(dt3.Rows[i].ItemArray.ElementAt(x).ToString());
                                bool nullOrWhiteSpace = String.IsNullOrWhiteSpace(dt3.Rows[i].ItemArray.ElementAt(x).ToString());

                                if (nullOrEmpty || nullOrWhiteSpace)
                                {
                                    //  Console.WriteLine("Blank, " + dt3.Rows[i].ItemArray.ElementAt(x));
                                    dt3.Rows[i][x] = dt3.Rows[j][x];

                                }//else we override the second file with the data from the master file
                                else
                                {
                                    //  Console.WriteLine("Override, " + dt3.Rows[j][x]);
                                    dt3.Rows[j][x] = dt3.Rows[i][x];
                                }
                            }
                        }
                        dtMergedRecords.ImportRow(dt3.Rows[j]);
                        dt3.Rows[j].Delete();
                        j--; //not sure how I feel about this
                        dt3Length = dt3.Rows.Count;
                    }
                }
                sanity++;
                percentage = (int)(Math.Floor((sanity/dt3Length)*100));

                if (percentage < 1||100 < percentage) {
                    percentage = 0;
                }

                Console.WriteLine("Percentage " + (sanity / dt3Length) * 100);
                Console.WriteLine();
                pw.setProgressBarValue(percentage);
                pw.setLabelText(String.Format("Merging files, {0:P0} completed ", (double)percentage/100));
            }

            pw.Close();
            pw.Dispose();

        }

        //may have to reassess this method based on memoery usage
        public void Writer(DataTable dt, string path)
        {

            String[] lines = new String[dt.Rows.Count + 1];
            string line = "";


            foreach (DataColumn col in dt.Columns)
            {
                line = line + col.ColumnName + ",";
            }

            lines[0] = line.Remove(line.LastIndexOf(','));

            int counter = 1;
            foreach (DataRow row in dt.Rows)
            {
                line = "";
                foreach (DataColumn col in dt.Columns)
                {
                    line = line + row[col].ToString() + ",";
                }
                lines[counter] = line.Remove(line.LastIndexOf(','));
                ++counter;
            }

            File.WriteAllLines(path, lines);

        }

        //getters and setters (for security 'n stuff)

        public DataTable getDT1()
        {
            return dt1;
        }

        public DataTable getDT2()
        {
            return dt2;
        }

        public DataTable getDT3()
        {
            return dt3; 
        }

        public DataTable getDT1MissMatch()
        {
            return dt1mismatch;
        }

        public DataTable getDT2MissMatch()
        {
            return dt2mismatch;
        }
        
        public DataTable getDTMergedRecords()
        {
            return dtMergedRecords;
        }
    }

}
