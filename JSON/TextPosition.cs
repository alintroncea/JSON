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
            int lineCount = 0;
            int counter = 0;
            int linePosition = 0;
            text.Replace('\r', '\n');

            for (int i = 0; i < text.Length; i++)
            {
                counter++;
                if (text[i] == '\n')
                {
                    linePosition = i;
                    lineCount++;
                }

                if (i == position)
                {
                    Console.WriteLine("Error at position index : " + (i-linePosition) + " value : " + text[i]+", on line : "+lineCount);
                    break;
                }


            }

        }
    }
}
