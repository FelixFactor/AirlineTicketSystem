namespace AdminPanel
{
    partial class FleetPanel
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
            this.cboxManufacturer = new System.Windows.Forms.ComboBox();
            this.cboxModel = new System.Windows.Forms.ComboBox();
            this.aircraftBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbSeats = new System.Windows.Forms.MaskedTextBox();
            this.DGVFleet = new System.Windows.Forms.DataGridView();
            this.internalIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstClassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondClassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.aircraftBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFleet)).BeginInit();
            this.SuspendLayout();
            // 
            // cboxManufacturer
            // 
            this.cboxManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxManufacturer.FormattingEnabled = true;
            this.cboxManufacturer.Items.AddRange(new object[] {
            "Airbus",
            "Boeing"});
            this.cboxManufacturer.Location = new System.Drawing.Point(27, 59);
            this.cboxManufacturer.Name = "cboxManufacturer";
            this.cboxManufacturer.Size = new System.Drawing.Size(169, 23);
            this.cboxManufacturer.TabIndex = 0;
            this.cboxManufacturer.Text = "--Select Manufacturer--";
            this.cboxManufacturer.SelectedValueChanged += new System.EventHandler(this.cboxManufacturer_SelectedValueChanged);
            // 
            // cboxModel
            // 
            this.cboxModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxModel.FormatString = "Model";
            this.cboxModel.FormattingEnabled = true;
            this.cboxModel.Location = new System.Drawing.Point(27, 112);
            this.cboxModel.Name = "cboxModel";
            this.cboxModel.Size = new System.Drawing.Size(169, 23);
            this.cboxModel.TabIndex = 1;
            this.cboxModel.SelectedIndexChanged += new System.EventHandler(this.cboxModel_SelectedIndexChanged);
            // 
            // aircraftBindingSource
            // 
            this.aircraftBindingSource.DataSource = typeof(ClassLibrary.Aircraft);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Manufacturer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Model";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total Seats";
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(280, 35);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 47);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add Aircraft";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(280, 88);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(76, 47);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit Aircraft";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(280, 141);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(76, 47);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete Aircraft";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbSeats
            // 
            this.tbSeats.Location = new System.Drawing.Point(27, 168);
            this.tbSeats.Mask = "000";
            this.tbSeats.Name = "tbSeats";
            this.tbSeats.Size = new System.Drawing.Size(25, 20);
            this.tbSeats.TabIndex = 2;
            this.tbSeats.Click += new System.EventHandler(this.tbSeats_Click);
            this.tbSeats.Enter += new System.EventHandler(this.tbSeats_Enter);
            // 
            // DGVFleet
            // 
            this.DGVFleet.AllowUserToAddRows = false;
            this.DGVFleet.AllowUserToDeleteRows = false;
            this.DGVFleet.AllowUserToResizeColumns = false;
            this.DGVFleet.AllowUserToResizeRows = false;
            this.DGVFleet.AutoGenerateColumns = false;
            this.DGVFleet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVFleet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.internalIDDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.modelDataGridViewTextBoxColumn,
            this.firstClassDataGridViewTextBoxColumn,
            this.secondClassDataGridViewTextBoxColumn});
            this.DGVFleet.DataSource = this.aircraftBindingSource;
            this.DGVFleet.Location = new System.Drawing.Point(51, 204);
            this.DGVFleet.MultiSelect = false;
            this.DGVFleet.Name = "DGVFleet";
            this.DGVFleet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVFleet.Size = new System.Drawing.Size(544, 168);
            this.DGVFleet.TabIndex = 13;
            this.DGVFleet.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVFleet_CellMouseClick);
            // 
            // internalIDDataGridViewTextBoxColumn
            // 
            this.internalIDDataGridViewTextBoxColumn.DataPropertyName = "InternalID";
            this.internalIDDataGridViewTextBoxColumn.HeaderText = "Aircraft ID";
            this.internalIDDataGridViewTextBoxColumn.Name = "internalIDDataGridViewTextBoxColumn";
            this.internalIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // modelDataGridViewTextBoxColumn
            // 
            this.modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
            this.modelDataGridViewTextBoxColumn.HeaderText = "Model";
            this.modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            this.modelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // firstClassDataGridViewTextBoxColumn
            // 
            this.firstClassDataGridViewTextBoxColumn.DataPropertyName = "FirstClass";
            this.firstClassDataGridViewTextBoxColumn.HeaderText = "Executive Seats";
            this.firstClassDataGridViewTextBoxColumn.Name = "firstClassDataGridViewTextBoxColumn";
            this.firstClassDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // secondClassDataGridViewTextBoxColumn
            // 
            this.secondClassDataGridViewTextBoxColumn.DataPropertyName = "SecondClass";
            this.secondClassDataGridViewTextBoxColumn.HeaderText = "Economy Seats";
            this.secondClassDataGridViewTextBoxColumn.Name = "secondClassDataGridViewTextBoxColumn";
            this.secondClassDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FleetPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGVFleet);
            this.Controls.Add(this.tbSeats);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxModel);
            this.Controls.Add(this.cboxManufacturer);
            this.Name = "FleetPanel";
            this.Size = new System.Drawing.Size(654, 375);
            ((System.ComponentModel.ISupportInitialize)(this.aircraftBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFleet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxManufacturer;
        private System.Windows.Forms.ComboBox cboxModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.MaskedTextBox tbSeats;
        private System.Windows.Forms.DataGridView DGVFleet;
        private System.Windows.Forms.DataGridViewTextBoxColumn internalIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstClassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondClassDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource aircraftBindingSource;
    }
}
