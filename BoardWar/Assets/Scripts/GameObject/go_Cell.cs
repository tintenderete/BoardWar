using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class go_Cell : MonoBehaviour 
{
	Cell cell;
	PlayerInputs inputs;

	void Start()
	{
		inputs = ScriptableObject.CreateInstance<PlayerInputs> ();
	}

	public void SetScript( Cell cell)
	{
		this.cell = cell;
	}


	void OnMouseDown()
	{
		if (Anim.IsWorking ())
			return;

		inputs.SetActor_Where (cell);
	}


}
