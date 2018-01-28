using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CubeTexturingEditorWindow : EditorWindow
{
	public static CubeTexturing ToEdit;

	private const uint IMAGE_VERTICAL_OFFSET = 25;

	public static void ToggleWindow(CubeTexturing toEdit)
	{
		if (ToEdit != null)
		{
			HideWindow();
		}
		else
		{
			ShowWindow(toEdit);
		}
	}

	public static void ShowWindow(CubeTexturing toEdit)
	{
		CubeTexturingEditorWindow window = GetCubeTextureWindow();
		ToEdit = toEdit;
		window.Show();
	}

	public static void HideWindow()
	{
		CubeTexturingEditorWindow window = GetCubeTextureWindow();
		ToEdit = null;
		window.Close();
	}

	private static CubeTexturingEditorWindow GetCubeTextureWindow()
	{
		return (CubeTexturingEditorWindow)GetWindow(typeof(CubeTexturingEditorWindow));
	}

	private int _side;
	private float _zoom = 256.0f;
	private Vector2 _offset;
	private Vector2 _dragStart;

	public void OnGUI()
	{
		GUILayout.BeginHorizontal();

		// Zoomable image
		Texture texture = ToEdit.GetComponent<MeshRenderer>().sharedMaterial.mainTexture;
		GUI.DrawTexture(new Rect(_offset.x, _offset.y + IMAGE_VERTICAL_OFFSET, _zoom, _zoom), texture);

		// Selection: side
		string[] sideOptions = new string[]
		{
			"Front", "Back", "Left", "Right", "Top", "Bottom" 
		};
		_side = EditorGUILayout.Popup("Side", _side, sideOptions);

		// Zoom
		if (GUILayout.Button("-"))
		{
			Debug.Log(_zoom);
			_zoom /= 2;
			_zoom = Mathf.Max(_zoom, 8);
		}
		if (GUILayout.Button("+"))
		{
			Debug.Log(_zoom);
			_zoom *= 2;
		}

		GUILayout.EndHorizontal();

		var evt = Event.current;

		// Drag image
		if (evt.button == 0)
		{
			if (evt.type == EventType.MouseDown)
			{
				_dragStart = evt.mousePosition;
			}
			if (evt.type == EventType.MouseDrag)
			{
				_offset += evt.mousePosition - _dragStart;
				_dragStart = evt.mousePosition;
				Repaint();
			}
		}
		
		// Select area
		if (evt.button == 1)
		{
			if (evt.type == EventType.MouseDown)
			{
				Vector2 pos = (evt.mousePosition - _offset - new Vector2(0, IMAGE_VERTICAL_OFFSET)) / _zoom;
				switch (_side)
				{
					case 0:
						ToEdit.FrontUpper_Left = pos;
						break;
					case 1:
						ToEdit.BackUpper_Left = pos;
						break;
					case 2:
						ToEdit.LeftUpper_Left = pos;
						break;
					case 3:
						ToEdit.RightUpper_Left = pos;
						break;
					case 4:
						ToEdit.TopUpper_Left = pos;
						break;
					case 5:
						ToEdit.BottomUpper_Left = pos;
						break;
				}
			}
			if (evt.type == EventType.MouseUp)
			{
				Vector2 pos = (evt.mousePosition - _offset - new Vector2(0, IMAGE_VERTICAL_OFFSET)) / _zoom;
				switch (_side)
				{
					case 0:
						ToEdit.FrontLower_Right = pos;
						break;
					case 1:
						ToEdit.BackLower_Right = pos;
						break;
					case 2:
						ToEdit.LeftLower_Right = pos;
						break;
					case 3:
						ToEdit.RightLower_Right = pos;
						break;
					case 4:
						ToEdit.TopLower_Right = pos;
						break;
					case 5:
						ToEdit.BottomLower_Right = pos;
						break;
				}
			}
		}		
	}
}
