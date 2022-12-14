using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MergeToStay.MonoBehaviours.Combat
{
	public class DragOnHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		public event Action<DragOnHandler> OnEnterDrag;
		public event Action<DragOnHandler> OnExitDrag;
		
		public bool IsDraggedOn = false;
		
		public void OnPointerEnter(PointerEventData eventData)
		{
			IsDraggedOn = true;
			// Debug.Log("was enter moved " + gameObject.name);
			OnEnterDrag?.Invoke(this);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			IsDraggedOn = false;
			// Debug.Log("was exit moved " + gameObject.name);
			OnExitDrag?.Invoke(this);
		}
	}
}