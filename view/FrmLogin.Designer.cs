﻿namespace MediaTekDocuments.view
{
     partial class FrmLogin
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
               this.txbLogin = new System.Windows.Forms.TextBox();
               this.lblIdentifiant = new System.Windows.Forms.Label();
               this.label1 = new System.Windows.Forms.Label();
               this.txbPwd = new System.Windows.Forms.TextBox();
               this.btnConnec = new System.Windows.Forms.Button();
               this.SuspendLayout();
               // 
               // txbLogin
               // 
               this.txbLogin.Location = new System.Drawing.Point(106, 54);
               this.txbLogin.Name = "txbLogin";
               this.txbLogin.Size = new System.Drawing.Size(174, 20);
               this.txbLogin.TabIndex = 0;
               // 
               // lblIdentifiant
               // 
               this.lblIdentifiant.AutoSize = true;
               this.lblIdentifiant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.lblIdentifiant.Location = new System.Drawing.Point(12, 54);
               this.lblIdentifiant.Name = "lblIdentifiant";
               this.lblIdentifiant.Size = new System.Drawing.Size(64, 13);
               this.lblIdentifiant.TabIndex = 1;
               this.lblIdentifiant.Text = "Identifiant";
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label1.Location = new System.Drawing.Point(12, 127);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(61, 13);
               this.label1.TabIndex = 2;
               this.label1.Text = "Password";
               // 
               // txbPwd
               // 
               this.txbPwd.Location = new System.Drawing.Point(106, 124);
               this.txbPwd.Name = "txbPwd";
               this.txbPwd.Size = new System.Drawing.Size(174, 20);
               this.txbPwd.TabIndex = 3;
               this.txbPwd.UseSystemPasswordChar = true;
               // 
               // btnConnec
               // 
               this.btnConnec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.btnConnec.Location = new System.Drawing.Point(180, 183);
               this.btnConnec.Name = "btnConnec";
               this.btnConnec.Size = new System.Drawing.Size(100, 23);
               this.btnConnec.TabIndex = 4;
               this.btnConnec.Text = "Connection";
               this.btnConnec.UseVisualStyleBackColor = true;
               this.btnConnec.Click += new System.EventHandler(this.btnConnec_Click);
               // 
               // FrmLogin
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(309, 218);
               this.Controls.Add(this.btnConnec);
               this.Controls.Add(this.txbPwd);
               this.Controls.Add(this.label1);
               this.Controls.Add(this.lblIdentifiant);
               this.Controls.Add(this.txbLogin);
               this.Name = "FrmLogin";
               this.Text = "FrmLogin";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.TextBox txbLogin;
          private System.Windows.Forms.Label lblIdentifiant;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.TextBox txbPwd;
          private System.Windows.Forms.Button btnConnec;
     }
}