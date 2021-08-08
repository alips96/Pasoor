namespace Pasoor.Players
{
    public interface IAIPlayer
    {
        //Something should be implemented here
        //This is specifically for addinitional methods for AI players.
    }

    public class AIPlayer : Player, IAIPlayer
    {
        public AIPlayer(string name)
        {
            Name = name;
        }
    }
}

