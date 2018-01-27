using UnityEngine;
using System.Collections;

public class ParticleLife : MonoBehaviour
{
	private ParticleSystem _particleSystem;

	void Start()
	{
		_particleSystem = GetComponent<ParticleSystem>();
	}

	void Update()
	{
		if (!_particleSystem.IsAlive())
		{
			Destroy(gameObject);
		}
	}
}
