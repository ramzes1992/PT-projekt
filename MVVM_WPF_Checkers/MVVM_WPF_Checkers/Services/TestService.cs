﻿using System;
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

            for (int c = 0; c < 1000; c++)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        _board[i, j] = (FieldState)(rand.Next() % 5);
                    }
                }

                Thread.Sleep(1000);
                if ((sender as BackgroundWorker).CancellationPending)
                {
                    return;
                }
                else
                {
                    RiseBoardChangedEvent();
                }

            }
        }
        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Worker has Stopped");
        }
        #endregion

        #endregion

        public void RunServiceAsync()
        {
            if (_worker != null)
            {
                _worker.RunWorkerAsync();
                Console.WriteLine("Worker has Started");
            }
        }
        public void CancelServiceAsync()
        {
            if (_worker != null)
            {
                _worker.CancelAsync();
            }
        }

        private void RiseBoardChangedEvent()
        {
            if (BoardChanged != null)
            {
                BoardChanged(this, _board);
            }
        }
    }
}
