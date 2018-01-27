using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : Thing
{
	public Thing[] ToTrigger;
	
	public override void OnInteract()
	{
		foreach (Thing ToTriggerItem in ToTrigger)
		{
			ToTriggerItem.OnTrigger(this);
		}
	}
}
