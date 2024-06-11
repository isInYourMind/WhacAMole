using System.Collections.Generic;
using MVC;

namespace HighScore
{
    public class HighScoreWindowParameters : IParameters
    {
        public Dictionary<string, int> PlayersScore;
    }
}