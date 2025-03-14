namespace DNSChanger
{
    partial class DNSChangerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DNSChangerForm));
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDNS = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPreferred = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAlternate = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtDNS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAdapter = new System.Windows.Forms.ComboBox();
            this.lblAdapter = new System.Windows.Forms.Label();
            this.dnsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.adapterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.btnDisableIPv6 = new System.Windows.Forms.Button();
            this.btnEnableIPv6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dnsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adapterBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "DNS Name:";
            // 
            // cmbDNS
            // 
            this.cmbDNS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDNS.FormattingEnabled = true;
            this.cmbDNS.Location = new System.Drawing.Point(89, 89);
            this.cmbDNS.Name = "cmbDNS";
            this.cmbDNS.Size = new System.Drawing.Size(193, 21);
            this.cmbDNS.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Preferred ID:";
            // 
            // txtPreferred
            // 
            this.txtPreferred.Location = new System.Drawing.Point(89, 129);
            this.txtPreferred.Name = "txtPreferred";
            this.txtPreferred.Size = new System.Drawing.Size(192, 20);
            this.txtPreferred.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Alternate ID:";
            // 
            // txtAlternate
            // 
            this.txtAlternate.Location = new System.Drawing.Point(89, 172);
            this.txtAlternate.Name = "txtAlternate";
            this.txtAlternate.Size = new System.Drawing.Size(192, 20);
            this.txtAlternate.TabIndex = 6;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(7, 16);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(133, 23);
            this.btnChange.TabIndex = 7;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(103, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(88, 23);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(195, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(147, 16);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(134, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset to default";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(9, 16);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(181, 23);
            this.btnAccept.TabIndex = 12;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(196, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDNS
            // 
            this.txtDNS.Location = new System.Drawing.Point(89, 90);
            this.txtDNS.Margin = new System.Windows.Forms.Padding(1);
            this.txtDNS.Name = "txtDNS";
            this.txtDNS.Size = new System.Drawing.Size(192, 20);
            this.txtDNS.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Adapter Name:";
            // 
            // cmbAdapter
            // 
            this.cmbAdapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdapter.FormattingEnabled = true;
            this.cmbAdapter.Location = new System.Drawing.Point(89, 26);
            this.cmbAdapter.Name = "cmbAdapter";
            this.cmbAdapter.Size = new System.Drawing.Size(193, 21);
            this.cmbAdapter.TabIndex = 15;
            // 
            // lblAdapter
            // 
            this.lblAdapter.AutoSize = true;
            this.lblAdapter.Location = new System.Drawing.Point(6, 57);
            this.lblAdapter.Name = "lblAdapter";
            this.lblAdapter.Size = new System.Drawing.Size(137, 13);
            this.lblAdapter.TabIndex = 16;
            this.lblAdapter.Text = "Adapter name not selected.";
            // 
            // Timer
            // 
            this.Timer.Interval = 1;
            // 
            // btnDisableIPv6
            // 
            this.btnDisableIPv6.Location = new System.Drawing.Point(146, 43);
            this.btnDisableIPv6.Name = "btnDisableIPv6";
            this.btnDisableIPv6.Size = new System.Drawing.Size(134, 23);
            this.btnDisableIPv6.TabIndex = 17;
            this.btnDisableIPv6.Text = "Disable IPv6";
            this.btnDisableIPv6.UseVisualStyleBackColor = true;
            this.btnDisableIPv6.Click += new System.EventHandler(this.btnDisableIPv6_Click);
            // 
            // btnEnableIPv6
            // 
            this.btnEnableIPv6.Location = new System.Drawing.Point(7, 43);
            this.btnEnableIPv6.Name = "btnEnableIPv6";
            this.btnEnableIPv6.Size = new System.Drawing.Size(134, 23);
            this.btnEnableIPv6.TabIndex = 18;
            this.btnEnableIPv6.Text = "Enable IPv6";
            this.btnEnableIPv6.UseVisualStyleBackColor = true;
            this.btnEnableIPv6.Click += new System.EventHandler(this.btnEnableIPv6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnEnableIPv6);
            this.groupBox1.Controls.Add(this.btnChange);
            this.groupBox1.Controls.Add(this.btnDisableIPv6);
            this.groupBox1.Location = new System.Drawing.Point(6, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 75);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change adapter settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnAccept);
            this.groupBox2.Location = new System.Drawing.Point(5, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 48);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change DNS list";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblAdapter);
            this.groupBox3.Controls.Add(this.cmbDNS);
            this.groupBox3.Controls.Add(this.cmbAdapter);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtPreferred);
            this.groupBox3.Controls.Add(this.txtDNS);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtAlternate);
            this.groupBox3.Location = new System.Drawing.Point(6, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(291, 201);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DNS and adapter info";
            // 
            // DNSChangerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 353);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DNSChangerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DNS Changer";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.DNSChangerForm_HelpButtonClicked);
            this.Load += new System.EventHandler(this.DNSChangerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dnsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adapterBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDNS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPreferred;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAlternate;
        private System.Windows.Forms.BindingSource dnsBindingSource;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtDNS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAdapter;
        private System.Windows.Forms.Label lblAdapter;
        private System.Windows.Forms.BindingSource adapterBindingSource;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Button btnDisableIPv6;
        private System.Windows.Forms.Button btnEnableIPv6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}