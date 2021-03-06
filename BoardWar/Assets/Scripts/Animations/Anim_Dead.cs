﻿using UnityEngine;
using System.Collections;
using BoardGameApi;

public class Anim_Dead : Anim 
{
	PieceManager piece;
	private  Animator anim;

	public void Execute(Action _action )
	{
		piece = FindOriginPieceManager (_action);
		piece.go.transform.GetChild (0).gameObject.GetComponent<CapsuleCollider> ().enabled = false;

		AnimStart (this);
		StartCoroutine ("Dead");
	}

	IEnumerator Dead()
	{
		
		anim = piece.go.GetComponent<Animator> ();

		anim.SetTrigger ("IsDead");

		float time = anim.GetCurrentAnimatorStateInfo (0).length + 1f;

		if (time > 2.5f) 
		{
			time = 2.5f;
		}

		yield return new WaitForSeconds (time);

		piece.go.SetActive (false);

		yield return new WaitForSeconds (0.5f);

		AnimFinish (this);



	}
}

