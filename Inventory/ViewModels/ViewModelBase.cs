using System.ComponentModel;
using System.Runtime.CompilerServices;
using Inventory.Properties;

namespace Inventory.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}