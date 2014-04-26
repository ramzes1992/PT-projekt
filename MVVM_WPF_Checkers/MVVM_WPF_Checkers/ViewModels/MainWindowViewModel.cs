using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MVVM_WPF_Checkers.Helpers;
using MVVM_WPF_Checkers.Models;
using MVVM_WPF_Checkers.Services;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Drawing;

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

        private Bitmap _imageFrame;
        public Bitmap ImageFrame
        {
            get
            {
                return _imageFrame;
            }

            set
            {
                if (_imageFrame != value)
                {
                    _imageFrame = value;
                    RaisePropertyChanged(() => ImageFrame);
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
            if (_testService != null) // TODO caly ten warunek do wyjebania
            {
                _testService.RunServiceAsync();
            }

            if (_webCamService != null)
            {
                _webCamService.RunWServiceAsync();
            }
        }

        private void OnStopWebCam()
        {
            if (_testService != null) // TODO ca³y ten warunek do wyjebania
            {
                _testService.CancelServiceAsync();
            }

            if (_webCamService != null)
            {
                _webCamService.CancelServiceAsync();
            }
        }

        private bool CanExecuteStopWebCam()
        {
            return (_webCamService != null) ? _webCamService.IsRunning : false;
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

            _webCamService = new WebCamService();
            _webCamService.ImageChanged += _webCamService_ImageChanged;
        }

        private void _webCamService_ImageChanged(object sender, System.Drawing.Bitmap image)
        {
            this.ImageFrame = image;
        }
        private void _testService_BoardChanged(object sender, FieldState[,] board)
        {
            this.Board = new ObservableCollection<FieldState>();
            foreach (var state in board)
            {
                this.Board.Add(state);
            }
        }
        #endregion

        #endregion


        #region Members
        private TestService _testService;
        private WebCamService _webCamService;
        #endregion
    }
}