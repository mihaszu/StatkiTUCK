﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiTUCK
{
        class Ship
        {
            private int StartCoordX;
            private int StartCoordY;
            private bool[] StateOfFlagpoles;// { get; set; }
            private bool IsVertical;

        public int X
        {
            get { return StartCoordX; }
        }
        public int Y
        {
            get { return StartCoordY; }
        }
        public bool[] Flagpoles
        {
            get { return StateOfFlagpoles; }
        }

        public bool Vert
        {
            get { return IsVertical; }
        }

        public Ship(int NumberOfFlagpoles, int StartPosX, int StartPosY, bool Vertical)
            {
                StartCoordX = StartPosX;
                StartCoordY = StartPosY;

                StateOfFlagpoles = new bool[NumberOfFlagpoles];

                for (int i = 0; i < NumberOfFlagpoles; i++)
                {
                    StateOfFlagpoles[i] = true; //is alive
                }

                IsVertical = Vertical;
            }



            public bool CheckOrHitIt(int HitX, int HitY, bool checkIfExistsOnly = false)
            {
                if (IsVertical && HitX == StartCoordX)
                {
                    if (0 <= (HitY - StartCoordY) && (HitY - StartCoordY) < StateOfFlagpoles.Length)
                    {
                        if (!checkIfExistsOnly)
                            StateOfFlagpoles[HitY - StartCoordY] = false;
                        return true;
                    }

                }
                else if (!IsVertical && HitY == StartCoordY)
                {
                    if (0 <= (HitX - StartCoordX) && (HitX - StartCoordX) < StateOfFlagpoles.Length)
                    {
                        if (!checkIfExistsOnly)
                            StateOfFlagpoles[HitX - StartCoordX] = false;
                        return true;
                    }
                }

                return false;
            }




            public bool HasBeenDestroyed()
            {
                for (int i = 0; i < StateOfFlagpoles.Length; i++)
                {
                    if (StateOfFlagpoles[i]) return false;
                }
                return true;
            }
        }

}
