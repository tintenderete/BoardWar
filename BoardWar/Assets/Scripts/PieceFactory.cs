using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class PieceFactory : MonoBehaviour 
{
	static private string pathAux = "Stats_";
	static private ItemContainer ic;

	static private Piece newPiece;
	static private List<SkillStats> listSkillStats;
	static private SkillStats newSkillStats;

	public static Piece MakePiece(string name, int color)
	{
		listSkillStats = new List<SkillStats> ();

		if (name == "Warrior") 
		{	
			ic = ItemContainer.Load (pathAux + name );

			foreach (Item item in ic.items)
			{
				newSkillStats = new SkillStats();
				newSkillStats.name = item.name;
				newSkillStats.power = item.power; 
				newSkillStats.range = item.range; 

				listSkillStats.Add (newSkillStats);
			}

			newPiece = new Piece (color, listSkillStats);
			newPiece.SetName ("Warrior");

			return newPiece;
		}

		if (name == "Archer") 
		{	
			ic = ItemContainer.Load (pathAux + name );

			foreach (Item item in ic.items)
			{
				newSkillStats = new SkillStats();
				newSkillStats.name = item.name;
				newSkillStats.power = item.power; 
				newSkillStats.range = item.range; 

				listSkillStats.Add (newSkillStats);
			}

			newPiece = new Piece (color, listSkillStats);
			newPiece.SetName ("Archer");

			return newPiece;
		}

		return null;
	}
}
