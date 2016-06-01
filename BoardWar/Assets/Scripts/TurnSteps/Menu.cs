using UnityEngine;
using System.Collections;
using BoardGameApi;

public class Menu : IStep 
{
	public void UpdateStep(TurnManager turnManager)
	{
		if (!Curtain.IsActive()) 
		{
			GameObject.Find ("Menu").GetComponent<go_Menu> ().SetActive (true);
		} 
	}

}
