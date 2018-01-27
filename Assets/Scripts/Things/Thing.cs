using UnityEngine;
using System.Collections;

public class Thing : MonoBehaviour//, IPointerEnterHandler
{
	public string description;

	public void OnMouseEnter()
	{
		Debug.Log(":: " + description);
	}

	public void OnMouseExit()
	{
		Debug.Log("// " + description);
	}

    // public void OnPointerEnter(PointerEventData eventData)
    // {
	// 	Debug.Log("** " + description);
    // }

    // public void OnPointerExit(PointerEventData eventData)
    // {
	// 	Debug.Log("++ " + description);
    // }
}
