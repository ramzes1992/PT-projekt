using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

namespace CameraCapture
{
    public partial class CameraCapture : Form
    {
        private Capture capture;       
        private bool captureInProgress;
        #region red
        public int redRMaxVal;
        public int redRMinVal;
        public int redGMaxVal;
        public int redGMinVal;
        public int redBMaxVal;
        public int redBMinVal;
        #endregion

        #region green
        public int greenRMaxVal;
        public int greenRMinVal;
        public int greenGMaxVal;
        public int greenGMinVal;
        public int greenBMaxVal;
        public int greenBMinVal;
                #endregion

        #region yellow
        public int yellowRMaxVal;
        public int yellowRMinVal;
        public int yellowGMaxVal;
        public int yellowGMinVal;
        public int yellowBMaxVal;
        public int yellowBMinVal;
                #endregion

        #region blue
        public int blueRMaxVal;
        public int blueRMinVal;
        public int blueGMaxVal;
        public int blueGMinVal;
        public int blueBMaxVal;
        public int blueBMinVal;
                #endregion
        

        public CameraCapture()
        {
            InitializeComponent();

            #region red
            redRMaxVal = Convert.ToInt32(redRMax.Text);
            redRMinVal = Convert.ToInt32(redRMin.Text);
            redGMaxVal = Convert.ToInt32(redGMax.Text);
            redGMinVal = Convert.ToInt32(redGMin.Text);
            redBMaxVal = Convert.ToInt32(redBMax.Text);
            redBMinVal = Convert.ToInt32(redBMin.Text);
            #endregion

            #region green
            greenRMaxVal = Convert.ToInt32(greenRMax.Text);
            greenRMinVal = Convert.ToInt32(greenRMin.Text);
            greenGMaxVal = Convert.ToInt32(greenGMax.Text);
            greenGMinVal = Convert.ToInt32(greenGMin.Text);
            greenBMaxVal = Convert.ToInt32(greenBMax.Text);
            greenBMinVal = Convert.ToInt32(greenBMin.Text);
            #endregion

            #region yellow
            yellowRMaxVal = Convert.ToInt32(yellowRMax.Text);
            yellowRMinVal = Convert.ToInt32(yellowRMin.Text);
            yellowGMaxVal = Convert.ToInt32(yellowGMax.Text);
            yellowGMinVal = Convert.ToInt32(yellowGMin.Text);
            yellowBMaxVal = Convert.ToInt32(yellowBMax.Text);
            yellowBMinVal = Convert.ToInt32(yellowBMin.Text);
            #endregion

            #region blue
            blueRMaxVal = Convert.ToInt32(blueRMax.Text);
            blueRMinVal = Convert.ToInt32(blueRMin.Text);
            blueGMaxVal = Convert.ToInt32(blueGMax.Text);
            blueGMinVal = Convert.ToInt32(blueGMin.Text);
            blueBMaxVal = Convert.ToInt32(blueBMax.Text);
            blueBMinVal = Convert.ToInt32(blueBMin.Text);
            #endregion
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            #region pierwsze testy
            Image<Bgr, Byte> ImageFrame = capture.QueryFrame().Copy();  //line 1
            //Image<Gray, Byte> ImageFrame = capture.QueryGrayFrame();  //line 1
            //CamImageBox.Image = ImageFrame;        //line 2


            int wysokosc = ImageFrame.Height;
            int szerokosc = ImageFrame.Width;
            for (int i = 0; i < ImageFrame.Height; i++)
            {
                for (int j = 0; j < ImageFrame.Width; j++)
                {

                }
            }
            CamImageBox.Image = ImageFrame;
            #endregion

            #region wykrywanie skory
           /* Image<Bgr, Byte> ImageFrame = capture.QueryFrame().Copy();  //line 1
            Image<Gray, byte> S = new Image<Gray, byte>(ImageFrame.Width, ImageFrame.Height);
            Image<Gray, byte> skin = new Image<Gray, byte>(ImageFrame.Width, ImageFrame.Height);


            for (int i = skin.Height - 1; i >= 0; i--)
            {
                for (int j = skin.Width - 1; j >= 0; j--)
                {
                    
                    int R = ImageFrame.Data[i, j, 2];
                    int G = ImageFrame.Data[i, j, 1];
                    int B = ImageFrame.Data[i, j, 0];

                    double Rg = Math.Log(R) - Math.Log(G);
                    double By = Math.Log(B) - (Math.Log(G) + Math.Log(R)) / 2;

                    double hue_val = Math.Atan2(Rg, By) * (180 / Math.PI);
                    double sat_val = Math.Sqrt(Rg * Rg + By * By) * 255;


                    if (sat_val >= 20 && sat_val <= 130 && hue_val >= 110 && hue_val <= 180) //I simplified the naked people filter's two overlapping criteria
                    {
                        S[i, j] = new Gray(255);
                    }
                    else
                    {
                        S[i, j] = new Gray(0);
                    }
                }
            }

            skin = S.SmoothMedian(15); 
            CamImageBox.Image = skin;*/
#endregion

            #region wykrywanie koloru pierwszy test 
        /*    Image<Bgr, Byte> ImageFrame = capture.QueryFrame().Copy();  
            //Image<Gray, Byte> ImageFrame = capture.QueryGrayFrame().Copy();  /

            int wysokosc = ImageFrame.Height;
            int szerokosc = ImageFrame.Width;
            Bgr pixel;
            //Gray pixelgray;
            for (int i = 0; i < ImageFrame.Height; i++)
            {
                for (int j = 0; j < ImageFrame.Width; j++)
                {
                    //pixelgray = ImageFrame[i, j];
                    pixel = ImageFrame[i, j];
                    double b = pixel.Blue;
                    double g = pixel.Green;
                    double r = pixel.Red;
                    //if (r > 150 && r < 255 && g > 50 && g < 170 && b > 0 && b < 130)
                    if (r > 128 && r < 255 && g > 0 && g < 110 && b > 0 && b < 97)
                    {
                        pixel.Blue = 0;
                        pixel.Green = 0;
                        pixel.Red = 255; // czerwony
                        ImageFrame[i, j] = pixel;
                    }
                    else if (r > 0 && r < 102 && g > 128 && g < 255 && b > 0 && b < 119) 
                    {
                        pixel.Blue = 0;
                        pixel.Green = 255;
                        pixel.Red = 0; //zielony
                        ImageFrame[i, j] = pixel;
                    }
                    else if (r > 194 && r < 255 && g > 165 && g < 240 && b > 32 && b < 140)
                    {
                        pixel.Blue = 0;
                        pixel.Green = 191;
                        pixel.Red = 255; // złóty
                        ImageFrame[i, j] = pixel;
                    }
                    else if (r > 0 && r < 65 && g > 0 && g < 105 && b > 70 && b < 255)
                    {
                        pixel.Blue = 255;
                        pixel.Green = 0;
                        pixel.Red = 0; // niebieski
                        ImageFrame[i, j] = pixel;
                    }
                    else
                    {
                        pixel.Blue = 0;
                        pixel.Green = 0;
                        pixel.Red = 0;
                        ImageFrame[i, j] = pixel;
                    }
                }
            }

            CamImageBox.Image = ImageFrame;      */ 
            #endregion

            #region wykrywanie koloru 
            /*Image<Bgr, Byte> ImageFrame = capture.QueryFrame().Copy();
            //Image<Gray, Byte> ImageFrame = capture.QueryGrayFrame().Copy();  /

            int wysokosc = ImageFrame.Height;
            int szerokosc = ImageFrame.Width;
            Bgr pixel;
            //Gray pixelgray;
            for (int i = 0; i < ImageFrame.Height; i++)
            {
                for (int j = 0; j < ImageFrame.Width; j++)
                {
                    //pixelgray = ImageFrame[i, j];
                    pixel = ImageFrame[i, j];
                    double b = pixel.Blue;
                    double g = pixel.Green;
                    double r = pixel.Red;
                    //if (r > 150 && r < 255 && g > 50 && g < 170 && b > 0 && b < 130)
                    if (r > redRMinVal && r < redRMaxVal && g > redGMinVal && g < redGMaxVal && b > redBMinVal && b < redBMaxVal)
                    {
                        pixel.Blue = 0;
                        pixel.Green = 0;
                        pixel.Red = 255; // czerwony
                        ImageFrame[i, j] = pixel;
                    }
                    else if (r > greenRMinVal && r < greenRMaxVal && g > greenGMinVal && g < greenGMaxVal && b > greenBMinVal && b < greenBMaxVal) //if (r > 0 && r < 102 && g > 128 && g < 255 && b > 0 && b < 119)
                    {
                        pixel.Blue = 0;
                        pixel.Green = 255;
                        pixel.Red = 0; //zielony
                        ImageFrame[i, j] = pixel;
                    }
                    else if (r > yellowRMinVal && r < yellowRMaxVal && g > yellowGMinVal && g < yellowGMaxVal && b > yellowBMinVal && b < yellowBMaxVal) // if (r > 194 && r < 255 && g > 165 && g < 240 && b > 32 && b < 140)
                    {
                        pixel.Blue = 0;
                        pixel.Green = 191;
                        pixel.Red = 255; // złóty
                        ImageFrame[i, j] = pixel;
                    }
                    else if (r > blueRMinVal && r < blueRMaxVal && g > blueGMinVal && g < blueGMaxVal && b > blueBMinVal && b < blueBMaxVal) // if (r > 0 && r < 65 && g > 0 && g < 105 && b > 70 && b < 255)
                    {
                        pixel.Blue = 255;
                        pixel.Green = 0;
                        pixel.Red = 0; // niebieski
                        ImageFrame[i, j] = pixel;
                    }
                    else
                    {
                        pixel.Blue = 0;
                        pixel.Green = 0;
                        pixel.Red = 0;
                        ImageFrame[i, j] = pixel;
                    }
                }
            }

            CamImageBox.Image = ImageFrame;    */
            #endregion



        }

        private void ReleaseData()
        {
            if (capture != null)
                capture.Dispose();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            #region if capture is not created, create it now
            if (capture == null)
            {
                try
                {
                    capture = new Capture();
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            #endregion

            if (capture != null)
            {
                if (captureInProgress)
                {  
                    btnStart.Text = "Start!"; //
                    Application.Idle -= ProcessFrame;
                }
                else
                {
                    
                    btnStart.Text = "Stop";
                    Application.Idle += ProcessFrame;
                }

                captureInProgress = !captureInProgress;
            }
        }

        private void GreenLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonRedChange_Click(object sender, EventArgs e)
        {
            redRMaxVal = Convert.ToInt32(redRMax.Text);
            redRMinVal = Convert.ToInt32(redRMin.Text);
            redGMaxVal = Convert.ToInt32(redGMax.Text);
            redGMinVal = Convert.ToInt32(redGMin.Text);
            redBMaxVal = Convert.ToInt32(redBMax.Text);
            redBMinVal = Convert.ToInt32(redBMin.Text);
        }

        private void buttonGreenChange_Click(object sender, EventArgs e)
        {
            greenRMaxVal = Convert.ToInt32(greenRMax.Text);
            greenRMinVal = Convert.ToInt32(greenRMin.Text);
            greenGMaxVal = Convert.ToInt32(greenGMax.Text);
            greenGMinVal = Convert.ToInt32(greenGMin.Text);
            greenBMaxVal = Convert.ToInt32(greenBMax.Text);
            greenBMinVal = Convert.ToInt32(greenBMin.Text);
        }

        private void buttonYellowChange_Click(object sender, EventArgs e)
        {
            yellowRMaxVal = Convert.ToInt32(yellowRMax.Text);
            yellowRMinVal = Convert.ToInt32(yellowRMin.Text);
            yellowGMaxVal = Convert.ToInt32(yellowGMax.Text);
            yellowGMinVal = Convert.ToInt32(yellowGMin.Text);
            yellowBMaxVal = Convert.ToInt32(yellowBMax.Text);
            yellowBMinVal = Convert.ToInt32(yellowBMin.Text);
        }

        private void buttonBlueChange_Click(object sender, EventArgs e)
        {
            blueRMaxVal = Convert.ToInt32(blueRMax.Text);
            blueRMinVal = Convert.ToInt32(blueRMin.Text);
            blueGMaxVal = Convert.ToInt32(blueGMax.Text);
            blueGMinVal = Convert.ToInt32(blueGMin.Text);
            blueBMaxVal = Convert.ToInt32(blueBMax.Text);
            blueBMinVal = Convert.ToInt32(blueBMin.Text);
            
        }
    }
}
