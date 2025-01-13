namespace EQEmu_Patcher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.txtList = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.splashLogo = new System.Windows.Forms.PictureBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.chkAutoPlay = new System.Windows.Forms.CheckBox();
            this.chkAutoPatch = new System.Windows.Forms.CheckBox();
            this.pendingPatchTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splashLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(10, 521);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(400, 39);
            this.progressBar.TabIndex = 0;
            // 
            // txtList
            // 
            this.txtList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtList.HideSelection = false;
            this.txtList.Location = new System.Drawing.Point(10, 6);
            this.txtList.Multiline = true;
            this.txtList.Name = "txtList";
            this.txtList.ReadOnly = true;
            this.txtList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtList.Size = new System.Drawing.Size(400, 450);
            this.txtList.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(315, 463);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(95, 52);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Play";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // splashLogo
            // 
            this.splashLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splashLogo.Image = global::EQEmu_Patcher.Properties.Resources.quarm_logo2;
            this.splashLogo.Location = new System.Drawing.Point(10, 6);
            this.splashLogo.Margin = new System.Windows.Forms.Padding(0);
            this.splashLogo.MinimumSize = new System.Drawing.Size(400, 450);
            this.splashLogo.Name = "splashLogo";
            this.splashLogo.Size = new System.Drawing.Size(400, 450);
            this.splashLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.splashLogo.TabIndex = 4;
            this.splashLogo.TabStop = false;
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheck.Location = new System.Drawing.Point(12, 463);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(95, 52);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "Patch";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // chkAutoPlay
            // 
            this.chkAutoPlay.AutoSize = true;
            this.chkAutoPlay.Location = new System.Drawing.Point(238, 463);
            this.chkAutoPlay.Name = "chkAutoPlay";
            this.chkAutoPlay.Size = new System.Drawing.Size(71, 17);
            this.chkAutoPlay.TabIndex = 7;
            this.chkAutoPlay.Text = "Auto Play";
            this.chkAutoPlay.UseVisualStyleBackColor = true;
            this.chkAutoPlay.CheckedChanged += new System.EventHandler(this.chkAutoPlay_CheckedChanged);
            // 
            // chkAutoPatch
            // 
            this.chkAutoPatch.AutoSize = true;
            this.chkAutoPatch.Location = new System.Drawing.Point(113, 463);
            this.chkAutoPatch.Name = "chkAutoPatch";
            this.chkAutoPatch.Size = new System.Drawing.Size(79, 17);
            this.chkAutoPatch.TabIndex = 8;
            this.chkAutoPatch.Text = "Auto Patch";
            this.chkAutoPatch.UseVisualStyleBackColor = true;
            this.chkAutoPatch.CheckedChanged += new System.EventHandler(this.chkAutoPatch_CheckedChanged);
            // 
            // pendingPatchTimer
            // 
            this.pendingPatchTimer.Tick += new System.EventHandler(this.pendingPatchTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 572);
            this.Controls.Add(this.chkAutoPatch);
            this.Controls.Add(this.chkAutoPlay);
            this.Controls.Add(this.txtList);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.splashLogo);
            this.Controls.Add(this.progressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(305, 371);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EQEmu Patcher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.splashLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox txtList;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox splashLogo;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.CheckBox chkAutoPlay;
        private System.Windows.Forms.CheckBox chkAutoPatch;
        private System.Windows.Forms.Timer pendingPatchTimer;
    }
}

