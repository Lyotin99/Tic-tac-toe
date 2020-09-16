using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace upr7zad2dom
{
    public partial class Form1 : Form
    {
        bool istrue = true;
        int counterX = 0;
        int counterO=0;
        int turn = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void cleanB()
        {
            try
            {

                b1.Text = "";
                b2.Text = "";
                b3.Text = "";
                b4.Text = "";
                b5.Text = "";
                b6.Text = "";
                b7.Text = "";
                b8.Text = "";
                b9.Text = "";
                b1.Enabled = true;
                b2.Enabled = true;
                b3.Enabled = true;
                b4.Enabled = true;
                b5.Enabled = true;
                b6.Enabled = true;
                b7.Enabled = true;
                b8.Enabled = true;
                b9.Enabled = true;
                turn = 0;
                istrue = true;
                
            }
            catch { };
        }//clean button end
        private void win()
        {
            bool winG = false;
            //horizontalno
            if (b1.Text == b2.Text && b2.Text == b3.Text && !b1.Enabled)
            {
                winG = true;
            }
            if (b4.Text == b5.Text && b5.Text == b6.Text && !b4.Enabled)
            {
                winG = true;
            }
            if (b7.Text == b8.Text && b8.Text == b9.Text && !b7.Enabled)
            {
                winG = true;
            }

            //vertikalno
            if (b1.Text == b4.Text && b4.Text == b7.Text && !b1.Enabled)
            {
                winG = true;
            }
            if (b2.Text == b5.Text && b5.Text == b8.Text && !b2.Enabled)
            {
                winG = true;
            }
            if (b3.Text == b6.Text && b6.Text == b9.Text && !b3.Enabled)
            {
                winG = true;
            }
            //diagonalno
            if (b1.Text == b5.Text && b5.Text == b9.Text && !b1.Enabled)
            {
                winG = true;
            }
            if (b3.Text == b5.Text && b5.Text == b7.Text && !b3.Enabled)
            {
                winG = true;
            }
          


            if (winG)
            {
                disableB();//disables buttons
                String a = " ";
                if (istrue)
                {
                    a = "O";
                    counterO++;
                    label2.Text="O:"+ counterO.ToString();
                
                }
                else
                {
                    a = "X";
                    counterX++;
                    label1.Text= counterX.ToString();
                    label1.Text = "X:" + counterX.ToString();
                }
                MessageBox.Show(a+" Won the game !","Congratulations");

                if (MessageBox.Show("Do you want to play another game?", "Another game?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    cleanB();
                }
                else
                {
                    if (counterX > counterO)
                    {
                        MessageBox.Show("Congratulation X you won the series!!!","Winner");
                    }
                    else if (counterX < counterO)
                    {
                        MessageBox.Show("That's too bad.Try again next time!","You Lost");
                    }
                    else MessageBox.Show("No winner in the series","Draw");
                    Application.Exit();
                };
            }
            else if(turn == 9)
            {
               
                if (MessageBox.Show("The result is draw.Do you want to play another game?", "Another game?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    cleanB();
                }
                else
                {
                    Application.Exit();
                };
            }
            

        }//end of win

        private void disableB()
        {
            try
            {
                foreach (Control o in Controls)
                {
                    Button b = (Button)o;
                    b.Enabled = false;
                }
            }
            catch { };
        }//disable button end

        private void button11_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (istrue)
                b.Text = "X";
            else b.Text = "O";
            istrue = !istrue;
            b.Enabled = false;
            b.Font = new Font("Microsoft Sans Serif", 30);
            turn++;
            win();

            if (!istrue)
            {
                CMM();
            }
            


            

        }
        private void CMM()
        {
            //priority 1:  get tick tac toe
            //priority 2:  block x tic tac toe
            //priority 3:  go for mid space
            //priority 4:  go for corner space
            //priority 5:  pick open space

            Button move = null;

            //look for tic tac toe opportunities
            move = look_for_win_or_block("O"); //look for win
            if (move == null)
            {
                move = look_for_win_or_block("X"); //look for block
                if (move == null)
                {
                    move = look_forO();
                    if (move == null)
                    {
                        move = look_for_corner();
                        if (move == null)
                        {
                            move = look_for_open_space();
                        }//end if
                    }
                }//end if
            }//end if

            move.PerformClick();
        }//computer move method end

        private Button look_for_open_space()
        {
            Console.WriteLine("Looking for open space");
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "")
                        return b;
                }//end if
            }//end if

            return null;
        }//look for space end

        private Button look_forO()
        {
            if(b5.Text=="")
            {
                return b5;
            }
            return null;
        }//look for O end
        private Button look_for_corner()
        {
            Console.WriteLine("Looking for corner");
            if (b1.Text == "O")
            {
                if (b3.Text == "")
                    return b3;
                if (b9.Text == "")
                    return b9;
                if (b7.Text == "")
                    return b7;
            }

            if (b3.Text == "O")
            {
                if (b1.Text == "")
                    return b1;
                if (b9.Text == "")
                    return b9;
                if (b7.Text == "")
                    return b7;
            }

            if (b9.Text == "O")
            {
                if (b1.Text == "")
                    return b3;
                if (b3.Text == "")
                    return b3;
                if (b7.Text == "")
                    return b7;
            }

            if (b7.Text == "O")
            {
                if (b1.Text == "")
                    return b3;
                if (b3.Text == "")
                    return b3;
                if (b9.Text == "")
                    return b9;
            }

            if (b1.Text == "")
                return b1;
            if (b3.Text == "")
                return b3;
            if (b7.Text == "")
                return b7;
            if (b9.Text == "")
                return b9;

            return null;
        }//look for corner end

        private Button look_for_win_or_block(string mark)
        {
            Console.WriteLine("Looking for win or block:  " + mark);
            //HORIZONTAL TESTS
            if ((b1.Text == mark) && (b2.Text == mark) && (b3.Text == ""))
                return b3;
            if ((b2.Text == mark) && (b3.Text == mark) && (b1.Text == ""))
                return b1;
            if ((b1.Text == mark) && (b3.Text == mark) && (b2.Text == ""))
                return b2;

            if ((b4.Text == mark) && (b5.Text == mark) && (b6.Text == ""))
                return b6;
            if ((b5.Text == mark) && (b6.Text == mark) && (b4.Text == ""))
                return b4;
            if ((b4.Text == mark) && (b6.Text == mark) && (b5.Text == ""))
                return b5;

            if ((b7.Text == mark) && (b8.Text == mark) && (b9.Text == ""))
                return b9;
            if ((b8.Text == mark) && (b9.Text == mark) && (b7.Text == ""))
                return b7;
            if ((b7.Text == mark) && (b9.Text == mark) && (b8.Text == ""))
                return b8;

            //VERTICAL TESTS
            if ((b1.Text == mark) && (b4.Text == mark) && (b7.Text == ""))
                return b7;
            if ((b4.Text == mark) && (b7.Text == mark) && (b1.Text == ""))
                return b1;
            if ((b1.Text == mark) && (b7.Text == mark) && (b4.Text == ""))
                return b4;

            if ((b2.Text == mark) && (b5.Text == mark) && (b8.Text == ""))
                return b8;
            if ((b5.Text == mark) && (b8.Text == mark) && (b2.Text == ""))
                return b2;
            if ((b2.Text == mark) && (b8.Text == mark) && (b5.Text == ""))
                return b5;

            if ((b3.Text == mark) && (b6.Text == mark) && (b9.Text == ""))
                return b9;
            if ((b6.Text == mark) && (b9.Text == mark) && (b3.Text == ""))
                return b3;
            if ((b3.Text == mark) && (b9.Text == mark) && (b6.Text == ""))
                return b6;

            //DIAGONAL TESTS
            if ((b1.Text == mark) && (b5.Text == mark) && (b9.Text == ""))
                return b9;
            if ((b5.Text == mark) && (b9.Text == mark) && (b1.Text == ""))
                return b1;
            if ((b1.Text == mark) && (b9.Text == mark) && (b5.Text == ""))
                return b5;

            if ((b3.Text == mark) && (b5.Text == mark) && (b7.Text == ""))
                return b7;
            if ((b5.Text == mark) && (b7.Text == mark) && (b3.Text == ""))
                return b3;
            if ((b3.Text == mark) && (b7.Text == mark) && (b5.Text == ""))
                return b5;

            return null;
        }
      
    }
}
