namespace ExampleMessageBoxTask
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.fieldTimeout = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fieldMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fieldButtons = new System.Windows.Forms.ComboBox();
            this.fieldIcons = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fieldDefaultButton = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fieldTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 160);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(323, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Create MessageBoxTask";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fieldTimeout
            // 
            this.fieldTimeout.Location = new System.Drawing.Point(170, 10);
            this.fieldTimeout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fieldTimeout.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.fieldTimeout.Name = "fieldTimeout";
            this.fieldTimeout.Size = new System.Drawing.Size(160, 22);
            this.fieldTimeout.TabIndex = 1;
            this.fieldTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fieldTimeout.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Timeout in seconds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Message";
            // 
            // fieldMessage
            // 
            this.fieldMessage.Location = new System.Drawing.Point(81, 40);
            this.fieldMessage.Name = "fieldMessage";
            this.fieldMessage.Size = new System.Drawing.Size(249, 22);
            this.fieldMessage.TabIndex = 4;
            this.fieldMessage.Text = "Some simple text for example";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Buttons";
            // 
            // fieldButtons
            // 
            this.fieldButtons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fieldButtons.FormattingEnabled = true;
            this.fieldButtons.Items.AddRange(new object[] {
            "AbortRetryIgnore",
            "OK",
            "OKCancel",
            "RetryCancel",
            "YesNo",
            "YesNoCancel"});
            this.fieldButtons.Location = new System.Drawing.Point(81, 70);
            this.fieldButtons.Name = "fieldButtons";
            this.fieldButtons.Size = new System.Drawing.Size(251, 24);
            this.fieldButtons.TabIndex = 6;
            // 
            // fieldIcons
            // 
            this.fieldIcons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fieldIcons.FormattingEnabled = true;
            this.fieldIcons.Items.AddRange(new object[] {
            "Asterisk",
            "Error",
            "Exclamation",
            "Hand",
            "Information",
            "None",
            "Question",
            "Stop",
            "Warning"});
            this.fieldIcons.Location = new System.Drawing.Point(81, 100);
            this.fieldIcons.Name = "fieldIcons";
            this.fieldIcons.Size = new System.Drawing.Size(251, 24);
            this.fieldIcons.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Icons";
            // 
            // fieldDefaultButton
            // 
            this.fieldDefaultButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fieldDefaultButton.FormattingEnabled = true;
            this.fieldDefaultButton.Items.AddRange(new object[] {
            "Button1",
            "Button2",
            "Button3"});
            this.fieldDefaultButton.Location = new System.Drawing.Point(130, 130);
            this.fieldDefaultButton.Name = "fieldDefaultButton";
            this.fieldDefaultButton.Size = new System.Drawing.Size(203, 24);
            this.fieldDefaultButton.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "DefaultButton";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 197);
            this.Controls.Add(this.fieldDefaultButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fieldIcons);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fieldButtons);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fieldMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fieldTimeout);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Example of message with closing timeout";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fieldTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown fieldTimeout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fieldMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox fieldButtons;
        private System.Windows.Forms.ComboBox fieldIcons;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox fieldDefaultButton;
        private System.Windows.Forms.Label label5;
    }
}

