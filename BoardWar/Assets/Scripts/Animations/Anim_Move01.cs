using UnityEngine;
using System.Collections;
using BoardGameApi;

public class Anim_Move01 : Anim
{
	private  GameObject pieceToMove;
	private  Position newPosition;
	private NavMeshAgent nav;
	private Animator animator;

	public  void Execute(Action action)
	{
		newPosition = action.destinyCells [0].GetBoardPosition();

		pieceToMove = FindOriginGameObject (action);

		Vector3 newPos = new Vector3 (
			newPosition.horizontal,
			pieceToMove.transform.position.y,
			newPosition.vertical
		);

		pieceToMove.transform.rotation = Quaternion.LookRotation (newPos - pieceToMove.transform.position);


		animator = pieceToMove.GetComponent<Animator> ();

		animator.SetBool ("IsWalking", true);

		nav = pieceToMove.GetComponent<NavMeshAgent> ();


		nav.destination = new Vector3 (
			newPosition.horizontal,
			pieceToMove.transform.position.y,
			newPosition.vertical
		);

		AnimStart (this);


		StartCoroutine ("Move");




	}

	IEnumerator Move()
	{
		yield return new WaitWhile (() => 	pieceToMove.transform.position.x != nav.destination.x &&
											pieceToMove.transform.position.z != nav.destination.y &&
											pieceToMove.transform.position.z != nav.destination.z 
									);

	
		animator.SetBool ("IsWalking", false);

		AnimFinish (this);

	}



}
