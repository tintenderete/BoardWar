using UnityEngine;
using System.Collections;
using BoardGameApi;
using UnityEditor.Animations;

public class Anim_Attack01 : Anim
{
	private  GameObject attacker;
	private  GameObject receiver;
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
		attacker = FindOriginGameObject (action);
		receiver = FindDestinyGameObject (action);

		attacker.transform.rotation = Quaternion.LookRotation (receiver.transform.position - attacker.transform.position);

		anim = attacker.GetComponent<Animator> ();

		anim.SetTrigger ("Attack01");

		yield return new WaitForSeconds (2);

		AnimFinish (this);



	}
	
}

