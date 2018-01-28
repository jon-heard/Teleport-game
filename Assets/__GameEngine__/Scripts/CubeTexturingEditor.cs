using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CubeTexturing))]
public class CubeTexturingEditor : Editor
{
	public override void OnInspectorGUI()
	{
		CubeTexturing toEdit = (CubeTexturing)target;
		if (GUILayout.Button("Toggle Texture Placer"))
		{
			CubeTexturingEditorWindow.ToggleWindow(toEdit);
		}
		DrawDefaultInspector();
	}
}
