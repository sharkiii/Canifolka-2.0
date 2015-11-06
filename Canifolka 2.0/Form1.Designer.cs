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
            this.label1 = new System.Windows.Forms.Label();
            this.label_leftY = new System.Windows.Forms.Label();
            this.labelRightX = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.btnPortOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Джойстик отключен";
            // 
            // label_leftY
            // 
            this.label_leftY.AutoSize = true;
            this.label_leftY.Location = new System.Drawing.Point(107, 109);
            this.label_leftY.Name = "label_leftY";
            this.label_leftY.Size = new System.Drawing.Size(67, 13);
            this.label_leftY.TabIndex = 1;
            this.label_leftY.Text = "Левый стик";
            // 
            // labelRightX
            // 
            this.labelRightX.AutoSize = true;
            this.labelRightX.Location = new System.Drawing.Point(107, 142);
            this.labelRightX.Name = "labelRightX";
            this.labelRightX.Size = new System.Drawing.Size(73, 13);
            this.labelRightX.TabIndex = 2;
            this.labelRightX.Text = "Правый стик";
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
            this.button1.Text = "SEND";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 392);
            this.Controls.Add(this.btnPortOK);
            this.Controls.Add(this.comboBoxPorts);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelRightX);
            this.Controls.Add(this.label_leftY);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_leftY;
        private System.Windows.Forms.Label labelRightX;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button btnPortOK;
    }
}

