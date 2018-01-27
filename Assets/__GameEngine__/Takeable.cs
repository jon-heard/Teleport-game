using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takeable : Thing
{
	public override void OnInteract()
	{
		InventoryManager.Instance.AddItem(this);
	}

	public override void OnInventoryInteract(Takeable other)
	{
		InventoryManager.Instance.AddItem(this);
	}
}
