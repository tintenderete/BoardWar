using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class PlayerInputs: ScriptableObject
{

	public static Action action = null;
	public static Actor actor_where = null;


	public PlayerInputs()
	{
		
	}

	public void SetActor_Where(Actor new_actor_where)
	{
		if (action == null) 
		{
			return;
		}

		actor_where = new_actor_where;
	}

	public void SetAction(Action new_action)
	{
		actor_where = null;
		action = new_action;

	}

	public void RightClick()
	{
		if (Input.GetMouseButtonDown (1)) 
		{
			CleanInputs ();
			GameObject.Find ("Canvas").GetComponent<go_Canvas> ().SkillsMenuOff();
			LookForMovements.UnMarkCells ();
			GameObject.Find ("PlayerInterfaceTools").transform.FindChild ("PieceMarked").gameObject.SetActive (false);
		}
	}

	public void CleanInputs()
	{
		action = null;
		actor_where = null;
	}
	
}
