namespace ValeraCinema.Pages
{
    partial class Admin_panel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_panel));
            this.all_users = new System.Windows.Forms.DataGridView();
            this.all_operators = new System.Windows.Forms.DataGridView();
            this.users = new System.Windows.Forms.Label();
            this.operators = new System.Windows.Forms.Label();
            this.btnSetOperater = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCloseWindow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.all_users)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.all_operators)).BeginInit();
            this.SuspendLayout();
            // 
            // all_users
            // 
            this.all_users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.all_users.Location = new System.Drawing.Point(27, 34);
            this.all_users.Name = "all_users";
            this.all_users.Size = new System.Drawing.Size(307, 357);
            this.all_users.TabIndex = 0;
            // 
            // all_operators
            // 
            this.all_operators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.all_operators.Location = new System.Drawing.Point(511, 34);
            this.all_operators.Name = "all_operators";
            this.all_operators.Size = new System.Drawing.Size(307, 357);
            this.all_operators.TabIndex = 1;
            // 
            // users
            // 
            this.users.AutoSize = true;
            this.users.BackColor = System.Drawing.Color.Transparent;
            this.users.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.users.ForeColor = System.Drawing.SystemColors.Control;
            this.users.Location = new System.Drawing.Point(24, 9);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(231, 18);
            this.users.TabIndex = 2;
            this.users.Text = "Все пользователи системы:";
            // 
            // operators
            // 
            this.operators.AutoSize = true;
            this.operators.BackColor = System.Drawing.Color.Transparent;
            this.operators.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operators.ForeColor = System.Drawing.SystemColors.Control;
            this.operators.Location = new System.Drawing.Point(508, 9);
            this.operators.Name = "operators";
            this.operators.Size = new System.Drawing.Size(205, 18);
            this.operators.TabIndex = 3;
            this.operators.Text = "Все операторы системы:";
            // 
            // btnSetOperater
            // 
            this.btnSetOperater.Location = new System.Drawing.Point(340, 118);
            this.btnSetOperater.Name = "btnSetOperater";
            this.btnSetOperater.Size = new System.Drawing.Size(80, 155);
            this.btnSetOperater.TabIndex = 4;
            this.btnSetOperater.Text = "Назначить оператора";
            this.btnSetOperater.UseVisualStyleBackColor = true;
            this.btnSetOperater.Click += new System.EventHandler(this.btnSetOperater_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(426, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 155);
            this.button2.TabIndex = 5;
            this.button2.Text = "Отменить оператора";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnDelOperater_Click);
            // 
            // btnCloseWindow
            // 
            this.btnCloseWindow.Location = new System.Drawing.Point(340, 279);
            this.btnCloseWindow.Name = "btnCloseWindow";
            this.btnCloseWindow.Size = new System.Drawing.Size(165, 60);
            this.btnCloseWindow.TabIndex = 6;
            this.btnCloseWindow.Text = "Вернуться на главную";
            this.btnCloseWindow.UseVisualStyleBackColor = true;
            this.btnCloseWindow.Click += new System.EventHandler(this.btnCloseWindow_Click);
            // 
            // Admin_panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(830, 428);
            this.Controls.Add(this.btnCloseWindow);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSetOperater);
            this.Controls.Add(this.operators);
            this.Controls.Add(this.users);
            this.Controls.Add(this.all_operators);
            this.Controls.Add(this.all_users);
            this.Name = "Admin_panel";
            this.Text = "Панель администратора";
            this.Load += new System.EventHandler(this.Admin_panel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.all_users)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.all_operators)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView all_users;
        private System.Windows.Forms.DataGridView all_operators;
        private System.Windows.Forms.Label users;
        private System.Windows.Forms.Label operators;
        private System.Windows.Forms.Button btnSetOperater;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCloseWindow;
    }
}