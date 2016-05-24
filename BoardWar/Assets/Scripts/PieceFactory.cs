using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class PieceFactory : ScriptableObject , IPieceFactory
{
	
	 private string pathAux = "Stats_";
	 private ItemContainer ic;

	 private Piece newPiece;
	 private List<SkillStats> listSkillStats;
	 private SkillStats newSkillStats;

	public Piece MakePiece(string pieceName, int color)
	{
		return _MakePiece(pieceName,  color);
	}

	private Piece _MakePiece(string name, int color)
	{
		listSkillStats = new List<SkillStats> ();

		if (name == "Warrior" ) 
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

		if (name == "Archer" ) 
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

		if (name == "NoPiece" ) 
		{	
			
			newSkillStats = new SkillStats();
			newPiece = new NoPiece ();
			newPiece.SetName ("NoPiece");

			return newPiece;
		}

		return null;
	}
}
