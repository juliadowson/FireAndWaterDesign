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

namespace FireAndWaterDesign
{
    public partial class Form1 : Form
    {
        SolidBrush wallBrush = new SolidBrush(Color.OliveDrab);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush doorBlueBrush = new SolidBrush(Color.DarkBlue);
        SolidBrush doorRedBrush = new SolidBrush(Color.DarkRed);
        Image fireBoy; // = new Image(Properties.Resources.fireboyImage);
        Image waterGirl;

        int wallThick = 15;

        bool jumpingGirl = false;
        bool dDown = false;
        bool aDown = false;

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

        string gameState = "waiting";

        int jumpSpeed = 10;
        int jump2Speed = 10;
        int force = 7;
        int force2 = 7;

        List<int> landingXList = new List<int>();
        List<int> landingYList = new List<int>();
        List<int> landingLList = new List<int>();
        List<int> landingHList = new List<int>();

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
                    if (gameState == "waiting" || gameState == "gameWon")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "gameWon")
                    {
                        Application.Exit();
                    }
                    break;
            }
            if (e.KeyCode == Keys.W && !jumpingGirl)
            {
                jumpingGirl = true;
            }
            if (e.KeyCode == Keys.Up && !jumpingBoy)
            {
                jumpingBoy = true;
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

            waterGirlX = 30; //30, 405
            waterGirlY = 385;
            fireBoyX = 30; //30, 340
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

            Rectangle waterDoorRec = new Rectangle(464, 40, 10, 35);
            Rectangle fireDoorRec = new Rectangle(490, 40, 10, 35);

            if (waterGirlRec.IntersectsWith(waterDoorRec) && fireBoyRec.IntersectsWith(fireDoorRec))
            {
                Thread.Sleep(500);
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
                    e.Graphics.FillRectangle(wallBrush, landingXList[i], landingYList[i], landingLList[i], landingHList[i]);
                }

                e.Graphics.FillRectangle(blueBrush, 300, 215, 40, 15); //water puddle
                e.Graphics.FillRectangle(doorBlueBrush, 440, 35, 30, 40);
                e.Graphics.FillRectangle(doorRedBrush, 480, 35, 30, 40);
                //e.Graphics.FillRectangle(blueBrush, waterGirlX, waterGirlY, playerLength, 20);
                //e.Graphics.FillRectangle(redBrush, fireBoyX, fireBoyY, playerLength, playerHeight);
                e.Graphics.DrawImage(fireBoy, fireBoyX, fireBoyY, playerLength, playerHeight);
                e.Graphics.DrawImage(waterGirl, waterGirlX, waterGirlY, playerLength, playerHeight);
            }
            else if (gameState == "gameWon")
            {
                mainLabel.Text = "You won!";
                outputLabel.Text = "Press Space to Start, Escape to Exit";
                gameTimer.Enabled = false;
            }
        }
    }
}
