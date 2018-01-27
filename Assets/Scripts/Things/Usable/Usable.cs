using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Usable : Thing
{
	public Texture2D cursor;

	private Button _button = null;

	public void CopyFrom(Usable other)
	{
		this.description = other.description;
		this.cursor = other.cursor;
	}

	public virtual void Init(GameObject gameObject)
	{
		if (_button != null)
		{
			_button.onClick.RemoveListener(OnClick);
		}
		_button = gameObject.GetComponent<Button>();
		if (_button != null)
		{
			_button.onClick.AddListener(OnClick);
		}
	}

	public void OnClick()
	{
		GameState.Instance.CurrentPc.CurrentUsable = this;
	}

	public virtual void Update()
	{

	}
}
