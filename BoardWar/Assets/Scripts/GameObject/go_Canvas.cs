using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class go_Canvas : MonoBehaviour 
{
	GameObject skillsMenu;
	Text manaText;

	// Use this for initialization
	void Start () 
	{
		skillsMenu = GameObject.Find ("SkillsMenu");
		skillsMenu.SetActive (false);
		manaText = GameObject.Find ("Mana").transform.FindChild("Text").gameObject.GetComponent<Text>();
	}

	public void SkillsMenuOn()
	{
		if(!skillsMenu.activeInHierarchy)
			skillsMenu.SetActive (true);
	}

	public void SkillsMenuOff()
	{
		if (skillsMenu.activeInHierarchy)
			skillsMenu.SetActive (false);
	}

	public void ResetManaText()
	{
		manaText.text = "10 / 10";
	}

	public void SetManaText(float newMana)
	{
		manaText.text = newMana + " / 10";
	}

}
