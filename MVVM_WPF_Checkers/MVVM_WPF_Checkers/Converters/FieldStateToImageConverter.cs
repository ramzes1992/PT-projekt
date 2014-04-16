using MVVM_WPF_Checkers.Models;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;


namespace MVVM_WPF_Checkers.Converters
{
    public class FieldsStatesCollectionToImagesCollectionConverter : IValueConverter
    {
        public FieldsStatesCollectionToImagesCollectionConverter()
        {
            RedPawn = StringToBitmapImage("Images/RedPawn.png");
            YellowPawn = StringToBitmapImage("Images/YellowPawn.png");
            BluePawn = StringToBitmapImage("Images/BluePawn.png");
            GreenPawn = StringToBitmapImage("Images/GreenPawn.png");
        }

        BitmapImage RedPawn;
        BitmapImage YellowPawn;
        BitmapImage BluePawn;
        BitmapImage GreenPawn;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<Image> result = new List<Image>();

            foreach (var state in (value as IEnumerable<FieldState>))
            {
                switch (state)
                {
                    case FieldState.Empty:
                        result.Add(new Image()
                            {
                                Visibility = System.Windows.Visibility.Hidden
                            });
                        break;
                    case FieldState.BluePawn:
                        result.Add(new Image()
                        {
                            Visibility = System.Windows.Visibility.Visible,
                            Source = BluePawn
                        });
                        break;
                    case FieldState.GreenPawn:
                        result.Add(new Image()
                        {
                            Visibility = System.Windows.Visibility.Visible,
                            Source = GreenPawn
                        });
                        break;
                    case FieldState.RedPawn:
                        result.Add(new Image()
                        {
                            Visibility = System.Windows.Visibility.Visible,
                            Source = RedPawn
                        });
                        break;
                    case FieldState.YellowPawn:
                        result.Add(new Image()
                        {
                            Visibility = System.Windows.Visibility.Visible,
                            Source = YellowPawn
                        });
                        break;
                    default:
                        result.Add(new Image()
                        {
                            Visibility = System.Windows.Visibility.Hidden
                        });
                        break;
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {//todo, or not todo xD
            throw new NotImplementedException();
        }

        private BitmapImage StringToBitmapImage(string RelativURI)
        {
            return new BitmapImage(new Uri(RelativURI, UriKind.Relative));
        }
    }
}
