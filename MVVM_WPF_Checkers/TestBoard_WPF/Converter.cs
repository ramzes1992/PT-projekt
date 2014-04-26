using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TestBoard_WPF
{
    class Converter
    {
        public static BitmapImage StringToBitmapImageConverter(string RelativURI)
        {
            return new BitmapImage(new Uri(RelativURI, UriKind.Relative));
        }
    }
}
