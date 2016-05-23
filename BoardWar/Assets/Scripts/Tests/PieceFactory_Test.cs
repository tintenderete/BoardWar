using UnityEngine;
using System.Collections;
using BoardGameApi;

public class PieceFactory_Test : MonoBehaviour 
{



	// Use this for initialization
	void Start () 
	{
		Piece piece = PieceFactory.MakePiece ("Warrior", 1);

		Debug.Log (piece.GetName());
		Debug.Log (piece.GetSkills()[0].name);
		Debug.Log (piece.GetSkills()[0].power);
		Debug.Log (piece.GetSkills()[0].range);

		piece = PieceFactory.MakePiece ("Archer", 1);

		Debug.Log (piece.GetName());
		Debug.Log (piece.GetSkills()[0].name);
		Debug.Log (piece.GetSkills()[0].power);
		Debug.Log (piece.GetSkills()[0].range);
	
	}
	

}
