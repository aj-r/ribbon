#region Using directives

using System.Windows;
using System.Windows.Media;

#endregion

namespace Crystalbyte.UI {
    public sealed class RibbonOption : DependencyObject {

        public static DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(RibbonOption));

        public string Title {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(RibbonOption));

        public bool IsSelected {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public string Description { get; set; }

        public static DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(RibbonOption));

        public ImageSource ImageSource {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public RibbonState Visibility { get; set; }
    }
}