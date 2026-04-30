using System.ComponentModel;
using System.Runtime.CompilerServices;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SfDataGridDemo
{
    public class InkColorRow : INotifyPropertyChanged
    {
        private int _pmsNumber;
        private string _inkColor;

        public bool ThisComp { get; set; }

        public int PMSNumber
        {
            get => _pmsNumber;
            set
            {
                if (_pmsNumber != value)
                {
                    _pmsNumber = value;
                    OnPropertyChanged();

                    UpdateInkColor();
                }
            }
        }

        public string InkColor
        {
            get => _inkColor;
            set
            {
                if (_inkColor != value)
                {
                    _inkColor = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ColorPreview => string.Empty;

        private void UpdateInkColor()
        {
            var info = PmsColorHelper.GetPmsInfo(PMSNumber);
            InkColor = info.Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
