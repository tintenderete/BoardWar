using UnityEngine;
using System.Collections;
using BoardGameApi;

public class Anim_Move01 : Anim
{
	private  GameObject pieceToMove;
	private  Position newPosition;
	private NavMeshAgent nav;
	private Animator animator;

	public  bool Execute(Action action)
	{
		newPosition = action.destinyCells [0].GetBoardPosition();

		pieceToMove = FindOriginGameObject (action);

		Vector3 newPos = new Vector3 (
			newPosition.horizontal,
			pieceToMove.transform.position.y,
			newPosition.vertical
		);

		pieceToMove.transform.rotation = Quaternion.LookRotation (newPos - pieceToMove.transform.position);

		if (!working) 
		{
			animator = pieceToMove.GetComponent<Animator> ();

			animator.SetBool ("IsWalking", true);

			nav = pieceToMove.GetComponent<NavMeshAgent> ();


			nav.destination = new Vector3 (
				newPosition.horizontal,
				pieceToMove.transform.position.y,
				newPosition.vertical
			);

			working = true;
		}

		if (working) 
		{
			if (pieceToMove.transform.position.x == newPosition.horizontal &&
				pieceToMove.transform.position.z == newPosition.vertical) 
			{
				animator.SetBool ("IsWalking", false);
				working = false;
			}
		}

		return working;
	}



}
