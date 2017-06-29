using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.GameCore;

namespace ITI.InterfaceUser
{
    public struct simulatepawn
    {
        public int _pawnSourceX;
        public int _pawnSourceY;
        public int _pawnDestinationX;
        public int _pawnDestinationY;
        int _simulateTurn;
        int _score;
        bool _pawnIsAtk;

        public simulatepawn(int PawnSourceX, int PawnSourceY, int PawnDestinationX, int PawnDestinationY, int simulateTurn, int Score, bool pawnIsAtk)
        {
            _pawnSourceX = PawnSourceX;
            _pawnSourceY = PawnSourceY;
            _pawnDestinationX = PawnDestinationX;
            _pawnDestinationY = PawnDestinationY;
            _simulateTurn = simulateTurn;
            _score = Score;
            _pawnIsAtk = pawnIsAtk;
        }
        public int PawnSourceX
        {
            get { return _pawnSourceX; }
            set { _pawnSourceX = value; }
        }

        public int PawnSourceY
        {
            get { return _pawnSourceY; }
            set { _pawnSourceY = value; }
        }

        public int PawnDestionationX
        {
            get { return _pawnDestinationX; }
            set { _pawnDestinationX = value; }
        }

        public int PawnDestinationY
        {
            get { return _pawnDestinationY; }
            set { _pawnDestinationY = value; }
        }

        public int SimulateTurn
        {
            get { return _simulateTurn; }
            set { _simulateTurn = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }




    }
    public class IA
    {
        IReadOnlyTafl _tafl;
        bool _isIaAtk;
        bool _isIaDef;
        public readonly List<simulatepawn> _SimulatePawn;
        int _width;
        int _height;
        int _simulateTurn;
        int _nbSimulation;
        int _finalScore;
        bool _pawnIsAtk;
        public IA(IReadOnlyTafl tafl, bool isIaAtk, bool isIaDef)
        {
            _tafl = tafl;
            _isIaAtk = isIaAtk;
            _isIaDef = isIaDef;
            _width = _tafl.Width;
            _height = _tafl.Height;

            _simulateTurn = 0;

        }

        
        private void simulationTurn(int SimulatePawnPositionX, int simulatePawnPositionY, bool iaIsAtk)
        {
            for(int y = 0; y < _height; y++)
            {
                for(int x = 0; x < _width; x++)
                {
                    if(_tafl[x, y] == Pawn.Attacker && _isIaAtk == true)
                    {
                        simulateMovePawn(x, y);
                    }else if(_tafl[x,y] == Pawn.Defender && _isIaDef == true)
                    {
                        simulateMovePawn(x, y);
                    }
                }
            }
            _simulateTurn++;
        }

        private bool simulateMovePawn(int PawnSourceX, int PawnSourceY)
        {
            for(int x = 0;  x < PawnSourceX; x++)
            {
                if(tryMove(PawnSourceX, PawnSourceY, x, PawnSourceY) == true)
                {
                    if(_tafl[PawnSourceX, PawnSourceY] == Pawn.Attacker)
                    {
                        _pawnIsAtk = true;
                    }else
                    {
                        _pawnIsAtk = false;
                    }
                    simulatepawn current = new simulatepawn(PawnSourceX, PawnSourceY, x, PawnSourceY, _simulateTurn, _finalScore, _pawnIsAtk);
                    _SimulatePawn.Add(current);
                }
            }
            for (int x = 0; x > PawnSourceX; x--)
            {
                if (tryMove(PawnSourceX, PawnSourceY, x, PawnSourceY) == true)
                {
                    if (_tafl[PawnSourceX, PawnSourceY] == Pawn.Attacker)
                    {
                        _pawnIsAtk = true;
                    }
                    else
                    {
                        _pawnIsAtk = false;
                    }
                    simulatepawn current = new simulatepawn(PawnSourceX, PawnSourceY, x, PawnSourceY, _simulateTurn, _finalScore, _pawnIsAtk);
                    _SimulatePawn.Add(current);
                }
            }
            for (int y = 0; y < PawnSourceY; y++)
            {
                if (tryMove(PawnSourceX, PawnSourceY, PawnSourceX, y) == true)
                {
                    if (_tafl[PawnSourceX, PawnSourceY] == Pawn.Attacker)
                    {
                        _pawnIsAtk = true;
                    }
                    else
                    {
                        _pawnIsAtk = false;
                    }
                    simulatepawn current = new simulatepawn(PawnSourceX, PawnSourceY, PawnSourceX, y, _simulateTurn, _finalScore, _pawnIsAtk);
                    _SimulatePawn.Add(current);
                }
            }
            for (int y = 0; y > PawnSourceY; y--)
            {
                if (tryMove(PawnSourceX, PawnSourceY, PawnSourceX, y) == true)
                {
                    if (_tafl[PawnSourceX, PawnSourceY] == Pawn.Attacker)
                    {
                        _pawnIsAtk = true;
                    }
                    else
                    {
                        _pawnIsAtk = false;
                    }
                    simulatepawn current = new simulatepawn(PawnSourceX, PawnSourceY, PawnSourceX, y, _simulateTurn, _finalScore, _pawnIsAtk);
                    _SimulatePawn.Add(current);
                }
            }

            return false;
        }

        private bool tryMove(int PawnSourceX, int PawnSourceY, int PawnDestX, int PawnDestY)
        {

            return false;
        }
    }
}
