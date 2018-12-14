namespace GyArc
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUI = new System.Windows.Forms.Button();
            this.btnUnhandle = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnFormatter = new System.Windows.Forms.Button();
            this.btnAOP = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUI
            // 
            this.btnUI.Location = new System.Drawing.Point(26, 21);
            this.btnUI.Name = "btnUI";
            this.btnUI.Size = new System.Drawing.Size(75, 23);
            this.btnUI.TabIndex = 0;
            this.btnUI.Text = "UI 异常策略";
            this.btnUI.UseVisualStyleBackColor = true;
            this.btnUI.Click += new System.EventHandler(this.btnUI_Click);
            // 
            // btnUnhandle
            // 
            this.btnUnhandle.Location = new System.Drawing.Point(143, 21);
            this.btnUnhandle.Name = "btnUnhandle";
            this.btnUnhandle.Size = new System.Drawing.Size(75, 23);
            this.btnUnhandle.TabIndex = 0;
            this.btnUnhandle.Text = "未处理异常";
            this.btnUnhandle.UseVisualStyleBackColor = true;
            this.btnUnhandle.Click += new System.EventHandler(this.btnUnhandle_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(26, 96);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(75, 23);
            this.btnLog.TabIndex = 0;
            this.btnLog.Text = "记录日志";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnFormatter
            // 
            this.btnFormatter.Location = new System.Drawing.Point(143, 96);
            this.btnFormatter.Name = "btnFormatter";
            this.btnFormatter.Size = new System.Drawing.Size(75, 23);
            this.btnFormatter.TabIndex = 0;
            this.btnFormatter.Text = "格式器";
            this.btnFormatter.UseVisualStyleBackColor = true;
            this.btnFormatter.Click += new System.EventHandler(this.btnFormatter_Click);
            // 
            // btnAOP
            // 
            this.btnAOP.Location = new System.Drawing.Point(26, 160);
            this.btnAOP.Name = "btnAOP";
            this.btnAOP.Size = new System.Drawing.Size(75, 23);
            this.btnAOP.TabIndex = 0;
            this.btnAOP.Text = "日志拦截";
            this.btnAOP.UseVisualStyleBackColor = true;
            this.btnAOP.Click += new System.EventHandler(this.btnAOP_Click);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(143, 160);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(75, 23);
            this.btnLock.TabIndex = 0;
            this.btnLock.Text = "锁测试";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "数据库连接测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAOP);
            this.Controls.Add(this.btnFormatter);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnUnhandle);
            this.Controls.Add(this.btnUI);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUI;
        private System.Windows.Forms.Button btnUnhandle;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnFormatter;
        private System.Windows.Forms.Button btnAOP;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button button1;
    }
}

