#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MergeToStay.Packages.TP.Readme.Runtime
{
	[Serializable]
	public class TextAreaObjectField
	{
		private static Color textBoxBackgroundColor;
		private static readonly Color selectedColor = new Color(0f / 255, 130f / 255, 255f / 255, .6f);
		[SerializeField] private string name;
		[SerializeField] private int objectId;
		[SerializeField] private Object objectRef;
		[SerializeField] private Rect fieldRect;
		[SerializeField] private int index;
		[SerializeField] private int length;

		private Action<TextAreaObjectField> OnChange;

		public TextAreaObjectField(Rect fieldRect, int objectId, int index, int length, Action<TextAreaObjectField> onChangeCallback)
		{
			this.fieldRect = fieldRect;
			this.index = index;
			this.length = length;

			ObjectId = objectId;
			ObjectRef = GetObjectFromId();

			name = (ObjectRef ? ObjectRef.name : "null") + " (" + ObjectId + ")";

			OnChange = onChangeCallback;
		}

		public bool IdInSync { get { return (ObjectId == 0 && ObjectRef == null) || GetObjectFromId(false) == ObjectRef; } }

		public int ObjectId { get { return objectId; } private set { objectId = value; } }

		public Object ObjectRef { get { return objectRef; } private set { objectRef = value; } }

		public Rect FieldRect { get { return fieldRect; } }

		public int Index { get { return index; } }

		public int IdIndex
		{
			get { return index + 4; } // +4 for the characters <o="
		}

		public int GetIdFromObject() { return ReadmeManager.GetIdFromObject(ObjectRef); }

		public Object GetObjectFromId(bool autoSync = true) { return ReadmeManager.GetObjectFromId(ObjectId, autoSync); }

		public static bool AllFieldsEqual(IEnumerable<TextAreaObjectField> listA, IEnumerable<TextAreaObjectField> listB)
		{
			return listA.OrderBy(item => item.Index).SequenceEqual(listB.OrderBy(item => item.Index), new AllFieldsEqualComparer());
		}

		public static bool BaseFieldsEqual(IEnumerable<TextAreaObjectField> listA, IEnumerable<TextAreaObjectField> listB)
		{
			return listA.OrderBy(item => item.Index).SequenceEqual(listB.OrderBy(item => item.Index), new BaseFieldsEqualComparer());
		}

		public void Draw(TextEditor textEditor = null, Vector2 offset = default, Rect bounds = default)
		{
			Rect fieldBounds = FieldRect;
			fieldBounds.position += offset;

			textBoxBackgroundColor = EditorGUIUtility.isProSkin ? Readme.darkBackgroundColor : Readme.lightBackgroundColor;

			// Only draw if in bounds
			if (bounds != default)
			{
				fieldBounds.yMin += Mathf.Min(Mathf.Max(bounds.yMin - fieldBounds.yMin, 0), fieldBounds.height);
				fieldBounds.yMax -= Mathf.Min(Mathf.Max(fieldBounds.yMax - bounds.yMax, 0), fieldBounds.height);
				if (fieldBounds.height <= 0)
				{
					Rect offscreen = new Rect(99999, 99999, 0, 0);
					fieldBounds = offscreen;
				}
			}

			EditorGUI.DrawRect(fieldBounds, textBoxBackgroundColor);
			Object obj = EditorGUI.ObjectField(fieldBounds, ObjectRef, typeof(Object), true);

			if (IdInSync && ObjectRef != obj)
			{
				ObjectRef = obj;
				UpdateId();
				OnChange(this);
			}

			if (textEditor != null &&
				IsSelected(textEditor))
			{
				EditorGUI.DrawRect(fieldBounds, selectedColor);
			}
		}

		public bool IsSelected(TextEditor textEditor)
		{
			bool isSelected =
				textEditor.controlID != 0 &&
				Mathf.Min(textEditor.selectIndex, textEditor.cursorIndex) <= index &&
				Mathf.Max(textEditor.selectIndex, textEditor.cursorIndex) >= (index + length);

			return isSelected;
		}

		public void UpdateId() { ObjectId = ObjectRef == null ? 0 : GetIdFromObject(); }

		private class AllFieldsEqualComparer : IEqualityComparer<TextAreaObjectField>
		{
			public bool Equals(TextAreaObjectField a, TextAreaObjectField b)
			{
				if (a == null ||
					b == null)
				{
					return a == null && b == null;
				}

				return a.fieldRect == b.fieldRect && a.index == b.index && a.length == b.length && a.objectId == b.ObjectId && a.objectRef == b.ObjectRef;
			}

			public int GetHashCode(TextAreaObjectField a) { return a.fieldRect.GetHashCode() ^ a.index.GetHashCode() ^ a.length.GetHashCode() ^ a.objectId.GetHashCode() ^ a.objectRef.GetHashCode(); }
		}

		private class BaseFieldsEqualComparer : IEqualityComparer<TextAreaObjectField>
		{
			public bool Equals(TextAreaObjectField a, TextAreaObjectField b)
			{
				if (a == null ||
					b == null)
				{
					return a == null && b == null;
				}

				return a.index == b.index && a.length == b.length && a.objectId == b.ObjectId && a.objectRef == b.ObjectRef;
			}

			public int GetHashCode(TextAreaObjectField a) { return a.index.GetHashCode() ^ a.length.GetHashCode() ^ a.objectId.GetHashCode() ^ a.objectRef.GetHashCode(); }
		}
	}
}

#endif