namespace Pasoor.Players
{
    public class Player
	{
        private string name;
        private byte points = 0;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public byte Points
        {
            get
            {
                return points;
            }
            set
            {
                if (value > 0)
                    points += value;
            }
        }

    }
}

