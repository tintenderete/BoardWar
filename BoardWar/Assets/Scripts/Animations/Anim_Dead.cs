using UnityEngine;
using System.Collections;
using BoardGameApi;

public class Anim_Dead : Anim 
{
	GameObject go;
	private  Animator anim;

	public void Execute(Action _action )
	{
		go = FindOriginGameObject (_action);
		go.transform.GetChild (0).gameObject.GetComponent<CapsuleCollider> ().enabled = false;

		AnimStart (this);
		StartCoroutine ("Dead");

	}

	IEnumerator Dead()
	{
		
		anim = go.GetComponent<Animator> ();

		anim.SetTrigger ("IsDead");

		yield return new WaitForSeconds (anim.GetCurrentAnimatorStateInfo(0).length + 1f);

		go.SetActive (false);

		AnimFinish (this);



	}
}
