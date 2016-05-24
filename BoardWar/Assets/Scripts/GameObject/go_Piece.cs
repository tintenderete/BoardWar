using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class go_Piece : MonoBehaviour 
{
	go_SkillsMenu skillsMenu;
	Piece piece;
	List<SkillStats> pieceSkills;
	Game game;

	void Start()
	{
		skillsMenu = GameObject.Find ("SkillsMenu").GetComponent<go_SkillsMenu> ();
	}

	public void SetScript(Game game, Piece piece)
	{
		this.game = game;
		this.piece = piece;
		this.pieceSkills = piece.GetSkills ();
	}

	void OnMouseDown()
	{
		
		Action action = ActionFactory.MakeAction (
			pieceSkills[0].name,
			game.GetBoard().GetCell(piece)
		);
		/*
		if (go_SkillsMenu != null) 
		{
			game.GetCurrentPlayer ().AddInput (action);
		}
*/
		skillsMenu.SetAction(action, game);


	}
}
