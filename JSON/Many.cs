using System;

using System.Collections.Generic;

using System.Text;


namespace JSON

{
    public class Many : IPattern
    {
        //Clasa Many primește un singur pattern și consumă pattern-ul din stringul dat de oricâte ori apare acesta la începutul textului dat.

        readonly IPattern pattern;
        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }
        public IMatch Match(string text)
        {

            IMatch match = pattern.Match(text);

            while (match.Success())
            {
                match = pattern.Match(match.RemainingText());

            }
            int positionError = text == null
                ? 0
                : text.Length - match.RemainingText().Length;
            if (match is Error error)
                positionError += error.Position();

            return new SpecialError(positionError, match.RemainingText());
        }

    }

}