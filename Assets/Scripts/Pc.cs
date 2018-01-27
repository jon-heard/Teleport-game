using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Pc : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Usable[] Inventory;

	public float BulletForce = 30.0f;
	public GameObject BulletFlash;
	public AudioClip Cock;
	public AudioClip Shot;

	public Texture2D CrosshairTexture = null;
	public float CrosshairScale = 3;

//	private AudioSource _audio;
	private Camera _cam;
	private bool _cocked;

	public Usable CurrentUsable
	{
		get { return _currentUsable; }
		set
		{
			_currentUsable = value;
			Cursor.SetCursor(_currentUsable.cursor, new Vector2(7, 7), CursorMode.ForceSoftware);
		}
	}
	private Usable _currentUsable;

	public void Start()
	{
		// Get audio source
//		_audio = GetComponent<AudioSource>();
		// Get camera
		for (int i = 0; i < transform.childCount; ++i)
		{
			var childCam = transform.GetChild(i).GetComponent<Camera>();
			if (childCam != null)
			{
				_cam = childCam;
				break;
			}
		}
		if (_cam == null)
		{
			Debug.Log("Pc: Error: No Camera Found!");
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#endif
		}
	}

	public void Update()
	{
		if (CurrentUsable != null)
		{
			CurrentUsable.Update();
		}
	//	GameState state = GameState.Instance; 

	//	if (state.CurrentInteractionMode == GameState.InteractionMode.EXTERNAL)
	//	{
	//		if (Input.GetMouseButtonDown(0))
	//		{
	//			_audio.PlayOneShot(Cock);
	//			_cocked = true;
	//		}
	//		if (Input.GetMouseButtonUp(0))
	//		{
	//			_cocked = false;
	//			if (!_audio.isPlaying)
	//			{
	//				_audio.PlayOneShot(Shot);
	//				RaycastHit hit;
	//				Ray ray = _cam.ScreenPointToRay(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f));
	//				if (Physics.Raycast(ray, out hit))
	//				{
	//					Instantiate(BulletFlash, hit.point, Quaternion.identity);
	//					Can can = hit.collider.GetComponent<Can>();
	//					if (can != null)
	//					{
	//						can.OnHit();
	//						hit.rigidbody.AddExplosionForce(BulletForce, hit.point, 1.0f);
	//					}
	//				}
	//			}
	//		}
	//	}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("Mouse enter");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("Mouse exit");
	}

	//public void OnGUI()
	//{
	//	if (_cocked && !_audio.isPlaying)
	//	{
	//		GUI.DrawTexture(
	//			new Rect(
	//				(Screen.width - CrosshairTexture.width * CrosshairScale) / 2,
	//				(Screen.height - CrosshairTexture.height * CrosshairScale) / 2,
	//				CrosshairTexture.width * CrosshairScale,
	//				CrosshairTexture.height * CrosshairScale),
	//			CrosshairTexture);
	//	}
	//}
}
