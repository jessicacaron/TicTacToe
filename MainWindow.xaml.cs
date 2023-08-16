using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// TicTacToe class to control the game logic
        /// </summary>
        clsTicTacToe TicTacToe;
        /// <summary>
        /// Checks to see if the game is active or not started
        /// </summary>
        bool started;
        /// <summary>
        /// Keeps track of who's turn it is during the game
        /// </summary>
        bool player1;


        public MainWindow()
        {
            InitializeComponent();
            //create instance of TicTacToe
            TicTacToe = new clsTicTacToe();
        }

        #region Click Methods

        /// <summary>
        /// Method starts when start button is clicked.  It loads initial game data.
        /// </summary>
        /// <param name="sender">Start button click object info</param>
        /// <param name="e">event data</param>
        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            //set up initial game board, player 1 to start, start game
            player1 = true;
            txtStatus.Text = "Player 1's turn";
            for (int i = 0; i < 9; i++)
            {
                TicTacToe.SetsaBoard(i, "");
            }
            started = true;
            player1 = true;

            //reset colors 
            resetColors();

            //reselt labels(buttons) 
            resetLabels();
        }

        /// <summary>
        /// This method activates when player clicks on a cell to make a move, then calls on the TicTacToe class to check 
        /// for and calculate a win, and then highlights the necessary cells in the game to display winning move.
        /// </summary>
        /// <param name="sender">Any click from the board </param>
        /// <param name="e"></param>
        private void PlayerMoveClick(object sender, RoutedEventArgs e)
        {
            //make sure game is active
            if (started)
            {
                //make sure space isnt already clicked
                var button = (Button)sender;
                if (button.Content.ToString() == " ")
                {
                    //load in players move
                    string move = button.Name;
                    int position = Int32.Parse(move.Last().ToString());

                    //load board method
                    button.Content = player1 ? "X" : "O";
                    loadBoard(position);

                    //check for tie
                    int check = 0;
                    for (int i = 0; i < 9; i++)
                    {
                        if (TicTacToe.GetsaBoard()[i] != "")
                        {
                            check++;
                        }
                    }

                    //check to see if the last move is a winning move
                    if (TicTacToe.IsWinningMove())
                    {
                        //if winning move, highlight col/row/diag on the board
                        string toHighlight = TicTacToe.GeteWinningMove();
                        if (toHighlight == "row1")
                        {
                            btnBoard0.Background = Brushes.Aqua;
                            btnBoard1.Background = Brushes.Aqua;
                            btnBoard2.Background = Brushes.Aqua;
                            //update stats
                            updateStats();
                        }
                        else if (toHighlight == "row2")
                        {
                            btnBoard3.Background = Brushes.Aqua;
                            btnBoard4.Background = Brushes.Aqua;
                            btnBoard5.Background = Brushes.Aqua;
                            //update stats
                            updateStats() ;
                        }
                        else if (toHighlight == "row3")
                        {
                            btnBoard6.Background = Brushes.Aqua;
                            btnBoard7.Background = Brushes.Aqua;
                            btnBoard8.Background = Brushes.Aqua;
                            //update stats
                            updateStats();
                        }
                        else if (toHighlight == "col1")
                        {
                            btnBoard0.Background = Brushes.Aqua;
                            btnBoard3.Background = Brushes.Aqua;
                            btnBoard6.Background = Brushes.Aqua;
                            //update stats
                            updateStats();
                        }
                        else if (toHighlight == "col2")
                        {
                            btnBoard1.Background = Brushes.Aqua;
                            btnBoard4.Background = Brushes.Aqua;
                            btnBoard7.Background = Brushes.Aqua;
                            //update stats
                            updateStats();
                        }
                        else if (toHighlight == "col2")
                        {
                            btnBoard2.Background = Brushes.Aqua;
                            btnBoard5.Background = Brushes.Aqua;
                            btnBoard8.Background = Brushes.Aqua;
                            //update stats
                            updateStats();
                        }
                        else if (toHighlight == "diag1")
                        {
                            btnBoard0.Background = Brushes.Aqua;
                            btnBoard4.Background = Brushes.Aqua;
                            btnBoard8.Background = Brushes.Aqua;
                            //update stats
                            updateStats();
                        }
                        else if (toHighlight == "diag2")
                        {
                            btnBoard2.Background = Brushes.Aqua;
                            btnBoard4.Background = Brushes.Aqua;
                            btnBoard6.Background = Brushes.Aqua;
                            //update stats
                            updateStats();
                        }
                    }
                    
                    //highlight whole board in the event of a tie
                    else if (check == 9)
                    {
                        btnBoard0.Background = Brushes.Aqua;
                        btnBoard1.Background = Brushes.Aqua;
                        btnBoard2.Background = Brushes.Aqua;
                        btnBoard3.Background = Brushes.Aqua;
                        btnBoard4.Background = Brushes.Aqua;
                        btnBoard5.Background = Brushes.Aqua;
                        btnBoard6.Background = Brushes.Aqua;
                        btnBoard7.Background = Brushes.Aqua;
                        btnBoard8.Background = Brushes.Aqua;
                        TicTacToe.SetiTies();
                        lblTies.Content = "Ties: " + TicTacToe.GetiTies();
                        txtStatus.Text = "The game is a tie";

                    }

                    //if there is no tie and no winning move, set up next player turn and update status board
                    else
                    {
                        //set player to next
                        if (player1)
                        {
                            txtStatus.Text = "Player 2's turn";
                            player1 = false;
                        }
                        else if (!player1)
                        {
                            txtStatus.Text = "Player 1's turn";
                            player1 = true;
                        }
                    } 

                }

            }

        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Method to update TicTacToe variable data(wins/ties) so correct information is displayed.
        /// </summary>
        private void updateStats()
        {
            if (player1)
            {
                txtStatus.Text = "Player 1 Wins";
                TicTacToe.SetPlayer1Wins();
                lblPlayer1Wins.Content = "Player 1 Wins: " + TicTacToe.GetiPlayer1Wins();
            }
            else if (!player1)
            {
                TicTacToe.SetPlayer2Wins();
                lblPlayer2Wins.Content = "Player 2 Wins: " + TicTacToe.GetiPlayer2Wins();
                txtStatus.Text = "Player 2 Wins";
            }
            started = false;
        }

        /// <summary>
        /// Method to reset cell colors back to the original start state.
        /// </summary>
        private void resetColors()
        {
            btnBoard0.Background = Brushes.LightGray;
            btnBoard1.Background = Brushes.LightGray;
            btnBoard2.Background = Brushes.LightGray;
            btnBoard3.Background = Brushes.LightGray;
            btnBoard4.Background = Brushes.LightGray;
            btnBoard5.Background = Brushes.LightGray; 
            btnBoard6.Background = Brushes.LightGray;
            btnBoard7.Background = Brushes.LightGray;
            btnBoard8.Background = Brushes.LightGray;
        }

        /// <summary>
        /// Method sets all labels back to the original start state.
        /// </summary>
        private void resetLabels()
        {
            btnBoard0.Content = " ";
            btnBoard1.Content = " ";
            btnBoard2.Content = " ";
            btnBoard3.Content = " ";
            btnBoard4.Content = " ";
            btnBoard5.Content = " ";
            btnBoard6.Content = " ";
            btnBoard7.Content = " ";
            btnBoard8.Content = " ";   
        }

        /// <summary>
        /// Access property for board and sets string saboard based on label position.
        /// </summary>
        /// <param name="position">Position of the cell that was played on the board.</param>
        private void loadBoard(int position)
        {
            if (player1)
            {
                TicTacToe.SetsaBoard(position, "X");
            }
            else 
            {
                TicTacToe.SetsaBoard(position, "0");
            }
        }

        #endregion
    }
}
