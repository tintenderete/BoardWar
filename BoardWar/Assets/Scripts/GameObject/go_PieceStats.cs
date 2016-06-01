using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BoardGameApi;

public class go_PieceStats : MonoBehaviour 
{
	GameObject panel;
	Text health;
	GameObject skill1;
	GameObject move;
	GameObject skill2;

	void Start()
	{
		panel = gameObject.transform.Find ("Panel").gameObject;
		health = panel.transform.Find ("Health").gameObject.GetComponent<Text>();
		skill1 = panel.transform.Find ("Skill1").gameObject;
		move = panel.transform.Find ("Move").gameObject;
		skill2 = panel.transform.Find ("Skill2").gameObject;
	}


	public void SetStats(Piece piece)
	{
		if (piece.GetSkills () == null || piece.GetSkills ().Count == 0) 
		{
			return;
		}

		health.text = "Health: " + piece.GetCurrentHealth () + " /" + piece.GetMaxHealth ();

		if (piece.GetSkills () [0] != null) 
		{
			skill1.transform.Find ("Name").GetComponent<Text> ().text = "Skill1: " + piece.GetSkills () [0].name;
			skill1.transform.Find ("Power").GetComponent<Text> ().text = "Power: " + piece.GetSkills () [0].power;
			skill1.transform.Find ("Range").GetComponent<Text> ().text =	"Range: " + piece.GetSkills () [0].range;
			skill1.transform.Find ("Cost").GetComponent<Text> ().text = "Cost:" + piece.GetSkills () [0].cost;
		}
		if (piece.GetSkills () [1] != null) 
		{
			move.transform.Find ("Name").GetComponent<Text> ().text = "Skill2: " + piece.GetSkills () [1].name;
			move.transform.Find ("Power").GetComponent<Text> ().text = "Power: " + piece.GetSkills () [1].power;
			move.transform.Find ("Range").GetComponent<Text> ().text =	"Range: " + piece.GetSkills () [1].range;
			move.transform.Find ("Cost").GetComponent<Text> ().text = "Cost:" + piece.GetSkills () [1].cost;
		}
		if (piece.GetSkills () [2] != null) 
		{
			skill2.transform.Find ("Name").GetComponent<Text> ().text = "Skill3: " + piece.GetSkills () [2].name;
			skill2.transform.Find ("Power").GetComponent<Text> ().text = "Power: " + piece.GetSkills () [2].power;
			skill2.transform.Find ("Range").GetComponent<Text> ().text =	"Range: " + piece.GetSkills () [2].range;
			skill2.transform.Find ("Cost").GetComponent<Text> ().text = "Cost:" + piece.GetSkills () [2].cost;
		}
	}

	public void SetActive(bool _bool)
	{
		panel.SetActive (_bool);
	}
}
