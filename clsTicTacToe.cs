using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// TicTacToe class creates an instance of game logic for a tictactoe game to be played.
    /// </summary>
    public class clsTicTacToe
    {
        /// <summary>
        /// Array that holds current content of each move ("X" or "O")
        /// </summary>
        private string[] saBoard;
        /// <summary>
        /// Holds the total number of Player 1 wins
        /// </summary>
        private int iPlayer1Wins;
        /// <summary>
        /// Holds the total number of Player 2 wins
        /// </summary>
        private int iPlayer2Wins;
        /// <summary>
        /// Holds the total number of ties
        /// </summary>
        private int iTies;
        /// <summary>
        /// Holds the cell position of the winning move using descriptive string, ie. row1
        /// </summary>
        private string eWinningMove;


        /// <summary>
        /// Constructor for TicTacToe class sets the board to 0 and creates empty board
        /// </summary>
        public clsTicTacToe()
        {
            //initialize saBoard with new
            saBoard = new string[9];
            iPlayer1Wins = 0;
            iPlayer2Wins = 0;
            iTies = 0;
            eWinningMove = "";
        }

        #region Getter Methods

        /// <summary>
        /// Returns the current state of the game board and its cell contents in an array
        /// </summary>
        /// <returns>String array of values X or O, or " " if not yet clicked</returns>
        public string[] GetsaBoard()
        {
            return saBoard;
        }
        /// <summary>
        /// Int that stores current player 1 wins is returned
        /// </summary>
        /// <returns>Returns the current player 1 wins</returns>
        public int GetiPlayer1Wins()
        {
            return iPlayer1Wins;
        }
        /// <summary>
        /// Int that stores current player 2 wins is returned
        /// </summary>
        /// <returns>Returns the current player 2 wins</returns>
        public int GetiPlayer2Wins()
        {
            return iPlayer2Wins;
        }
        /// <summary>
        /// Int that stores current number of ties is returned
        /// </summary>
        /// <returns>Returns the current number of ties</returns>
        public int GetiTies()
        {
            return iTies;
        }
        /// <summary>
        /// String that stores the winning move cells is returned
        /// </summary>
        /// <returns>Returns the current winning move</returns>
        public string GeteWinningMove()
        {
            return eWinningMove;
        }

        #endregion


        #region Setter Methods

        /// <summary>
        /// Sets the current game board at position the value passed
        /// </summary>
        public void SetsaBoard(int index, string value)
        {
            saBoard[index] = value;
        }
        /// <summary>
        /// Sets current player 1 wins
        /// </summary>
        public void SetPlayer1Wins()
        {
            iPlayer1Wins++;
        }
        /// <summary>
        /// Sets current player 2 wins
        /// </summary>
        public void SetPlayer2Wins()
        {
            iPlayer2Wins++;
        }
        /// <summary>
        /// Sets current ties
        /// </summary>
        public void SetiTies()
        {
            iTies++;
        }

        #endregion


        #region Other Methods

        /// <summary>
        /// Method calculates if the move made was a winning move or not.
        /// </summary>
        /// <returns>If winning move, method returns the cells involved in the win.</returns>
        public bool IsWinningMove()
        {
            //check for winning move
            //row1
            if (saBoard[0] !="" && saBoard[0] == saBoard[1] && saBoard[0] == saBoard[2])
            {
                eWinningMove = "row1";
                return true;
            }

            //col1
            else if (saBoard[0] != "" && saBoard[0] == saBoard[3] && saBoard[0] == saBoard[6])
            {
                eWinningMove = "col1";
                return true;
            }

            //row 2
            else if (saBoard[3] != "" && saBoard[3] == saBoard[4] && saBoard[3] == saBoard[5])
            {
                eWinningMove = "row2";
                return true;
            }

            //col2
            else if (saBoard[1] != "" && saBoard[1] == saBoard[4] && saBoard[1] == saBoard[7])
            {
                eWinningMove = "col2";
                return true;
            }

            //row3
            else if (saBoard[6] != "" && saBoard[6] == saBoard[7] && saBoard[6] == saBoard[8])
            {
                eWinningMove = "row3";
                return true;
            }

            //col3
            else if (saBoard[2] != "" && saBoard[2] == saBoard[5] && saBoard[2] == saBoard[8])
            {
                eWinningMove = "col3";
                return true;
            }

            //diag1
            else if (saBoard[0] != "" && saBoard[0] == saBoard[4] && saBoard[0] == saBoard[8])
            {
                eWinningMove = "diag1";
                return true;
            }

            //diag2
            else if (saBoard[2] != "" && saBoard[2] == saBoard[4] && saBoard[2] == saBoard[6])
            {
                eWinningMove = "diag2";
                return true;
            }

            //return false if it is not a winning move
            else
            {
                return false;
            }
        }

        #endregion
    }
}
