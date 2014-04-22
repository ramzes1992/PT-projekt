using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MVVM_WPF_Checkers.Helpers;
using MVVM_WPF_Checkers.Models;
using MVVM_WPF_Checkers.Services;
using System.Windows.Media.Imaging;
using System.Windows.Media;

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

        private string _imageSource;
        public string ImageSource
        {
            get
            {
                return _imageSource;
            }

            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    RaisePropertyChanged(() => ImageSource);
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
                _exampleService.RunServiceAsync();//do wyjebania(tylko test)
            }
        }

        private void OnStopWebCam()
        {
            if (_testService != null)
            {
                _testService.CancelServiceAsync();
                _exampleService.CancelServiceAsync();//do wyjebania (tylko test)
            }
        }

        private bool CanExecuteStopWebCam()
        {
            return (_testService != null) ? _testService.IsRunning : false;
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

            _exampleService = new ExampleService();
            _exampleService.ImageChanged += _exampleService_ImageChanged;
        }
        private void _testService_BoardChanged(object sender, FieldState[,] board)
        {
            this.Board = new ObservableCollection<FieldState>();
            foreach (var state in board)
            {
                this.Board.Add(state);
            }
        }
        private void _exampleService_ImageChanged(object sender, int args)
        {
            if (args % 2 == 0)
            {
                this.ImageSource = "Images/testChess2.jpg";//new BitmapImage(new Uri("Images/testChess2.jpg", UriKind.Relative));
            }
            else
            {
                this.ImageSource = "Images/testChess1.jpg";//new BitmapImage(new Uri("Images/testChess1.jpg", UriKind.Relative));
            }
        }
        #endregion

        #endregion

        private TestService _testService;
        private ExampleService _exampleService;
        
    }
}