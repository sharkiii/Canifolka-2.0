namespace Canifolka_2._0
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.btnPortOK = new System.Windows.Forms.Button();
            this.checkBoxStick = new System.Windows.Forms.CheckBox();
            this.checkBoxRobot = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Порты :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "ON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(351, 26);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(114, 21);
            this.comboBoxPorts.TabIndex = 5;
            this.comboBoxPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxPorts_SelectedIndexChanged);
            // 
            // btnPortOK
            // 
            this.btnPortOK.Location = new System.Drawing.Point(472, 26);
            this.btnPortOK.Name = "btnPortOK";
            this.btnPortOK.Size = new System.Drawing.Size(35, 23);
            this.btnPortOK.TabIndex = 6;
            this.btnPortOK.Text = "ОК";
            this.btnPortOK.UseVisualStyleBackColor = true;
            this.btnPortOK.Click += new System.EventHandler(this.btnPortOK_Click);
            // 
            // checkBoxStick
            // 
            this.checkBoxStick.AutoSize = true;
            this.checkBoxStick.Location = new System.Drawing.Point(35, 25);
            this.checkBoxStick.Name = "checkBoxStick";
            this.checkBoxStick.Size = new System.Drawing.Size(132, 17);
            this.checkBoxStick.TabIndex = 7;
            this.checkBoxStick.Text = "Связь с джойстиком";
            this.checkBoxStick.UseVisualStyleBackColor = true;
            // 
            // checkBoxRobot
            // 
            this.checkBoxRobot.AutoSize = true;
            this.checkBoxRobot.Location = new System.Drawing.Point(35, 59);
            this.checkBoxRobot.Name = "checkBoxRobot";
            this.checkBoxRobot.Size = new System.Drawing.Size(112, 17);
            this.checkBoxRobot.TabIndex = 8;
            this.checkBoxRobot.Text = "Связь с роботом";
            this.checkBoxRobot.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 392);
            this.Controls.Add(this.checkBoxRobot);
            this.Controls.Add(this.checkBoxStick);
            this.Controls.Add(this.btnPortOK);
            this.Controls.Add(this.comboBoxPorts);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button btnPortOK;
        private System.Windows.Forms.CheckBox checkBoxStick;
        public System.Windows.Forms.CheckBox checkBoxRobot;
    }
}

