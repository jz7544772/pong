namespace WinformPong
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
            this.stage = new System.Windows.Forms.Panel();
            this.opponent = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            this.ballTimer = new System.Windows.Forms.Timer(this.components);
            this.opponentTimer = new System.Windows.Forms.Timer(this.components);
            this.stage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opponent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.SuspendLayout();
            // 
            // stage
            // 
            this.stage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.stage.Controls.Add(this.opponent);
            this.stage.Controls.Add(this.player);
            this.stage.Controls.Add(this.ball);
            this.stage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stage.Location = new System.Drawing.Point(1, 1);
            this.stage.Name = "stage";
            this.stage.Size = new System.Drawing.Size(626, 200);
            this.stage.TabIndex = 0;
            // 
            // opponent
            // 
            this.opponent.BackColor = System.Drawing.Color.Teal;
            this.opponent.Location = new System.Drawing.Point(608, 69);
            this.opponent.Name = "opponent";
            this.opponent.Size = new System.Drawing.Size(15, 70);
            this.opponent.TabIndex = 2;
            this.opponent.TabStop = false;
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Orange;
            this.player.Location = new System.Drawing.Point(0, 69);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(15, 70);
            this.player.TabIndex = 1;
            this.player.TabStop = false;
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Black;
            this.ball.InitialImage = null;
            this.ball.Location = new System.Drawing.Point(296, 95);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(15, 15);
            this.ball.TabIndex = 0;
            this.ball.TabStop = false;
            // 
            // ballTimer
            // 
            this.ballTimer.Enabled = true;
            this.ballTimer.Interval = 1;
            this.ballTimer.Tick += new System.EventHandler(this.ballTimer_Tick);
            // 
            // opponentTimer
            // 
            this.opponentTimer.Enabled = true;
            this.opponentTimer.Tick += new System.EventHandler(this.opponentTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 203);
            this.Controls.Add(this.stage);
            this.Name = "MainForm";
            this.Text = "WinformPong";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.stage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.opponent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel stage;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.Timer ballTimer;
        private System.Windows.Forms.PictureBox opponent;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer opponentTimer;
    }
}

