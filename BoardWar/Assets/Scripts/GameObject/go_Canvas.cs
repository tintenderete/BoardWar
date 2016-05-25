using UnityEngine;
using System.Collections;

public class go_Canvas : MonoBehaviour 
{
	GameObject skillsMenu;

	// Use this for initialization
	void Start () 
	{
		skillsMenu = GameObject.Find ("SkillsMenu");
		skillsMenu.SetActive (false);
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
}
