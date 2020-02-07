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
            this.aircraftBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbEdit = new System.Windows.Forms.GroupBox();
            this.tbEcon = new System.Windows.Forms.MaskedTextBox();
            this.tbExec = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.gbEditBtns = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFleet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aircraftBindingSource)).BeginInit();
            this.gbEdit.SuspendLayout();
            this.gbButtons.SuspendLayout();
            this.gbEditBtns.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Manufacturer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Model";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total Seats";
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(6, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 47);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add Aircraft";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(6, 72);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(76, 47);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit Aircraft";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(6, 125);
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
//            this.tbSeats.Enter += new System.EventHandler(this.tbSeats_Enter);
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
            // aircraftBindingSource
            // 
            this.aircraftBindingSource.DataSource = typeof(ClassLibrary.Aircraft);
            // 
            // gbEdit
            // 
            this.gbEdit.Controls.Add(this.tbEcon);
            this.gbEdit.Controls.Add(this.tbExec);
            this.gbEdit.Controls.Add(this.label5);
            this.gbEdit.Controls.Add(this.label4);
            this.gbEdit.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEdit.Location = new System.Drawing.Point(395, 88);
            this.gbEdit.Name = "gbEdit";
            this.gbEdit.Size = new System.Drawing.Size(160, 100);
            this.gbEdit.TabIndex = 14;
            this.gbEdit.TabStop = false;
            this.gbEdit.Text = "Edit Seats";
            this.gbEdit.Visible = false;
            // 
            // tbEcon
            // 
            this.tbEcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEcon.Location = new System.Drawing.Point(86, 46);
            this.tbEcon.Mask = "000";
            this.tbEcon.Name = "tbEcon";
            this.tbEcon.Size = new System.Drawing.Size(25, 20);
            this.tbEcon.TabIndex = 9;
            this.tbEcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbEcon_MouseClick);
            // 
            // tbExec
            // 
            this.tbExec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExec.Location = new System.Drawing.Point(9, 46);
            this.tbExec.Mask = "000";
            this.tbExec.Name = "tbExec";
            this.tbExec.Size = new System.Drawing.Size(25, 20);
            this.tbExec.TabIndex = 8;
            this.tbExec.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbExec_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(83, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Economy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Executive";
            // 
            // gbButtons
            // 
            this.gbButtons.Controls.Add(this.btnAdd);
            this.gbButtons.Controls.Add(this.btnEdit);
            this.gbButtons.Controls.Add(this.btnDelete);
            this.gbButtons.Location = new System.Drawing.Point(248, 3);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Size = new System.Drawing.Size(89, 185);
            this.gbButtons.TabIndex = 15;
            this.gbButtons.TabStop = false;
            // 
            // gbEditBtns
            // 
            this.gbEditBtns.Controls.Add(this.btnSave);
            this.gbEditBtns.Controls.Add(this.btnCancel);
            this.gbEditBtns.Location = new System.Drawing.Point(561, 3);
            this.gbEditBtns.Name = "gbEditBtns";
            this.gbEditBtns.Size = new System.Drawing.Size(89, 185);
            this.gbEditBtns.TabIndex = 16;
            this.gbEditBtns.TabStop = false;
            this.gbEditBtns.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(6, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 47);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(6, 72);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 47);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel Changes";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FleetPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbEditBtns);
            this.Controls.Add(this.gbButtons);
            this.Controls.Add(this.gbEdit);
            this.Controls.Add(this.DGVFleet);
            this.Controls.Add(this.tbSeats);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxModel);
            this.Controls.Add(this.cboxManufacturer);
            this.Name = "FleetPanel";
            this.Size = new System.Drawing.Size(654, 375);
            ((System.ComponentModel.ISupportInitialize)(this.DGVFleet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aircraftBindingSource)).EndInit();
            this.gbEdit.ResumeLayout(false);
            this.gbEdit.PerformLayout();
            this.gbButtons.ResumeLayout(false);
            this.gbEditBtns.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox gbEdit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox tbEcon;
        private System.Windows.Forms.MaskedTextBox tbExec;
        private System.Windows.Forms.GroupBox gbButtons;
        private System.Windows.Forms.GroupBox gbEditBtns;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
