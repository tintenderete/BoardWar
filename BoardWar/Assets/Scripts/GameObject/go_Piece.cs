using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class go_Piece : MonoBehaviour 
{
	Piece piece;
	List<SkillStats> pieceSkills;
	Game game;
	PlayerInputs inputs;
	go_Canvas canvas;

	void Start()
	{
		
		inputs = ScriptableObject.CreateInstance<PlayerInputs> ();
		canvas = GameObject.Find ("Canvas").GetComponent<go_Canvas> ();
	}

	public void SetScript(Game game, Piece piece)
	{
		this.game = game;
		this.piece = piece;
		this.pieceSkills = piece.GetSkills ();
	}

	void OnMouseDown()
	{
		if (Anim.IsWorking ())
			return;

		inputs.SetActor_Where (piece);

		if (piece.GetColor () != game.GetCurrentPlayer ().GetColor ()) 
		{
			return;
		}
		else if (PlayerInputs.action == null) 
		{
			canvas.SkillsMenuOn ();

			GameObject.Find ("SkillsMenu").GetComponent<go_SkillsMenu> ().SetActions (piece, pieceSkills, game);
		}

	}
		
}
