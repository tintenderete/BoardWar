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
	GameObject mouseOverPiece_tool;
	GameObject pieceMarked_tool;

	void Start()
	{
		pieceStats = GameObject.Find ("PieceStats").GetComponent<go_PieceStats>();
		inputs = ScriptableObject.CreateInstance<PlayerInputs> ();
		canvas = GameObject.Find ("Canvas").GetComponent<go_Canvas> ();
		mouseOverPiece_tool = GameObject.Find ("PlayerInterfaceTools").transform.FindChild ("MouseOverPiece").gameObject;
		pieceMarked_tool = GameObject.Find ("PlayerInterfaceTools").transform.FindChild ("PieceMarked").gameObject;
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

		mouseOverPiece_tool.transform.position = gameObject.transform.position;
		mouseOverPiece_tool.SetActive (true);

	}
	void OnMouseExit()
	{
		pieceStats.SetActive (false);

		if(mouseOverPiece_tool.activeSelf)
		{
			mouseOverPiece_tool.SetActive (false);
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

			pieceMarked_tool.transform.position = gameObject.transform.position;
			pieceMarked_tool.SetActive (true);
		}

	}

	public Piece GetPiece()
	{
		return piece;
	}
		
}
