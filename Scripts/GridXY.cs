using UnityEngine;
using VictorKrogh.Games.Grid.Debugger;

namespace VictorKrogh.Games.Grid
{
    internal class GridXY<TGridItem> : GridBase<TGridItem>
    {
        public GridXY(int width, int height, float cellSize, Vector3 originPosition, IGridDebugger gridDebugger = null) 
            : base(width, height, cellSize, originPosition, gridDebugger)
        {
        }

        protected override Vector2Int GetGridCoords(Vector3 worldPosition)
        {
            var result = new Vector2Int
            {
                x = Mathf.FloorToInt((worldPosition - OriginPosition).x / CellSize),
                y = Mathf.FloorToInt((worldPosition - OriginPosition).y / CellSize)
            };

            return result;
        }

        protected override Vector3Int GetGridPosition(int x, int y)
        {
            return new Vector3Int(x, y, 0);
        }
    }

}
