using CodeBase.HexLib;
using System.ComponentModel;

namespace CodeBase.Character
{
    public class CharacterModel : INotifyPropertyChanged
    {
        private Hex _currentPosition;

        public Hex CurrentPosition
        {
            get => _currentPosition;
            private set
            {
                _currentPosition = value;
                OnPropertyChanged(nameof(CurrentPosition));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
