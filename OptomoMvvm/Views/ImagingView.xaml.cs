using OptomoMvvm.ViewModel;
using System.Windows;
using System.Windows.Media;

namespace OptomoMvvm.Views
{
    public partial class ImagingView : Window
    {
        private readonly VtkViewModel viewModel;
        public ImagingView(VtkViewModel model)
        {
            viewModel = model;
            DataContext = viewModel;
            InitializeComponent();
            viewModel.DpiScale = VisualTreeHelper.GetDpi(this).PixelsPerDip;
        }
    }
}
