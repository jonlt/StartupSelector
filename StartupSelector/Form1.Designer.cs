﻿namespace StartupSelector
{
    partial class Startup
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
            this.btnAll = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.btnSelected = new System.Windows.Forms.Button();
            this.clbPrograms = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(13, 240);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnNone
            // 
            this.btnNone.Location = new System.Drawing.Point(94, 240);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(75, 23);
            this.btnNone.TabIndex = 3;
            this.btnNone.Text = "None";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // btnSelected
            // 
            this.btnSelected.Location = new System.Drawing.Point(175, 240);
            this.btnSelected.Name = "btnSelected";
            this.btnSelected.Size = new System.Drawing.Size(75, 23);
            this.btnSelected.TabIndex = 1;
            this.btnSelected.Text = "Selected";
            this.btnSelected.UseVisualStyleBackColor = true;
            this.btnSelected.Click += new System.EventHandler(this.btnSelected_Click);
            // 
            // clbPrograms
            // 
            this.clbPrograms.CheckOnClick = true;
            this.clbPrograms.FormattingEnabled = true;
            this.clbPrograms.Location = new System.Drawing.Point(13, 13);
            this.clbPrograms.Name = "clbPrograms";
            this.clbPrograms.Size = new System.Drawing.Size(237, 214);
            this.clbPrograms.TabIndex = 4;
            // 
            // Startup
            // 
            this.AcceptButton = this.btnSelected;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNone;
            this.ClientSize = new System.Drawing.Size(266, 275);
            this.Controls.Add(this.clbPrograms);
            this.Controls.Add(this.btnSelected);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.btnAll);
            this.Name = "Startup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Startup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.Button btnSelected;
        private System.Windows.Forms.CheckedListBox clbPrograms;
    }
}

