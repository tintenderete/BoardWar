using UnityEngine;
using System.Collections;
using BoardGameApi;

public class NoAction : Action 
{

	public NoAction(Cell originCell):base(originCell){}

	public override void LookForMovements (Player currentPlayer, Board board){}

	public override void Execute (Cell destinyCell, Board board){}
}
