using UnityEngine;
using System.Collections;
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


		PieceFactory factory = ScriptableObject.CreateInstance<PieceFactory> ();

		BoardTableEditor editor = new BoardTableEditor (3, 3, factory);

		editor.SetPointerInLine (0);

		editor.PushPiece (1, "Warrior", (int)Player.colors.Blue);
		editor.PushPiece (1, "Warrior", (int)Player.colors.Red);

		turnManager = new TurnManager ();

		game = new Game (editor.GetBoard(), turnManager);

		MakeListsManager.MakeLists (game);

		turnManager.SetGame (game);

		turnManager.AddStep (new PlayerPlay ());
		turnManager.AddStep (new PlayAnimation ());
		turnManager.AddStep (new UpdateBoardTable ());
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		game.Update ();
	}
}
