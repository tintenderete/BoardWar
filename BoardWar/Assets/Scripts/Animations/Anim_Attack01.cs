using UnityEngine;
using System.Collections;
using BoardGameApi;
using UnityEditor.Animations;

public class Anim_Attack01 : Anim
{
	private  PieceManager attacker;
	private  PieceManager receiver;
	private  Animator anim;
	private  Action action;


	public void Execute(Action _action )
	{
		//newPosition = action.destinyCells [0].GetBoardPosition();

		action = _action;


		AnimStart (this);
		StartCoroutine ("Attack");



	}

	IEnumerator Attack()
	{
		attacker = FindOriginPieceManager (action);
		receiver = FindDestinyPieceManager (action);

		attacker.transform.rotation = Quaternion.LookRotation (receiver.transform.position - attacker.transform.position);

		anim = attacker.go.GetComponent<Animator> ();

		anim.SetTrigger ("Attack01");

		yield return new WaitForSeconds (2);

		receiver.stateBar.SetCurrentHealth (action);

		AnimFinish (this);



	}
	
}

