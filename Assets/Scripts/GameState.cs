using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour
{
	public enum InteractionMode
	{
		INTERNAL,
		EXTERNAL
	}

	static public GameState Instance { get; private set; }

	public InteractionMode CurrentInteractionMode = InteractionMode.INTERNAL;
	public Pc CurrentPc;

	public void Awake()
	{
		Instance = this;
	}

	public void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			switch (CurrentInteractionMode)
			{
				case InteractionMode.EXTERNAL:
					CurrentInteractionMode = InteractionMode.INTERNAL;
					break;
				case InteractionMode.INTERNAL:
					CurrentInteractionMode = InteractionMode.EXTERNAL;
					break;
				default:
					CurrentInteractionMode = InteractionMode.INTERNAL;
					break;
			}
		}
	}
}
