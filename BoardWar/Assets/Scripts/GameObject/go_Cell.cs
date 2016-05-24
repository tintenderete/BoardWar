using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class go_Cell : MonoBehaviour 
{

	go_SkillsMenu skillsMenu;
	Cell cell;
	Game game;

	void Start()
	{
		skillsMenu = GameObject.Find ("SkillsMenu").GetComponent<go_SkillsMenu> ();
	}

	public void SetScript(Game game, Cell cell)
	{
		this.game = game;
		this.cell = cell;
	}


	void OnMouseDown()
	{

		Action action = new NoAction (cell);
		/*
		if (go_SkillsMenu != null) 
		{
			game.GetCurrentPlayer ().AddInput (action);
		}
		*/
		skillsMenu.SetAction(action, game);


	}


}
