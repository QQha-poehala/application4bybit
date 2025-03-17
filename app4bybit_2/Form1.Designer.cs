namespace app4bybit_2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            настройкаУведомленийToolStripMenuItem = new ToolStripMenuItem();
            оформлениеToolStripMenuItem = new ToolStripMenuItem();
            terminal = new RichTextBox();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.FloralWhite;
            label1.Location = new Point(41, 173);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(153, 39);
            label1.TabIndex = 0;
            label1.Text = "Консоль";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(14, 42);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(258, 113);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { настройкаУведомленийToolStripMenuItem, оформлениеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(933, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // настройкаУведомленийToolStripMenuItem
            // 
            настройкаУведомленийToolStripMenuItem.Name = "настройкаУведомленийToolStripMenuItem";
            настройкаУведомленийToolStripMenuItem.Size = new Size(155, 20);
            настройкаУведомленийToolStripMenuItem.Text = "Настройка уведомлений";
            // 
            // оформлениеToolStripMenuItem
            // 
            оформлениеToolStripMenuItem.Name = "оформлениеToolStripMenuItem";
            оформлениеToolStripMenuItem.Size = new Size(93, 20);
            оформлениеToolStripMenuItem.Text = "Оформление";
            оформлениеToolStripMenuItem.Click += ColorToolStripMenuItem_Click;
            // 
            // terminal
            // 
            terminal.BackColor = SystemColors.WindowText;
            terminal.ForeColor = SystemColors.Menu;
            terminal.Location = new Point(28, 222);
            terminal.Margin = new Padding(4, 3, 4, 3);
            terminal.Name = "terminal";
            terminal.ScrollBars = RichTextBoxScrollBars.Vertical;
            terminal.Size = new Size(891, 401);
            terminal.TabIndex = 3;
            terminal.Text = "";
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(299, 42);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(117, 35);
            button1.TabIndex = 4;
            button1.Text = "Активы";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.ForeColor = Color.Black;
            button2.Location = new Point(789, 152);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(117, 35);
            button2.TabIndex = 5;
            button2.Text = "Очистить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(933, 637);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(terminal);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            ForeColor = Color.Navy;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Bybit";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem настройкаУведомленийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оформлениеToolStripMenuItem;
        private System.Windows.Forms.RichTextBox terminal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

