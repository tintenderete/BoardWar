using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class Anim : MonoBehaviour
{
	private static List<Anim> animationsWorking = new List<Anim> ();


	public static void AnimStart(Anim animation)
	{
		
		if(animation != null) animationsWorking.Add (animation);
	}

	public static void AnimFinish(Anim animation)
	{
		
		if(animation != null) animationsWorking.Remove (animation);
	}

	public static bool IsWorking()
	{
		if (animationsWorking.Count > 0 ) 
		{
			return true;
		}
		return false;
	}


	public static PieceManager FindOriginPieceManager(Action action)
	{

		foreach (PieceManager piece in ListPieceManager.listPiece) 
		{

			if (piece.id == action.originCell.GetPiece().GetId ()) 
			{
				return piece;
			}
		}

		return null;
	}

	public static PieceManager FindDestinyPieceManager(Action action)
	{

		foreach (PieceManager piece in ListPieceManager.listPiece) 
		{

			if (piece.id == action.destinyCells[0].GetPiece().GetId ()) 
			{
				return piece;
			}
		}

		return null;
	}



}
