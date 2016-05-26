using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class go_SkillsMenu : MonoBehaviour 
{
	
	public Action action_A;
	public Action action_B;
	public Action action_C;

	PlayerInputs inputs;


	void Start()
	{
		inputs = ScriptableObject.CreateInstance<PlayerInputs> ();
	}

	public void SetActions(Piece piece, List<SkillStats> skills, Game game)
	{
		
		if (skills.Count > 0) 
		{
			this.action_A  = ActionFactory.MakeAction 
			(
				skills [0].name,
				game.GetBoard ().GetCell (piece)
			);
			
		}
		if (skills.Count > 1) 
		{
			this.action_B = ActionFactory.MakeAction 
			(
				skills [1].name,
				game.GetBoard ().GetCell (piece)
			);
		}
		if (skills.Count > 2) 
		{
			this.action_C  = ActionFactory.MakeAction 
			(
				skills [2].name,
				game.GetBoard ().GetCell (piece)
			);
			
		}
	}

	public void SendAction_A()
	{
		if (action_A == null)
			return;
		inputs.SetAction (action_A);
	}
	public void SendAction_B()
	{
		if (action_B == null)
			return;
		inputs.SetAction (action_B);
	}
	public void SendAction_C()
	{
		if (action_C == null)
			return;

		inputs.SetAction (action_C);
	}

}
