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
        SolidBrush doorBrush = new SolidBrush(Color.DarkBlue);

        int wallThick = 15;

        bool jumping = false;
        bool dDown = false;
        bool aDown = false;

        int waterGirlX = 30;
        int waterGirlY = 405;
        //int playerSpeed = 7;
        int playerSize = 20;


        int jumpSpeed = 10;
        int force = 7;

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
            }
            if (e.KeyCode == Keys.W && !jumping)
            {
                jumping = true;
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
            }
            if (jumping)
            {
                jumping = false;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < landingXList.Count(); i++)
            {
                e.Graphics.FillRectangle(wallBrush, landingXList[i], landingYList[i], landingLList[i], landingHList[i]); 
            }

            e.Graphics.FillRectangle(blueBrush, waterGirlX, waterGirlY, playerSize, playerSize);
            e.Graphics.FillRectangle(doorBrush, 440, 40, 30, 35);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region move 
            waterGirlY += jumpSpeed;
            if (jumping && force < 0)
            {
                jumping = false;
            }
            if (aDown)
            {
                waterGirlX -= 5;
            }
            if (dDown)
            { 
                waterGirlX += 5;
            }
            if (jumping)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }
            #endregion 

            Rectangle waterGirlRec = new Rectangle(waterGirlX, waterGirlY, playerSize, playerSize);

            for (int i = 0; i < landingXList.Count(); i++)
            {
                Rectangle land1Rec = new Rectangle (landingXList[i], landingYList[i], landingLList[i], 1);

                if (waterGirlRec.IntersectsWith(land1Rec) && !jumping)
                {
                    force = 7;
                    waterGirlY = landingYList[i] - playerSize;
                }

            }

            Rectangle doorRec = new Rectangle(440, 40, 30, 35);
            if (waterGirlRec.IntersectsWith(doorRec))
            {
                Thread.Sleep(2000);
                Application.Exit();
            }

            Refresh();
        }


    }
}
