using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.AnalysisServices.AdomdClient;

namespace LocalCube
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdomdConnection conn = new AdomdConnection();
            conn.ConnectionString = string.Format("Provider=MSOLAP;Data Source={0}", "C:\\CUBOS\\Sales.cub"); try
            {
                conn.Open(); AdomdCommand cmd = new AdomdCommand(); cmd.Connection = conn;      /* XMLA query used previously in Management Studio */    
                cmd.CommandText = "SELECT {[store_country].[All].Children} ON ROWS, {[Measures].[store_sales]} ON COLUMNS FROM [Sales]" /*+ "where [Measures].[SALE Count] "*/;
                /* ADOMD is just an ADO.NET provider and so       * principles are the same      */
                AdomdDataAdapter da = new AdomdDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
            catch (Exception ex)  {
                string a = ex.Message;

            }
        }
    }
}