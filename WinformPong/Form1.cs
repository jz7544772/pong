using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinformPong.Properties;

namespace WinformPong
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        PictureBox[] playerScore = new PictureBox[5]; 
        PictureBox[] opponentScore = new PictureBox[5]; 
        Color scoreColor = Color.Silver;
        Random rng = new Random();
        Boolean playerUp, playerDown = false;
        Boolean ballGoingLeft = false;
        Boolean gameOn = false;

        int playerSpeed;
        int opponentSpeed;
        int ballSpeed;
        int ballForce = 0;
        int round = 0; 

        public void ApplySettings()
        {
            playerSpeed = Properties.Settings.Default.PlayerSpeed;
            opponentSpeed = Properties.Settings.Default.OpponentSpeed;
            ballSpeed = Properties.Settings.Default.BallSpeed;
            ballTimer.Interval = Properties.Settings.Default.TimerMovement;
            opponentTimer.Interval = Properties.Settings.Default.TimerOpponent;
        }

        public Boolean CollisionLeft(PictureBox pb)
        {
            if(pb.Location.X <= 0)
            {
                return true;
            }
            return false;
        }

        public Boolean CollisionRight(PictureBox pb)
        {
            if(pb.Location.X + pb.Width >= stage.Width)
            {
                return true;
            }
            return false;
        }

        public Boolean CollisionUp(PictureBox pb)
        {
            if(pb.Location.Y <= 0)
            {
                return true;
            }
            return false;
        }

        public Boolean CollisionDown(PictureBox pb)
        {
            if(pb.Location.Y + pb.Height >= stage.Height)
            {
                return true; 
            }
            return false;
        }

        public Boolean CollisionOpponent(PictureBox pb)
        {
            if (pb.Bounds.IntersectsWith(opponent.Bounds))
            {
                PictureBox tempPb = new PictureBox();
                tempPb.Size = new Size(1, 10);
                tempPb.Location = new Point(opponent.Location.X -1, opponent.Location.Y);

                if (ball.Bounds.IntersectsWith(tempPb.Bounds))
                {
                    ballForce = 3;
                    return true;
                }
                tempPb.Top += 10;
                if (ball.Bounds.IntersectsWith(tempPb.Bounds))
                {
                    ballForce = 2;
                    return true;
                }
                tempPb.Top += 10;
                if (ball.Bounds.IntersectsWith(tempPb.Bounds))
                {
                    ballForce = 1;
                    return true;
                }
                tempPb.Top += 10;
                if (ball.Bounds.IntersectsWith(tempPb.Bounds))
                {
                    ballForce = 0;
                    return true;
                }
                tempPb.Top += 10;
                if (ball.Bounds.IntersectsWith(tempPb.Bounds))
                {
                    ballForce = -1;
                    return true;
                }
                tempPb.Top += 10;
                if (ball.Bounds.IntersectsWith(tempPb.Bounds))
                {
                    ballForce = -2;
                    return true;
                }
                tempPb.Top += 10;
                if (ball.Bounds.IntersectsWith(tempPb.Bounds))
                {
                    ballForce = -3;
                    return true;
                }
            }
            return false;
        }

        public Boolean CollisionPlayer(PictureBox pb)
        {
            if(pb.Bounds.IntersectsWith(player.Bounds))
            {
                PictureBox tempPb = new PictureBox();
                tempPb.Size = new Size(1, 10);
                tempPb.Location = new Point(player.Location.X + player.Width, player.Location.Y);

                if(ball.Bounds.IntersectsWith(tempPb.Bounds))
                {
                    ballForce = 3;
                    return true;
                }
                tempPb.Top += 10;
                if(ball.Bounds.IntersectsWith(tempPb.Bounds)) {
                    ballForce = 2;
                    return true;
                }
                tempPb.Top += 10;
                if (ball.Bounds.IntersectsWith(tempPb.Bounds)) {
                    ballForce = 1;
                    return true;
                }
                tempPb.Top += 10;
                if (ball.Bounds.IntersectsWith(tempPb.Bounds)) {
                    ballForce = 0;
                    return true;
                }
                tempPb.Top += 10;
                if (ball.Bounds.IntersectsWith(tempPb.Bounds)) {
                    ballForce = -1;
                    return true;
                }
                tempPb.Top += 10;
                if (ball.Bounds.IntersectsWith(tempPb.Bounds)) {
                    ballForce = -2;
                    return true;
                }
                tempPb.Top += 10;
                if (ball.Bounds.IntersectsWith(tempPb.Bounds)) {
                    ballForce = -3;
                    return true;
                }
            }
            return false;
        }

        public int ReverseInt(int x, Boolean force = false, Boolean negative = false)
        {
            if(force)
            {
                if(negative)
                {
                    if(x > 0)
                    {
                        x = ~x + 1;
                    }
                }
                else
                {
                    x = x - (x * 2);
                }
            }
            else
            {
                if(x > 0)
                {
                    x = x - (x * 2);
                }
                else
                {
                    x = ~x + 1;
                }
            }
            return x;
        }

        private void ballTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                ApplySettings();

                if (gameOn)
                {
                    if (playerUp && !(CollisionUp(player)))
                    {
                        player.Top -= playerSpeed;
                    }
                    else if (playerDown && !(CollisionDown(player)))
                    {
                        player.Top += playerSpeed;
                    }

                    if (ballForce != 0)
                    {
                        ball.Top -= ballForce;
                    }

                    if (CollisionUp(ball) || CollisionDown(ball))
                    {
                        ballForce = ~ballForce + 1;
                    }

                    if (ballGoingLeft)
                    {
                        ball.Left -= ballSpeed;
                        if (CollisionPlayer(ball) || CollisionLeft(ball))
                        {
                            ballGoingLeft = false;
                            ball.Left += 6;
                        }
                    }
                    else // Ball currently going right 
                    {
                        ball.Left += ballSpeed;
                        if (CollisionOpponent(ball) || CollisionRight(ball))
                        {
                            ballGoingLeft = true;
                            ball.Left -= 6;
                        }
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    playerUp = false;
                    break;
                case Keys.S:
                case Keys.Down:
                    playerDown = false;
                    break;
            }
        }

        private void opponentTimer_Tick(object sender, EventArgs e)
        {
            if(gameOn)
            {
                if(opponent.Location.Y +28 < ball.Location.Y)
                {
                    if(!CollisionDown(opponent))
                    {
                        opponent.Top += opponentSpeed;
                    }
                }
                else {
                    if(!CollisionUp(opponent))
                    {
                        opponent.Top -= opponentSpeed;
                    }
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    playerDown = false;
                    playerUp = true;
                    break;
                case Keys.S:
                case Keys.Down:
                    playerUp = false;
                    playerDown = true;
                    break;
                case Keys.Space:
                    gameOn = !(gameOn);
                    break;
            }
        }
    }
}
