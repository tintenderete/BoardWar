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


	public bool Execute(Action _action )
	{
		//newPosition = action.destinyCells [0].GetBoardPosition();

		action = _action;

		if (!working) 
		{
			AnimStart ();
			StartCoroutine ("Attack");
		}


		return working;
	}

	IEnumerator Attack()
	{
		Debug.Log ("Start");


		attacker = FindOriginGameObject (action);
		receiver = FindDestinyGameObject (action);

		attacker.transform.rotation = Quaternion.LookRotation (receiver.transform.position - attacker.transform.position);

		anim = attacker.GetComponent<Animator> ();

		anim.SetTrigger ("Attack01");

		yield return new WaitForSeconds (2);
		AnimFinish ();
		Debug.Log ("End");

		//StopCoroutine ("Attack");
		//yield return null;


	}
	
}

