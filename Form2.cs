using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetApp
{
    public partial class frmTrack : Form
    {
        OleDbConnection conn;
        OleDbCommand cmdExpense;
        OleDbDataAdapter expenseAdapter;
        DataTable expenseTable;
        public frmTrack()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTrack_Load(object sender, EventArgs e)
        {
            var connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:/DB/BudgetApp.accdb;Persist Security Info=False;";
            try
            {
                conn = new OleDbConnection(connString);
                conn.Open();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            }

        private void btn_expense_Click(object sender, EventArgs e)
        {
            try
            {

                //string cmd = "select * from expense where E_Date >= " + dt_start.Value.ToShortDateString() + " and E_Date<=" + dt_end.Value.ToShortDateString();
                
                string startDate = dt_start.Value.Month.ToString()+"/"+dt_start.Value.Day.ToString()+"/"+dt_start.Value.Year.ToString();
                string endDate = dt_end.Value.Month.ToString() + "/" + dt_end.Value.Day.ToString() + "/" + dt_end.Value.Year.ToString();
                string cmd = "select * from expense where E_Date  Between #"+startDate+"# and #"+endDate+"#";
                
                //string cmd = "Select * from expense";
                cmdExpense = new OleDbCommand(cmd, conn);
                expenseAdapter = new OleDbDataAdapter();
                expenseAdapter.SelectCommand = cmdExpense;
                expenseTable = new DataTable();
                expenseAdapter.Fill(expenseTable);
                cmdExpense.Dispose();
                expenseAdapter.Dispose();

                var food = expenseTable.Compute("sum(Amount)", "Category=1");
                var shopping =expenseTable.Compute("sum(Amount)", "Category=2");
                var bills = expenseTable.Compute("sum(Amount)", "Category=3");
                var others = expenseTable.Compute("sum(Amount)", "Category=4");

                //clear previous plots on chart
                foreach (var series in chrt_exp.Series)
                {
                    series.Points.Clear();
                }
                //clear tile
                chrt_exp.Titles.Clear();

                //add points to chart
                chrt_exp.Series["Expense"].Points.AddXY("Food", food);
                chrt_exp.Series["Expense"].Points.AddXY("Shopping", shopping);
                chrt_exp.Series["Expense"].Points.AddXY("bills", bills);
                chrt_exp.Series["Expense"].Points.AddXY("others", others);

                chrt_exp.Titles.Add("Expense chart");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
