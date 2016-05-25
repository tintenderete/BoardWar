using UnityEngine;
using System.Collections;
using BoardGameApi;

public class AnimationFactory 
{

	public static void ExecuteAnimation(Action action)
	{
		if (action is Move01) 
		{
			Anim_Move01.Execute (action);
		}
	}

}
