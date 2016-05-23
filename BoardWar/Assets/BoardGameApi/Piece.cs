using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    public class Piece: Actor
    {
        public enum colors {NoPiece, Blue, Red};
        protected int color;
		protected List<SkillStats> skills;
		private float health;

        public Piece(): base()
        {
            this.type = (int)Actor.types.Piece;
        }

		public Piece(int color, List<SkillStats> skills): base()
        {
            this.color = color;
			this.skills = skills;
            this.type = (int)Actor.types.Piece;
			this.health = 100;
        }

        public int GetColor()
        {
            return color;
        }

		public List<SkillStats> GetSkills()
        {
			return skills;
        }

		public float GetHealth()
		{
			return health;
		}
        
		public void SetHealth(float newHealth)
		{
			this.health = health;
		}
    }
}
