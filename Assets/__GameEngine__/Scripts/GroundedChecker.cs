using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundedChecker : MonoBehaviour
{
	public bool IsGrounded = false;

	// Can be standing on multiple colliders.  Need to keep track of all standing colliders and only
	// have IsGrounded==false if they are ALL removed from collision
	private HashSet<Collider> _collidingWith = new HashSet<Collider>();

	public void OnTriggerEnter(Collider c)
	{
		_collidingWith.Add(c);
		IsGrounded = true;
	}

	public void OnTriggerExit(Collider c)
	{
		_collidingWith.Remove(c);
		IsGrounded = (_collidingWith.Count != 0);
	}
}
