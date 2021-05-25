/*Julia Dowson 
 * Mr. T 
 * April 7, 2021
 * This is a two player game based off the original Fireboy and Watergirl.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace FireAndWaterDesign
{
    public partial class Form1 : Form
    {
        //creates sounds 
        SoundPlayer jumpSound = new SoundPlayer(Properties.Resources.jump);
        SoundPlayer lostSound = new SoundPlayer(Properties.Resources.end);
        System.Windows.Media.MediaPlayer backMedia = new System.Windows.Media.MediaPlayer();

        //creates the brushes and images 
        SolidBrush wallBrush = new SolidBrush(Color.OliveDrab);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush doorBlueBrush = new SolidBrush(Color.DarkBlue);
        SolidBrush doorRedBrush = new SolidBrush(Color.DarkRed);
        Image fireBoy;
        Image waterGirl;

        int wallThick = 15;

        //watergirl control setup 
        bool jumpingGirl = false;
        bool dDown = false;
        bool aDown = false;

        //fireboy control setup 
        bool jumpingBoy = false;
        bool leftArrow = false;
        bool rightArrow = false;

        int waterGirlX = 30;
        int waterGirlY = 375;
        int fireBoyX = 30;
        int fireBoyY = 302;
        int playerSpeed = 5;
        int player2Speed = 5;
        int playerLength = 21;
        int playerHeight = 40;

        int jumpSpeed = 10;
        int jump2Speed = 10;
        int force = 7;
        int force2 = 7;

        List<int> landingXList = new List<int>();
        List<int> landingYList = new List<int>();
        List<int> landingLList = new List<int>();
        List<int> landingHList = new List<int>();

        string gameState = "waiting";

        public Form1()
        {
            InitializeComponent();

            landingXList.Add(0); //bottom
            landingYList.Add(425);
            landingLList.Add(800);
            landingHList.Add(wallThick);

            landingXList.Add(0); //top
            landingYList.Add(0);
            landingLList.Add(800);
            landingHList.Add(wallThick);

            landingXList.Add(0); //left
            landingYList.Add(0);
            landingLList.Add(wallThick);
            landingHList.Add(600);

            landingXList.Add(572); //right
            landingYList.Add(0);
            landingLList.Add(wallThick);
            landingHList.Add(600);

            landingXList.Add(0); //landing 1
            landingYList.Add(360);
            landingLList.Add(210);
            landingHList.Add(wallThick);

            landingXList.Add(0); //landing 2
            landingYList.Add(300);
            landingLList.Add(370);
            landingHList.Add(wallThick);

            landingXList.Add(200); //landing 3
            landingYList.Add(220);
            landingLList.Add(380);
            landingHList.Add(wallThick);

            landingXList.Add(0); //landing 4
            landingYList.Add(150);
            landingLList.Add(350);
            landingHList.Add(wallThick);

            landingXList.Add(250); //landing 5
            landingYList.Add(75);
            landingLList.Add(330);
            landingHList.Add(wallThick);

            landingXList.Add(435); //landing 6
            landingYList.Add(350);
            landingLList.Add(140);
            landingHList.Add(wallThick);

            backMedia.Open(new Uri(Application.StartupPath + "/Resources/Fireboy and Watergirl Music (In-game quality).wav"));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Left:
                    leftArrow = true;
                    break;
                case Keys.Right:
                    rightArrow = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "gameWon" || gameState == "gameLost")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "gameWon" || gameState == "gameLost")
                    {
                        Application.Exit();
                    }
                    break;
            }

            if (e.KeyCode == Keys.W && !jumpingGirl)
            {
                jumpingGirl = true;
                jumpSound.Play();
            }

            if (e.KeyCode == Keys.Up && !jumpingBoy)
            {
                jumpingBoy = true;
                jumpSound.Play();
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Left:
                    leftArrow = false;
                    break;
                case Keys.Right:
                    rightArrow = false;
                    break;
            }

            if (jumpingGirl)
            {
                jumpingGirl = false;
            }

            if (jumpingBoy)
            {
                jumpingBoy = false;
            }
        }

        public void GameInitialize()
        {
            fireBoy = (Properties.Resources.fireboyImage);
            waterGirl = (Properties.Resources.watergirlImage);

            fireLabel.Text = "";
            waterLabel.Text = "";
            outputLabel.Text = "";
            mainLabel.Text = "";

            gameTimer.Enabled = true;
            gameState = "running";
            backMedia.Play();

            waterGirlX = 30;
            waterGirlY = 385;
            fireBoyX = 30;
            fireBoyY = 320;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region move 
            waterGirlY += jumpSpeed;
            fireBoyY += jump2Speed;

            //watergirl moving
            if (jumpingGirl && force < 0)
            {
                jumpingGirl = false;
            }

            if (aDown)
            {
                waterGirlX -= playerSpeed;
            }

            if (dDown)
            {
                waterGirlX += playerSpeed;
            }

            if (jumpingGirl)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }

            //fireboy moving
            if (jumpingBoy && force2 < 0)
            {
                jumpingBoy = false;
            }

            if (leftArrow)
            {
                fireBoyX -= player2Speed;
            }

            if (rightArrow)
            {
                fireBoyX += player2Speed;
            }

            if (jumpingBoy)
            {
                jump2Speed = -12;
                force2 -= 1;
            }
            else
            {
                jump2Speed = 12;
            }
            #endregion 

            Rectangle waterGirlRec = new Rectangle(waterGirlX, waterGirlY + 20, playerLength, playerHeight - 20);
            Rectangle fireBoyRec = new Rectangle(fireBoyX, fireBoyY + 20, playerLength, playerHeight - 20);

            for (int i = 0; i < landingXList.Count(); i++)
            {
                Rectangle landRec = new Rectangle(landingXList[i], landingYList[i], landingLList[i], 1);
                Rectangle bottomLand = new Rectangle(landingXList[i], landingYList[i] + wallThick, landingLList[i], 2);
                Rectangle leftWallRec = new Rectangle(0, landingYList[i], wallThick, landingHList[i]);
                Rectangle rightWallRec = new Rectangle(572, 0, wallThick, 600);

                #region watergirl intersections 
                if (waterGirlRec.IntersectsWith(landRec) && !jumpingGirl)
                {
                    force = 7;
                    waterGirlY = landingYList[i] - playerHeight;
                }

                if (waterGirlRec.IntersectsWith(bottomLand))
                {
                    waterGirlY = waterGirlY + 10;
                }

                if (waterGirlRec.IntersectsWith(leftWallRec))
                {
                    waterGirlX = waterGirlX + playerSpeed;
                }

                if (waterGirlRec.IntersectsWith(rightWallRec))
                {
                    waterGirlX = waterGirlX - 1;
                }
                #endregion

                #region fireboy intersections
                if (fireBoyRec.IntersectsWith(landRec) && !jumpingBoy)
                {
                    force2 = 7;
                    fireBoyY = landingYList[i] - playerHeight;
                }

                if (fireBoyRec.IntersectsWith(bottomLand))
                {
                    fireBoyY = fireBoyY + 10;
                }

                if (fireBoyRec.IntersectsWith(leftWallRec))
                {
                    fireBoyX = fireBoyX + player2Speed;
                }

                if (fireBoyRec.IntersectsWith(rightWallRec))
                {
                    fireBoyX = fireBoyX - 1;
                }
                #endregion
            }

            //if you run into the 'puddles'
            Rectangle waterPuddle = new Rectangle(285, 230, 10, 3);
            Rectangle firePuddle = new Rectangle(350, 415, 10, 3);
            if (fireBoyRec.IntersectsWith(waterPuddle) || waterGirlRec.IntersectsWith(firePuddle))
            {
                gameState = "gameLost";
            }

            //how to win the game, both players are touching their door 
            Rectangle waterDoorRec = new Rectangle(464, 40, 10, 35);
            Rectangle fireDoorRec = new Rectangle(490, 40, 10, 35);

            if (waterGirlRec.IntersectsWith(waterDoorRec) && fireBoyRec.IntersectsWith(fireDoorRec))
            {
                Thread.Sleep(500);
                backMedia.Stop();
                gameState = "gameWon";
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                fireLabel.Text = "Fireboy";
                waterLabel.Text = "Watergirl";
                mainLabel.Text = "and";
                outputLabel.Text = "Press Space to Start, Escape to Exit";
            }
            else if (gameState == "running")
            {

                for (int i = 0; i < landingXList.Count(); i++)
                {
                    //draws all the landings and walls 
                    e.Graphics.FillRectangle(wallBrush, landingXList[i], landingYList[i], landingLList[i], landingHList[i]);
                }

                e.Graphics.FillRectangle(blueBrush, 265, 215, 40, 15); //water puddle
                e.Graphics.FillRectangle(redBrush, 330, 420, 40, 15); //fire puddle 
                e.Graphics.FillRectangle(doorBlueBrush, 440, 35, 30, 40);
                e.Graphics.FillRectangle(doorRedBrush, 480, 35, 30, 40);
                e.Graphics.DrawImage(fireBoy, fireBoyX, fireBoyY, playerLength, playerHeight);
                e.Graphics.DrawImage(waterGirl, waterGirlX, waterGirlY, playerLength, playerHeight);
            }
            else if (gameState == "gameWon")
            {
                mainLabel.Text = "You won!";
                outputLabel.Text = "Press Space to Start, Escape to Exit";
                gameTimer.Enabled = false;
            }
            else if (gameState == "gameLost")
            {
                lostSound.Play();
                mainLabel.Text = "You lost!";
                outputLabel.Text = "Press Space to Start, Escape to Exit";
                gameTimer.Enabled = false;
            }
        }
    }
}
