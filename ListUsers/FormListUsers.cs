using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Configuration;

namespace ListUsers
{
    public partial class FormListUsers : Form
    {
        public string filter;
        public FormListUsers()
        {
            InitializeComponent();
        }
        public FormListUsers(int a)
        {
            InitializeComponent();
            Global.DataSet = new DataSet();
        }

        private void FormListUsers_Load(object sender, EventArgs e)
        {

            DataLoad();

            ListBoxUpdate();

        }
        private void butDataLoad_Click(object sender, EventArgs e)
        {

            ClearUserTable();

            DataLoad();

            ListBoxUpdate();

        }

        private void butExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void butDataUpdate_Click(object sender, EventArgs e)
        {

            DataUpdate();

            //ClearUserTable();

            //DataLoad();

            //ListBoxUpdate();


        }

        public void DataLoad()
        {
            var configuration = ConfigurationManager.ConnectionStrings["appConnection"];
            var providerName = configuration.ProviderName;
            var connectioString = configuration.ConnectionString;
            var providerFactory = DbProviderFactories.GetFactory(providerName);

            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectioString;
                var dataAdapter = providerFactory.CreateDataAdapter();
                var selectUsersCommand = connection.CreateCommand();

                selectUsersCommand.CommandText = "select * from Users";
                dataAdapter.SelectCommand = selectUsersCommand;

                try
                {
                    dataAdapter.Fill(Global.DataSet, "Users");

                    // класс, на основании select добавляет insert, update, delete
                    var commandBuilder = providerFactory.CreateCommandBuilder();
                    commandBuilder.DataAdapter = dataAdapter;

                    MessageBox.Show("Из основной базы загружены данные в локальную асинхронную таблицу.");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }
        }

        public void DataUpdate()
            {
            var configuration = ConfigurationManager.ConnectionStrings["appConnection"];
            var providerName = configuration.ProviderName;
            var connectioString = configuration.ConnectionString;
            var providerFactory = DbProviderFactories.GetFactory(providerName);

            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectioString;
                //                dataSet = new DataSet("users");
                var dataAdapter = providerFactory.CreateDataAdapter();
                var selectUsersCommand = connection.CreateCommand();

                selectUsersCommand.CommandText = "select * from Users";
                dataAdapter.SelectCommand = selectUsersCommand;

                // класс, на основании select добавляет insert, update, delete
                var commandBuilder = providerFactory.CreateCommandBuilder();
                commandBuilder.DataAdapter = dataAdapter;

                try
                {
                    dataAdapter.Update(Global.DataSet, "Users");
                    MessageBox.Show("Данные из локальной асинхронной таблицы обновлены в основной базе.");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }
        public void ListBoxUpdate()
        {
            string format;
            bool sign;

            listBoxUsers.Items.Clear();

            if (checkBoxShowAdmins.Checked == true)
            {
                filter = "SignAdmin = true";
            }
            else
            {
                filter = "";
            }
            var usersTable = Global.DataSet.Tables["Users"].Select(filter).OrderBy(u => u["Login"]).ToList();

            for (int i = 0; i < usersTable.Count; i++)
            {
                format = usersTable[i]["Login"].ToString() + " ~ "
                    + usersTable[i]["Password"].ToString() + " ~ "
                    + usersTable[i]["Address"].ToString() + " ~ "
                    + usersTable[i]["PhoneNumber"].ToString();
                sign = (bool)usersTable[i]["SignAdmin"];

                if (sign == false)
                {
                    format = format + "        ";
                }
                else
                {
                    format = format + " ~ админ";
                }

                listBoxUsers.Items.Add(format);
            }

            if (usersTable.Count != 0)
            {
                listBoxUsers.SetSelected(0, true);
            }

        }

        public void ClearUserTable()
        {
            Global.DataSet.Tables["Users"].Rows.Clear();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            DataRow rw = null;
            Form ifrm = new FormUserUpdate(StatusForm.Add, rw);
            ifrm.ShowDialog();

            var usersTable = Global.DataSet.Tables["Users"];
            int cn = usersTable.Rows.Count;

            ListBoxUpdate();

        }

        private void listBoxUsers_DoubleClick(object sender, EventArgs e)
        {
            // двойное нажатие
            DataRow dataRowWork = Global.DataSet.Tables["Users"].Select(filter).OrderBy(u => u["Login"]).ToList()[listBoxUsers.SelectedIndex];
            Form formUser = new FormUserUpdate(StatusForm.Edit, dataRowWork);
            formUser.ShowDialog();

            ListBoxUpdate();

        }
        private void butDelete_Click(object sender, EventArgs e)
        {
            DataRow dataRowWork = Global.DataSet.Tables["Users"].Select(filter).OrderBy(u => u["Login"]).ToList()[listBoxUsers.SelectedIndex];
            Form formUser = new FormUserUpdate(StatusForm.Delete, dataRowWork);
            formUser.ShowDialog();

            ListBoxUpdate();

        }

        private void checkBoxShowAdmins_CheckedChanged(object sender, EventArgs e)
        {
            ListBoxUpdate();       
        }

    }
}
