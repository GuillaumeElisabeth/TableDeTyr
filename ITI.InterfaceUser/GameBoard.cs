﻿using ITI.GameCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.InterfaceUser
{
    public partial class m_GameBoard : Form
    {
        public Pawn[,] _plateau = new Pawn[11,11];
        bool _checkMove;
        public bool _allowMove = false;
        public bool[,] _tryMove;
        bool _endTurn;
        public Game _partie;
        public int _pawnMoveX;
        public int _pawnMoveY;
        public int _pawnDestinationX;
        public int _pawnDestinationY;
        

        /// <summary>
        /// Call the form m_GameBoard
        /// test : I hard put the position of the pawn 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public m_GameBoard(int width, int height)
        {
            InitializeComponent();
            Game partie = new Game();
            _partie = partie;
            _plateau = partie.GetTafl;
            _tryMove = new bool[11, 11];
            
            #region hardcode du tafl
            /*
            _plateau = new int[11, 11];

            _plateau[3, 0] = 1;
            _plateau[4, 0] = 1;
            _plateau[5, 0] = 1;
            _plateau[6, 0] = 1;
            _plateau[7, 0] = 1;

            _plateau[5, 1] = 1;

            _plateau[3, 10] = 1;
            _plateau[4, 10] = 1;
            _plateau[5, 10] = 1;
            _plateau[6, 10] = 1;
            _plateau[7, 10] = 1;

            _plateau[5, 9] = 1;

            _plateau[0, 3] = 1;
            _plateau[0, 4] = 1;
            _plateau[0, 5] = 1;
            _plateau[0, 6] = 1;
            _plateau[0, 7] = 1;

            _plateau[1, 5] = 1;

            _plateau[10, 3] = 1;
            _plateau[10, 4] = 1;
            _plateau[10, 5] = 1;
            _plateau[10, 6] = 1;
            _plateau[10, 7] = 1;

            _plateau[9, 5] = 1;

            _plateau[3, 5] = 2;
            _plateau[4, 4] = 2;
            _plateau[4, 5] = 2;
            _plateau[4, 6] = 2;
            _plateau[5, 3] = 2;
            _plateau[5, 4] = 2;
            _plateau[5, 6] = 2;
            _plateau[5, 7] = 2;
            _plateau[6, 4] = 2;
            _plateau[6, 5] = 2;
            _plateau[6, 6] = 2;
            _plateau[7, 5] = 2;

            _plateau[5, 5] = 3;
            */
            #endregion
            

        }


        /// <summary>
        /// This function look the Itafl states and show the position of the pawn on the board.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int i = 0, j = 0;

            //vérifiez les conditions de victoire
            // si victoire affichez la victoire
            //sinon : pictureBox1.Refresh();
            // m_PlayerTurn.Refresh();

            for (int y = 22; y < 490; y++)
            {
                for (int x = 21; x < 490; x++)
                {

                    if (_plateau[i, j] == Pawn.Attacker)
                    {
                        using (Pen g = new Pen(Brushes.DarkBlue))
                        {
                            e.Graphics.DrawEllipse(g, x, y, 38, 38);
                        }
                    }
                    if (_plateau[i, j] == Pawn.Defender)
                    {
                        using (Pen a = new Pen(Brushes.White))
                        {
                            e.Graphics.DrawEllipse(a, x, y, 38, 38);
                        }
                    }
                    if (_plateau[i, j] == Pawn.King)
                    {
                        using (Pen h = new Pen(Brushes.Green))
                        {
                            e.Graphics.DrawEllipse(h, x, y, 38, 38);
                        }
                    }
                    i++;
                    x = x + 42;
                }
                i = 0;
                j++;
                y = y + 42;
            }
            
            
        }

        /// <summary>
        /// For the moment, This function give the x, y of the board.
        /// After, it will give x, y to the gamecore to communicate the pawn's position the user
        /// wants to move.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            int i = 0, j = 0;

            for (int y = 22; y < 490; y++)
            {
                for (int x = 21; x < 490; x++)
                {
                    if (e.X > x && e.X < x + 48 && e.Y > y && e.Y < y + 50)
                    {

                        if (_checkMove == false)
                        {
                            _pawnMoveX = i;
                            _pawnMoveY = j;
                            _checkMove = true;
                            m_positionSouris.Text = "x = " + _pawnMoveX + "y = " + _pawnMoveY;
                        }
                        else
                        {

                            _pawnDestinationX = i;
                            _pawnDestinationY = j;
                            m_positionSouris.Text = "x = " + _pawnDestinationX + "y = " + _pawnDestinationY;
                            _endTurn = true;
                            _allowMove = true;
                        }
                    }
                    i++;
                    x = x + 42;
                }
                i = 0;
                j++;
                y = y + 42;
            }
            
        }

        /// <summary>
        /// Show who is playing, 
        /// Will show other information after like : 
        /// number of pans alive ...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_GameBoard_Load(object sender, EventArgs e)
        {
            
            /*if (_ATKTurn == true)
            {
                m_PlayerTurn.Text = "c'est au tour de l'attaquant";
            }
            else
            {
                m_PlayerTurn.Text = "C'est au tour du défenseur";
            }*/
            m_PlayerTurn.Text = "C'est au tour de :";
        }

        private void m_updateTurn_Click(object sender, EventArgs e)
        {
            /*
            _plateau[_pawnDestinationX, _pawnDestinationY] = _plateau[_pawnMoveX,_pawnMoveY];
            _plateau[_pawnMoveX, _pawnMoveY] = Pawn.None;
            */
            _allowMove = true;
            
            if (_endTurn == true)
            {
                _allowMove = _partie.AllowMove(_pawnMoveX, _pawnMoveY, _pawnDestinationX, _pawnDestinationY);
                _plateau = _partie.GetTafl;

                if (_allowMove == true)
                {
                    m_PlayerTurn.Refresh();
                    _endTurn = false;
                    _checkMove = false;
                    _allowMove = false;
                    pictureBox1.Refresh();
                }
                else
                {
                    _checkMove = false;
                    _allowMove = false;
                }
            }

        }

    }
}