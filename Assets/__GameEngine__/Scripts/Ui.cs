using UnityEngine;
using System.Collections;

public class Ui : MonoBehaviour
{
	void Start()
	{
		_gameState = GameState.Instance;
		_menu = transform.Find("Menu").gameObject;
		_inventory = transform.Find("Inventory").gameObject;
	}

	void Update()
	{
		_menu.SetActive(_gameState.CurrentInteractionMode == InteractionMode.MENU);
		_inventory.SetActive(_gameState.CurrentInteractionMode == InteractionMode.IN_GAME);
	}

	// Private members
	private GameState _gameState;
	private GameObject _menu;
	private GameObject _inventory;
}
