using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Input
    {
        //Załaduj listę dostępnych przycisków Klawiatury
        private static Hashtable keyTable = new Hashtable();

        //Sprawdz czy dany przycisk jest wcisnięty
        public static bool KeyPressed(Keys key)
        {
            if(keyTable[key] == null)
            {
                return false;        
            }

            return (bool)keyTable[key];
        }

        //Wykrywanie czy przycisk klawiatury jest wciśnięty
        public static void ChangeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }
}
