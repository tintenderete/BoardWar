using UnityEngine;
using System.Collections;
using BoardGameApi;

public class AnimationFactory 
{
	static Anim_Attack01 attack01;
	static Anim_Move01 movek01;

	public static bool ExecuteAnimation(Action action)
	{
		if (action is Move01) 
		{
			if (movek01 == null) 
			{
				GameObject go = new GameObject ();
				movek01 =  go.AddComponent<Anim_Move01> ();
			}

			return movek01.Execute (action);
		}

		if (action is Attack01) 
		{
			if (attack01 == null) 
			{
				GameObject go = new GameObject ();
				attack01 =  go.AddComponent<Anim_Attack01> ();
			}

			return attack01.Execute (action);
		}

		return false;
	}

}
