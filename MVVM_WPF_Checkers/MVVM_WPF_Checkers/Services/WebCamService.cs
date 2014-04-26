using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
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
    public class WebCamService
    {
        #region Members
        private Emgu.CV.Capture capture;
        private BackgroundWorker _worker;
        #endregion

        #region Events
        public event ImageChangedEventHndler ImageChanged;
        public delegate void ImageChangedEventHndler(object sender, Bitmap image);
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

        #region Public Methods

        public void RunWServiceAsync()
        {
            _worker.RunWorkerAsync();
        }

        public void CancelServiceAsync()
        {
            _worker.CancelAsync();
        }
        #endregion

        #region Private Methods
        private void RaiseImageChangedEvent(Bitmap image)
        {
            if (ImageChanged != null)
            {
                ImageChanged(this, image);
            }
        }
        #endregion

        #region Constructor
        public WebCamService()
        {
            capture = new Capture();
            InitializeWorkers();
        }

        #region InitializeWorkers
        private void InitializeWorkers()
        {
            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
        }
        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Image<Bgr, Byte> ImageFrame = capture.QueryFrame().Copy();  //line 1
            //Image<Gray, Byte> ImageFrame = capture.QueryGrayFrame();  //line 1
            //CamImageBox.Image = ImageFrame;        //line 2

            /*
            int wysokosc = ImageFrame.Height;
            int szerokosc = ImageFrame.Width;
            for (int i = 0; i < ImageFrame.Height; i++)
            {
                for (int j = 0; j < ImageFrame.Width; j++)
                {

                }
            }*/
            //CamImageBox.Image = ImageFrame;
            RaiseImageChangedEvent(ImageFrame.ToBitmap());
        }
        void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }
        #endregion

        #endregion
    }
}
