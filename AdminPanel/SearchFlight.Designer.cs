namespace AdminPanel
{
    partial class SearchFlight
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOrigin = new System.Windows.Forms.TextBox();
            this.tbDestination = new System.Windows.Forms.TextBox();
            this.dateBox = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.DGVSearch = new System.Windows.Forms.DataGridView();
            this.flightNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hourDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flightBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkOrigin = new System.Windows.Forms.CheckBox();
            this.btnBooking = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flightBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(164, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "To:";
            // 
            // tbOrigin
            // 
            this.tbOrigin.Location = new System.Drawing.Point(27, 81);
            this.tbOrigin.Name = "tbOrigin";
            this.tbOrigin.Size = new System.Drawing.Size(100, 20);
            this.tbOrigin.TabIndex = 2;
            this.tbOrigin.TextChanged += new System.EventHandler(this.tbOrigin_TextChanged);
            // 
            // tbDestination
            // 
            this.tbDestination.Location = new System.Drawing.Point(167, 81);
            this.tbDestination.Name = "tbDestination";
            this.tbDestination.Size = new System.Drawing.Size(100, 20);
            this.tbDestination.TabIndex = 3;
            // 
            // dateBox
            // 
            this.dateBox.Location = new System.Drawing.Point(380, 81);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(200, 20);
            this.dateBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(377, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(27, 160);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 45);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search Flight";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(93, 160);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 45);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear Search";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // DGVSearch
            // 
            this.DGVSearch.AllowUserToAddRows = false;
            this.DGVSearch.AllowUserToDeleteRows = false;
            this.DGVSearch.AllowUserToResizeColumns = false;
            this.DGVSearch.AllowUserToResizeRows = false;
            this.DGVSearch.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flightNumberDataGridViewTextBoxColumn,
            this.originDataGridViewTextBoxColumn,
            this.destinationDataGridViewTextBoxColumn,
            this.AData,
            this.hourDataGridViewTextBoxColumn,
            this.planeDataGridViewTextBoxColumn});
            this.DGVSearch.DataSource = this.flightBindingSource;
            this.DGVSearch.Location = new System.Drawing.Point(3, 211);
            this.DGVSearch.MultiSelect = false;
            this.DGVSearch.Name = "DGVSearch";
            this.DGVSearch.ReadOnly = true;
            this.DGVSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVSearch.Size = new System.Drawing.Size(648, 161);
            this.DGVSearch.TabIndex = 8;
            // 
            // flightNumberDataGridViewTextBoxColumn
            // 
            this.flightNumberDataGridViewTextBoxColumn.DataPropertyName = "FlightNumber";
            this.flightNumberDataGridViewTextBoxColumn.HeaderText = "FlightNumber";
            this.flightNumberDataGridViewTextBoxColumn.Name = "flightNumberDataGridViewTextBoxColumn";
            this.flightNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // originDataGridViewTextBoxColumn
            // 
            this.originDataGridViewTextBoxColumn.DataPropertyName = "Origin";
            this.originDataGridViewTextBoxColumn.HeaderText = "Origin";
            this.originDataGridViewTextBoxColumn.Name = "originDataGridViewTextBoxColumn";
            this.originDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // destinationDataGridViewTextBoxColumn
            // 
            this.destinationDataGridViewTextBoxColumn.DataPropertyName = "Destination";
            this.destinationDataGridViewTextBoxColumn.HeaderText = "Destination";
            this.destinationDataGridViewTextBoxColumn.Name = "destinationDataGridViewTextBoxColumn";
            this.destinationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // AData
            // 
            this.AData.DataPropertyName = "AData";
            this.AData.HeaderText = "Date";
            this.AData.Name = "AData";
            this.AData.ReadOnly = true;
            this.AData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // hourDataGridViewTextBoxColumn
            // 
            this.hourDataGridViewTextBoxColumn.DataPropertyName = "Hour";
            this.hourDataGridViewTextBoxColumn.HeaderText = "Hour";
            this.hourDataGridViewTextBoxColumn.Name = "hourDataGridViewTextBoxColumn";
            this.hourDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // planeDataGridViewTextBoxColumn
            // 
            this.planeDataGridViewTextBoxColumn.DataPropertyName = "Plane";
            this.planeDataGridViewTextBoxColumn.HeaderText = "Aircraft";
            this.planeDataGridViewTextBoxColumn.Name = "planeDataGridViewTextBoxColumn";
            this.planeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // flightBindingSource
            // 
            this.flightBindingSource.DataSource = typeof(ClassLibrary.Flight);
            this.flightBindingSource.Sort = "AData";
            // 
            // checkOrigin
            // 
            this.checkOrigin.AutoSize = true;
            this.checkOrigin.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOrigin.Location = new System.Drawing.Point(27, 132);
            this.checkOrigin.Name = "checkOrigin";
            this.checkOrigin.Size = new System.Drawing.Size(101, 22);
            this.checkOrigin.TabIndex = 9;
            this.checkOrigin.Text = "Flexible date";
            this.checkOrigin.UseVisualStyleBackColor = true;
            this.checkOrigin.CheckedChanged += new System.EventHandler(this.checkOrigin_CheckedChanged);
            // 
            // btnBooking
            // 
            this.btnBooking.Enabled = false;
            this.btnBooking.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBooking.Location = new System.Drawing.Point(159, 160);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Size = new System.Drawing.Size(65, 45);
            this.btnBooking.TabIndex = 10;
            this.btnBooking.Text = "Go to Booking";
            this.btnBooking.UseVisualStyleBackColor = true;
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // SearchFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBooking);
            this.Controls.Add(this.checkOrigin);
            this.Controls.Add(this.DGVSearch);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.tbDestination);
            this.Controls.Add(this.tbOrigin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SearchFlight";
            this.Size = new System.Drawing.Size(654, 375);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flightBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbOrigin;
        private System.Windows.Forms.TextBox tbDestination;
        private System.Windows.Forms.DateTimePicker dateBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView DGVSearch;
  //      private System.Windows.Forms.DataGridViewTextBoxColumn aircraftDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox checkOrigin;
        private System.Windows.Forms.BindingSource flightBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn flightNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn originDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AData;
        private System.Windows.Forms.DataGridViewTextBoxColumn hourDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn planeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnBooking;
    }
}
