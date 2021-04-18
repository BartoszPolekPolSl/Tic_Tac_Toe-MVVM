using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe.Model;
using System.Windows.Input;

namespace Tic_Tac_Toe.ViewModel
{
    using BaseClass;
    using System.Windows;

    class MainViewModel : ViewModel
    {
        char sign = 'X';
        char Sign
        {
            get
            {
                if (sign == 'X')
                {
                    sign = 'O';
                }
                else
                {
                    sign = 'X';
                }
                return sign;
            } 
        }
        private char[] board = new char[9];
        public char[] Board
        {
            get { return board; }
            private set 
            {
                board = value;
                OnPropertyChange(nameof(Board));
                if (GameEngine.IsEnd(Board, sign) == true)
                {
                    MessageBox.Show("Wygrał gracz: ", "Koniec gry", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private ICommand setSign;
        public ICommand SetSign
        {
            get
            {
                return setSign ?? (setSign = new RelayCommand(parameter =>Board= GameEngine.UpdateBoard(Board, parameter.ToString(), Sign),parameter=> GameEngine.CanSetSign(Board,parameter.ToString())));
            }
        }
        private ICommand changeWindow;
        public ICommand ChangeWindow
        {
            get
            {
                return changeWindow ?? (changeWindow = new RelayCommand(p=>App.ChangeWindow(), null)) ;
            }
        }
        

    }
}
