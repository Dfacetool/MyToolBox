using System;
using System.ComponentModel;

namespace ToolBox
{
    public class BMI : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public double BMInumber
        { 
            get 
            {
                double a = (double)High;
                a = Weigh / Math.Pow(a / 100, 2.0);
                return Math.Round(a, 2);
            } 
        }

        private int _high = 0;

        public int High
        {
            get { return _high; }
            set
            {
                _high = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.High)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.BMInumber)));
            }
        }

        private int _weigh = 0;

        public int Weigh
        {
            get { return _weigh; }
            set
            {
                _weigh = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Weigh)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.BMInumber)));
            }
        }
    }
}