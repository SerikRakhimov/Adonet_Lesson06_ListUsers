using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListUsers
{
    public partial class FormUserUpdate : Form
        
    {
        StatusForm statusFormWork;
        DataRow dataRowWork;

        public FormUserUpdate(StatusForm statusForm, DataRow dataRow)
        {
            InitializeComponent();

            if (statusForm == StatusForm.Add)
            {
                labelTitle.Text = "Добавление записи";
            }
            else   // if (statusForm == StatusForm.Edit) || (statusForm == StatusForm.Delete)
            {
                textBoxLogin.Text = dataRow["Login"].ToString();
                textBoxPassword.Text = dataRow["Password"].ToString();
                textBoxAddress.Text = dataRow["Address"].ToString();
                textBoxPhoneNumber.Text = dataRow["PhoneNumber"].ToString();
                checkBoxSignAdmin.Checked = (bool)dataRow["SignAdmin"];

                if (statusForm == StatusForm.Edit)
                {
                    labelTitle.Text = "Корректировка записи";
                }else // (statusForm == StatusForm.Edit)
                {
                    textBoxLogin.Enabled = false;
                    textBoxAddress.Enabled = false;
                    textBoxPhoneNumber.Enabled = false;
                    checkBoxSignAdmin.Enabled = false;
                    labelTitle.Text = "Удалить запись? (Ok - да, Отмена - нет)";
                }
            }
            statusFormWork = statusForm;
            dataRowWork = dataRow;
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if ((statusFormWork == StatusForm.Add) || (statusFormWork == StatusForm.Edit))
            {
                if (textBoxLogin.Text == "")
                {
                    MessageBox.Show("Введите логин!");
                    textBoxLogin.Focus();
                    return;
                }else if (textBoxAddress.Text == "")
                {
                    MessageBox.Show("Введите адрес!");
                    textBoxAddress.Focus();
                    return;
                }
                else if (textBoxPhoneNumber.Text == "")
                {
                    MessageBox.Show("Введите номер телефона!");
                    textBoxPhoneNumber.Focus();
                    return;
                }
            }

            if (statusFormWork == StatusForm.Add)
            {
                var usersTable = Global.DataSet.Tables["Users"];

                var tableFilter = usersTable.Select("Login = '" + textBoxLogin.Text + "'").ToList();
                if (tableFilter.Count== 0)
                {

                    DataRow row = usersTable.NewRow();

                    row.BeginEdit();
                    row["Login"] = textBoxLogin.Text;
                    row["Password"] = textBoxPassword.Text;
                    row["Address"] = textBoxAddress.Text;
                    row["PhoneNumber"] = textBoxPhoneNumber.Text;
                    row["SignAdmin"] = checkBoxSignAdmin.Checked;
                    row.EndEdit();

                    Global.DataSet.Tables["Users"].Rows.Add(row);
                }
                else
                {
                    MessageBox.Show("Логин '" + textBoxLogin.Text + "' уже существует!");
                    textBoxLogin.Focus();
                    return;
                }

            }
            else if (statusFormWork == StatusForm.Edit)
            {
                var usersTable = Global.DataSet.Tables["Users"];

                dataRowWork.BeginEdit();
                dataRowWork["Login"] = textBoxLogin.Text;
                dataRowWork["Password"] = textBoxPassword.Text;
                dataRowWork["Address"] = textBoxAddress.Text;
                dataRowWork["PhoneNumber"] = textBoxPhoneNumber.Text;
                dataRowWork["SignAdmin"] = checkBoxSignAdmin.Checked;
                dataRowWork.EndEdit();

            }
            else if (statusFormWork == StatusForm.Delete)
            {
                Global.DataSet.Tables["Users"].Rows.Remove(dataRowWork);
            }

            this.Close();

        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword.Text = textBoxLogin.Text.GetHashCode().ToString();
        }
    }
}
