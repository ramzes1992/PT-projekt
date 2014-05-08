using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVM_WPF_Checkers.Models;
using System.ComponentModel;
using System.Threading;

namespace MVVM_WPF_Checkers.Services
{
    public class TestService
    {
        public event BoardChangedEventHandler BoardChanged;
        public delegate void BoardChangedEventHandler(object sender, FieldState[,] board);
        public bool IsRunning
        {
            get
            {
                return (_worker != null) ? _worker.IsBusy : false;
            }
        }

        private FieldState[,] _board;
        private BackgroundWorker _worker;

        #region Constructor

        public TestService()
        {
            _board = new FieldState[8, 8];
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
        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Random rand = new Random();

            while (!(sender as BackgroundWorker).CancellationPending)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        _board[i, j] = (FieldState)(rand.Next() % 5);
                    }
                }

                RaiseBoardChangedEvent();
                Thread.Sleep(1000);
            }
        }
        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("TestServiceWorker has Stopped");
        }
        #endregion

        #endregion

        public void RunServiceAsync()
        {
            if (_worker != null)
            {
                _worker.RunWorkerAsync();
                Console.WriteLine("TestServiceWorker has Started");
            }
        }
        public void CancelServiceAsync()
        {
            if (_worker != null)
            {
                _worker.CancelAsync();
                Console.WriteLine("WebCamService was canceled");
            }
        }

        private void RaiseBoardChangedEvent()
        {
            if (BoardChanged != null)
            {
                BoardChanged(this, _board);
            }
        }
    }
}
