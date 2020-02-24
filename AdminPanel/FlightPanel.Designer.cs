namespace AdminPanel
{
    partial class FlightPanel
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
            this.btnCreateFlight = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxOrigin = new System.Windows.Forms.ComboBox();
            this.cboxDestination = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAircrafts = new System.Windows.Forms.ComboBox();
            this.DGVFlights = new System.Windows.Forms.DataGridView();
            this.flightNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departureDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departureHourDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flightBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbHour = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFlights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flightBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateFlight
            // 
            this.btnCreateFlight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateFlight.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateFlight.Location = new System.Drawing.Point(468, 119);
            this.btnCreateFlight.Name = "btnCreateFlight";
            this.btnCreateFlight.Size = new System.Drawing.Size(146, 30);
            this.btnCreateFlight.TabIndex = 25;
            this.btnCreateFlight.Text = "Create Flight";
            this.btnCreateFlight.UseVisualStyleBackColor = true;
            this.btnCreateFlight.Click += new System.EventHandler(this.btnCreateFlight_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(449, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 24;
            this.label3.Text = "Time:";
            // 
            // calendar
            // 
            this.calendar.BackColor = System.Drawing.SystemColors.Control;
            this.calendar.CausesValidation = false;
            this.calendar.Location = new System.Drawing.Point(212, 41);
            this.calendar.MaxSelectionCount = 1;
            this.calendar.Name = "calendar";
            this.calendar.ShowToday = false;
            this.calendar.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "Origin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "Destination:";
            // 
            // cboxOrigin
            // 
            this.cboxOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxOrigin.FormattingEnabled = true;
            this.cboxOrigin.Location = new System.Drawing.Point(20, 41);
            this.cboxOrigin.Name = "cboxOrigin";
            this.cboxOrigin.Size = new System.Drawing.Size(180, 23);
            this.cboxOrigin.TabIndex = 0;
            // 
            // cboxDestination
            // 
            this.cboxDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDestination.FormattingEnabled = true;
            this.cboxDestination.Location = new System.Drawing.Point(20, 88);
            this.cboxDestination.Name = "cboxDestination";
            this.cboxDestination.Size = new System.Drawing.Size(180, 23);
            this.cboxDestination.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(209, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 18);
            this.label4.TabIndex = 28;
            this.label4.Text = "Date:";
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(468, 155);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(146, 30);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "Delete Flight";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 18);
            this.label5.TabIndex = 30;
            this.label5.Text = "Aircraft:";
            // 
            // cbAircrafts
            // 
            this.cbAircrafts.Location = new System.Drawing.Point(18, 155);
            this.cbAircrafts.Name = "cbAircrafts";
            this.cbAircrafts.Size = new System.Drawing.Size(182, 21);
            this.cbAircrafts.TabIndex = 4;
            // 
            // DGVFlights
            // 
            this.DGVFlights.AllowUserToAddRows = false;
            this.DGVFlights.AllowUserToDeleteRows = false;
            this.DGVFlights.AllowUserToResizeColumns = false;
            this.DGVFlights.AllowUserToResizeRows = false;
            this.DGVFlights.AutoGenerateColumns = false;
            this.DGVFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVFlights.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flightNumberDataGridViewTextBoxColumn,
            this.originDataGridViewTextBoxColumn,
            this.destinationDataGridViewTextBoxColumn,
            this.departureDateDataGridViewTextBoxColumn,
            this.departureHourDataGridViewTextBoxColumn,
            this.planeDataGridViewTextBoxColumn});
            this.DGVFlights.DataSource = this.flightBindingSource;
            this.DGVFlights.Location = new System.Drawing.Point(6, 202);
            this.DGVFlights.MultiSelect = false;
            this.DGVFlights.Name = "DGVFlights";
            this.DGVFlights.ReadOnly = true;
            this.DGVFlights.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVFlights.Size = new System.Drawing.Size(645, 170);
            this.DGVFlights.TabIndex = 32;
            // 
            // flightNumberDataGridViewTextBoxColumn
            // 
            this.flightNumberDataGridViewTextBoxColumn.DataPropertyName = "FlightNumber";
            this.flightNumberDataGridViewTextBoxColumn.HeaderText = "Number";
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
            // departureDateDataGridViewTextBoxColumn
            // 
            this.departureDateDataGridViewTextBoxColumn.DataPropertyName = "DepartureDate";
            this.departureDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.departureDateDataGridViewTextBoxColumn.Name = "departureDateDataGridViewTextBoxColumn";
            this.departureDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // departureHourDataGridViewTextBoxColumn
            // 
            this.departureHourDataGridViewTextBoxColumn.DataPropertyName = "DepartureHour";
            this.departureHourDataGridViewTextBoxColumn.HeaderText = "Time";
            this.departureHourDataGridViewTextBoxColumn.Name = "departureHourDataGridViewTextBoxColumn";
            this.departureHourDataGridViewTextBoxColumn.ReadOnly = true;
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
            // 
            // tbHour
            // 
            this.tbHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbHour.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.tbHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHour.Location = new System.Drawing.Point(452, 41);
            this.tbHour.Mask = "00:00";
            this.tbHour.Name = "tbHour";
            this.tbHour.PromptChar = ' ';
            this.tbHour.Size = new System.Drawing.Size(56, 26);
            this.tbHour.SkipLiterals = false;
            this.tbHour.TabIndex = 2;
            this.tbHour.ValidatingType = typeof(System.DateTime);
            this.tbHour.Click += new System.EventHandler(this.tbHour_Click);
            this.tbHour.Enter += new System.EventHandler(this.tbHour_Enter);
            // 
            // FlightPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tbHour);
            this.Controls.Add(this.DGVFlights);
            this.Controls.Add(this.cbAircrafts);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCreateFlight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboxOrigin);
            this.Controls.Add(this.cboxDestination);
            this.Name = "FlightPanel";
            this.Size = new System.Drawing.Size(654, 375);
            ((System.ComponentModel.ISupportInitialize)(this.DGVFlights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flightBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateFlight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxOrigin;
        private System.Windows.Forms.ComboBox cboxDestination;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbAircrafts;
        private System.Windows.Forms.DataGridView DGVFlights;
        private System.Windows.Forms.MaskedTextBox tbHour;
        private System.Windows.Forms.BindingSource flightBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn flightNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn originDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departureDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departureHourDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn planeDataGridViewTextBoxColumn;
    }
}
