using UnityEngine;
using System.Collections;

public class CellManager : ActorManager 
{
	public GameObject markedCell;
	public CellManager(GameObject go): base(go){}

	public void SetStateMarkedCell(bool _bool)
	{
		markedCell.SetActive (_bool);
	}
}
