using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MergeToStay.MonoBehaviours.Combat
{
	[RequireComponent(typeof(DragOnHandler))]
	[RequireComponent(typeof(Image))]
	public class CellView : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
	{
		public event Action<CellView> OnSelected;
		public event Action<CellView> OnStartDrag;
		public event Action<CellView> OnEndDrag;


		public Vector2 Position = new Vector2(0, 0);
		public bool IsBeingDragged = false;
		
		public void OnPointerClick(PointerEventData eventData)
		{
			// Debug.Log("was touched " + gameObject.name);
			OnSelected?.Invoke(this);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			IsBeingDragged = true;
			// Debug.Log("was start drag " + gameObject.name);
			OnStartDrag?.Invoke(this);
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			IsBeingDragged = false;
			// Debug.Log("was end drag " + gameObject.name);
			OnEndDrag?.Invoke(this);
		}

		public void SetPosition(Vector2 position) { Position = position; }
	}
}