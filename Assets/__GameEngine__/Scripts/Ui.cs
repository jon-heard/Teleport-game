using UnityEngine;
using System.Collections;

public class Ui : MonoBehaviour
{
	void Start()
	{
		_gameState = GameState.Instance;
		_menu = transform.Find("Menu").gameObject;
	}

	void Update()
	{
		_menu.SetActive(_gameState.CurrentInteractionMode == InteractionMode.MENU);
	}

	// Private members
	private GameState _gameState;
	private GameObject _menu;
}
