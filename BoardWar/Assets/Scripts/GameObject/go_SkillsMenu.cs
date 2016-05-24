using UnityEngine;
using System.Collections;
using BoardGameApi;

public class go_SkillsMenu : MonoBehaviour 
{
	
	public Action action;
	Game game;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}



	public void SetAction(Action action, Game game)
	{
		this.action = action;
		this.game = game;
	}

	public void SendActionAsInput()
	{
		if (action == null)
			return;
		
		game.GetCurrentPlayer ().AddInput (action);
	}

}
