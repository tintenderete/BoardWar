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
		private float maxHealth;
		private float currentHealth;

        public Piece(): base()
        {
            this.type = (int)Actor.types.Piece;
        }

		public Piece(int color, List<SkillStats> skills): base()
        {
            this.color = color;
			this.skills = skills;
            this.type = (int)Actor.types.Piece;
        }

        public int GetColor()
        {
            return color;
        }

		public List<SkillStats> GetSkills()
        {
			return skills;
        }

		public float GetMaxHealth()
		{
			return maxHealth;
		}
		public float GetCurrentHealth()
		{
			return currentHealth;
		}
		public void SetMaxHealth(float newHealth)
		{
			this.maxHealth = newHealth;
		}
		public void SetCurrentHealth(float newHealth)
		{
			this.currentHealth = newHealth;
		}
    }
}
