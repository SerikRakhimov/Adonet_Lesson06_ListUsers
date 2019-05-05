namespace ListUsers
{
    partial class FormListUsers
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.butAdd = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.butDataLoad = new System.Windows.Forms.Button();
            this.labelText = new System.Windows.Forms.Label();
            this.butExit = new System.Windows.Forms.Button();
            this.butDataUpdate = new System.Windows.Forms.Button();
            this.checkBoxShowAdmins = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.ItemHeight = 17;
            this.listBoxUsers.Location = new System.Drawing.Point(133, 63);
            this.listBoxUsers.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(651, 293);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.DoubleClick += new System.EventHandler(this.listBoxUsers_DoubleClick);
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(255, 455);
            this.butAdd.Margin = new System.Windows.Forms.Padding(4);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(137, 37);
            this.butAdd.TabIndex = 1;
            this.butAdd.Text = "Добавить";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(512, 455);
            this.butDelete.Margin = new System.Windows.Forms.Padding(4);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(139, 37);
            this.butDelete.TabIndex = 2;
            this.butDelete.Text = "Удалить";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butDataLoad
            // 
            this.butDataLoad.Location = new System.Drawing.Point(833, 63);
            this.butDataLoad.Margin = new System.Windows.Forms.Padding(4);
            this.butDataLoad.Name = "butDataLoad";
            this.butDataLoad.Size = new System.Drawing.Size(141, 62);
            this.butDataLoad.TabIndex = 4;
            this.butDataLoad.Text = "Загрузить с основной базы";
            this.butDataLoad.UseVisualStyleBackColor = true;
            this.butDataLoad.Click += new System.EventHandler(this.butDataLoad_Click);
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(283, 394);
            this.labelText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(326, 17);
            this.labelText.TabIndex = 5;
            this.labelText.Text = "Для корректировки щелкните мышкой два раза";
            this.labelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelText.UseWaitCursor = true;
            // 
            // butExit
            // 
            this.butExit.Location = new System.Drawing.Point(833, 295);
            this.butExit.Margin = new System.Windows.Forms.Padding(4);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(141, 60);
            this.butExit.TabIndex = 6;
            this.butExit.Text = "Выход с программы";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butDataUpdate
            // 
            this.butDataUpdate.Location = new System.Drawing.Point(833, 181);
            this.butDataUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.butDataUpdate.Name = "butDataUpdate";
            this.butDataUpdate.Size = new System.Drawing.Size(141, 60);
            this.butDataUpdate.TabIndex = 7;
            this.butDataUpdate.Text = "Обновить в основной базе";
            this.butDataUpdate.UseVisualStyleBackColor = true;
            this.butDataUpdate.Click += new System.EventHandler(this.butDataUpdate_Click);
            // 
            // checkBoxShowAdmins
            // 
            this.checkBoxShowAdmins.AutoSize = true;
            this.checkBoxShowAdmins.Location = new System.Drawing.Point(133, 35);
            this.checkBoxShowAdmins.Name = "checkBoxShowAdmins";
            this.checkBoxShowAdmins.Size = new System.Drawing.Size(195, 21);
            this.checkBoxShowAdmins.TabIndex = 8;
            this.checkBoxShowAdmins.Text = "Вывести только админов";
            this.checkBoxShowAdmins.UseVisualStyleBackColor = true;
            this.checkBoxShowAdmins.CheckedChanged += new System.EventHandler(this.checkBoxShowAdmins_CheckedChanged);
            // 
            // FormListUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 554);
            this.Controls.Add(this.checkBoxShowAdmins);
            this.Controls.Add(this.butDataUpdate);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.butDataLoad);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.listBoxUsers);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormListUsers";
            this.Text = "Список пользователей";
            this.Load += new System.EventHandler(this.FormListUsers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butDataLoad;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Button butDataUpdate;
        private System.Windows.Forms.CheckBox checkBoxShowAdmins;
    }
}

