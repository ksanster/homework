using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public class Question : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string text;
        private bool isTrue;
        public string Text 
        {
            get => text;
            set
            {
                text = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsTrue 
        {
            get => isTrue;
            set
            {
                isTrue = value;
                NotifyPropertyChanged();
            }
        }

        public Question()
        { }

        public Question(string text, bool isTrue)
        {
            this.text = text;
            this.isTrue = isTrue;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
