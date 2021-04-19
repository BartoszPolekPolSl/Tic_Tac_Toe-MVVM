using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Tic_Tac_Toe.Model
{
    static class GameEngine
    {
        static public char[] UpdateBoard(char[] board, string index, char sign)
        {
            var i = int.Parse(index);
            char[] newBoard = board;
            newBoard[i] = sign;
            return newBoard;
        }
        static public bool CanSetSign(char[] board, string index)
        {
            var i = int.Parse(index);
            if (board[i] != '\0') return false;
            else return true;
        }
        static public bool IsEnd(char[] board, char sign)
        {
            List<char[]> endingPositions = new List<char[]>()
            {
                new char[3] {board[0], board[3], board[6] },
                new char[3] { board[1], board[4], board[7] },
                new char[3] { board[2], board[5], board[8] },
                new char[3] { board[0], board[1], board[2] },
                new char[3] { board[3], board[4], board[5] },
                new char[3] { board[6], board[7], board[8] },
                new char[3] { board[0], board[4], board[8] },
                new char[3] { board[2], board[4], board[6] }

            };
            foreach (var e in endingPositions)
            {
                if (IsEndingPosition(e, sign) == true)
                {
                    return true;
                }
            }
            return false;
        }
        static public bool IsDraw(char[] board)
        {
            int counter = 0;
            for (int i = 0; i <=8; i++)
            {
                if (board[i] != '\0')
                {
                    counter++;
                }
            }
            if (counter == 9) return true;
            else return false;
        }
        static public void ShowEndingMessage(string player)
        {
            MessageBox.Show($"Wygrał gracz: {player}", "Gratulacje!", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBoxResult result = MessageBox.Show("Czy chcesz zagrać jeszcze raz?", "Koniec gry", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                App.NewGame();
            }
            else
            {
                App.Current.MainWindow.Close();
            }
        }
        static public void ShowEndingMessage()
        {
            MessageBox.Show("Remis", "Wynik!", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBoxResult result = MessageBox.Show("Czy chcesz zagrać jeszcze raz?", "Koniec gry", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                App.NewGame();
            }
            else
            {
                App.Current.MainWindow.Close();
            }
        }
        static private bool IsEndingPosition(char[] endingPosition, char sign)
        {
            int counter = 0;
            for (int i = 0; i <= 2; i++)
            {
                if (endingPosition[i] == sign)
                {
                    counter += 1;
                }
            }
            if (counter == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static public List<Brush>UpdateSignColorList(List<Brush> list, string index, Brush color)
        {
            var i = int.Parse(index);
            List<Brush> newList = new List<Brush>();
            newList = list;
            newList[i] = color;
            return newList;
        }
    }
}

