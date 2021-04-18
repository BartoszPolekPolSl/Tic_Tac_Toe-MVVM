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
        public MainViewModel()
        {
            CurrentPlayer = Player1;
            sign = 'X';
        }
        public string Player1_binded {  get; set; }
        public string Player2_binded {  get; set; }
        static private string Player1 { get; set; }
        static private string Player2 { get; set; }
        public string CurrentPlayer { get; private set; }
        private char sign;
        private char Sign
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
                if (CurrentPlayer == Player1)
                {
                    CurrentPlayer = Player2;
                }
                else CurrentPlayer = Player1;
                OnPropertyChange(nameof(CurrentPlayer));
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
                    GameEngine.ShowEndingMessage((CurrentPlayer==Player1?Player2:Player1));
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
                return changeWindow ?? (changeWindow = new RelayCommand((p)=> { Player1 = Player1_binded; Player2 = Player2_binded; App.ChangeWindow(); }, null)) ;
            }
        }
    }
}
