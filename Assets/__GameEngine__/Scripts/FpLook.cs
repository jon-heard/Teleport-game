﻿using UnityEngine;
using System.Collections;

public class FpLook : MonoBehaviour
{
	public float Sensitivity = 5.0f;
	public float MaxLookDownAngle = 60.0f;
	public float MinLookUpAngle = 290.0f;
	public Camera Cam;

	private bool _isInLookMode = false;
	private GameState _gameState;
	private Rigidbody _rigidbody;

	public void Start()
	{
		_gameState = GameState.Instance;
		_rigidbody = GetComponent<Rigidbody>();
	}

	public void Update()
	{
		if (_gameState.CurrentInteractionMode == InteractionMode.IN_GAME && !_isInLookMode)
		{
			_isInLookMode = true;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else if (_gameState.CurrentInteractionMode != InteractionMode.IN_GAME && _isInLookMode)
		{
			_isInLookMode = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		else if (_isInLookMode)
		{
			var eulerAngles = transform.transform.eulerAngles;
			eulerAngles.y += Sensitivity * Input.GetAxis("Mouse X");
			_rigidbody.MoveRotation(Quaternion.Euler(eulerAngles));

			eulerAngles = Cam.transform.eulerAngles;
			eulerAngles.x -= Sensitivity * Input.GetAxis("Mouse Y");
			if (eulerAngles.x > 180.0f && eulerAngles.x < MinLookUpAngle)
			{
				eulerAngles.x = MinLookUpAngle;
			}
			if (eulerAngles.x < 180.0f && eulerAngles.x > MaxLookDownAngle)
			{
				eulerAngles.x = MaxLookDownAngle;
			}
			Cam.transform.eulerAngles = eulerAngles;
		}
	}
}
