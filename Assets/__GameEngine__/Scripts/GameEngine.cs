using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
	public float CursorScale = 3.0f;
	public Vector2 CursorOffset;
	public Texture2D Cursor_Normal;
	public Texture2D Cursor_Usable;
	public Texture2D Cursor_Takeable;
	public Texture2D Cursor_Talkable;
	public Texture2D Cursor_Interacting;
	public Texture2D Cursor_Look;
	public GameObject Tooltip;

	private GameState _gamestate;
	private Text _lookText;
	private RectTransform _lookTextTransform;
	private RectTransform _lookBackgroundTransform;
	private RectTransform _lookOutlineransform;

	// Singleton-ness
	static public GameEngine Instance { get; private set; }
	public void Awake()
	{
		Instance = this;
	}

	public void Start()
	{
		_gamestate = GameState.Instance;
		_lookText = Tooltip.transform.GetChild(0).GetChild(0).GetComponent<Text>();
		_lookTextTransform = _lookText.GetComponent<RectTransform>();
		_lookBackgroundTransform = _lookText.transform.parent.GetComponent<RectTransform>();
		_lookOutlineransform = _lookBackgroundTransform.transform.parent.GetComponent<RectTransform>();
	}

	public void Update()
	{
		// Interaction mode swap
		#if UNITY_EDITOR
			if (Input.GetKeyDown(KeyCode.Backspace))
		#else
			if (Input.GetKeyDown(KeyCode.Escape))
		#endif
		{
			switch (_gamestate.CurrentInteractionMode)
			{
				case InteractionMode.IN_GAME:
					_gamestate.CurrentInteractionMode = InteractionMode.MENU;
					_gamestate.IsLooking = false;
					break;
				case InteractionMode.MENU:
					_gamestate.CurrentInteractionMode = InteractionMode.IN_GAME;
					break;
				default:
					Debug.Log("Invalid game state");
					break;
			}
		}

		// Handle in-game specific features
		if (_gamestate.CurrentInteractionMode == InteractionMode.IN_GAME)
		{
			_gamestate.IsLooking = Input.GetMouseButton(1);

			// Cursor set
			Thing focus = _gamestate.CurrentFocus;
			if (_gamestate.IsLooking)
			{
				_gamestate.CurrentCursor = Cursor_Look;
			}
			else if (focus == null)
			{
				_gamestate.CurrentCursor = Cursor_Normal;
			}
			else
			{
				bool isInteracting = _gamestate.InteractingFocus != null;
				switch (_gamestate.CurrentFocus.Cursor)
				{
					case CursorType.BACKGROUND:
						_gamestate.CurrentCursor = Cursor_Normal;
						break;
					case CursorType.USABLE:
						_gamestate.CurrentCursor =
							!isInteracting ? Cursor_Usable : Cursor_Interacting;
						break;
					case CursorType.TAKEABLE:
						_gamestate.CurrentCursor =
							!isInteracting ? Cursor_Takeable : Cursor_Interacting;
						break;
					case CursorType.TALKABLE:
						_gamestate.CurrentCursor = Cursor_Talkable;
						break;
					default:
						Debug.Log("Invalid type");
						_gamestate.CurrentCursor = Cursor_Normal;
						break;
				}
			}

			// Click handling
			if (focus != null)
			{
				if (Input.GetMouseButtonDown(0))
				{
					_gamestate.InteractingFocus = _gamestate.CurrentFocus;
				}
				if (Input.GetMouseButtonUp(0) && _gamestate.InteractingFocus != null)
				{
					if (InventoryManager.Instance.CurrentItemIndex == InventoryManager.EMPTY_ITEM_INDEX)
					{
						_gamestate.InteractingFocus.OnInteract();
					}
					else
					{
						_gamestate.InteractingFocus.OnInventoryInteract(InventoryManager.Instance.CurrentItem);
					}
					_gamestate.InteractingFocus = null;
				}
				if (_gamestate.InteractingFocus != _gamestate.CurrentFocus)
				{
					_gamestate.InteractingFocus = null;
				}	
			}

			// Look tooltip
			if (_gamestate.IsLooking == true && focus != null && focus.Description != "")
			{
				Tooltip.SetActive(true);
				_lookText.text = focus.Description;
				_lookBackgroundTransform.sizeDelta =
					new Vector2(_lookTextTransform.sizeDelta.x + 10, _lookBackgroundTransform.sizeDelta.y);
				_lookOutlineransform.sizeDelta =
					new Vector2(_lookBackgroundTransform.sizeDelta.x + 5, _lookOutlineransform.sizeDelta.y);
			}
			else
			{
				Tooltip.SetActive(false);
			}
		}
	}

	public void OnGUI()
	{
		// Draw cursor
		if (_gamestate.CurrentInteractionMode == InteractionMode.IN_GAME)
		{
			float cursorSize = 16.0f * CursorScale;
			GUI.DrawTexture(
				new Rect(
					(Screen.width - cursorSize + CursorOffset.x) / 2.0f, (Screen.height - cursorSize + CursorOffset.y) / 2.0f,
					cursorSize, cursorSize),
				_gamestate.CurrentCursor);
		}	
	}

	public void MenuNew()
	{
		Debug.Log("Menu new");
	}

	public void MenuLoad()
	{
		Debug.Log("Menu load");
	}

	public void MenuSave()
	{
		Debug.Log("Menu save");
	}

	public void MenuVolumeUp()
	{
		Debug.Log("Menu volume up");
	}

	public void MenuVolumeDown()
	{
		Debug.Log("Menu volume down");
	}

	public void MenuExit()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
}
