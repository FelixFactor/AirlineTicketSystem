namespace AdminPanel
{
    partial class AirportPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AirportPanel));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbPanel = new System.Windows.Forms.GroupBox();
            this.gbEditor = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbShortName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAirportName = new System.Windows.Forms.TextBox();
            this.listBoxAirports = new System.Windows.Forms.DataGridView();
            this.internIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iATADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.airportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ListResults = new System.Windows.Forms.ListBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnClean = new System.Windows.Forms.Button();
            this.gbPanel.SuspendLayout();
            this.gbEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxAirports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.airportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "City:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(277, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Country:";
            // 
            // textBoxCountry
            // 
            this.textBoxCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCountry.Location = new System.Drawing.Point(276, 30);
            this.textBoxCountry.Name = "textBoxCountry";
            this.textBoxCountry.Size = new System.Drawing.Size(157, 21);
            this.textBoxCountry.TabIndex = 1;
            // 
            // textBoxCity
            // 
            this.textBoxCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCity.Location = new System.Drawing.Point(24, 30);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(202, 21);
            this.textBoxCity.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(4, 19);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 50);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Create Connection";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(95, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 50);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Edit Connection";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(186, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 50);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete Connection";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gbPanel
            // 
            this.gbPanel.Controls.Add(this.btnAdd);
            this.gbPanel.Controls.Add(this.btnEdit);
            this.gbPanel.Controls.Add(this.btnDelete);
            this.gbPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbPanel.Location = new System.Drawing.Point(272, 160);
            this.gbPanel.Margin = new System.Windows.Forms.Padding(1);
            this.gbPanel.Name = "gbPanel";
            this.gbPanel.Size = new System.Drawing.Size(275, 80);
            this.gbPanel.TabIndex = 11;
            this.gbPanel.TabStop = false;
            // 
            // gbEditor
            // 
            this.gbEditor.Controls.Add(this.btnSave);
            this.gbEditor.Controls.Add(this.btnCancel);
            this.gbEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbEditor.Location = new System.Drawing.Point(237, 282);
            this.gbEditor.Margin = new System.Windows.Forms.Padding(1);
            this.gbEditor.Name = "gbEditor";
            this.gbEditor.Size = new System.Drawing.Size(275, 80);
            this.gbEditor.TabIndex = 12;
            this.gbEditor.TabStop = false;
            this.gbEditor.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(4, 19);
            this.btnSave.Margin = new System.Windows.Forms.Padding(1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 50);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(95, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 50);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel Changes";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbShortName
            // 
            this.tbShortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbShortName.Location = new System.Drawing.Point(276, 86);
            this.tbShortName.Name = "tbShortName";
            this.tbShortName.Size = new System.Drawing.Size(157, 21);
            this.tbShortName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(277, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "I.A.T.A. Code:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(277, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "Airport Name:";
            // 
            // tbAirportName
            // 
            this.tbAirportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAirportName.Location = new System.Drawing.Point(276, 138);
            this.tbAirportName.Name = "tbAirportName";
            this.tbAirportName.Size = new System.Drawing.Size(157, 21);
            this.tbAirportName.TabIndex = 4;
            // 
            // listBoxAirports
            // 
            this.listBoxAirports.AllowUserToAddRows = false;
            this.listBoxAirports.AllowUserToDeleteRows = false;
            this.listBoxAirports.AllowUserToResizeColumns = false;
            this.listBoxAirports.AllowUserToResizeRows = false;
            this.listBoxAirports.AutoGenerateColumns = false;
            this.listBoxAirports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listBoxAirports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.internIdDataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.iATADataGridViewTextBoxColumn});
            this.listBoxAirports.DataSource = this.airportBindingSource;
            this.listBoxAirports.Location = new System.Drawing.Point(3, 244);
            this.listBoxAirports.MultiSelect = false;
            this.listBoxAirports.Name = "listBoxAirports";
            this.listBoxAirports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listBoxAirports.Size = new System.Drawing.Size(648, 118);
            this.listBoxAirports.TabIndex = 17;
            this.listBoxAirports.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.listBoxAirports_CellMouseClick);
            // 
            // internIdDataGridViewTextBoxColumn
            // 
            this.internIdDataGridViewTextBoxColumn.DataPropertyName = "InternId";
            this.internIdDataGridViewTextBoxColumn.HeaderText = "InternId";
            this.internIdDataGridViewTextBoxColumn.Name = "internIdDataGridViewTextBoxColumn";
            this.internIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.internIdDataGridViewTextBoxColumn.Width = 60;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            this.cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            this.cityDataGridViewTextBoxColumn.HeaderText = "City";
            this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            this.cityDataGridViewTextBoxColumn.ReadOnly = true;
            this.cityDataGridViewTextBoxColumn.Width = 140;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "Country";
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            this.countryDataGridViewTextBoxColumn.ReadOnly = true;
            this.countryDataGridViewTextBoxColumn.Width = 140;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 170;
            // 
            // iATADataGridViewTextBoxColumn
            // 
            this.iATADataGridViewTextBoxColumn.DataPropertyName = "IATA";
            this.iATADataGridViewTextBoxColumn.HeaderText = "IATA";
            this.iATADataGridViewTextBoxColumn.Name = "iATADataGridViewTextBoxColumn";
            this.iATADataGridViewTextBoxColumn.ReadOnly = true;
            this.iATADataGridViewTextBoxColumn.Width = 60;
            // 
            // airportBindingSource
            // 
            this.airportBindingSource.DataSource = typeof(ClassLibrary.Airport);
            // 
            // ListResults
            // 
            this.ListResults.FormattingEnabled = true;
            this.ListResults.Location = new System.Drawing.Point(24, 67);
            this.ListResults.Name = "ListResults";
            this.ListResults.Size = new System.Drawing.Size(202, 173);
            this.ListResults.TabIndex = 18;
            this.ListResults.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListResults_MouseClick);
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnSearch.BackgroundImage")));
            this.BtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(230, 31);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(1);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(20, 20);
            this.BtnSearch.TabIndex = 10;
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click_1);
            // 
            // BtnClean
            // 
            this.BtnClean.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnClean.BackgroundImage")));
            this.BtnClean.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnClean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClean.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClean.Location = new System.Drawing.Point(252, 31);
            this.BtnClean.Margin = new System.Windows.Forms.Padding(1);
            this.BtnClean.Name = "BtnClean";
            this.BtnClean.Size = new System.Drawing.Size(20, 20);
            this.BtnClean.TabIndex = 19;
            this.BtnClean.UseVisualStyleBackColor = true;
            this.BtnClean.Click += new System.EventHandler(this.BtnClean_Click);
            // 
            // AirportPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnClean);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.ListResults);
            this.Controls.Add(this.gbEditor);
            this.Controls.Add(this.listBoxAirports);
            this.Controls.Add(this.tbAirportName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbShortName);
            this.Controls.Add(this.gbPanel);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.textBoxCountry);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AirportPanel";
            this.Size = new System.Drawing.Size(654, 375);
            this.gbPanel.ResumeLayout(false);
            this.gbEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxAirports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.airportBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCountry;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbPanel;
        private System.Windows.Forms.GroupBox gbEditor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbShortName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAirportName;
        private System.Windows.Forms.BindingSource airportBindingSource;
        private System.Windows.Forms.DataGridView listBoxAirports;
        private System.Windows.Forms.DataGridViewTextBoxColumn internIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iATADataGridViewTextBoxColumn;
        private System.Windows.Forms.ListBox ListResults;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnClean;
    }
}
