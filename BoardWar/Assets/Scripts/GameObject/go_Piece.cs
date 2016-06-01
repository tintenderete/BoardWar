using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class go_Piece : MonoBehaviour 
{
	go_PieceStats pieceStats;
	Piece piece;
	List<SkillStats> pieceSkills;
	Game game;
	PlayerInputs inputs;
	go_Canvas canvas;
	GameObject ps_pieceSelection;

	void Start()
	{
		pieceStats = GameObject.Find ("PieceStats").GetComponent<go_PieceStats>();
		inputs = ScriptableObject.CreateInstance<PlayerInputs> ();
		canvas = GameObject.Find ("Canvas").GetComponent<go_Canvas> ();
		ps_pieceSelection = GameObject.Find ("PlayerInterfaceTools").transform.FindChild ("MouseOverPiece").gameObject;
	}

	public void SetScript(Game game, Piece piece)
	{
		this.game = game;
		this.piece = piece;
		this.pieceSkills = piece.GetSkills ();
	}

	void OnMouseOver()
	{
		//if (piece.GetName () != "Boss") 
		//{
			pieceStats.SetStats (piece);
			pieceStats.SetActive (true);
		//}

		ps_pieceSelection.transform.position = gameObject.transform.position;
		ps_pieceSelection.SetActive (true);

	}
	void OnMouseExit()
	{
		pieceStats.SetActive (false);

		if(ps_pieceSelection.activeSelf)
		{
			ps_pieceSelection.SetActive (false);
		}
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
		else if (PlayerInputs.action == null && piece.GetName() != "Boss") 
		{
			canvas.SkillsMenuOn ();

			GameObject.Find ("SkillsMenu").GetComponent<go_SkillsMenu> ().SetActions (piece, pieceSkills, game);
		}

	}

	public Piece GetPiece()
	{
		return piece;
	}
		
}
