using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    class TextPosition
    {
        int position;
        string text;
        public TextPosition(int position, string text)
        {
            this.position = position;
            this.text = text;
        }

        public void DisplayError()
        {

        }
    }
}
