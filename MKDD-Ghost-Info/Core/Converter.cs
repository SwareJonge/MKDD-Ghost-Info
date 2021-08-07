using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKDD_Ghost_Info.Core
{
    class ConverterFunctions
    {
        public string[] ECharIDstrTable = new string[] {"NONE", "Baby Mario", "Baby Luigi" , "Patroopa", "Koopa", "Peach", "Daisy", "Mario", "Luigi", "Wario", "Waluigi", "Yoshi", "Birdo", "Donkey Kong", "Diddy Kong", "Bowser", "Bowser Jr.", "Toad", "Toadette", "King Boo", "Petey Piranha"};
        public string[] EKartIDstrTable = new string[] {"Red Fire", "DK Jumbo", "Turbo Yoshi", "Koopa Dasher", "Heart Coach", "Goo-Goo Buggy", "Wario Car", "Koopa King", "Green Fire", "Barrel Train", "Turbo Birdo", "Para Wing", "Bloom Coach", "Rattle Buggy", "Waluigi Racer", "Bullet Blaster", "Toad Kart", "Toadette Kart", "Boo Pipes", "Piranha Pipes", "Parade Kart" };

        public string GetCourseID(byte x)
        {
            // TODO Make this an array and add the unused course names too
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

        public byte ConvertAnalogY(byte y, out byte origin)
        {
            y = (byte)(((uint)y << 0x1d) >> 0x1d); // leave out the bits of the X axis
            byte stickY = (byte)(y * 18);

            byte stickPos = 128; // neutral
            // convert JUTGamepad::CStick to PADStick
            if (y >= 5) // down
            {
                stickPos = 0xE1; // -31
            }
            else if (y >= 1 && y < 4) // up
            {
                stickPos = 143;
            }
            origin = y;
            return (byte)(stickY + stickPos);
        }

        public byte ConvertAnalogX(byte x, out byte origin)
        {
            x = (byte)(x >> 3); // shift 3 bits to the right to leave out the Y axis and to get the bits in the right position
            byte stickX = (byte)(x * 4);

            byte stickPos = 128; // neutral

            // convert JUTGamepad::CStick to PADStick
            if (x >= 16) // left
            {
                stickPos = 0xF1; // -15
            }
            else if (x >= 1 && x <= 15) // right
            {
                stickPos = 143;
            }
            origin = x;
            return (byte)(stickX + stickPos);
        }

        public byte checkIfAPressed(byte x)
        {
            return Convert.ToByte((x & 1) != 0);
        }
        public byte checkIfBPressed(byte x)
        {
            return Convert.ToByte((x & 0x2) != 0);
        }
        public byte checkIfXPressed(byte x)
        {
            return Convert.ToByte(((x & 0x4) != 0) || ((x & 0x8) != 0));
        }
        public byte checkIfRPressed(byte x)
        {
            return Convert.ToByte((x & 0x20) != 0);
        }

        public byte checkIfLPressed(byte x)
        {
            return Convert.ToByte((x & 0x10) != 0);
        }

        public byte checkIfZPressed(byte x)
        {
            return Convert.ToByte((x & 0x40) != 0);
        }

    }
}
