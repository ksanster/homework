
namespace Ex1
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
            this.lblValue = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.btnReset = new System.Windows.Forms.Button();
            this.menuPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblValue.Location = new System.Drawing.Point(12, 38);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(68, 23);
            this.lblValue.TabIndex = 0;
            this.lblValue.Text = "label1";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.Location = new System.Drawing.Point(207, 42);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+1";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMultiply
            // 
            this.btnMultiply.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMultiply.Location = new System.Drawing.Point(207, 81);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(75, 23);
            this.btnMultiply.TabIndex = 2;
            this.btnMultiply.Text = "*2";
            this.btnMultiply.UseVisualStyleBackColor = true;
            this.btnMultiply.Click += new System.EventHandler(this.btnMultiply_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.Location = new System.Drawing.Point(207, 119);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Отмена";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPlay});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(294, 24);
            this.menuMain.TabIndex = 4;
            this.menuMain.Text = "menuStrip1";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReset.Location = new System.Drawing.Point(207, 157);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // menuPlay
            // 
            this.menuPlay.Name = "menuPlay";
            this.menuPlay.Size = new System.Drawing.Size(57, 20);
            this.menuPlay.Text = "Играть";
            this.menuPlay.Click += new System.EventHandler(this.menuPlay_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 211);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.Text = "Удвоитель";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnMultiply;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ToolStripMenuItem menuPlay;
    }
}

