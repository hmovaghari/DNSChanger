﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNSChanger
{
    public partial class DNSChangerForm : Form
    {
        List<DNS> dnsList = new List<DNS>();
        List<Adapter> adapterList = new List<Adapter>();

        private ModifyMode modifyMode;

        int position = -1;

        DNS current = new DNS();

        public ModifyMode ModifyMode
        {
            get { return modifyMode; }
            set
            {
                ModifyMode_Changed(value);
            }
        }

        private void ModifyMode_Changed(ModifyMode value)
        {
            switch (value)
            {
                case ModifyMode.Null:
                    ClearBinding();
                    AddDataBinding();
                    if (position != -1)
                    {
                        dnsBindingSource.Position = position;
                    }
                    cmbDNS.Visible = true;
                    txtDNS.Visible = false;
                    txtPreferred.Enabled = false;
                    txtAlternate.Enabled = false;
                    btnChange.Visible = true;
                    btnReset.Visible = true;
                    btnAdd.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    btnAccept.Visible = false;
                    btnCancel.Visible = false;
                    break;
                case ModifyMode.Add:
                case ModifyMode.Edit:
                    if (value == ModifyMode.Add)
                    {
                        ClearBindingForInsert();
                    }
                    cmbDNS.Visible = false;
                    txtDNS.Visible = true;
                    txtPreferred.Enabled = true;
                    txtAlternate.Enabled = true;
                    btnChange.Visible = false;
                    btnReset.Visible = false;
                    btnAdd.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    btnAccept.Visible = true;
                    btnCancel.Visible = true;
                    break;
            }
            modifyMode = value;
        }

        /// <summary>
        /// Bind the components to the DNS list
        /// </summary>
        private void AddDataBinding()
        {
            dnsBindingSource.DataSource = dnsList;
            cmbDNS.DataSource = dnsBindingSource;
            cmbDNS.DisplayMember = "Name";
            cmbDNS.ValueMember = "Name";
            txtDNS.DataBindings.Add("Text", dnsBindingSource, "Name");
            txtPreferred.DataBindings.Add("Text", dnsBindingSource, "Preferred");
            txtAlternate.DataBindings.Add("Text", dnsBindingSource, "Alternate");
        }

        /// <summary>
        /// Clear the components binding source from DNS list
        /// </summary>
        private void ClearBinding()
        {
            try
            {
                dnsBindingSource.DataSource = null;
            }
            catch{}
            
            cmbDNS.DataBindings.Clear();
            ClearBindingForInsert();
        }

        /// <summary>
        /// Clear binding sources of components for inserting a DNS, from DNS list
        /// </summary>
        private void ClearBindingForInsert()
        {
            txtDNS.DataBindings.Clear();
            txtPreferred.DataBindings.Clear();
            txtAlternate.DataBindings.Clear();
            txtDNS.Text = string.Empty;
            txtPreferred.Text = string.Empty;
            txtAlternate.Text = string.Empty;
        }

        /// <summary>
        /// Form Constructor
        /// </summary>
        public DNSChangerForm()
        {
            InitializeComponent();
            ReadXMLFile();
            AddAdapterBinding();
            SetModifyMode(ModifyMode.Null);
            cmbAdapter_SelectedIndexChanged(cmbAdapter, null);
        }

        
        /// <summary>
        /// Read XML file
        /// </summary>
        private void ReadXMLFile()
        {
            string error;
            DNS.ReadXMLFile(dnsList, out error);
            if (!string.IsNullOrEmpty(error))
            {
                ShowError(error);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Bind the components to the adapter list
        /// </summary>
        private void AddAdapterBinding()
        {
            Adapter.GetAdapters(adapterList);
            adapterBindingSource.DataSource = adapterList;
            cmbAdapter.DataSource = adapterBindingSource;
            cmbAdapter.DisplayMember = "Name";
            cmbAdapter.ValueMember = "Name";
            cmbAdapter.SelectedIndexChanged += cmbAdapter_SelectedIndexChanged;
        }

        /// <summary>
        /// Clear the components binding source from adapter list
        /// </summary>
        private void ClearAdapterBinding()
        {
            adapterList = new List<Adapter>();
            adapterBindingSource.Clear();
            cmbAdapter.DataSource = null;
            cmbAdapter.Items.Clear();
            cmbAdapter.SelectedIndexChanged -= cmbAdapter_SelectedIndexChanged;
        }

        /// <summary>
        /// Event of Combobox when selected:
        /// When the selected adapter connected to a DNS name of DNS list shows the message with green color
        /// else show the message with red color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAdapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var comboBox = sender as ComboBox;
            var invalidText = new List<string>() { string.Empty, "DNSChanger.Adapter" };
            if (!invalidText.Contains(cmbAdapter.Text /*comboBox.Text*/))
            {
                lblAdapter.Text = Adapter.GetDnsNameOfAdapter(adapterList, dnsList, cmbAdapter.Text /*comboBox.Text*/);
                lblAdapter.ForeColor = lblAdapter.Text.StartsWith("This adapter not connected") ? Color.Red : Color.DarkGreen;
                btnChange.Enabled = true;
                btnReset.Enabled = true;
            }
            else
            {
                lblAdapter.Text = "Adapter name not selected.";
                lblAdapter.ForeColor = Color.Red;
                btnChange.Enabled = false;
                btnReset.Enabled = false;
            }
        }

        /// <summary>
        /// Set ModifyMode to mode
        /// </summary>
        /// <param name="mode">mode of ModifyMode</param>
        private void SetModifyMode(ModifyMode mode)
        {
            ModifyMode = mode;
        }

        /// <summary>
        /// Change DNS of adapter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, EventArgs e)
        {
            ChangeOrResetAdapterDNS(isChange: true);
        }

        /// <summary>
        /// Reset DNS of adapter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ChangeOrResetAdapterDNS(isChange: false);
        }

        /// <summary>
        /// Change or Reset DNS of adapter
        /// </summary>
        /// <param name="isChange"></param>
        private void ChangeOrResetAdapterDNS(bool isChange)
        {
            Thread pleaseWaitThread = new Thread(LoadingFunction);
            pleaseWaitThread.Start();
            position = adapterBindingSource.Position;
            if (isChange)
            {
                Adapter.ChangeAdapterDNS(cmbAdapter.Text, txtPreferred.Text, txtAlternate.Text);
            }
            else
            {
                Adapter.ResetAdapterDNS(cmbAdapter.Text);
            }
            SendKeys.SendWait("{Esc}");//Enter or Esc// Close loadingForm
            pleaseWaitThread.Abort();
            ClearAdapterBinding();
            AddAdapterBinding();
            adapterBindingSource.Position = position;
            cmbAdapter_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// Please wait loading form
        /// </summary>
        public void LoadingFunction()
        {
            LoadingForm loadingForm = new LoadingForm();
            loadingForm.Location = new Point(Location.X + 90  , Location.Y + 90);
            loadingForm.ShowDialog();
        }

        /// <summary>
        /// Add a new DNS to DNS list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            position = dnsBindingSource.Count - 1;
            SetModifyMode(ModifyMode.Add);
        }

        /// <summary>
        /// Edit a DNS in DNS list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            position = dnsBindingSource.Position;
            var currentDNS = dnsBindingSource.Current as DNS;
            current = new DNS
            {
                Name = currentDNS.Name,
                Preferred = currentDNS.Preferred,
                Alternate = currentDNS.Alternate
            };
            SetModifyMode(ModifyMode.Edit);
        }

        /// <summary>
        /// Remove a DNS from DNS list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var current = dnsBindingSource.Current as DNS;
            string error;
            DNS.DeleteDNS(current, out error);
            if (!IsErrorOccurred(error))
            {
                dnsList.Remove(current);
            }
            SetModifyMode(ModifyMode.Null);
        }

        /// <summary>
        /// Accept: (Add / Edit a DNS)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ChangeXML(ModifyMode))
            {
                SetModifyMode(ModifyMode.Null);
            }
        }

        /// <summary>
        /// Chane in XML file and DNS list (Add or Edit a DNS)
        /// </summary>
        /// <param name="modifyMode"></param>
        /// <returns></returns>
        private bool ChangeXML(ModifyMode modifyMode)
        {
            
            switch (modifyMode)
            {
                case ModifyMode.Add:
                    return AddXML();
                case ModifyMode.Edit:
                    return EditXML();
                default:
                    return false;
            }
        }

        /// <summary>
        /// Edit a DNS in XML file AND DNS list
        /// </summary>
        /// <returns></returns>
        private bool EditXML()
        {
            string error = null;
            if (!IsExistsDupicateName(error))
            {
                return false;
            }
            var newDNS = new DNS()
            {
                Name = txtDNS.Text,
                Preferred = txtPreferred.Text,
                Alternate = txtAlternate.Text
            };
            DNS.EditXML(oldDNS: this.current, newDNS, out error);
            if (IsErrorOccurred(error))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Add a new DNS in XML file and XML list
        /// </summary>
        /// <returns></returns>
        private bool AddXML()
        {
            string error = null;
            if (!IsExistsDupicateName(error))
            {
                return false;
            }
            DNS dns = new DNS()
            {
                Name = txtDNS.Text,
                Preferred = txtPreferred.Text,
                Alternate = txtAlternate.Text
            };
            DNS.WriteXML(dns, isAppend: true, out error);
            if (IsErrorOccurred(error))
            {
                return false;
            }
            dnsList.Add(dns);
            ++position;
            return true;
        }

        /// <summary>
        /// Is exists duplicate name
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        private bool IsExistsDupicateName(string error)
        {
            if (DNS.IsExistsDuplicateName(dnsList, txtDNS.Text, out error, modifyMode))
            {
                ShowError(error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Is error occurred:
        /// When the 'error' variable is not null, it means an error has occurred. And the error message stored in this variable.
        /// </summary>
        /// <param name="error">Error variable</param>
        /// <returns></returns>
        public static bool IsErrorOccurred(string error)
        {
            if (!string.IsNullOrEmpty(error))
            {
                ShowError(error);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Cancel Add or Edit a DNS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            position = modifyMode == ModifyMode.Add ? -1 : position;
            if (modifyMode == ModifyMode.Edit)
            {
                var obj = dnsList.FirstOrDefault(x => x == dnsBindingSource.Current);
                if (current != null)
                {
                    obj.Name = current.Name;
                    obj.Preferred = current.Preferred;
                    obj.Alternate = current.Alternate;
                }
            }
            SetModifyMode(ModifyMode.Null);
        }

        /// <summary>
        /// Show the error message stored in error variable
        /// </summary>
        /// <param name="error">Error variable</param>
        public static void ShowError(string error)
        {
            MessageBox.Show(error, "Error occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
