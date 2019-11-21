/// <summary>
/// Authors: Nick Smith & Kyle Wyse
/// Date:    25 Feb 19
/// 
/// Description: declarations of all the widgets for the GUI.
/// </summary>

namespace c4GUI
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.butCol7 = new System.Windows.Forms.Button();
            this.butCol6 = new System.Windows.Forms.Button();
            this.butCol5 = new System.Windows.Forms.Button();
            this.butCol4 = new System.Windows.Forms.Button();
            this.butCol3 = new System.Windows.Forms.Button();
            this.butCol2 = new System.Windows.Forms.Button();
            this.butCol1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblP1Stats = new System.Windows.Forms.Label();
            this.lblP2Stats = new System.Windows.Forms.Label();
            this.butSaveQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butCol7
            // 
            this.butCol7.Location = new System.Drawing.Point(492, 71);
            this.butCol7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butCol7.Name = "butCol7";
            this.butCol7.Size = new System.Drawing.Size(51, 50);
            this.butCol7.TabIndex = 48;
            this.butCol7.UseVisualStyleBackColor = true;
            this.butCol7.Click += new System.EventHandler(this.butCol7_Click);
            // 
            // butCol6
            // 
            this.butCol6.Location = new System.Drawing.Point(436, 71);
            this.butCol6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butCol6.Name = "butCol6";
            this.butCol6.Size = new System.Drawing.Size(51, 50);
            this.butCol6.TabIndex = 47;
            this.butCol6.UseVisualStyleBackColor = true;
            this.butCol6.Click += new System.EventHandler(this.butCol6_Click);
            // 
            // butCol5
            // 
            this.butCol5.Location = new System.Drawing.Point(380, 71);
            this.butCol5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butCol5.Name = "butCol5";
            this.butCol5.Size = new System.Drawing.Size(51, 50);
            this.butCol5.TabIndex = 46;
            this.butCol5.UseVisualStyleBackColor = true;
            this.butCol5.Click += new System.EventHandler(this.butCol5_Click);
            // 
            // butCol4
            // 
            this.butCol4.Location = new System.Drawing.Point(324, 71);
            this.butCol4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butCol4.Name = "butCol4";
            this.butCol4.Size = new System.Drawing.Size(51, 50);
            this.butCol4.TabIndex = 45;
            this.butCol4.UseVisualStyleBackColor = true;
            this.butCol4.Click += new System.EventHandler(this.butCol4_Click);
            // 
            // butCol3
            // 
            this.butCol3.Location = new System.Drawing.Point(268, 71);
            this.butCol3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butCol3.Name = "butCol3";
            this.butCol3.Size = new System.Drawing.Size(51, 50);
            this.butCol3.TabIndex = 44;
            this.butCol3.UseVisualStyleBackColor = true;
            this.butCol3.Click += new System.EventHandler(this.butCol3_Click);
            // 
            // butCol2
            // 
            this.butCol2.Location = new System.Drawing.Point(212, 71);
            this.butCol2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butCol2.Name = "butCol2";
            this.butCol2.Size = new System.Drawing.Size(51, 50);
            this.butCol2.TabIndex = 43;
            this.butCol2.UseVisualStyleBackColor = true;
            this.butCol2.Click += new System.EventHandler(this.butCol2_Click);
            // 
            // butCol1
            // 
            this.butCol1.Location = new System.Drawing.Point(156, 71);
            this.butCol1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butCol1.Name = "butCol1";
            this.butCol1.Size = new System.Drawing.Size(51, 50);
            this.butCol1.TabIndex = 42;
            this.butCol1.UseVisualStyleBackColor = true;
            this.butCol1.Click += new System.EventHandler(this.butCol1_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(156, 128);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 315);
            this.panel1.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(220, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 45);
            this.label1.TabIndex = 50;
            this.label1.Text = "Connect Four";
            // 
            // clock
            // 
            this.clock.Enabled = true;
            this.clock.Interval = 1000;
            this.clock.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(561, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 29);
            this.label4.TabIndex = 53;
            this.label4.Text = "Player 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 29);
            this.label5.TabIndex = 54;
            this.label5.Text = "Player 1";
            // 
            // lblP1Stats
            // 
            this.lblP1Stats.AutoSize = true;
            this.lblP1Stats.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP1Stats.Location = new System.Drawing.Point(12, 128);
            this.lblP1Stats.Name = "lblP1Stats";
            this.lblP1Stats.Size = new System.Drawing.Size(116, 85);
            this.lblP1Stats.TabIndex = 55;
            this.lblP1Stats.Text = "Current moves: 0\r\nTotal moves: 0\r\nTotal wins: 0\r\nLeast moves \r\nto win: n/a\r\n";
            // 
            // lblP2Stats
            // 
            this.lblP2Stats.AutoSize = true;
            this.lblP2Stats.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP2Stats.Location = new System.Drawing.Point(563, 128);
            this.lblP2Stats.Name = "lblP2Stats";
            this.lblP2Stats.Size = new System.Drawing.Size(116, 85);
            this.lblP2Stats.TabIndex = 58;
            this.lblP2Stats.Text = "Current moves: 0\r\nTotal moves: 0\r\nTotal wins: 0\r\nLeast moves \r\nto win: n/a\r\n";
            // 
            // butSaveQuit
            // 
            this.butSaveQuit.Location = new System.Drawing.Point(548, 420);
            this.butSaveQuit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butSaveQuit.Name = "butSaveQuit";
            this.butSaveQuit.Size = new System.Drawing.Size(123, 23);
            this.butSaveQuit.TabIndex = 59;
            this.butSaveQuit.Text = "Save and Quit";
            this.butSaveQuit.UseVisualStyleBackColor = true;
            this.butSaveQuit.Click += new System.EventHandler(this.butSaveQuit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(683, 454);
            this.Controls.Add(this.butSaveQuit);
            this.Controls.Add(this.lblP2Stats);
            this.Controls.Add(this.lblP1Stats);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butCol7);
            this.Controls.Add(this.butCol6);
            this.Controls.Add(this.butCol3);
            this.Controls.Add(this.butCol5);
            this.Controls.Add(this.butCol1);
            this.Controls.Add(this.butCol4);
            this.Controls.Add(this.butCol2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCol7;
        private System.Windows.Forms.Button butCol6;
        private System.Windows.Forms.Button butCol5;
        private System.Windows.Forms.Button butCol4;
        private System.Windows.Forms.Button butCol3;
        private System.Windows.Forms.Button butCol2;
        private System.Windows.Forms.Button butCol1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer clock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblP1Stats;
        private System.Windows.Forms.Label lblP2Stats;
        private System.Windows.Forms.Button butSaveQuit;
    }
}

