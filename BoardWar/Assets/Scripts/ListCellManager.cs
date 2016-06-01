using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class ListCellManager : ScriptableObject 
{
	public static List<CellManager> listCell = new List<CellManager>();

	public static CellManager FindCell(Cell cell)
	{
		foreach (CellManager cellM in listCell) 
		{
			if (cellM.transform.position.x == cell.GetBoardPosition ().horizontal && cellM.transform.position.z == cell.GetBoardPosition ().vertical) 
			{
				return cellM;
			}
		}

		return null;
	}

}
