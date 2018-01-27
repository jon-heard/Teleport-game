using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
	public const uint EMPTY_ITEM_INDEX = 11;

	public List<Takeable> Items;
	public GameObject Ui;
	public Transform InventorySpot;
	public Color UiUnselected = new Color(1.0f, 1.0f, 1.0f, 0.5f);
	public Color UiSelected = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	public uint CurrentItemIndex = EMPTY_ITEM_INDEX;

	public Takeable CurrentItem
	{
		get
		{
			if (CurrentItemIndex == EMPTY_ITEM_INDEX)
			{
				return null;
			}
			else
			{
				return Items[(int)CurrentItemIndex];
			}
		}
	}

	private RawImage[] _uiItems = new RawImage[10];

	// Singleton-ness
	static public InventoryManager Instance { get; private set; }
	public void Awake()
	{
		Instance = this;
	}

	public void Start()
	{
		for (int i = 0; i < 10; ++i)
		{
			_uiItems[i] = Ui.transform.GetChild(i).GetComponent<RawImage>();
			_uiItems[i].color = UiUnselected;
		}
	}

	public bool AddItem(Takeable item)
	{
		if (Items.Count >= 10)
		{
			return false;
		}
		else
		{
			Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();
			if (itemRigidbody) { itemRigidbody.isKinematic = true; }
			Collider itemCollider = item.GetComponent<Collider>();
			if (itemCollider) { itemCollider.enabled = false; }
			MeshRenderer renderer = item.GetComponent<MeshRenderer>();
			if (renderer) { renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off; }
			item.transform.parent = InventorySpot;
			item.transform.localPosition = Vector3.zero;
			item.transform.localRotation = Quaternion.identity;

			uint index = (uint)Items.Count;
			Items.Add(item);
			item.gameObject.SetActive(false);
			_uiItems[index].gameObject.SetActive(true);
			SetCurrentItem(index);
			return true;
		}
	}

	public void SetCurrentItem(uint index)
	{
		if (CurrentItemIndex != index)
		{
			if (index != EMPTY_ITEM_INDEX && index >= Items.Count)
			{
				SetCurrentItem(EMPTY_ITEM_INDEX);
			}
			else
			{
				// Disable old item
				if (CurrentItemIndex != EMPTY_ITEM_INDEX)
				{
					_uiItems[CurrentItemIndex].color = UiUnselected;
					Items[(int)CurrentItemIndex].gameObject.SetActive(false);
				}

				CurrentItemIndex = index;

				// Enable new item
				if (CurrentItemIndex != EMPTY_ITEM_INDEX)
				{
					_uiItems[CurrentItemIndex].color = UiSelected;
					Items[(int)CurrentItemIndex].gameObject.SetActive(true);
				}
			}
		}
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.BackQuote)) { SetCurrentItem(EMPTY_ITEM_INDEX); }
		if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0)) { SetCurrentItem(10); }
		if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) { SetCurrentItem(0); }
		if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) { SetCurrentItem(1); }
		if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) { SetCurrentItem(2); }
		if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) { SetCurrentItem(3); }
		if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) { SetCurrentItem(4); }
		if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6)) { SetCurrentItem(5); }
		if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7)) { SetCurrentItem(6); }
		if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8)) { SetCurrentItem(7); }
		if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9)) { SetCurrentItem(8); }
	}
}
