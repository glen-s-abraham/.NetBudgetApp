using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.VisualBasic;

namespace BudgetApp
{
    public partial class frmMain : Form
    {
        OleDbConnection conn;
        OleDbCommand cmdExpense,cmdCategory,cmdBalance;
        OleDbDataAdapter expenseAdapter,categoryAdapter,balanceAdapter;
        DataTable expenseTable,categoryTable,balanceTable;
        private void fill_expense_grid()
        {
            try
            {
                cmdExpense = new OleDbCommand("select  ID,E_Date,Amount,Descreption,Category from expense order by id desc", conn);
                expenseAdapter = new OleDbDataAdapter();
                expenseAdapter.SelectCommand = cmdExpense;
                expenseTable = new DataTable();
                expenseAdapter.Fill(expenseTable);
                grdExpense.DataSource = expenseTable;
                //hide id column
                grdExpense.Columns[0].Visible = false;
                //hide category column
                grdExpense.Columns[4].Visible = false;
                expenseAdapter.Dispose();
                cmdExpense.Dispose();
                lblfood.Text = "₹"+expenseTable.Compute("sum(Amount)", "Category=1").ToString();
                lblshopping.Text = "₹" + expenseTable.Compute("sum(Amount)", "Category=2").ToString();
                lblbills.Text = "₹" + expenseTable.Compute("sum(Amount)", "Category=3").ToString();
                lblothers.Text = "₹" + expenseTable.Compute("sum(Amount)", "Category=4").ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        private void fill_balance_label()
        {
            try
            {
                cmdBalance = new OleDbCommand("Select Balance from FinalBalance", conn);
                balanceAdapter = new OleDbDataAdapter();
                balanceAdapter.SelectCommand = cmdBalance;
                balanceTable = new DataTable();
                balanceAdapter.Fill(balanceTable);
                lbl_finalBalance.DataBindings.Add("Text", balanceTable,  "Balance");
                lbl_finalBalance.Text = "₹" + lbl_finalBalance.Text;
                balanceAdapter.Dispose();
                cmdBalance.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_decreasebalance_Click(object sender, EventArgs e)
        {
            var amount = Interaction.InputBox("Amount To Add", "Add To Balance");
            cmdBalance = new OleDbCommand("Update  FinalBalance set Balance=Balance-" + amount + " where identifier=\'final\'", conn);
            balanceAdapter = new OleDbDataAdapter();
            balanceAdapter.UpdateCommand = cmdBalance;
            try
            {
                balanceAdapter.UpdateCommand.ExecuteNonQuery();
                lbl_finalBalance.DataBindings.Clear();
                fill_balance_label();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            balanceAdapter.Dispose();
            cmdBalance.Dispose();
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            if(txt_amount.Text!="" || txt_descreption.Text!="")
            {
                var date = dt_Edate.Value.Date;
                var category = cmb_category.SelectedValue;
                string amount = txt_amount.Text;
                string descreption = txt_descreption.Text;
                try
                {
                   
                    //insert operation expenses
                    string command = "Insert into Expense(E_Date,Category,Amount,Descreption) Values('" + date.ToString() + "'," + category + "," + amount + ",'" + descreption + "')";
                    cmdExpense = new OleDbCommand(command, conn);
                    expenseAdapter = new OleDbDataAdapter();
                    expenseAdapter.InsertCommand = cmdExpense;
                    expenseAdapter.InsertCommand.ExecuteNonQuery();
                    cmdExpense.Dispose();
                    expenseAdapter.Dispose();
                    fill_expense_grid();

                    //updation on balance
                    cmdBalance = new OleDbCommand("Update  FinalBalance set Balance=Balance-" + amount + " where identifier=\'final\'", conn);
                    balanceAdapter = new OleDbDataAdapter();
                    balanceAdapter.UpdateCommand = cmdBalance;
                    balanceAdapter.UpdateCommand.ExecuteNonQuery();
                    lbl_finalBalance.DataBindings.Clear();
                    fill_balance_label();
                    balanceAdapter.Dispose();
                    cmdBalance.Dispose();





                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Enter all the values");
            }
            
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var id = grdExpense.SelectedCells[0].Value;
            var amount = grdExpense.SelectedCells[2].Value;
            cmdExpense = new OleDbCommand("Delete from Expense where id=" + id.ToString(), conn);
            expenseAdapter = new OleDbDataAdapter();
            expenseAdapter.DeleteCommand = cmdExpense;
            try
            {
                expenseAdapter.DeleteCommand.ExecuteNonQuery();

                //update balance
                //updation on balance
                cmdBalance = new OleDbCommand("Update  FinalBalance set Balance=Balance+" + amount + " where identifier=\'final\'", conn);
                balanceAdapter = new OleDbDataAdapter();
                balanceAdapter.UpdateCommand = cmdBalance;
                balanceAdapter.UpdateCommand.ExecuteNonQuery();
                lbl_finalBalance.DataBindings.Clear();
                fill_balance_label();
                balanceAdapter.Dispose();
                cmdBalance.Dispose();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmdExpense.Dispose();
            expenseAdapter.Dispose();
            fill_expense_grid();

        }

        private void btnAddBalance_Click(object sender, EventArgs e)
        {
            var amount=Interaction.InputBox("Amount To Add", "Add To Balance");
            cmdBalance = new OleDbCommand("Update  FinalBalance set Balance=Balance+"+amount+" where identifier=\'final\'", conn);
            balanceAdapter = new OleDbDataAdapter();
            balanceAdapter.UpdateCommand = cmdBalance;
            try
            {
                balanceAdapter.UpdateCommand.ExecuteNonQuery();
                lbl_finalBalance.DataBindings.Clear();
                fill_balance_label();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            balanceAdapter.Dispose();
            cmdBalance.Dispose();

        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:/DB/BudgetApp.accdb;Persist Security Info=False;";
            try
            {
                conn = new OleDbConnection(connString);
                conn.Open();
                //Category combo box fill

                cmdCategory = new OleDbCommand("Select * from Category", conn);
                categoryAdapter = new OleDbDataAdapter();
                categoryAdapter.SelectCommand = cmdCategory;
                categoryTable = new DataTable();
                categoryAdapter.Fill(categoryTable);

                cmb_category.DataSource = categoryTable;
                cmb_category.ValueMember = "id";
                cmb_category.DisplayMember = "Name";
                cmdCategory.Dispose();
                categoryAdapter.Dispose();

                //expense table fill

                fill_expense_grid();

                //fill balances

                fill_balance_label();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
