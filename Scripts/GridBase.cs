using UnityEngine;

namespace VictorKrogh.Games.CircuitDefender.Grid
{

    public abstract class GridBase<TGridItem> : IGrid
    {
        public delegate void GridValueChanged(Vector3Int coords, TGridItem newValue);
        public event GridValueChanged OnGridValueChanged;

        public GridBase(int width, int height, float cellSize, Vector3 originPosition, IGridDebugger gridDebugger = null)
        {
            Width = width;
            Height = height;
            CellSize = cellSize;
            OriginPosition = originPosition;
            GridDebugger = gridDebugger;
            
            GridItems = new TGridItem[Width * Height];

            GridDebugger?.Setup(this);
        }

        public int Width { get; }
        public int Height { get; }
        public float CellSize { get; }
        public Vector3 OriginPosition { get; }
        protected IGridDebugger GridDebugger { get; }
        protected TGridItem[] GridItems { get; set; }

        public void SetValue(Vector3 worldPosition, TGridItem value)
        {
            var gridPosition = GetGridCoords(worldPosition);
            SetValue(gridPosition.x, gridPosition.y, value);
        }

        public void SetValue(int x, int y, TGridItem value)
        {
            if (!IsValidCoord(x, y))
            {
                return;
            }

            var arrayIndex = GetArrayIndex(x, y);
            GridItems[arrayIndex] = value;

            GridDebugger?.UpdateText(x, y, $"{GridItems[arrayIndex]}");

            OnGridValueChanged?.Invoke(GetGridPosition(x, y), GridItems[arrayIndex]);
        }

        public TGridItem GetValue(Vector3 worldPosition)
        {
            var gridPosition = GetGridCoords(worldPosition);
            return GetValue(gridPosition.x, gridPosition.y);
        }

        public TGridItem GetValue(int x, int y)
        {
            if (!IsValidCoord(x, y))
            {
                return default;
            }

            var arrayIndex = GetArrayIndex(x, y);
            return GridItems[arrayIndex];
        }

        public bool IsValidCoord(Vector3 worldPosition)
        {
            var gridPosition = GetGridCoords(worldPosition);
            return IsValidCoord(gridPosition.x, gridPosition.y);
        }

        private bool IsValidCoord(int x, int y)
        {
            return (x >= 0 && y >= 0 && x < Width && y < Height);
        }

        protected int GetArrayIndex(int x, int y)
        {
            return y * Width + x;
        }

        protected abstract Vector3Int GetGridPosition(int x, int y);
        protected abstract Vector2Int GetGridCoords(Vector3 worldPosition);
    }

}