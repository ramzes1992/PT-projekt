using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MVVM_WPF_Checkers.Helpers;
using MVVM_WPF_Checkers.Models;
using MVVM_WPF_Checkers.Services;

namespace MVVM_WPF_Checkers.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Properties

        private ObservableCollection<FieldState> _board;
        public ObservableCollection<FieldState> Board
        {
            get
            {
                return _board;
            }

            set
            {
                if (_board != value)
                {
                    _board = value;
                    RaisePropertyChanged(() => Board);
                }
            }
        }

        #endregion

        #region Commands

        public ICommand RunWebCamCommand { get { return new DelegateCommand(OnRunWebCam); } }
        public ICommand StopWebCamCommand { get { return new DelegateCommand(OnStopWebCam, CanExecuteStopWebCam); } }

        #endregion

        #region Command Handlers

        private void OnRunWebCam()
        {
            if (_testService != null)
            {
                _testService.RunServiceAsync();
            }
        }

        private void OnStopWebCam()
        {
            if (_testService != null)
            {
                _testService.CancelServiceAsync();
            }
        }

        private bool CanExecuteStopWebCam()
        {
            return true;
        }

        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            this.Board = new ObservableCollection<FieldState>();
            InitializeServices();
        }

        #region Initialize Services
        private void InitializeServices()
        {
            _testService = new TestService();
            _testService.BoardChanged += _testService_BoardChanged;
        }
        void _testService_BoardChanged(object sender, FieldState[,] board)
        {
            this.Board = new ObservableCollection<FieldState>();
            foreach (var state in board)
            {
                this.Board.Add(state);
            }
        }
        #endregion

        #endregion

        private TestService _testService;
    }
}