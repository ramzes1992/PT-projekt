using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MVVM_WPF_Checkers.Helpers;
using CheckersLogic.Models;
using MVVM_WPF_Checkers.Services;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Drawing;
using CheckersLogic;

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

        private string _logMessages;
        public string LogMessages
        {
            get
            {
                if (_logMessages != null)
                {
                    return _logMessages;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if(_logMessages != value)
                {
                    _logMessages = value;
                    RaisePropertyChanged(() => LogMessages);
                }
            }
        }

        private Bitmap _imageFrame;
        public Bitmap ImageFrame
        {
            get
            {
                if (_imageFrame != null)
                {
                    return _imageFrame;
                }
                else
                {
                    return new Bitmap(640, 480);
                }
            }

            set
            {
                if (_imageFrame != value)
                {
                    _imageFrame = value;
                    RaisePropertyChanged(() => ImageFrame);
                    RaisePropertyChanged(() => RedRectangleFrame);
                    RaisePropertyChanged(() => GreenRectangleFrame);
                    RaisePropertyChanged(() => BlueRectangleFrame);
                    RaisePropertyChanged(() => YellowRectangleFrame);
                    RaisePropertyChanged(() => WhiteRectangleFrame);
                    RaisePropertyChanged(() => BlackRectangleFrame);
                }
            }
        }

        private Bitmap _tmpImageFrame;
        public Bitmap TmpImageFrame
        {
            get
            {
                return _tmpImageFrame;
            }
            set
            {
                if (_tmpImageFrame != value)
                {
                    _tmpImageFrame = value;
                    RaisePropertyChanged(() => TmpImageFrame);
                }
            }
        }

        public int Deviation
        {
            get
            {
                return _deviation;
            }
            set
            {
                if (value != _deviation)
                {
                    _deviation = value;
                    RaisePropertyChanged(() => Deviation);
                }
            }
        }
        private int _deviation;

        #region Colours Properties
        private double _redR;
        private double _redG;
        private double _redB;
        private double _greenR;
        private double _greenG;
        private double _greenB;
        private double _blueR;
        private double _blueG;
        private double _blueB;
        private double _yellowR;
        private double _yellowG;
        private double _yellowB;
        private double _whiteR;
        private double _whiteG;
        private double _whiteB;
        private double _blackR;
        private double _blackG;
        private double _blackB;

        public double RedR
        {
            get
            {
                return _redR;
            }
            set
            {
                if (value != _redR)
                {
                    _redR = value;
                    RaisePropertyChanged(() => RedR);
                }
            }
        }
        public double RedG
        {
            get
            {
                return _redG;
            }
            set
            {
                if (value != _redG)
                {
                    _redG = value;
                    RaisePropertyChanged(() => RedG);
                }
            }
        }
        public double RedB
        {
            get
            {
                return _redB;
            }
            set
            {
                if (value != _redB)
                {
                    _redB = value;
                    RaisePropertyChanged(() => RedB);
                }
            }
        }

        public double GreenR
        {
            get
            {
                return _greenR;
            }
            set
            {
                if (value != _greenR)
                {
                    _greenR = value;
                    RaisePropertyChanged(() => GreenR);
                }
            }
        }
        public double GreenG
        {
            get
            {
                return _greenG;
            }
            set
            {
                if (value != _greenG)
                {
                    _greenG = value;
                    RaisePropertyChanged(() => GreenG);
                }
            }
        }
        public double GreenB
        {
            get
            {
                return _greenB;
            }
            set
            {
                if (value != _greenB)
                {
                    _greenB = value;
                    RaisePropertyChanged(() => GreenB);
                }
            }
        }

        public double BlueR
        {
            get
            {
                return _blueR;
            }
            set
            {
                if (value != _blueR)
                {
                    _blueR = value;
                    RaisePropertyChanged(() => BlueR);
                }
            }
        }
        public double BlueG
        {
            get
            {
                return _blueG;
            }
            set
            {
                if (value != _blueG)
                {
                    _blueG = value;
                    RaisePropertyChanged(() => BlueG);
                }
            }
        }
        public double BlueB
        {
            get
            {
                return _blueB;
            }
            set
            {
                if (value != _blueB)
                {
                    _blueB = value;
                    RaisePropertyChanged(() => BlueB);
                }
            }
        }

        public double YellowR
        {
            get
            {
                return _yellowR;
            }
            set
            {
                if (value != _yellowR)
                {
                    _yellowR = value;
                    RaisePropertyChanged(() => YellowR);
                }
            }
        }
        public double YellowG
        {
            get
            {
                return _yellowG;
            }
            set
            {
                if (value != _yellowG)
                {
                    _yellowG = value;
                    RaisePropertyChanged(() => YellowG);
                }
            }
        }
        public double YellowB
        {
            get
            {
                return _yellowB;
            }
            set
            {
                if (value != _yellowB)
                {
                    _yellowB = value;
                    RaisePropertyChanged(() => YellowB);
                }
            }
        }

        public double WhiteR
        {
            get
            {
                return _whiteR;
            }
            set
            {
                if (value != _whiteR)
                {
                    _whiteR = value;
                    RaisePropertyChanged(() => WhiteR);
                }
            }
        }
        public double WhiteG
        {
            get
            {
                return _whiteG;
            }
            set
            {
                if (value != _whiteG)
                {
                    _whiteG = value;
                    RaisePropertyChanged(() => WhiteG);
                }
            }
        }
        public double WhiteB
        {
            get
            {
                return _whiteB;
            }
            set
            {
                if (value != _whiteB)
                {
                    _whiteB = value;
                    RaisePropertyChanged(() => WhiteB);
                }
            }
        }

        public double BlackR
        {
            get
            {
                return _blackR;
            }
            set
            {
                if (value != _blackR)
                {
                    _blackR = value;
                    RaisePropertyChanged(() => BlackR);
                }
            }
        }
        public double BlackG
        {
            get
            {
                return _blackG;
            }
            set
            {
                if (value != _blackG)
                {
                    _blackG = value;
                    RaisePropertyChanged(() => BlackG);
                }
            }
        }
        public double BlackB
        {
            get
            {
                return _blackB;
            }
            set
            {
                if (value != _blackB)
                {
                    _blackB = value;
                    RaisePropertyChanged(() => BlackB);
                }
            }
        }
        #endregion


        #region Colours Rectangles
        public Bitmap RedRectangleFrame
        {
            get
            {
                return ImageFrame.Clone(new Rectangle(490, 10, 140, 60), System.Drawing.Imaging.PixelFormat.DontCare);
            }
        }
        public Bitmap GreenRectangleFrame
        {
            get
            {
                return ImageFrame.Clone(new Rectangle(490, 90, 140, 60), System.Drawing.Imaging.PixelFormat.DontCare);
            }
        }
        public Bitmap BlueRectangleFrame
        {
            get
            {
                return ImageFrame.Clone(new Rectangle(490, 170, 140, 60), System.Drawing.Imaging.PixelFormat.DontCare);
            }
        }
        public Bitmap YellowRectangleFrame
        {
            get
            {
                return ImageFrame.Clone(new Rectangle(490, 250, 140, 60), System.Drawing.Imaging.PixelFormat.DontCare);
            }
        }
        public Bitmap WhiteRectangleFrame
        {
            get
            {
                return ImageFrame.Clone(new Rectangle(490, 330, 140, 60), System.Drawing.Imaging.PixelFormat.DontCare);
            }
        }
        public Bitmap BlackRectangleFrame
        {
            get
            {
                return ImageFrame.Clone(new Rectangle(490, 410, 140, 60), System.Drawing.Imaging.PixelFormat.DontCare);
            }
        }
        #endregion

        #endregion

        #region Commands

        public ICommand RunWebCamCommand { get { return new DelegateCommand(OnRunWebCam, CanExecuteRunWebCam); } }
        public ICommand StopWebCamCommand { get { return new DelegateCommand(OnStopWebCam, CanExecuteStopWebCam); } }
        public ICommand RunCalibrationCommand { get { return new DelegateCommand(OnRunCalibration, CanExecuteStartCalibration); } }
        public ICommand StopCalibrationCommand { get { return new DelegateCommand(OnStopCalibration, CanExecuteStopCalibration); } }
        public ICommand StartGameTracking { get { return new DelegateCommand(OnStartGameTracking, CanExecteStartGameTracking); } }
        #endregion

        #region Command Handlers

        private void OnRunWebCam()
        {
            if (_webCamService != null)
            {
                _webCamService.RunServiceAsync();
            }
        }

        private bool CanExecuteRunWebCam()
        {
            return (_webCamService != null) ? !_webCamService.IsRunning : false;
        }

        private void OnStopWebCam()
        {
            if (_webCamService != null)
            {
                _webCamService.CancelServiceAsync();
            }
        }

        private bool CanExecuteStopWebCam()
        {
            return (_webCamService != null) ? _webCamService.IsRunning : false;
        }

        private void OnRunCalibration()
        {
            if (_calibrationService != null)
            {
                _calibrationService.RunServiceAsync();
            }
        }

        private bool CanExecuteStartCalibration()
        {
            return (_calibrationService != null) ? !_calibrationService.IsRunning : false;
        }

        private void OnStopCalibration()
        {
            if (_calibrationService != null)
            {
                _calibrationService.CancelServiceAsync();
            }
        }

        private bool CanExecuteStopCalibration()
        {
            return (_calibrationService != null) ? _calibrationService.IsRunning : false;
        }

        private bool isTracking = false;
        private void OnStartGameTracking()
        {
            ////TODO
            //if (_currentBoard != null)
            //{
            //    _logicService.InitBoard(_currentBoard);
            //    isTracking = true;
            //}
        }

        bool isInitialValid = false;
        private bool CanExecteStartGameTracking()
        {
            return isInitialValid;
        }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            this.Board = new ObservableCollection<FieldState>();
            InitializeServices();

            Deviation = 50;
        }

        #region Initialize Services
        private void InitializeServices()
        {
            _webCamService = new WebCamService();
            _webCamService.ImageChanged += _webCamService_ImageChanged;
            _webCamService.ValidatedImageChanged += _webCamService_ValidatedImageChanged;
            _webCamService.BoardChanged += _webCamService_BoardChanged;

            _calibrationService = new CalibrationService();
            _calibrationService.RedPixelsModeChanged += _calibrationService_RedPixelsModeChanged;
            _calibrationService.GreenPixelsModeChanged += _calibrationService_GreenPixelsModeChanged;
            _calibrationService.BluePixelsModeChanged += _calibrationService_BluePixelsModeChanged;
            _calibrationService.YellowPixelsModeChanged += _calibrationService_YellowPixelsModeChanged;
            _calibrationService.WhitePixelsModeChanged += _calibrationService_WhitePixelsModeChanged;
            _calibrationService.BlackPixelsModeChanged += _calibrationService_BlackPixelsModeChanged;
        }

        private void _webCamService_BoardChanged(object sender, FieldState[,] board)
        {
            var tmp = new ObservableCollection<FieldState>();
            foreach (var state in board)
            {
                tmp.Add(state);
            }

            this.Board = tmp;
            //_currentBoard = board; // TODO
            //isInitialValid = _logicService.InitialValid(board); //TODO

            if (isTracking)
            {
                //_logMessages = _logicService.UpdateBoard(board) + Environment.NewLine + _logMessages; //TODO
            }
        }
        private void _webCamService_ImageChanged(object sender, System.Drawing.Bitmap image)
        {
            this.ImageFrame = image;
        }
        private void _webCamService_ValidatedImageChanged(object sender, Bitmap image)
        {
            this.TmpImageFrame = image;
        }

        #region PixelsModeChanged
        private void _calibrationService_RedPixelsModeChanged(double r, double g, double b)
        {
            RedR = r;
            RedG = g;
            RedB = b;

            _webCamService.Red_R_max = Convert.ToInt32(r) + Deviation;
            _webCamService.Red_R_min = Convert.ToInt32(r) - Deviation;
            _webCamService.Red_G_max = Convert.ToInt32(g) + Deviation;
            _webCamService.Red_G_min = Convert.ToInt32(g) - Deviation;
            _webCamService.Red_B_max = Convert.ToInt32(b) + Deviation;
            _webCamService.Red_B_min = Convert.ToInt32(b) - Deviation;
        }

        private void _calibrationService_GreenPixelsModeChanged(double r, double g, double b)
        {
            GreenR = r;
            GreenG = g;
            GreenB = b;

            _webCamService.Green_R_max = Convert.ToInt32(r) + Deviation;
            _webCamService.Green_R_min = Convert.ToInt32(r) - Deviation;
            _webCamService.Green_G_max = Convert.ToInt32(g) + Deviation;
            _webCamService.Green_G_min = Convert.ToInt32(g) - Deviation;
            _webCamService.Green_B_max = Convert.ToInt32(b) + Deviation;
            _webCamService.Green_B_min = Convert.ToInt32(b) - Deviation;
        }

        private void _calibrationService_BluePixelsModeChanged(double r, double g, double b)
        {
            BlueR = r;
            BlueG = g;
            BlueB = b;

            _webCamService.Blue_R_max = Convert.ToInt32(r) + Deviation;
            _webCamService.Blue_R_min = Convert.ToInt32(r) - Deviation;
            _webCamService.Blue_G_max = Convert.ToInt32(g) + Deviation;
            _webCamService.Blue_G_min = Convert.ToInt32(g) - Deviation;
            _webCamService.Blue_B_max = Convert.ToInt32(b) + Deviation;
            _webCamService.Blue_B_min = Convert.ToInt32(b) - Deviation;
        }

        private void _calibrationService_YellowPixelsModeChanged(double r, double g, double b)
        {
            YellowR = r;
            YellowG = g;
            YellowB = b;

            _webCamService.Yellow_R_max = Convert.ToInt32(r) + Deviation;
            _webCamService.Yellow_R_min = Convert.ToInt32(r) - Deviation;
            _webCamService.Yellow_G_max = Convert.ToInt32(g) + Deviation;
            _webCamService.Yellow_G_min = Convert.ToInt32(g) - Deviation;
            _webCamService.Yellow_B_max = Convert.ToInt32(b) + Deviation;
            _webCamService.Yellow_B_min = Convert.ToInt32(b) - Deviation;
        }

        private void _calibrationService_WhitePixelsModeChanged(double r, double g, double b)
        {
            WhiteR = r;
            WhiteG = g;
            WhiteB = b;

            _webCamService.White_R_max = Convert.ToInt32(r) + Deviation;
            _webCamService.White_R_min = Convert.ToInt32(r) - Deviation;
            _webCamService.White_G_max = Convert.ToInt32(g) + Deviation;
            _webCamService.White_G_min = Convert.ToInt32(g) - Deviation;
            _webCamService.White_B_max = Convert.ToInt32(b) + Deviation;
            _webCamService.White_B_min = Convert.ToInt32(b) - Deviation;
        }

        private void _calibrationService_BlackPixelsModeChanged(double r, double g, double b)
        {
            BlackR = r;
            BlackG = g;
            BlackB = b;

            _webCamService.Black_R_max = Convert.ToInt32(r) + Deviation;
            _webCamService.Black_R_min = Convert.ToInt32(r) - Deviation;
            _webCamService.Black_G_max = Convert.ToInt32(g) + Deviation;
            _webCamService.Black_G_min = Convert.ToInt32(g) - Deviation;
            _webCamService.Black_B_max = Convert.ToInt32(b) + Deviation;
            _webCamService.Black_B_min = Convert.ToInt32(b) - Deviation;
        }
        #endregion
        #endregion

        #endregion

        #region Members
        private WebCamService _webCamService;
        private CalibrationService _calibrationService;
        private CheckCheckers _logicService;
        private FieldState[,] _currentBoard;
        #endregion
    }
}