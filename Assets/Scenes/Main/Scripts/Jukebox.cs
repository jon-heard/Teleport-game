using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : Thing
{
	public Takeable Key;
	public bool Locked = true;

	public override void OnInteract()
	{
		if (Locked)
		{
			Debug.Log("Hmmm.  It's locked.");
		}
		else
		{
			Debug.Log("It's unlocked but it's not turning on.");
		}
	}

	public override void OnInventoryInteract(Takeable other)
	{
		if (other == Key)
		{
			Debug.Log("Yay!  The key worked");
			Locked = !Locked;
		}
		else
		{
			if (Locked)
			{
				Debug.Log("I can't unlock the jukebox with this.");
			}
			else
			{
				Debug.Log("I'm not sure how to use these things together.");
			}
		}
	}
}
