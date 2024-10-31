using Kitware.VTK;
using System.Windows;

namespace OptomoMvvm.Views
{
    public partial class ImagingView : Window
    {
        public ImagingView()
        {
            InitializeComponent();
            this.Loaded += Load;
        }

        // Düzeltilecek
        private void Load(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            if (viewModel != null)
            {
                // RenderWindowControl'ün RenderWindow'unu ayarla
                vtkWindow.Child = viewModel.VTKViewModel.RenderControl;
            }
        }
    }
}
