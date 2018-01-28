using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeTexturing : MonoBehaviour
{
	public Vector2 FrontUpper_Left = new Vector2(0.0f, 0.0f);
	public Vector2 FrontLower_Right = new Vector2(1.0f, 1.0f);
	public Vector2 BackUpper_Left = new Vector2(0.0f, 0.0f);
	public Vector2 BackLower_Right = new Vector2(1.0f, 1.0f);
	public Vector2 LeftUpper_Left = new Vector2(0.0f, 0.0f);
	public Vector2 LeftLower_Right = new Vector2(1.0f, 1.0f);
	public Vector2 RightUpper_Left = new Vector2(0.0f, 0.0f);
	public Vector2 RightLower_Right = new Vector2(1.0f, 1.0f);
	public Vector2 TopUpper_Left = new Vector2(0.0f, 0.0f);
	public Vector2 TopLower_Right = new Vector2(1.0f, 1.0f);
	public Vector2 BottomUpper_Left = new Vector2(0.0f, 0.0f);
	public Vector2 BottomLower_Right = new Vector2(1.0f, 1.0f);

	public void Start()
	{
		RefreshTexturing();
	}

	public void Update()
	{
		if (CubeTexturingEditorWindow.ToEdit == this)
		{
			RefreshTexturing();
		}
	}

	public void RefreshTexturing()
	{
		MeshFilter meshFilter = GetComponent<MeshFilter>();
		if (meshFilter == null)
		{
			Debug.Log("Error: No mesh filter found");
			return;
		}

		Mesh mesh = meshFilter.sharedMesh;
		if (mesh == null || mesh.uv.Length != 24)
		{
			Debug.Log("Error: Mesh with rectangular uv's not found");
			return;
		}

		Vector2[] uvs = mesh.uv;

		// Front
		uvs[0]  = new Vector2(FrontUpper_Left.x, 1.0f-FrontLower_Right.y);
		uvs[1]  = new Vector2(FrontLower_Right.x, 1.0f-FrontLower_Right.y);
		uvs[2]  = new Vector2(FrontUpper_Left.x, 1.0f-FrontUpper_Left.y);
		uvs[3]  = new Vector2(FrontLower_Right.x, 1.0f-FrontUpper_Left.y);

		// Back
		uvs[10] = new Vector2(BackLower_Right.x, 1.0f-BackUpper_Left.y);
		uvs[11] = new Vector2(BackUpper_Left.x, 1.0f-BackUpper_Left.y);
		uvs[6]  = new Vector2(BackLower_Right.x, 1.0f-BackLower_Right.y);
		uvs[7]  = new Vector2(BackUpper_Left.x, 1.0f-BackLower_Right.y);

		// Left
		uvs[16] = new Vector2(LeftUpper_Left.x, 1.0f-LeftLower_Right.y);
		uvs[18] = new Vector2(LeftLower_Right.x, 1.0f-LeftUpper_Left.y);
		uvs[19] = new Vector2(LeftLower_Right.x, 1.0f-LeftLower_Right.y);
		uvs[17] = new Vector2(LeftUpper_Left.x, 1.0f-LeftUpper_Left.y);

		// Right
		uvs[20] = new Vector2(RightUpper_Left.x, 1.0f-RightLower_Right.y);
		uvs[22] = new Vector2(RightLower_Right.x, 1.0f-RightUpper_Left.y);
		uvs[23] = new Vector2(RightLower_Right.x, 1.0f-RightLower_Right.y);
		uvs[21] = new Vector2(RightUpper_Left.x, 1.0f-RightUpper_Left.y);    

		// Top
		uvs[8]  = new Vector2(TopUpper_Left.x, 1.0f-TopLower_Right.y);
		uvs[9]  = new Vector2(TopLower_Right.x, 1.0f-TopLower_Right.y);
		uvs[4]  = new Vector2(TopUpper_Left.x, 1.0f-TopUpper_Left.y);
		uvs[5]  = new Vector2(TopLower_Right.x, 1.0f-TopUpper_Left.y);

		// Bottom
		uvs[12] = new Vector2(BottomUpper_Left.x, 1.0f-BottomLower_Right.y);
		uvs[14] = new Vector2(BottomLower_Right.x, 1.0f-BottomUpper_Left.y);
		uvs[15] = new Vector2(BottomLower_Right.x, 1.0f-BottomLower_Right.y);
		uvs[13] = new Vector2(BottomUpper_Left.x, 1.0f-BottomUpper_Left.y);                

		mesh.uv = uvs;
	}
}
