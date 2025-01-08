using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Chaser
{
    public partial class Form1 : Form
    {
        // All Global variables

        //Shapes and coordinates
        Rectangle player1 = new Rectangle(50, 270, 20, 20);
        Rectangle player2 = new Rectangle(700, 270, 20, 20);
        Rectangle ball = new Rectangle(295, 195, 10, 10);
        Rectangle ball2 = new Rectangle(330, 195, 10, 10);



        //Player Score
        int player1Score = 0;
        int player2Score = 0;

       //Speeds
        int player1Speed = 4;
        int player2Speed = 4;
        int playerSpeed = 4;
        int ballXSpeed = 8;
        int ballYSpeed = 8;

        // buttons
        bool wPressed = false;
        bool sPressed = false;
        bool aPressed = false;
        bool dPressed = false;
        bool rightPressed = false;
        bool leftPressed = false;
        bool upPressed = false;
        bool downPressed = false;
       
        //Brushes and colors
        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush yellowbrush = new SolidBrush(Color.Yellow);
       
        // Random generator
        Random randgen = new Random();

        // Sound
        SoundPlayer sp = new  SoundPlayer(Properties.Resources.Blow);
        SoundPlayer sp2 = new SoundPlayer (Properties.Resources.Lion);    


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           // All of the true statments
           
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = true;
                    break;
               
                case Keys.S:
                    sPressed = true;
                    break;
               
                case Keys.Up:
                    upPressed = true;
                    break;
               
                case Keys.Down:
                    downPressed = true;
                    break;
               
                case Keys.D:
                    dPressed = true;
                    break;
               
                case Keys.A:
                    aPressed = true;
                    break;
              
                case Keys.Right:
                    rightPressed = true;
                    break;
              
                case Keys.Left:
                    leftPressed = true;
                    break;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
           // All of the false statments
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
               
                case Keys.S:
                    sPressed = false;
                    break;
               
                case Keys.Up:
                    upPressed = false;
                    break;
               
                case Keys.Down:
                    downPressed = false;
                    break;
               
                case Keys.A:
                    aPressed = false;
                    break;
              
                case Keys.D:
                    dPressed = false;
                    break;
              
                case Keys.Right:
                    rightPressed = false;
                    break;
               
                case Keys.Left:
                    leftPressed = false;
                    break;
            }




        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            {
               // Player scores and filling the shapes with brushes 
                player1ScoreLabel.Text = $"{player1Score}";
                player2ScoreLabel.Text = $"{player2Score}";
                e.Graphics.FillRectangle(blueBrush, player1);
                e.Graphics.FillRectangle(blueBrush, player2);
                e.Graphics.FillRectangle(whiteBrush, ball);
                e.Graphics.FillRectangle(yellowbrush, ball2);
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            // Makes the keys used move the players in all directions
            if (wPressed == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }
          
            if (sPressed == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += player1Speed;
            }
           
            if (aPressed == true && player1.X > 0)
            {
                player1.X -= player1Speed;
            }
          
            if (dPressed == true && player1.X < this.Width - player1.Width)
            {
                player1.X += playerSpeed;
            }

            if (rightPressed == true && player2.X < this.Width - player2.Width)
            {
                player2.X += player2Speed;
            }
           
            if (leftPressed == true && player2.X > 0)
            {
                player2.X -= player2Speed;
            }
          
            if (upPressed == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }
           
            if (downPressed == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player2Speed;
            }

            // check if ball hit wall
            if (ball.Y < 0 || ball.Y > this.Height - ball.Height)
            {
                ballYSpeed *= -1; // or: ballYSpeed = -ballYSpeed
            }
           
            if (ball.X < 0 || ball.X > this.Width - ball.Width)
            {
                ballXSpeed *= -1; // or: ballXSpeed = -ballXSpeed
            }
           
            // change if ball hits either player. If it does place in new random spot
           
            if (player1.IntersectsWith(ball))
            {
                //plays sounds
                sp2.Play();
                player1Score++;
                ball.X = randgen.Next(30, 300);
                ball.Y = randgen.Next(30, 300);
            }

            if (player2.IntersectsWith(ball))
            {
                sp.Play();
                player2Score++;
                ball.X = randgen.Next(30, 300);
                ball.Y = randgen.Next(30, 300);
            }

            // check if player hits boost and replace it in a random spot
           
            if (player1.IntersectsWith(ball2))
            {
                sp.Play();
                player1Speed += 2;
                ball2.X = randgen.Next(30, 300);
                ball2.Y = randgen.Next(30, 300);
            }
           
            if (player2.IntersectsWith(ball2))
            {
                sp2.Play();
                player2Speed += 2;
                ball2.X = randgen.Next(30, 300);
                ball2.Y = randgen.Next(30, 300);
            }




            // check if the game is over and show a winner
           
            if (player1Score == 5)
            {
                timerTick1.Stop();

            }
           
            if (player2Score == 5)
            {
                timerTick1.Stop();
            }
           
            Refresh();
        }
    }
}

