using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsUI
{
    class ButtonCard : Button
    {
        char m_Letter;
        string m_coordinates;

        public ButtonCard(char i_Letter, string i_coordinates)
        {
            m_Letter = i_Letter;
            m_coordinates = i_coordinates;
        }

        public char Letter
        {
            get
            {
                return m_Letter;
            }
            set
            {
                m_Letter = value;
            }
        }

        public string Coordinates
        {
            get

            {
                return m_coordinates;
            }
            set
            {
                m_coordinates = value;
            }
        }
    }
}