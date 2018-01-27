using UnityEngine;
using System.Collections;

public enum CursorType
{
	BACKGROUND,
	USABLE,
	TAKEABLE,
	TALKABLE
}

public class Thing : MonoBehaviour
{
	public string Description;
	public CursorType Cursor;

	public void OnMouseEnter()
	{
		GameState.Instance.CurrentFocus = this;
	}

	public void OnMouseExit()
	{
		GameState.Instance.CurrentFocus = null;
	}

	public virtual void OnInteract() {}
}
