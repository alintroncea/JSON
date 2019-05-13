using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Sequence : IPattern
    {

        //Clasa Sequance reprezintă o secvență de pattern-uri. 
        //Dar spre deosebire de Choice toate pattern-urile din secvență trebuie să se potrivească pentru ca secevența să fie validă.
        //Pattern-urile se aplică succesiv unul după altul peste textul care a rămas de la pattern-ul anterior.

        readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            string original = text;
            int counter = 0;

            foreach (var pattern in patterns)
            {

                IMatch match = pattern.Match(text);
                if (!match.Success())
                {
                    if (match is Error error)
                    {
                        counter += error.Position();
                    }
                    return new Error(counter, original);
                }
                counter += text.Length - match.RemainingText().Length;

                text = match.RemainingText();
            }
            return new Match(true, text);
        }
    }
}
