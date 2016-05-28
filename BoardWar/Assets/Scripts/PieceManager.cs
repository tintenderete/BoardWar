using UnityEngine;
using System.Collections;


public class PieceManager : ActorManager 
{
	public go_StateBar stateBar;

	public PieceManager(GameObject go):base(go){}

	public void SetStateBar(go_StateBar stateBar)
	{
		this.stateBar = stateBar;
	}
}
