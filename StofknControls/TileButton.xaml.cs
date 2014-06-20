using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StofknControls
{
    [Description("Represents a custom button control that responds to a Click event. Displays an image using a custom Source property if the Source property is bound to an Image in the template.")]
    public partial class TileButton : Button
    {
        [Description("The image displayed in the button if there is an Image control in the template whose Source property is template-bound to the ImageButton Source property."), Category("Common Properties")] 
        public ImageSource Source
        {
            get { return base.GetValue(SourceProperty) as ImageSource; }
            set { base.SetValue(SourceProperty, value); }
        }
        public static readonly DependencyProperty SourceProperty =
          DependencyProperty.Register("Source", typeof(ImageSource), typeof(TileButton), null);
    }
}
