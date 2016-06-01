using UnityEngine;
using System.Collections;


public class go_Menu : MonoBehaviour 
{

	GameObject panel;

	void Start()
	{
		panel = gameObject.transform.Find("Panel").gameObject;
	}

	public void SetActive(bool _bool)
	{
		panel.SetActive (_bool);
	}

	public void NewGame()
	{
		GameObject PieceAndCells = GameObject.Find ("Piece&Cells");
	/*
		PieceAndCells.SetActive (false);
		Destroy (PieceAndCells);
		*/
		for (int i = 0; i < PieceAndCells.transform.childCount; i++) 
		{
			Destroy (PieceAndCells.transform.GetChild(i).gameObject);
		}
		/*
		GameObject newPieceAndCells = new GameObject ();
		newPieceAndCells.name = "Piece&Cells";
*/
		GameObject.Find ("Game").gameObject.GetComponent<go_Game>().NewGame();

		this.SetActive (false);
	}

	public void ExitApp()
	{
		Application.Quit ();
	}
}
