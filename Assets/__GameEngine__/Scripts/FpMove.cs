using UnityEngine;
using System.Collections;

public class FpMove : MonoBehaviour
{
	public float MoveSpeed_Walk = 50.0f;
	public float MoveSpeed_Run = 120.0f;
	public float MoveSpeed_Fall = 5.0f;
	public float MoveSpeed_Duck = 2.0f;
	public float JumpForce = 400.0f;
	public float GroundDrag = 0.2f;
	public float GroundDragWhenDucked = 0.1f;
	public GroundedChecker GroundedCheck;
	public bool IsGrounded;

	private Rigidbody _rigidbody;
	private bool _isJumping = false;
	private bool _isDucking = false;

	public void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	public void FixedUpdate()
	{
		if (GroundedCheck.IsGrounded)
		{
			float drag = _isDucking ? GroundDragWhenDucked : GroundDrag;
			var vel = _rigidbody.velocity;
			vel.x *= 1.0f - drag;
			vel.z *= 1.0f - drag;
			_rigidbody.velocity = vel;
		}

		GameState state = GameState.Instance; 
		if (state.CurrentInteractionMode != InteractionMode.IN_GAME)
		{
			return;
		}

		bool spacePressed = Input.GetKey(KeyCode.Space);
		if (!spacePressed)
		{
			_isJumping = false;
		}
		if (GroundedCheck.IsGrounded && _isJumping == false && spacePressed)
		{
			_isJumping = true;
			_rigidbody.AddForce(new Vector3(0, JumpForce, 0));
		}

		Vector2 movement = Vector2.zero;
		if (Input.GetKey(KeyCode.W))
		{
			movement.y += 1.0f;
		}
		if (Input.GetKey(KeyCode.A))
		{
			movement.x -= 1.0f;
		}
		if (Input.GetKey(KeyCode.S))
		{
			movement.y -= 1.0f;
		}
		if (Input.GetKey(KeyCode.D))
		{
			movement.x += 1.0f;
		}
		if (movement.magnitude != 0)
		{
			var speed = MoveSpeed_Walk;
			if (!GroundedCheck.IsGrounded)
			{
				speed = MoveSpeed_Fall;
			}
			else if (_isDucking)
			{
				speed = MoveSpeed_Duck;
			}
			else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				speed = MoveSpeed_Run;
			}

			movement = movement.normalized * speed;
			_rigidbody.AddRelativeForce(new Vector3(movement.x, 0, movement.y));
		}

		if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
		{
			_isDucking = true;
			Vector3 scale = transform.localScale;
			scale.y = 1;
			transform.localScale = scale;
		}
		else
		{
			_isDucking = false;
			Vector3 scale = transform.localScale;
			scale.y = 2;
			transform.localScale = scale;
		}
	}
}
