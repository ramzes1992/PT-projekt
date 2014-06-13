using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using CheckersLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MVVM_WPF_Checkers.Services
{
    public class CalibrationService
    {
        #region Events

        public event PixelChangedHandler RedPixelsModeChanged;
        public event PixelChangedHandler GreenPixelsModeChanged;
        public event PixelChangedHandler BluePixelsModeChanged;
        public event PixelChangedHandler YellowPixelsModeChanged;
        public event PixelChangedHandler WhitePixelsModeChanged;
        public event PixelChangedHandler BlackPixelsModeChanged;
        public delegate void PixelChangedHandler(double r, double g, double b);
        #endregion

        #region Properties
        public bool IsRunning
        {
            get
            {
                return (_worker != null) ? _worker.IsBusy : false;
            }
        }
        #endregion

        #region Members
        private Emgu.CV.Capture _capture;
        private BackgroundWorker _worker;
        #endregion

        #region Constructor

        public CalibrationService()
        {
            _capture = new Emgu.CV.Capture();
            InitializeWorkers();
        }

        #region InitializeWorkers
        private void InitializeWorkers()
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
            _worker.WorkerSupportsCancellation = true;
        }
        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("CalibrationServiceWorker has Stopped");
        }
        #endregion

        #endregion

        #region Public Methods
        public void RunServiceAsync()
        {
            if (_worker != null)
            {
                _worker.RunWorkerAsync();
                Console.WriteLine("CalibrationServiceWorker has Started");
            }
        }
        public void CancelServiceAsync()
        {
            if (_worker != null)
            {
                _worker.CancelAsync();
                Console.WriteLine("CalibrationService was canceled");
            }
        }
        #endregion

        #region Work
        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!_worker.CancellationPending)
            {
                var frame = _capture.QueryFrame().Copy();

                var redRectangle = frame.Copy(new Rectangle(490, 10, 140, 60));
                var greenRectangle = frame.Copy(new Rectangle(490, 90, 140, 60));
                var blueRectangle = frame.Copy(new Rectangle(490, 170, 140, 60));
                var yellowRectangle = frame.Copy(new Rectangle(490, 250, 140, 60));
                var whiteRectangle = frame.Copy(new Rectangle(490, 330, 140, 60));
                var blackRectangle = frame.Copy(new Rectangle(490, 410, 140, 60));

                RaiseRedPixelsModeChanged(GetRGBMode(redRectangle));
                RaiseGreenPixelsModeChanged(GetRGBMode(greenRectangle));
                RaiseBluePixelsModeChanged(GetRGBMode(blueRectangle));
                RaiseYellowPixelsModeChanged(GetRGBMode(yellowRectangle));
                RaiseWhitePixelsModeChanged(GetRGBMode(whiteRectangle));
                RaiseBlackPixelsModeChanged(GetRGBMode(blackRectangle));
            }
        }
        #endregion

        #region Private Methods

        private void RaiseRedPixelsModeChanged(Pixel pixel)
        {
            var eventCopy = RedPixelsModeChanged;
            if (RedPixelsModeChanged != null)
            {
                eventCopy(pixel.R, pixel.G, pixel.B);
            }
        }
        private void RaiseGreenPixelsModeChanged(Pixel pixel)
        {
            var eventCopy = GreenPixelsModeChanged;
            if (GreenPixelsModeChanged != null)
            {
                eventCopy(pixel.R, pixel.G, pixel.B);
            }
        }
        private void RaiseBluePixelsModeChanged(Pixel pixel)
        {
            var eventCopy = BluePixelsModeChanged;
            if (BluePixelsModeChanged != null)
            {
                eventCopy(pixel.R, pixel.G, pixel.B);
            }
        }
        private void RaiseYellowPixelsModeChanged(Pixel pixel)
        {
            var eventCopy = YellowPixelsModeChanged;
            if (YellowPixelsModeChanged != null)
            {
                eventCopy(pixel.R, pixel.G, pixel.B);
            }
        }
        private void RaiseWhitePixelsModeChanged(Pixel pixel)
        {
            var eventCopy = WhitePixelsModeChanged;
            if (WhitePixelsModeChanged != null)
            {
                eventCopy(pixel.R, pixel.G, pixel.B);
            }
        }
        private void RaiseBlackPixelsModeChanged(Pixel pixel)
        {
            var eventCopy = BlackPixelsModeChanged;
            if (BlackPixelsModeChanged != null)
            {
                eventCopy(pixel.R, pixel.G, pixel.B);
            }
        }

        private Pixel GetRGBMode(Image<Bgr, Byte> image)
        {
            Dictionary<double, int> redValues = new Dictionary<double, int>();
            Dictionary<double, int> greenValues = new Dictionary<double, int>();
            Dictionary<double, int> blueValues = new Dictionary<double, int>();

            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 140; j++)
                {
                    var pixel = image[i, j];


                    if (redValues.ContainsKey(pixel.Red))
                    {
                        redValues[pixel.Red]++;
                    }
                    else
                    {
                        redValues[pixel.Red] = 1;
                    }

                    if (greenValues.ContainsKey(pixel.Green))
                    {
                        greenValues[pixel.Green]++;
                    }
                    else
                    {
                        greenValues[pixel.Green] = 1;
                    }

                    if (blueValues.ContainsKey(pixel.Blue))
                    {
                        blueValues[pixel.Blue]++;
                    }
                    else
                    {
                        blueValues[pixel.Blue] = 1;
                    }
                }
            }

            var r = redValues.OrderByDescending(t => t.Value).First().Key;
            var g = greenValues.OrderByDescending(t => t.Value).First().Key;
            var b = blueValues.OrderByDescending(t => t.Value).First().Key;

            return new Pixel(r, g, b);
        }
        #endregion

        private class Pixel
        {
            public double R;
            public double G;
            public double B;

            public Pixel(double r, double g, double b)
            {
                this.R = r;
                this.G = g;
                this.B = b;
            }
        }
    }

    
}
