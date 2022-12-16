using UnityEngine;

using UnityEngine.UI;

namespace MergeToStay.MonoBehaviours.UI
{
	public class FlexibleGridLayout : LayoutGroup
	{
		public int Rows;
		public int Columns;

		public Vector2 CellSize;
		public Vector2 Spacing;

		public override void CalculateLayoutInputHorizontal()
		{
			base.CalculateLayoutInputHorizontal();
			
			float sqrRt = Mathf.Sqrt(transform.childCount);
			Rows = Mathf.CeilToInt(sqrRt);
			Columns = Mathf.CeilToInt(sqrRt);

			var rect = rectTransform.rect;
			float parentWidth = rect.width;
			float parentHeight = rect.height;

			float cellWidth = (parentWidth / (float)Columns) - (Spacing.x / Columns) * (Columns-1);
			float cellHeight = (parentHeight / (float)Rows) - (Spacing.y / Rows) * (Rows-1);


			UnityEngine.Debug.Log( parentHeight + " " + cellHeight);
			UnityEngine.Debug.Log(parentWidth + " " + cellWidth);
			// Debug.(cellWidth);
 
			
			CellSize.x = cellWidth;
			CellSize.y = cellHeight;

			int colCount = 0;
			int rowCount = 0;
			for (int i = 0; i < rectChildren.Count; i++)
			{
				rowCount = i / Columns;
				colCount = i % Columns;

				RectTransform child = rectChildren[i];
				float xPos = CellSize.x * colCount + Spacing.x * colCount;
				float yPos = CellSize.y * rowCount + Spacing.y * rowCount;
				// float xPos = CellSize.x * colCount;
				// float yPos = CellSize.y * rowCount;
				
				SetChildAlongAxis(child, 0, xPos, CellSize.x);
				SetChildAlongAxis(child, 1, yPos, CellSize.y);
			}
		}
		
		public override void CalculateLayoutInputVertical()
		{

		}

		public override void SetLayoutHorizontal()
		{


		}

		public override void SetLayoutVertical()
		{
		}
	}
}