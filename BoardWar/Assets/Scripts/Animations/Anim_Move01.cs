using UnityEngine;
using System.Collections;
using BoardGameApi;

public class Anim_Move01 : Anim
{
	private  PieceManager pieceToMove;
	private  Position newPosition;
	private NavMeshAgent nav;
	private Animator animator;

	public  void Execute(Action action)
	{
		newPosition = action.destinyCells [0].GetBoardPosition();

		pieceToMove = FindOriginPieceManager (action);

		Vector3 newPos = new Vector3 (
			newPosition.horizontal,
			pieceToMove.go.transform.position.y,
			newPosition.vertical
		);

		pieceToMove.go.transform.rotation = Quaternion.LookRotation (newPos - pieceToMove.go.transform.position);


		animator = pieceToMove.go.GetComponent<Animator> ();

		animator.SetBool ("IsWalking", true);

		nav = pieceToMove.go.GetComponent<NavMeshAgent> ();


		nav.destination = new Vector3 (
			newPosition.horizontal,
			pieceToMove.go.transform.position.y,
			newPosition.vertical
		);

		AnimStart (this);


		StartCoroutine ("Move");




	}

	IEnumerator Move()
	{
		yield return new WaitWhile (() => 	pieceToMove.go.transform.position.x != nav.destination.x &&
											pieceToMove.go.transform.position.z != nav.destination.y &&
											pieceToMove.go.transform.position.z != nav.destination.z 
									);

	
		animator.SetBool ("IsWalking", false);

		AnimFinish (this);

	}



}
