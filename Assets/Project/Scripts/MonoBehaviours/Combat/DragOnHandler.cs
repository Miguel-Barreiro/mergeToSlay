using System;
using MergeToSlay.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MergeToSlay.MonoBehaviours.Combat
{
	public class DragOnHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		public event Action<DragOnHandler> OnEnterDrag;
		public event Action<DragOnHandler> OnExitDrag;
		
		public bool IsDraggedOn = false;
		
		public void OnPointerEnter(PointerEventData eventData)
		{
			IsDraggedOn = true;
			// Log.Normal("was enter moved " + gameObject.name);
			OnEnterDrag?.Invoke(this);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			IsDraggedOn = false;
			// Log.Normal("was exit moved " + gameObject.name);
			OnExitDrag?.Invoke(this);
		}
	}
}