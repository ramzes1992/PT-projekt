using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CheckersLogic.Models;
using CheckersLogic;

namespace TestBoard_WPF
{
    public partial class MainWindow
    {
        private readonly CheckCheckers _checkCheckers;
        private string _messageLog;
        private int _messageLogCounter;

        public MainWindow()
        {
            InitializeComponent();
            Images = new ObservableCollection<Image>();
            v_ListBox_Board.DataContext = Images;
            _checkCheckers = new CheckCheckers();
        }

        public ObservableCollection<Image> Images { get; private set; }

        readonly BitmapImage RedPawn = Converter.StringToBitmapImageConverter("Images/RedPawn.png");
        readonly BitmapImage YellowPawn = Converter.StringToBitmapImageConverter("Images/YellowPawn.png");
        readonly BitmapImage BluePawn = Converter.StringToBitmapImageConverter("Images/BluePawn.png");
        readonly BitmapImage GreenPawn = Converter.StringToBitmapImageConverter("Images/GreenPawn.png");

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < 8; i++)//64 fiels on board
                for (var j = 0; j < 8; j++)
                {
                    var tag = new Tuple<int, int>(i, j);
                    Images.Add(new Image { Visibility = Visibility.Hidden, Tag = tag });
                }
        }

        private readonly int[,] _boardArray = new int[8, 8];
        private void v_ListBox_Board_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tag = (v_ListBox_Board.SelectedItem as Image).Tag as Tuple<int, int>;

            _boardArray[tag.Item1, tag.Item2]++;
            if (_boardArray[tag.Item1, tag.Item2] > 4) _boardArray[tag.Item1, tag.Item2] = 0;

            var index = tag.Item1 * 8 + tag.Item2;
            switch (_boardArray[tag.Item1, tag.Item2] % 5)
            {
                case 0:
                    Images[index].Visibility = Visibility.Hidden;
                    break;
                case 1:
                    Images[index].Visibility = Visibility.Visible;
                    Images[index].Source = RedPawn;
                    break;
                case 2:
                    Images[index].Visibility = Visibility.Visible;
                    Images[index].Source = YellowPawn;
                    break;
                case 3:
                    Images[index].Visibility = Visibility.Visible;
                    Images[index].Source = BluePawn;
                    break;
                case 4:
                    Images[index].Visibility = Visibility.Visible;
                    Images[index].Source = GreenPawn;
                    break;
                default:
                    Images[index].Visibility = Visibility.Hidden;
                    break;
            }

            v_ListBox_Board.SelectionChanged -= v_ListBox_Board_SelectionChanged;// umożliwia klikanie kilka razy w to samo pole
            v_ListBox_Board.SelectedItem = null;
            v_ListBox_Board.SelectionChanged += v_ListBox_Board_SelectionChanged;
        }

        private void DrawPawnsLine(int start, int offset, int pawnType, BitmapImage pwanImage)
        {
            for (var i = offset; i < 8; i += 2)
            {
                var index = start * 8 + i;
                _boardArray[start, i] = pawnType;
                Images[index].Visibility = Visibility.Visible;
                Images[index].Source = pwanImage;
            }  
        }

        private void Clear()
        {
            for (var i = 0; i < 8; i ++)
                for (var j = 0; j < 8; j ++)
                {
                    var index = i * 8 + j;
                    _boardArray[i, j] = 0;
                    Images[index].Visibility = Visibility.Hidden;
                }
        }

        private void Button_SetInit_Click(object sender, RoutedEventArgs e)
        {
            _checkCheckers.InitBoard(boardArrayToFieldState());
            InitConfiguration();
        }

        private void Button_Init_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            DrawPawnsLine(0, 0, 1, RedPawn);
            DrawPawnsLine(1, 1, 1, RedPawn);
            DrawPawnsLine(2, 0, 1, RedPawn);
            DrawPawnsLine(5, 1, 2, YellowPawn);
            DrawPawnsLine(6, 0, 2, YellowPawn);
            DrawPawnsLine(7, 1, 2, YellowPawn);
            _checkCheckers.InitBoard(boardArrayToFieldState());
            InitConfiguration();
        }

        private void InitConfiguration()
        {
            TestLog("Init Ready");
            Move_Button.IsEnabled = true;
            Back_Button.IsEnabled = false;
        }

        private FieldState[,] boardArrayToFieldState()
        {
            var result = new FieldState[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    switch (_boardArray[i, j])
                    {
                        case 0:
                            result[i, j] = FieldState.Empty;
                            break;
                        case 1:
                            result[i, j] = FieldState.RedPawn;
                            break;
                        case 2:
                            result[i, j] = FieldState.YellowPawn;
                            break;
                        case 3:
                            result[i, j] = FieldState.BluePawn;
                            break;
                        case 4:
                            result[i, j] = FieldState.GreenPawn;
                            break;
                        default:
                            result[i, j] = FieldState.Empty;
                            break;
                    }
                }
            }
            return result;
        }

        private void Button_Move_Click(object sender, RoutedEventArgs e)
        {
            var board = boardArrayToFieldState();
            TestLog(_checkCheckers.UpdateAndValidBoard(board));
            //InvalidMove(_checkCheckers.IsError); // jak ma być powrót do ruchu to nie będzie reseta nigdy
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Button_InitAndValid_Click(object sender, RoutedEventArgs e)
        {
            var initAndValid = _checkCheckers.InitAndValid(boardArrayToFieldState());
            if (initAndValid) InitConfiguration();
            TestLog(initAndValid ? "InitAndValid Success" : "InitAndValid Failed");
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {

            var array = _checkCheckers.GetCorrectBoard();
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                {
                    _boardArray[i, j] = (int) array[i, j];

                    int index = i * 8 + j;
                    switch (_boardArray[i, j] % 5)
                    {
                        case 0:
                            Images[index].Visibility = Visibility.Hidden;
                            break;
                        case 1:
                            Images[index].Visibility = Visibility.Visible;
                            Images[index].Source = RedPawn;
                            break;
                        case 2:
                            Images[index].Visibility = Visibility.Visible;
                            Images[index].Source = YellowPawn;
                            break;
                        case 3:
                            Images[index].Visibility = Visibility.Visible;
                            Images[index].Source = BluePawn;
                            break;
                        case 4:
                            Images[index].Visibility = Visibility.Visible;
                            Images[index].Source = GreenPawn;
                            break;
                        default:
                            Images[index].Visibility = Visibility.Hidden;
                            break;
                    }
             }

            Back_Button.IsEnabled = false;
            Move_Button.IsEnabled = true;
            TestLog("Back");
        }

        private void InvalidMove(bool isError)
        {
            if (!isError) return;

            Back_Button.IsEnabled = true;
            Move_Button.IsEnabled = false;
        }

        private void TestLog(string text)
        {
            var oldLog = _messageLog;
            _messageLog = String.Format("{0}: {1} \n{2}", ++_messageLogCounter, text, oldLog);
            v_TextBlock_Test.Text = _messageLog;
        }
    }
}
