using UnityEngine;
using System.Collections;
using BoardGameApi;

public class Anim : MonoBehaviour
{

	public static bool working;

	public static void AnimStart()
	{
		working = true;
	}

	public static void AnimFinish()
	{
		working = false;
	}

	public static GameObject FindOriginGameObject(Action action)
	{

		foreach (PieceManager piece in ListPieceManager.listPiece) 
		{

			if (piece.id == action.originCell.GetPiece().GetId ()) 
			{
				return piece.go;
			}
		}

		return null;
	}

	public static GameObject FindDestinyGameObject(Action action)
	{

		foreach (PieceManager piece in ListPieceManager.listPiece) 
		{

			if (piece.id == action.destinyCells[0].GetPiece().GetId ()) 
			{
				return piece.go;
			}
		}

		return null;
	}


}
