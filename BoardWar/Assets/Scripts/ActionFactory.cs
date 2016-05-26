using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class ActionFactory : ScriptableObject 
{
	private static Action newAction;

	public static Action MakeAction(string action, Cell originCell)
	{
		if (action == "Attack01") 
		{
			newAction = new Attack01 ("Attack01", originCell);

			return newAction;
		}
		if (action == "Move01") 
		{
			newAction = new Move01 ("Move01", originCell);

			return newAction;
		}

		return null;
	}

}
