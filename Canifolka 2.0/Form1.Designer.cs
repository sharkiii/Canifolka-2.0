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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 392);
            this.Controls.Add(this.labelRightX);
            this.Controls.Add(this.label_leftY);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_leftY;
        private System.Windows.Forms.Label labelRightX;
    }
}

