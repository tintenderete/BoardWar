using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class go_Game : MonoBehaviour 
{
	Game game;
	TurnManager turnManager;
	Curtain curtain;
	// Use this for initialization
	void Start () 
	{
		curtain = ScriptableObject.CreateInstance<Curtain> ();
		curtain.CreateNewCurtain ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(game != null)game.Update ();
	}

	public void NewGame()
	{

		ListCellManager.listCell = new List<CellManager>();
		ListPieceManager.listPiece = new List<PieceManager>();

		PieceFactory factory = ScriptableObject.CreateInstance<PieceFactory> ();

		BoardTableEditor editor = new BoardTableEditor (7, 7, factory);

		editor.SetPointerInLine (0);
		editor.PushPiece (3, "Archer", (int)Player.colors.Blue);
		editor.PushPiece (1, "Boss", (int)Player.colors.Blue);
		editor.PushPiece (3, "Archer", (int)Player.colors.Blue);
		editor.SetPointerInLine (1);
		editor.PushPiece (7, "Warrior", (int)Player.colors.Blue);

		editor.SetPointerInLine (5);
		editor.PushPiece (7, "Warrior", (int)Player.colors.Red);
		editor.SetPointerInLine (6);
		editor.PushPiece (3, "Archer", (int)Player.colors.Red);
		editor.PushPiece (1, "Boss", (int)Player.colors.Red);
		editor.PushPiece (3, "Archer", (int)Player.colors.Red);

		/*
		BoardTableEditor editor = new BoardTableEditor (2, 2, factory);
		editor.SetPointerInLine (0);
		editor.PushPiece (1, "Archer", (int)Player.colors.Blue);
		editor.PushPiece (1, "Boss", (int)Player.colors.Blue);
		editor.SetPointerInLine (1);
		editor.PushPiece (1, "Archer", (int)Player.colors.Red);
		editor.PushPiece (1, "Boss", (int)Player.colors.Red);

*/
		turnManager = new TurnManager ();

		game = new Game (editor.GetBoard(), turnManager);

		MakeListsManager.MakeLists (game);

		turnManager.SetGame (game);

		turnManager.AddStep (new NewTurn ());
		turnManager.AddStep (new PlayerPlay ());
		turnManager.AddStep (new UpdateScene ());
		turnManager.AddStep (new UpdateGame ());
		turnManager.AddStep (new Winner ());
		turnManager.AddStep (new Menu ());
	}
}
