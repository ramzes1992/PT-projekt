using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using MVVM_WPF_Checkers.Models;
using System.ComponentModel;
using System.Threading;

namespace MVVM_WPF_Checkers.Services
{
    public class ExampleService
    {
        public event ImageChangedEventHandler ImageChanged;
        public delegate void ImageChangedEventHandler(object sender, int args);
        public bool IsRunning
        {
            get
            {
                return (_worker != null) ? _worker.IsBusy : false;
            }
        }

        private BackgroundWorker _worker;
        private int _count = 0;

        #region Constructor
        public ExampleService()
        {
            InitializeWorkers();
        }
        
        private void InitializeWorkers()
        {
            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
        }
        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!_worker.CancellationPending)
            {
                Thread.Sleep(33);
                RaiseImageChangedEvent();
            }
        }
        void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("ExampleServiceWorker has Stopped");
        }
        #endregion

        public void RunServiceAsync()
        {
            if (_worker != null)
            {
                _worker.RunWorkerAsync();
                Console.WriteLine("ExampleServiceWorker has Started");
            }
        }
        public void CancelServiceAsync()
        {
            if (_worker != null)
            {
                _worker.CancelAsync();
            }
        }

        private void RaiseImageChangedEvent()
        {
            if (this.ImageChanged != null)
            {
                this.ImageChanged(this, _count++);
            }
        }
    }
}
