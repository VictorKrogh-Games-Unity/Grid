using TMPro;
using UnityEngine;

namespace VictorKrogh.Games.Grid.Debugger
{

    internal class GridXYDebugger : MonoBehaviour, IGridDebugger
    {
        private IGrid m_Grid;
        private TextMeshPro[] m_DebugTextArray;
        private static float s_DebugDrawLineDuration = 100.0f;

        public void Setup<TGridItem>(GridBase<TGridItem> grid)
        {
            m_Grid = grid;
            m_DebugTextArray = new TextMeshPro[grid.Width * grid.Height];

            for (int x = 0; x < grid.Width; x++)
            {
                for (int y = 0; y < grid.Height; y++)
                {
                    var arrayIndex = GetArrayIndexByCoord(x, y);
                    var worldPositionXY = GetGridWorldPositionXY(x, y);

                    m_DebugTextArray[arrayIndex] = Utils.CreateWorldText($"{grid.GetValue(x, y)}", 20, transform, worldPositionXY + new Vector3(grid.CellSize, grid.CellSize) * 0.5f);
                    Debug.DrawLine(worldPositionXY, GetGridWorldPositionXY(x, y + 1), Color.white, s_DebugDrawLineDuration);
                    Debug.DrawLine(worldPositionXY, GetGridWorldPositionXY(x + 1, y), Color.white, s_DebugDrawLineDuration);
                }
            }
            Debug.DrawLine(GetGridWorldPositionXY(0, grid.Height), GetGridWorldPositionXY(grid.Width, grid.Height), Color.white, s_DebugDrawLineDuration);
            Debug.DrawLine(GetGridWorldPositionXY(grid.Width, 0), GetGridWorldPositionXY(grid.Width, grid.Height), Color.white, s_DebugDrawLineDuration);
        }

        public void UpdateText(int x, int y, string text)
        {
            var arrayIndex = GetArrayIndexByCoord(x, y);
            if (m_DebugTextArray != null && m_DebugTextArray[arrayIndex] != null)
            {
                m_DebugTextArray[arrayIndex].text = text;
            }
        }

        private int GetArrayIndexByCoord(int x, int y)
        {
            return y * m_Grid.Width + x;
        }

        private Vector3 GetGridWorldPositionXY(int x, int y)
        {
            return new Vector3(x, y, 0.0f) * m_Grid.CellSize + m_Grid.OriginPosition;
        }
    }

}
