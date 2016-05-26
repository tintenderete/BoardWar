using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    public class Player
    {
        public enum colors {NoPiece, Blue, Red};

		private static List<Action> inputs;
		public static int mana;

        private int color;

        public Player()
        {
            if (inputs == null)
            {
				inputs = new List<Action>();
            }

        }

        public Player(int color)
        {
            if (inputs == null)
            {
				inputs = new List<Action>();
            }

            this.color = color;
        }

        public int GetColor()
        {
            return color;
        }

		public void AddInput(Action action)
        {
			inputs.Add(action);
        }

		public List<Action> GetInputs()
        {
            return inputs;
        }

		public void SetInputs(List<Action> newInputs)
        {
            inputs.Clear();
			foreach (Action action in newInputs)
            {
				inputs.Add(action);
            }
        }

        public void SetZeroInputs()
        {
            inputs.Clear();
        }


    }
}
