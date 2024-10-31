using System.ComponentModel;

namespace OptomoMvvm.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string property) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
