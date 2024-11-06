using OptomoMvvm.ViewModel;
using System.Windows;

namespace OptomoMvvm.Views
{
    /// <summary>
    /// ControlView.xaml etkileşim mantığı
    /// </summary>
    public partial class ControlView : Window
    {
        private readonly VtkViewModel viewModel;
        public ControlView(VtkViewModel model)
        {
            viewModel = model;
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
