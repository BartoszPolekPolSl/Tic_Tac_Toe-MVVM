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
    using System.Windows.Data;
    using System.Windows.Media;

    class MainViewModel : ViewModel
    {
        public MainViewModel()
        {

            currentPlayer = Player1;
            sign = 'O';
            signColor =Brushes.Red;
            SignColorList= new List<Brush>()
            {
                Brushes.Red,
                Brushes.Red,
                Brushes.Red,
                Brushes.Red,
                Brushes.Red,
                Brushes.Red,
                Brushes.Red,
                Brushes.Red,
                Brushes.Red
            };
        }
        public string Player1_binded {  get; set; }
        public string Player2_binded {  get; set; }
        static private string Player1 { get; set; }
        static private string Player2 { get; set; }
        private string currentPlayer;
        public string CurrentPlayer 
        { get
          { 
             return currentPlayer; 
          } 
          private set
          {
                currentPlayer = value;
                OnPropertyChange(nameof(CurrentPlayer));
          }
        }
        private Brush signColor;
        public Brush SignColor
        {
            get
            {
                return signColor;
            }
            private set
            {
                signColor = value;
                OnPropertyChange(nameof(SignColor));
            }
        }
        private List<Brush> signColorList;
        public List<Brush> SignColorList
        {
            get
            {
                return signColorList;
            }
            private set
            {
                signColorList = value;
                OnPropertyChange(nameof(SignColorList));
            }
        }
        private char sign;
        public char Sign
        {
            get
            {
                return sign;
            }
            private set
            {
                sign = value;
                OnPropertyChange(nameof(Sign));
            }
            
        }
        private char[] board = new char[9];
        public char[] Board
        {
            get 
            {
                return board; 
            }
            private set 
            {
                board = value;
                OnPropertyChange(nameof(Board));
                if (GameEngine.IsEnd(Board, sign) == true)
                {
                    GameEngine.ShowEndingMessage(CurrentPlayer);
                }
                else if (GameEngine.IsDraw(Board)==true)
                {
                    GameEngine.ShowEndingMessage();
                }
                else
                {
                    if (CurrentPlayer == Player1) CurrentPlayer = Player2;
                    else CurrentPlayer = Player1;
                    if (sign == 'X') Sign = 'O';
                    else Sign = 'X';
                    if (SignColor == Brushes.Blue) SignColor = Brushes.Red;
                    else SignColor = Brushes.Blue;
                }
            }
        }
        private ICommand setSign;
        public ICommand SetSign
        {
            get
            {
                return setSign ?? (setSign = new RelayCommand((parameter) => { SignColorList = GameEngine.UpdateSignColorList(SignColorList, parameter.ToString(), SignColor); Board = GameEngine.UpdateBoard(Board, parameter.ToString(), Sign); },parameter=> GameEngine.CanSetSign(Board,parameter.ToString())));
            }
        }
        private ICommand changeWindow;
        public ICommand ChangeWindow
        {
            get
            {
                return changeWindow ?? (changeWindow = new RelayCommand((p) => { Player1 = Player1_binded; Player2 = Player2_binded; App.ChangeWindow(); }, p => string.IsNullOrWhiteSpace(Player1_binded) || string.IsNullOrWhiteSpace(Player2_binded) ? false:true)) ;
            }
        }
    }
}
