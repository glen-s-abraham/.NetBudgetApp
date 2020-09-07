namespace BudgetApp
{
    partial class frmTrack
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrack));
            this.dt_start = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_end = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_expense = new System.Windows.Forms.Button();
            this.chrt_exp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chrt_exp)).BeginInit();
            this.SuspendLayout();
            // 
            // dt_start
            // 
            this.dt_start.CustomFormat = "M/dd/yyyy";
            this.dt_start.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_start.Location = new System.Drawing.Point(37, 66);
            this.dt_start.Name = "dt_start";
            this.dt_start.Size = new System.Drawing.Size(171, 26);
            this.dt_start.TabIndex = 6;
            this.dt_start.Value = new System.DateTime(2020, 9, 7, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(34, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start ";
            // 
            // dt_end
            // 
            this.dt_end.CustomFormat = "M/dd/yyyy";
            this.dt_end.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_end.Location = new System.Drawing.Point(37, 147);
            this.dt_end.Name = "dt_end";
            this.dt_end.Size = new System.Drawing.Size(171, 26);
            this.dt_end.TabIndex = 8;
            this.dt_end.Value = new System.DateTime(2020, 9, 7, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(34, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "End";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(72)))), ((int)(((byte)(102)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(134, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 38);
            this.button1.TabIndex = 10;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_expense
            // 
            this.btn_expense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(156)))), ((int)(((byte)(202)))));
            this.btn_expense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_expense.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_expense.ForeColor = System.Drawing.Color.Snow;
            this.btn_expense.Location = new System.Drawing.Point(37, 200);
            this.btn_expense.Name = "btn_expense";
            this.btn_expense.Size = new System.Drawing.Size(75, 38);
            this.btn_expense.TabIndex = 9;
            this.btn_expense.Text = "Track ";
            this.btn_expense.UseVisualStyleBackColor = false;
            this.btn_expense.Click += new System.EventHandler(this.btn_expense_Click);
            // 
            // chrt_exp
            // 
            chartArea2.Name = "ChartArea1";
            this.chrt_exp.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrt_exp.Legends.Add(legend2);
            this.chrt_exp.Location = new System.Drawing.Point(271, 28);
            this.chrt_exp.Name = "chrt_exp";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Expense";
            this.chrt_exp.Series.Add(series2);
            this.chrt_exp.Size = new System.Drawing.Size(300, 237);
            this.chrt_exp.TabIndex = 11;
            this.chrt_exp.Text = "Expenses";
            // 
            // frmTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(39)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(619, 309);
            this.Controls.Add(this.chrt_exp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_expense);
            this.Controls.Add(this.dt_end);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dt_start);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTrack";
            this.Text = "Track Expenses";
            this.Load += new System.EventHandler(this.frmTrack_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chrt_exp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dt_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt_end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_expense;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrt_exp;
    }
}