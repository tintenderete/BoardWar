using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class PieceFactory : ScriptableObject , IPieceFactory
{
	
	private string pathAux = "Stats_";
	private ItemContainer ic;

	private Piece newPiece;
	private float newHealth;	
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
				newHealth = GetHealth (item);
				newSkillStats = new SkillStats();
				newSkillStats.name = item.name;
				newSkillStats.power = item.power; 
				newSkillStats.range = item.range; 
				newSkillStats.cost = item.cost;

				listSkillStats.Add (newSkillStats);
			}

			newPiece = new Piece (color, listSkillStats);
			newPiece.SetName ("Warrior");
			newPiece.SetMaxHealth (newHealth);
			newPiece.SetCurrentHealth (newHealth);
			return newPiece;
		}

		if (name == "Archer" ) 
		{	
			ic = ItemContainer.Load (pathAux + name );

			foreach (Item item in ic.items)
			{
				newHealth = GetHealth (item);
				newSkillStats = new SkillStats();
				newSkillStats.name = item.name;
				newSkillStats.power = item.power; 
				newSkillStats.range = item.range; 
				newSkillStats.cost = item.cost;

				listSkillStats.Add (newSkillStats);
			}

			newPiece = new Piece (color, listSkillStats);
			newPiece.SetName ("Archer");
			newPiece.SetMaxHealth (newHealth);
			newPiece.SetCurrentHealth (newHealth);

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

	private float GetHealth(Item item)
	{
		if (item.name == "Health") 
		{
			return item.power;
		}
		return 0f;
	}
}
