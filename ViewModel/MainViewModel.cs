using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe.ViewModel
{
    using BaseClass;
    using System.Windows.Input;

    class MainViewModel : ViewModel
    {
        private ICommand changeWindow;
        public ICommand ChangeWindow
        {
            get
            {
                return changeWindow ?? (changeWindow = new RelayCommand(p=>App.ChangeWindow(), p => true)) ;
            }
        }

    }
}
