using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    public class TurnManager
    {
        private List<IStep> steps;
		private IStep currentStep;
        private Game game;

        public TurnManager(Game newGame)
        {
			currentStep = null;
            steps = new List<IStep>();
            game = newGame;
        }

        public TurnManager()
        {
			currentStep = null;
            steps = new List<IStep>();
            game = null;
        }

        public void AddStep(IStep step)
        {
			if (steps.Count == 0) 
			{
				this.currentStep = step;
			}
            steps.Add(step);
        }

        public void Update()
        {
            currentStep.UpdateStep(this);  
        }

        public List<IStep> GetSteps()
        {
            return this.steps;
        }

        public void NextStep<T>()
        {
			currentStep = (IStep)FindOneStepLike<T> ();
        }
			

        public Game GetGame()
        {
            return game;
        }

        public void SetGame(Game game)
        {
             this.game = game ;
        }

       

        public T FindOneStepLike<T>()
        {

            for (int i = 0; i < steps.Count; i++)
            {
                if (steps[i] is T)
                {
                    return (T)steps[i];
                }
            }

            return default(T);
        }

    }
}
