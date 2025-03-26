namespace AuctionServiceClientDesktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GroupBox groupBox1;
            listBoxUsers = new ListBox();
            labelProcessText = new Label();
            buttonGetUsers = new Button();
            groupBox2 = new GroupBox();
            labelProcessSave = new Label();
            buttonSaveUser = new Button();
            textBoxEmail = new TextBox();
            label2 = new Label();
            textBoxUsername = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBoxUsers);
            groupBox1.Controls.Add(labelProcessText);
            groupBox1.Controls.Add(buttonGetUsers);
            groupBox1.Location = new Point(33, 32);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(302, 357);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Get users";
            // 
            // listBoxUsers
            // 
            listBoxUsers.FormattingEnabled = true;
            listBoxUsers.Location = new Point(6, 67);
            listBoxUsers.Name = "listBoxUsers";
            listBoxUsers.Size = new Size(290, 264);
            listBoxUsers.TabIndex = 2;
            // 
            // labelProcessText
            // 
            labelProcessText.AutoSize = true;
            labelProcessText.Location = new Point(6, 334);
            labelProcessText.Name = "labelProcessText";
            labelProcessText.Size = new Size(15, 20);
            labelProcessText.TabIndex = 1;
            labelProcessText.Text = "..";
            // 
            // buttonGetUsers
            // 
            buttonGetUsers.Location = new Point(167, 26);
            buttonGetUsers.Name = "buttonGetUsers";
            buttonGetUsers.Size = new Size(129, 35);
            buttonGetUsers.TabIndex = 0;
            buttonGetUsers.Text = "Get All Users";
            buttonGetUsers.UseVisualStyleBackColor = true;
            buttonGetUsers.Click += ButtonGetUsers_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(labelProcessSave);
            groupBox2.Controls.Add(buttonSaveUser);
            groupBox2.Controls.Add(this.textBoxEmail);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBoxUsername);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(443, 43);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(316, 342);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Insert user";
            // 
            // labelProcessSave
            // 
            labelProcessSave.AutoSize = true;
            labelProcessSave.Location = new Point(21, 310);
            labelProcessSave.Name = "labelProcessSave";
            labelProcessSave.Size = new Size(15, 20);
            labelProcessSave.TabIndex = 7;
            labelProcessSave.Text = "..";
            // 
            // buttonSaveUser
            // 
            buttonSaveUser.Location = new Point(86, 191);
            buttonSaveUser.Name = "buttonSaveUser";
            buttonSaveUser.Size = new Size(129, 35);
            buttonSaveUser.TabIndex = 6;
            buttonSaveUser.Text = "Save User";
            buttonSaveUser.UseVisualStyleBackColor = true;
            buttonSaveUser.Click += ButtonSaveUser_Click;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new Point(40, 142);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new Size(233, 27);
            this.textBoxEmail.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 119);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 2;
            label2.Text = "Email:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(40, 71);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(233, 27);
            textBoxUsername.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 48);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label labelProcessText;
        private Button buttonGetUsers;
        private ListBox listBoxUsers;
        private GroupBox groupBox2;
        private Label labelProcessSave;
        private Button buttonSaveUser;
        private Label label3;
        private TextBox textBoxEmail;
        private Label label2;
        private TextBox textBoxUsername;
        private Label label1;
    }
}
