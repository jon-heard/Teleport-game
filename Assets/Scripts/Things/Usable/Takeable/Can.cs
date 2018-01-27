using UnityEngine;
using System.Collections;

public class Can : Thing
{
	public AudioClip Hit;
	private AudioSource _audio;

	public void Start()
	{
		_audio = GetComponent<AudioSource>();
	}

	public void OnHit()
	{
		_audio.PlayOneShot(Hit);
	}

	void OnCollisionEnter(Collision collision)
	{
		_audio.PlayOneShot(Hit, collision.relativeVelocity.magnitude / 16.0f);
	}
}
