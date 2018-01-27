using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
	public int Volume = 100;

	public void Update()
	{
		float internalVolume = Volume / 100.0f;
		if (AudioListener.volume != internalVolume)
		{
			AudioListener.volume = internalVolume;
		}
	}

	public void VolumeUp()
	{
		Volume = Mathf.Min(Volume + 10, 100);
	}

	public void VolumeDown()
	{
		Volume = Mathf.Max(Volume - 10, 0);
	}
}
