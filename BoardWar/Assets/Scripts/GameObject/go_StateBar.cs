using UnityEngine;
using System.Collections;
using BoardGameApi;

public class go_StateBar : MonoBehaviour 
{
	GameObject maxHealth;
	GameObject currentHealth;
	float scale_maxHealth;
	float piece_maxHealth;
	float piece_currentHealth;
	Piece piece;

	void Start()
	{
		//scale_currentHealth = gameObject.transform.localScale.x;
		maxHealth = gameObject.transform.FindChild ("Health").FindChild ("MaxHealth").gameObject;
		currentHealth = gameObject.transform.FindChild ("Health").FindChild ("CurrentHealth").gameObject;
		piece = gameObject.transform.parent.FindChild("Body").gameObject.GetComponent<go_Piece>().GetPiece();

		scale_maxHealth = maxHealth.transform.localScale.x;
		piece_maxHealth = piece.GetMaxHealth ();
		piece_currentHealth = piece.GetCurrentHealth ();

		SetColorBar ();
	}

	void LateUpdate()
	{
		LookCamera ();
	}


	public void SetCurrentHealth(Action action)
	{
		piece_currentHealth = piece_currentHealth - action.power;

		float newHealthBar = (piece_currentHealth * scale_maxHealth) / piece_maxHealth;

		currentHealth.transform.localScale = new Vector3( 
			newHealthBar,
			currentHealth.transform.localScale.y,
			currentHealth.transform.localScale.z
		);

		if (currentHealth.transform.localScale.x < 0) 
		{
			currentHealth.transform.localScale = new Vector3( 
				0,
				currentHealth.transform.localScale.y,
				90
			);
		}
	}

	private void SetColorBar()
	{
		if (piece.GetColor () == (int)Piece.colors.Blue) 
		{
			SetMaterial ("Blue");
		} 
		else 
		{
			SetMaterial ("Red");
		}

	}

	private void SetMaterial(string name)
	{
		Material material = Resources.Load(name) as Material;
		maxHealth.GetComponent<MeshRenderer> ().material = material;
	}

	private void LookCamera()
	{
		Vector3 direction = new Vector3 (
								-1,
			                    0,
			                    0
		);

		gameObject.transform.rotation = Quaternion.LookRotation (direction);
		
	}
}
