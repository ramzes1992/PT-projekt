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
    public class WebCamService
    {
        #region Members
        private Emgu.CV.Capture capture;
        private BackgroundWorker _webCamWorker;
        private BackgroundWorker _validationWorker;
        private object _syncPropsObject;
        private object _syncImageObcject;

        private Image<Bgr, Byte> _currentCapture;
        private Image<Bgr, Byte> CurrentCapture
        {
            get
            {
                return _currentCapture;
            }

            set
            {
                if (_currentCapture != value)
                {
                    lock (_syncImageObcject)
                    {
                        _currentCapture = value;
                    }
                }
            }
        }

        #endregion

        #region Events
        public event ImageChangedEventHndler ImageChanged;
        public delegate void ImageChangedEventHndler(object sender, Bitmap image);

        public event ValidatedImageChangedEventHndler ValidatedImageChanged;
        public delegate void ValidatedImageChangedEventHndler(object sender, Bitmap image);

        public event BoardChangedEventHandler BoardChanged;
        public delegate void BoardChangedEventHandler(object sender, FieldState[,] board);
        #endregion

        #region Properties
        public bool IsRunning
        {
            get
            {
                return (_webCamWorker != null) ? _webCamWorker.IsBusy : false
                    && (_validationWorker != null) ? _validationWorker.IsBusy : false;
            }
        }

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
                    lock (_syncPropsObject)
                    {
                        _red_R_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _red_R_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _red_G_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _red_G_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _red_B_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _red_B_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _green_R_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _green_R_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _green_G_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _green_G_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _green_B_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _green_B_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _blue_R_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _blue_R_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _blue_G_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _blue_G_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _blue_B_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _blue_B_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _yellow_R_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _yellow_R_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _yellow_G_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _yellow_G_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _yellow_B_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _yellow_B_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _white_R_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _white_R_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _white_G_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _white_G_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _white_B_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _white_B_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _black_R_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _black_R_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _black_G_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _black_G_max = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _black_B_min = value;
                    }
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
                    lock (_syncPropsObject)
                    {
                        _black_B_max = value;
                    }
                }
            }
        }
        #endregion

        #endregion

        #region Public Methods
        public void RunServiceAsync()
        {
            _webCamWorker.RunWorkerAsync();
            _validationWorker.RunWorkerAsync();
            Console.WriteLine("WebCamService has started");
            Console.WriteLine("ValidationService has started");
        }

        public void CancelServiceAsync()
        {
            if (_webCamWorker != null)
            {
                _webCamWorker.CancelAsync();
                Console.WriteLine("WebCamService was canceled");

                _validationWorker.CancelAsync();
                Console.WriteLine("ValidationService was canceled");
            }
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

        private void RaiseValidatedImageChangedEvent(Bitmap image)
        {
            if (ValidatedImageChanged != null)
            {
                ValidatedImageChanged(this, image);
            }
        }

        private void RaiseBoardChangedEvent(FieldState[,] board)
        {
            if (BoardChanged != null)
            {
                BoardChanged(this, board);
            }
        }

        private Tuple<FieldCounter[,], Image<Bgr, Byte>> getFileStateTabel(Image<Bgr, Byte> boardPlaceImage)
        {

            FieldCounter[,] fieldCounterTable;
            fieldCounterTable = new FieldCounter[8, 8];



            for (int boardHeight = 0; boardHeight < 8; boardHeight++)
            {
                for (int boardWidth = 0; boardWidth < 8; boardWidth++)
                {
                    int imin = 60 * boardWidth;
                    int imax = (60 * boardWidth) + 60;
                    int jmin = 60 * boardHeight;
                    int jmax = (60 * boardHeight) + 60;
                    int iminRefresh = imin;
                    fieldCounterTable[boardHeight, boardWidth] = new FieldCounter();
                    //FieldCounter varFieldCounter = new FieldCounter();
                    for (; jmin < jmax; jmin++)
                    {
                        imin = iminRefresh;
                        for (; imin < imax; imin++)
                        {

                            Bgr pixel = boardPlaceImage[jmin, imin];
                            double b = pixel.Blue;
                            double g = pixel.Green;
                            double r = pixel.Red;

                            if (r >= Red_R_min && r <= Red_R_max && g >= Red_G_min && g <= Red_G_max && b >= Red_B_min && b <= Red_B_max)
                            {
                                pixel.Blue = 0;
                                pixel.Green = 0;
                                pixel.Red = 255; // czerwony
                                boardPlaceImage[jmin, imin] = pixel;
                                fieldCounterTable[boardHeight, boardWidth].red++;
                            }
                            else if (r >= Green_R_min && r <= Green_R_max && g >= Green_G_min && g <= Green_G_max && b >= Green_B_min && b <= Green_B_max) //if (r >= 0 && r <= 102 && g >= 128 && g <= 255 && b >= 0 && b <= 119)
                            {
                                pixel.Blue = 0;
                                pixel.Green = 255;
                                pixel.Red = 0; //zielony
                                boardPlaceImage[jmin, imin] = pixel;
                                fieldCounterTable[boardHeight, boardWidth].green++;
                            }
                            else if (r >= Yellow_R_min && r <= Yellow_R_max && g >= Yellow_G_min && g <= Yellow_G_max && b >= Yellow_B_min && b <= Yellow_B_max) // if (r >= 194 && r <= 255 && g >= 165 && g <= 240 && b >= 32 && b <= 140)
                            {
                                pixel.Blue = 0;
                                pixel.Green = 191;
                                pixel.Red = 255; // złóty
                                boardPlaceImage[jmin, imin] = pixel;
                                fieldCounterTable[boardHeight, boardWidth].yellow++;
                            }
                            else if (r >= Blue_R_min && r <= Blue_R_max && g >= Blue_G_min && g <= Blue_G_max && b >= Blue_B_min && b <= Blue_B_max) // if (r >= 0 && r <= 65 && g >= 0 && g <= 105 && b >= 70 && b <= 255)
                            {
                                pixel.Blue = 255;
                                pixel.Green = 0;
                                pixel.Red = 0; // niebieski
                                boardPlaceImage[jmin, imin] = pixel;
                                fieldCounterTable[boardHeight, boardWidth].blue++;
                            }
                            else if (r >= White_R_min && r <= White_R_max && g >= White_G_min && g <= White_G_max && b >= White_B_min && b <= White_B_max)
                            {
                                pixel.Blue = 255;
                                pixel.Green = 255;
                                pixel.Red = 255;//bialy
                                boardPlaceImage[jmin, imin] = pixel;
                                fieldCounterTable[boardHeight, boardWidth].white++;
                            }
                            else if (r >= Black_R_min && r <= Black_R_max && g >= Black_G_min && g <= Black_G_max && b >= Black_B_min && b <= Black_B_max)
                            {
                                pixel.Blue = 0;
                                pixel.Green = 0;
                                pixel.Red = 0; //czarny
                                boardPlaceImage[jmin, imin] = pixel;
                                fieldCounterTable[boardHeight, boardWidth].black++;
                            }
                            else
                            {
                                pixel.Blue = 194;
                                pixel.Green = 255;
                                pixel.Red = 0; //szpitalny
                                boardPlaceImage[jmin, imin] = pixel;
                                fieldCounterTable[boardHeight, boardWidth].undefined++;
                            }
                        }
                    }
                }
            }
            Tuple<FieldCounter[,], Image<Bgr, Byte>> result = new Tuple<FieldCounter[,], Image<Bgr, Byte>>(fieldCounterTable, boardPlaceImage);
            return result;
        }
        #endregion

        #region Constructor
        public WebCamService()
        {
            capture = new Emgu.CV.Capture();
            _syncPropsObject = new object();
            _syncImageObcject = new object();
            CurrentCapture = new Image<Bgr, byte>(640, 480);
            InitializeWorkers();

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

        #region InitializeWorkers
        private void InitializeWorkers()
        {
            _webCamWorker = new BackgroundWorker();
            _webCamWorker.WorkerSupportsCancellation = true;
            _webCamWorker.DoWork += _webCamWorker_DoWork;
            _webCamWorker.RunWorkerCompleted += _webCamWorker_RunWorkerCompleted;

            _validationWorker = new BackgroundWorker();
            _validationWorker.WorkerSupportsCancellation = true;
            _validationWorker.DoWork += _validationWorker_DoWork;
            _validationWorker.RunWorkerCompleted += _validationWorker_RunWorkerCompleted;
        }
        private void _webCamWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("WebCamService has stopped");
        }
        private void _validationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("ValidationService has stopped");
        }
        #endregion

        #endregion

        #region Work

        private void _webCamWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!_webCamWorker.CancellationPending)
            {
                CurrentCapture = capture.QueryFrame().Copy();
                RaiseImageChangedEvent(CurrentCapture.Bitmap);
            }
        }

        private void _validationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!_validationWorker.CancellationPending)
            {
                #region Some Shit

                Image<Bgr, Byte> ImageFrameClone = CurrentCapture.Copy(new Rectangle(0, 0, 480, 480));

                Tuple<FieldCounter[,], Image<Bgr, Byte>> result = getFileStateTabel(ImageFrameClone);
                ImageFrameClone = result.Item2;


                FieldState[,] fieldStareTable;
                fieldStareTable = new FieldState[8, 8];
                bool playerMakeMove = false;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        int[] fieldValues = { result.Item1[i, j].white, result.Item1[i, j].black, result.Item1[i, j].red, result.Item1[i, j].green, result.Item1[i, j].blue, result.Item1[i, j].yellow, result.Item1[i, j].undefined };
                        int dominationColor = fieldValues.Max();

                        if (result.Item1[i, j].white == dominationColor)
                        {
                            fieldStareTable[i, j] = FieldState.Empty;
                        }
                        else if (result.Item1[i, j].black == dominationColor)
                        {
                            fieldStareTable[i, j] = FieldState.Empty;
                        }
                        else if (result.Item1[i, j].red == dominationColor)
                        {
                            fieldStareTable[i, j] = FieldState.RedPawn;
                        }
                        else if (result.Item1[i, j].green == dominationColor)
                        {
                            fieldStareTable[i, j] = FieldState.GreenPawn;
                        }
                        else if (result.Item1[i, j].yellow == dominationColor)
                        {
                            fieldStareTable[i, j] = FieldState.YellowPawn;
                        }
                        else if (result.Item1[i, j].blue == dominationColor)
                        {
                            fieldStareTable[i, j] = FieldState.BluePawn;
                        }
                        else if (result.Item1[i, j].undefined == dominationColor)
                        {
                            playerMakeMove = true;
                            break;
                        }
                    }
                    if (playerMakeMove)
                    {
                        break;
                    }
                }

                if (!playerMakeMove)
                {
                    RaiseBoardChangedEvent(fieldStareTable);
                }

                RaiseValidatedImageChangedEvent(ImageFrameClone.Bitmap);
                #endregion
            }
        }

        #endregion
    }

    class FieldCounter
    {
        public int white;
        public int black;
        public int red;
        public int green;
        public int yellow;
        public int blue;
        public int undefined;
        public FieldCounter()
        {
            this.white = 0;
            this.black = 0;
            this.green = 0;
            this.red = 0;
            this.yellow = 0;
            this.blue = 0;
            this.undefined = 0;

        }
    }
}
