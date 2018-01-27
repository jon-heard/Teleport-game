using UnityEngine;
using System.Collections;

public class Ui : MonoBehaviour
{

	private GameState _gameState;
	private Canvas _internal;

	void Start ()
	{
		_gameState = GameState.Instance;
		_internal = transform.Find("Internal").GetComponent<Canvas>();
	}
	
	void Update ()
	{
		_internal.enabled = _gameState.CurrentInteractionMode == GameState.InteractionMode.INTERNAL;
	}
}
