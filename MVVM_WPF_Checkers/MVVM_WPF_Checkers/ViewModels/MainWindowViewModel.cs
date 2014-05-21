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


        private Bitmap _tmpImageFrame;
        public Bitmap TmpImageFrame
        {
            get
            {
                return _tmpImageFrame;
            }
            set
            {
                if(_tmpImageFrame != value)
                {
                    _tmpImageFrame = value;
                    RaisePropertyChanged(() => TmpImageFrame);
                }
            }
        }
        #endregion

        #region Shit

        #region Red
        //R
        private int _red_R_min;
        public int Red_R_min
        {
            get
            {
                return _red_R_min;
            }
            set
            {
                if (_red_R_min != value)
                {
                    _red_R_min = value;
                    _webCamService.Red_R_min = _red_R_min;
                    RaisePropertyChanged(() => Red_R_min);
                }
            }
        }

        private int _red_R_max;
        public int Red_R_max
        {
            get
            {
                return _red_R_max;
            }
            set
            {
                if (_red_R_max != value)
                {
                    _red_R_max = value;
                    _webCamService.Red_R_max = _red_R_max;
                    RaisePropertyChanged(() => Red_R_max);
                }
            }
        }

        //G
        private int _red_G_min;
        public int Red_G_min
        {
            get
            {
                return _red_G_min;
            }
            set
            {
                if (_red_G_min != value)
                {
                    _red_G_min = value;
                    _webCamService.Red_G_min = _red_G_min;
                    RaisePropertyChanged(() => Red_G_min);
                }
            }
        }

        private int _red_G_max;
        public int Red_G_max
        {
            get
            {
                return _red_G_max;
            }
            set
            {
                if (_red_G_max != value)
                {
                    _red_G_max = value;
                    _webCamService.Red_G_max = _red_G_max;
                    RaisePropertyChanged(() => Red_G_max);
                }
            }
        }

        //B
        private int _red_B_min;
        public int Red_B_min
        {
            get
            {
                return _red_B_min;
            }
            set
            {
                if (_red_B_min != value)
                {
                    _red_B_min = value;
                    _webCamService.Red_B_min = _red_B_min;
                    RaisePropertyChanged(() => Red_B_min);
                }
            }
        }

        private int _red_B_max;
        public int Red_B_max
        {
            get
            {
                return _red_B_max;
            }
            set
            {
                if (_red_B_max != value)
                {
                    _red_B_max = value;
                    _webCamService.Red_B_max = _red_B_max;
                    RaisePropertyChanged(() => Red_B_max);
                }
            }
        }
        #endregion

        #region Green
        //R
        private int _green_R_min;
        public int Green_R_min
        {
            get
            {
                return _green_R_min;
            }
            set
            {
                if (_green_R_min != value)
                {
                    _green_R_min = value;
                    _webCamService.Green_R_min = _green_R_min;
                    RaisePropertyChanged(() => Green_R_min);
                }
            }
        }

        private int _green_R_max;
        public int Green_R_max
        {
            get
            {
                return _green_R_max;
            }
            set
            {
                if (_green_R_max != value)
                {
                    _green_R_max = value;
                    _webCamService.Green_R_max = _green_R_max;
                    RaisePropertyChanged(() => Green_R_max);
                }
            }
        }

        //G
        private int _green_G_min;
        public int Green_G_min
        {
            get
            {
                return _green_G_min;
            }
            set
            {
                if (_green_G_min != value)
                {
                    _green_G_min = value;
                    _webCamService.Green_G_min = _green_G_min;
                    RaisePropertyChanged(() => Green_G_min);
                }
            }
        }

        private int _green_G_max;
        public int Green_G_max
        {
            get
            {
                return _green_G_max;
            }
            set
            {
                if (_green_G_max != value)
                {
                    _green_G_max = value;
                    _webCamService.Green_G_max = _green_G_max;
                    RaisePropertyChanged(() => Green_G_max);
                }
            }
        }

        //B
        private int _green_B_min;
        public int Green_B_min
        {
            get
            {
                return _green_B_min;
            }
            set
            {
                if (_green_B_min != value)
                {
                    _green_B_min = value;
                    _webCamService.Green_B_min = _green_B_min;
                    RaisePropertyChanged(() => Green_B_min);
                }
            }
        }

        private int _green_B_max;
        public int Green_B_max
        {
            get
            {
                return _green_B_max;
            }
            set
            {
                if (_green_B_max != value)
                {
                    _green_B_max = value;
                    _webCamService.Green_B_max = _green_B_max;
                    RaisePropertyChanged(() => Green_B_max);
                }
            }
        }
        #endregion

        #region Blue
        //R
        private int _blue_R_min;
        public int Blue_R_min
        {
            get
            {
                return _blue_R_min;
            }
            set
            {
                if (_blue_R_min != value)
                {
                    _blue_R_min = value;
                    _webCamService.Blue_R_min = _blue_R_min;
                    RaisePropertyChanged(() => Blue_R_min);
                }
            }
        }

        private int _blue_R_max;
        public int Blue_R_max
        {
            get
            {
                return _blue_R_max;
            }
            set
            {
                if (_blue_R_max != value)
                {
                    _blue_R_max = value;
                    _webCamService.Blue_R_max = _blue_R_max;
                    RaisePropertyChanged(() => Blue_R_max);
                }
            }
        }

        //G
        private int _blue_G_min;
        public int Blue_G_min
        {
            get
            {
                return _blue_G_min;
            }
            set
            {
                if (_blue_G_min != value)
                {
                    _blue_G_min = value;
                    _webCamService.Blue_G_min = _blue_G_min;
                    RaisePropertyChanged(() => Blue_G_min);
                }
            }
        }

        private int _blue_G_max;
        public int Blue_G_max
        {
            get
            {
                return _blue_G_max;
            }
            set
            {
                if (_blue_G_max != value)
                {
                    _blue_G_max = value;
                    _webCamService.Blue_G_max = _blue_G_max;
                    RaisePropertyChanged(() => Blue_G_max);
                }
            }
        }

        //B
        private int _blue_B_min;
        public int Blue_B_min
        {
            get
            {
                return _blue_B_min;
            }
            set
            {
                if (_blue_B_min != value)
                {
                    _blue_B_min = value;
                    _webCamService.Blue_B_min = _blue_B_min;
                    RaisePropertyChanged(() => Blue_B_min);
                }
            }
        }

        private int _blue_B_max;
        public int Blue_B_max
        {
            get
            {
                return _blue_B_max;
            }
            set
            {
                if (_blue_B_max != value)
                {
                    _blue_B_max = value;
                    _webCamService.Blue_B_max = _blue_B_max;
                    RaisePropertyChanged(() => Blue_B_max);
                }
            }
        }
        #endregion

        #region Yellow
        //R
        private int _yellow_R_min;
        public int Yellow_R_min
        {
            get
            {
                return _yellow_R_min;
            }
            set
            {
                if (_yellow_R_min != value)
                {
                    _yellow_R_min = value;
                    _webCamService.Yellow_R_min = _yellow_R_min;
                    RaisePropertyChanged(() => Yellow_R_min);
                }
            }
        }

        private int _yellow_R_max;
        public int Yellow_R_max
        {
            get
            {
                return _yellow_R_max;
            }
            set
            {
                if (_yellow_R_max != value)
                {
                    _yellow_R_max = value;
                    _webCamService.Yellow_R_max = _yellow_R_max;
                    RaisePropertyChanged(() => Yellow_R_max);
                }
            }
        }

        //G
        private int _yellow_G_min;
        public int Yellow_G_min
        {
            get
            {
                return _yellow_G_min;
            }
            set
            {
                if (_yellow_G_min != value)
                {
                    _yellow_G_min = value;
                    _webCamService.Yellow_G_min = _yellow_G_min;
                    RaisePropertyChanged(() => Yellow_G_min);
                }
            }
        }

        private int _yellow_G_max;
        public int Yellow_G_max
        {
            get
            {
                return _yellow_G_max;
            }
            set
            {
                if (_yellow_G_max != value)
                {
                    _yellow_G_max = value;
                    _webCamService.Yellow_G_max = _yellow_G_max;
                    RaisePropertyChanged(() => Yellow_G_max);
                }
            }
        }

        //B
        private int _yellow_B_min;
        public int Yellow_B_min
        {
            get
            {
                return _yellow_B_min;
            }
            set
            {
                if (_yellow_B_min != value)
                {
                    _yellow_B_min = value;
                    _webCamService.Yellow_B_min = _yellow_B_min;
                    RaisePropertyChanged(() => Yellow_B_min);
                }
            }
        }

        private int _yellow_B_max;
        public int Yellow_B_max
        {
            get
            {
                return _yellow_B_max;
            }
            set
            {
                if (_yellow_B_max != value)
                {
                    _yellow_B_max = value;
                    _webCamService.Yellow_B_max = _yellow_B_max;
                    RaisePropertyChanged(() => Yellow_B_max);
                }
            }
        }
        #endregion

        #region White
        //R
        private int _white_R_min;
        public int White_R_min
        {
            get
            {
                return _white_R_min;
            }
            set
            {
                if (_white_R_min != value)
                {
                    _white_R_min = value;
                    _webCamService.White_R_min = _white_R_min;
                    RaisePropertyChanged(() => White_R_min);
                }
            }
        }

        private int _white_R_max;
        public int White_R_max
        {
            get
            {
                return _white_R_max;
            }
            set
            {
                if (_white_R_max != value)
                {
                    _white_R_max = value;
                    _webCamService.White_R_max = _white_R_max;
                    RaisePropertyChanged(() => White_R_max);
                }
            }
        }

        //G
        private int _white_G_min;
        public int White_G_min
        {
            get
            {
                return _white_G_min;
            }
            set
            {
                if (_white_G_min != value)
                {
                    _white_G_min = value;
                    _webCamService.White_G_min = _white_G_min;
                    RaisePropertyChanged(() => White_G_min);
                }
            }
        }

        private int _white_G_max;
        public int White_G_max
        {
            get
            {
                return _white_G_max;
            }
            set
            {
                if (_white_G_max != value)
                {
                    _white_G_max = value;
                    _webCamService.White_G_max = _white_G_max;
                    RaisePropertyChanged(() => White_G_max);
                }
            }
        }

        //B
        private int _white_B_min;
        public int White_B_min
        {
            get
            {
                return _white_B_min;
            }
            set
            {
                if (_white_B_min != value)
                {
                    _white_B_min = value;
                    _webCamService.White_B_min = _white_B_min;
                    RaisePropertyChanged(() => White_B_min);
                }
            }
        }

        private int _white_B_max;
        public int White_B_max
        {
            get
            {
                return _white_B_max;
            }
            set
            {
                if (_white_B_max != value)
                {
                    _white_B_max = value;
                    _webCamService.White_B_max = _white_B_max;
                    RaisePropertyChanged(() => White_B_max);
                }
            }
        }
        #endregion

        #region Black
        //R
        private int _black_R_min;
        public int Black_R_min
        {
            get
            {
                return _black_R_min;
            }
            set
            {
                if (_black_R_min != value)
                {
                    _black_R_min = value;
                    _webCamService.Black_R_min = _black_R_min;
                    RaisePropertyChanged(() => Black_R_min);
                }
            }
        }

        private int _black_R_max;
        public int Black_R_max
        {
            get
            {
                return _black_R_max;
            }
            set
            {
                if (_black_R_max != value)
                {
                    _black_R_max = value;
                    _webCamService.Black_R_max = _black_R_max;
                    RaisePropertyChanged(() => Black_R_max);
                }
            }
        }

        //G
        private int _black_G_min;
        public int Black_G_min
        {
            get
            {
                return _black_G_min;
            }
            set
            {
                if (_black_G_min != value)
                {
                    _black_G_min = value;
                    _webCamService.Black_G_min = _black_G_min;
                    RaisePropertyChanged(() => Black_G_min);
                }
            }
        }

        private int _black_G_max;
        public int Black_G_max
        {
            get
            {
                return _black_G_max;
            }
            set
            {
                if (_black_G_max != value)
                {
                    _black_G_max = value;
                    _webCamService.Black_G_max = _black_G_max;
                    RaisePropertyChanged(() => Black_G_max);
                }
            }
        }

        //B
        private int _black_B_min;
        public int Black_B_min
        {
            get
            {
                return _black_B_min;
            }
            set
            {
                if (_black_B_min != value)
                {
                    _black_B_min = value;
                    _webCamService.Black_G_min = _black_B_min;
                    RaisePropertyChanged(() => Black_B_min);
                }
            }
        }

        private int _black_B_max;
        public int Black_B_max
        {
            get
            {
                return _black_B_max;
            }
            set
            {
                if (_black_B_max != value)
                {
                    _black_B_max = value;
                    _webCamService.Black_B_max = _black_B_max;
                    RaisePropertyChanged(() => Black_B_max);
                }
            }
        }
        #endregion

        #endregion

        #region Commands

        public ICommand RunWebCamCommand { get { return new DelegateCommand(OnRunWebCam); } }
        public ICommand StopWebCamCommand { get { return new DelegateCommand(OnStopWebCam, CanExecuteStopWebCam); } }

        #endregion

        #region Command Handlers

        private void OnRunWebCam()
        {
            if (_webCamService != null)
            {
                _webCamService.RunWServiceAsync();
            }
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

        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            this.Board = new ObservableCollection<FieldState>();
            InitializeServices();

            Red_R_min = 194;
            Red_R_max = 255;

            Red_G_min = 54;
            Red_G_max = 151;

            Red_B_min = 33;
            Red_B_max = 122;


            Green_R_min = 60;
            Green_R_max = 169;

            Green_G_min = 175;
            Green_G_max = 255;

            Green_B_min = 67;
            Green_B_max = 191;


            Yellow_R_min = 220;
            Yellow_R_max = 255;

            Yellow_G_min = 216;
            Yellow_G_max = 255;

            Yellow_B_min = 73;
            Yellow_B_max = 205;

            Blue_R_min = 0;
            Blue_R_max = 72;

            Blue_G_min = 161;
            Blue_G_max = 255;

            Blue_B_min = 202;
            Blue_B_max = 255;

            White_R_min = 220;
            White_R_max = 255;

            White_G_min = 220;
            White_G_max = 255;

            White_B_min = 220;
            White_B_max = 255;

            Black_R_min = 0;
            Black_R_max = 130;

            Black_G_min = 0;
            Black_G_max = 130;

            Black_B_min = 0;
            Black_B_max = 130;

        }

        #region Initialize Services
        private void InitializeServices()
        {
            _webCamService = new WebCamService();
            _webCamService.ImageChanged += _webCamService_ImageChanged;
            _webCamService.ValidatedImageChanged += _webCamService_ValidatedImageChanged;
            _webCamService.BoardChanged += _webCamService_BoardChanged;
        }

        void _webCamService_BoardChanged(object sender, FieldState[,] board)
        {
            var tmp = new ObservableCollection<FieldState>();
            foreach (var state in board)
            {
                tmp.Add(state);
            }

            this.Board = tmp;
        }
        private void _webCamService_ImageChanged(object sender, System.Drawing.Bitmap image)
        {
            this.ImageFrame = image;
        }
        private void _webCamService_ValidatedImageChanged(object sender, Bitmap image)
        {
            this.TmpImageFrame = image;
        }
        #endregion

        #endregion

        #region Members
        private WebCamService _webCamService;
        #endregion
    }
}