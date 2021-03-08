
namespace Ex2
{
    partial class MainForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.lblTryResult = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(385, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Угадай число от 1 до 100";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inputBox
            // 
            this.inputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputBox.Location = new System.Drawing.Point(121, 65);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(137, 20);
            this.inputBox.TabIndex = 1;
            this.inputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.inputBox_KeyUp);
            // 
            // btnInput
            // 
            this.btnInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInput.Location = new System.Drawing.Point(121, 128);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(137, 23);
            this.btnInput.TabIndex = 2;
            this.btnInput.Text = "Ввести";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // lblTryResult
            // 
            this.lblTryResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTryResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTryResult.Location = new System.Drawing.Point(0, 26);
            this.lblTryResult.Name = "lblTryResult";
            this.lblTryResult.Size = new System.Drawing.Size(385, 26);
            this.lblTryResult.TabIndex = 3;
            this.lblTryResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(121, 170);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(137, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Играть заново";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 205);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblTryResult);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.lblTitle);
            this.Name = "MainForm";
            this.Text = "Угадай число";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Label lblTryResult;
        private System.Windows.Forms.Button btnReset;
    }
}

