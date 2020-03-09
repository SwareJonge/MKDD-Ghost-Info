using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKDD_Ghost_Info.Core
{
    class ConverterFunctions
    {
        public string GetCharInfo(byte x)
        {
            if (x == 1)
            {
                return "Baby Mario";
            }
            if (x == 2)
            {
                return "Baby Luigi";
            }
            if (x == 3)
            {
                return "Patroopa";
            }
            if (x == 4)
            {
                return "Koopa";
            }
            if (x == 5)
            {
                return "Peach";
            }
            if (x == 6)
            {
                return "Daisy";
            }
            if (x == 7)
            {
                return "Mario";
            }
            if (x == 8)
            {
                return "Luigi";
            }
            if (x == 9)
            {
                return "Wario";
            }
            if (x == 10)
            {
                return "Waluigi";
            }
            if (x == 11)
            {
                return "Yoshi";
            }
            if (x == 12)
            {
                return "Birdo";
            }
            if (x == 13)
            {
                return "Donkey Kong";
            }
            if (x == 14)
            {
                return "Diddy Kong";
            }
            if (x == 15)
            {
                return "Bowser";
            }
            if (x == 16)
            {
                return "Bowser Jr.";
            }
            if (x == 17)
            {
                return "Toad";
            }
            if (x == 18)
            {
                return "Toadette";
            }
            if (x == 19)
            {
                return "King Boo";
            }
            if (x == 20)
            {
                return "Petey Piranha";
            }
            else
            {
                return "None";
            }
        }

        public string GetKartID(byte x)
        {

            if (x == 0)
            {
                return "Red Fire";
            }
            if (x == 1)
            {
                return "DK Jumbo";
            }
            if (x == 2)
            {
                return "Turbo Yoshi";
            }
            if (x == 3)
            {
                return "Koopa Dasher";
            }
            if (x == 4)
            {
                return "Heart Coach";
            }
            if (x == 5)
            {
                return "Goo-Goo Buggy";
            }
            if (x == 6)
            {
                return "Wario Car";
            }
            if (x == 7)
            {
                return "Koopa King";
            }
            if (x == 8)
            {
                return "Green Fire";
            }
            if (x == 9)
            {
                return "Barrel Train";
            }
            if (x == 10)
            {
                return "Turbo Birdo";
            }
            if (x == 11)
            {
                return "Para Wing";
            }
            if (x == 12)
            {
                return "Bloom Coach";
            }
            if (x == 13)
            {
                return "Rattle Buggy";
            }
            if (x == 14)
            {
                return "Waluigi Racer";
            }
            if (x == 15)
            {
                return "Bullet Blaster";
            }
            if (x == 16)
            {
                return "Toad Kart";
            }
            if (x == 17)
            {
                return "Toadette Kart";
            }
            if (x == 18)
            {
                return "Boo Pipes";
            }
            if (x == 19)
            {
                return "Piranha Pipes";
            }
            if (x == 20)
            {
                return "Parade Kart";
            }
            else
            {
                return "Unknown ID";
            }
        }

        public string GetCourseID(byte x)
        {

            if (x == 0x21)
            {
                return "Baby Park";
            }
            if (x == 0x22)
            {
                return "Peach Beach";
            }
            if (x == 0x23)
            {
                return "Daisy Cruiser";
            }
            if (x == 0x24)
            {
                return "Luigi Circuit";
            }
            if (x == 0x25)
            {
                return "Mario Circuit";
            }
            if (x == 0x26)
            {
                return "Yoshi Circuit";
            }
            if (x == 0x28)
            {
                return "Mushroom Bridge";
            }
            if (x == 0x29)
            {
                return "Mushroom City";
            }
            if (x == 0x2A)
            {
                return "Waluigi Stadium";
            }
            if (x == 0x2B)
            {
                return "Wario Colosseum";
            }
            if (x == 0x2C)
            {
                return "Dino Dino Jungle";
            }
            if (x == 0x2D)
            {
                return "DK Mountain";
            }
            if (x == 0x2F)
            {
                return "Bowser\'s Castle";
            }
            if (x == 0x31)
            {
                return "Rainbow Road";
            }
            if (x == 0x32)
            {
                return "Waluigi Racer";
            }
            if (x == 0x33)
            {
                return "Dry Dry Desert";
            }
            else
            {
                return "Sherbet Land";
            }
        }
        public byte ConvertAnalogY(int x)
        {
            if (x == 3)
            {
                return 197;
            }
            if (x == 2)
            {
                return 179;
            }
            if (x == 1)
            {
                return 161;
            }
            if (x == 7)
            {
                return 95;
            }
            if (x == 6)
            {
                return 77;
            }
            if (x == 5)
            {
                return 59;
            }
            else
            {
                return 128;
            }
        }

        public byte ConvertAnalogX(int x)
        {
            if (x == 0x88)
            {
                return 53;
            }
            if (x == 0x90)
            {
                return 57;
            }
            if (x == 0x98)
            {
                return 61;
            }
            if (x == 0xA0)
            {
                return 65;
            }
            if (x == 0xA8)
            {
                return 69;
            }
            if (x == 0xB0)
            {
                return 73;
            }
            if (x == 0xB8)
            {
                return 77;
            }
            if (x == 0xC0)
            {
                return 81;
            }
            if (x == 0xC8)
            {
                return 85;
            }
            if (x == 0xD0)
            {
                return 89;
            }
            if (x == 0xD8)
            {
                return 93;
            }
            if (x == 0xE0)
            {
                return 97;
            }
            if (x == 0xE8)
            {
                return 101;
            }
            if (x == 0xF0)
            {
                return 105;
            }
            if (x == 0xF8)
            {
                return 109;
            }
            if (x == 0x08)
            {
                return 147;
            }
            if (x == 0x10)
            {
                return 151;
            }
            if (x == 0x18)
            {
                return 155;
            }
            if (x == 0x20)
            {
                return 159;
            }
            if (x == 0x28)
            {
                return 163;
            }
            if (x == 0x30)
            {
                return 167;
            }
            if (x == 0x38)
            {
                return 171;
            }
            if (x == 0x40)
            {
                return 175;
            }
            if (x == 0x48)
            {
                return 179;
            }
            if (x == 0x50)
            {
                return 183;
            }
            if (x == 0x58)
            {
                return 187;
            }
            if (x == 0x60)
            {
                return 191;
            }
            if (x == 0x68)
            {
                return 195;
            }
            if (x == 0x70)
            {
                return 199;
            }
            if (x == 0x78)
            {
                return 203;
            }
            else
            {
                return 128;
            }
        }

        public byte checkIfAPressed(byte x)
        {
            if ((x & (1 << 0)) != 0)
            {
                return 1;
            }
            return 0;
        }
        public byte checkIfBPressed(byte x)
        {
            if ((x & (1 << 1)) != 0)
            {
                return 1;
            }
            return 0;
        }
        public byte checkIfXPressed(byte x)
        {
            if ((x & (1 << 2)) != 0 || (x & (1 << 3)) != 0)
            {
                return 1;
            }
            return 0;
        }
        public byte checkIfRPressed(byte x)
        {
            if ((x & (1 << 5)) != 0)
            {
                return 1;
            }
            return 0;
        }

        public byte checkIfLPressed(byte x)
        {
            if ((x & (1 << 4)) != 0)
            {
                return 1;
            }
            return 0;
        }

        public byte checkIfZPressed(byte x)
        {
            if ((x & (1 << 6)) != 0)
            {
                return 1;
            }
            return 0;
        }

    }
}
