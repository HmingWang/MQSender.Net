namespace MQSender.Net.View.WinForm
{
    partial class MQConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxHostName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.tbxCCSID = new System.Windows.Forms.TextBox();
            this.tbxUserId = new System.Windows.Forms.TextBox();
            this.tbxQmgrName = new System.Windows.Forms.TextBox();
            this.tbxQueueName = new System.Windows.Forms.TextBox();
            this.tbxChannel = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址：";
            // 
            // tbxHostName
            // 
            this.tbxHostName.Location = new System.Drawing.Point(95, 29);
            this.tbxHostName.Name = "tbxHostName";
            this.tbxHostName.Size = new System.Drawing.Size(100, 21);
            this.tbxHostName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "CCSID：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "用户名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "队列管理器：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "发送队列：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "服务通道：";
            // 
            // tbxPort
            // 
            this.tbxPort.Location = new System.Drawing.Point(95, 63);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(100, 21);
            this.tbxPort.TabIndex = 8;
            // 
            // tbxCCSID
            // 
            this.tbxCCSID.Location = new System.Drawing.Point(95, 97);
            this.tbxCCSID.Name = "tbxCCSID";
            this.tbxCCSID.Size = new System.Drawing.Size(100, 21);
            this.tbxCCSID.TabIndex = 9;
            // 
            // tbxUserId
            // 
            this.tbxUserId.Location = new System.Drawing.Point(95, 131);
            this.tbxUserId.Name = "tbxUserId";
            this.tbxUserId.Size = new System.Drawing.Size(100, 21);
            this.tbxUserId.TabIndex = 10;
            // 
            // tbxQmgrName
            // 
            this.tbxQmgrName.Location = new System.Drawing.Point(95, 165);
            this.tbxQmgrName.Name = "tbxQmgrName";
            this.tbxQmgrName.Size = new System.Drawing.Size(100, 21);
            this.tbxQmgrName.TabIndex = 11;
            // 
            // tbxQueueName
            // 
            this.tbxQueueName.Location = new System.Drawing.Point(95, 199);
            this.tbxQueueName.Name = "tbxQueueName";
            this.tbxQueueName.Size = new System.Drawing.Size(100, 21);
            this.tbxQueueName.TabIndex = 12;
            // 
            // tbxChannel
            // 
            this.tbxChannel.Location = new System.Drawing.Point(95, 233);
            this.tbxChannel.Name = "tbxChannel";
            this.tbxChannel.Size = new System.Drawing.Size(100, 21);
            this.tbxChannel.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "测试连接";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 293);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "保存配置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MQConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 328);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxChannel);
            this.Controls.Add(this.tbxQueueName);
            this.Controls.Add(this.tbxQmgrName);
            this.Controls.Add(this.tbxUserId);
            this.Controls.Add(this.tbxCCSID);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxHostName);
            this.Controls.Add(this.label1);
            this.Name = "MQConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MQConfig";
            this.Load += new System.EventHandler(this.MQConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxHostName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.TextBox tbxCCSID;
        private System.Windows.Forms.TextBox tbxUserId;
        private System.Windows.Forms.TextBox tbxQmgrName;
        private System.Windows.Forms.TextBox tbxQueueName;
        private System.Windows.Forms.TextBox tbxChannel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}