using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum InteractionMode
{
	MENU,
//	NARRATION,
	IN_GAME
}

public class GameState : MonoBehaviour
{
	[HideInInspector]
	public InteractionMode CurrentInteractionMode = InteractionMode.IN_GAME;
	[HideInInspector]
	public Thing CurrentFocus;
	[HideInInspector]
	public Texture2D CurrentCursor;
	[HideInInspector]
	public bool IsLooking;
	[HideInInspector]
	public Thing InteractingFocus;
	[HideInInspector]
	public List<string> Narration;
	[HideInInspector]
	public uint NarrationIndex;

	// Singleton-ness
	static public GameState Instance { get; private set; }

	public void Awake()
	{
		Instance = this;
	}

}
