namespace Лаба_про_граф
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
            this.components = new System.ComponentModel.Container();
            this.addButton = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.optimizeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.isFinalState = new System.Windows.Forms.CheckBox();
            this.stepButton = new System.Windows.Forms.Button();
            this.nodeContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.nodeContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 74);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(6, 48);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 20);
            this.nameBox.TabIndex = 1;
            this.nameBox.Text = "root";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // optimizeButton
            // 
            this.optimizeButton.Location = new System.Drawing.Point(6, 169);
            this.optimizeButton.Name = "optimizeButton";
            this.optimizeButton.Size = new System.Drawing.Size(100, 24);
            this.optimizeButton.TabIndex = 2;
            this.optimizeButton.Text = "Оптимизация";
            this.optimizeButton.UseVisualStyleBackColor = true;
            this.optimizeButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.isFinalState);
            this.groupBox1.Controls.Add(this.stepButton);
            this.groupBox1.Controls.Add(this.optimizeButton);
            this.groupBox1.Controls.Add(this.nameBox);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 252);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nodes";
            // 
            // isFinalState
            // 
            this.isFinalState.AutoSize = true;
            this.isFinalState.Location = new System.Drawing.Point(6, 25);
            this.isFinalState.Name = "isFinalState";
            this.isFinalState.Size = new System.Drawing.Size(130, 17);
            this.isFinalState.TabIndex = 4;
            this.isFinalState.Text = "Конечное состояние";
            this.isFinalState.UseVisualStyleBackColor = true;
            this.isFinalState.CheckedChanged += new System.EventHandler(this.isFinalState_CheckedChanged);
            // 
            // stepButton
            // 
            this.stepButton.Location = new System.Drawing.Point(6, 199);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(75, 23);
            this.stepButton.TabIndex = 4;
            this.stepButton.Text = "Шаг 1";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // nodeContext
            // 
            this.nodeContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteItem,
            this.clearItem});
            this.nodeContext.Name = "nodeContext";
            this.nodeContext.Size = new System.Drawing.Size(127, 48);
            this.nodeContext.Opening += new System.ComponentModel.CancelEventHandler(this.nodeContext_Opening);
            // 
            // deleteItem
            // 
            this.deleteItem.Name = "deleteItem";
            this.deleteItem.Size = new System.Drawing.Size(126, 22);
            this.deleteItem.Text = "Удалить";
            // 
            // clearItem
            // 
            this.clearItem.Name = "clearItem";
            this.clearItem.Size = new System.Drawing.Size(126, 22);
            this.clearItem.Text = "Очистить";
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(2, 504);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.ReadOnly = true;
            this.statusStrip.Size = new System.Drawing.Size(885, 20);
            this.statusStrip.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 527);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Граф";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.nodeContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button optimizeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.CheckBox isFinalState;
        private System.Windows.Forms.ContextMenuStrip nodeContext;
        private System.Windows.Forms.ToolStripMenuItem deleteItem;
        private System.Windows.Forms.ToolStripMenuItem clearItem;
        private System.Windows.Forms.TextBox statusStrip;
    }
}

