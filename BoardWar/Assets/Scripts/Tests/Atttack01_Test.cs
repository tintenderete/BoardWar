using UnityEngine;
using System.Collections;
using BoardGameApi;

public class Atttack01_Test : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		PieceFactory factory = ScriptableObject.CreateInstance<PieceFactory> ();
		BoardTableEditor editor = new BoardTableEditor (2, 2, factory);

		editor.SetPointerInLine (0);
		editor.PushPiece (1, "Warrior", (int)Piece.colors.Blue);
		editor.PushPiece (1, "Archer", (int)Piece.colors.Red);

		Board board = editor.GetBoard ();
		Player player = new Player ((int)Piece.colors.Blue);

		Action action = new Attack01 (board.GetCell (0, 0));
		action.LookForMovements (player, board);


		Debug.Log (action.destinyCells[0].GetPiece().GetHealth());

		action.Execute (action.destinyCells [0], board);

		Debug.Log (action.destinyCells[0].GetPiece().GetHealth());




	}
	

}
