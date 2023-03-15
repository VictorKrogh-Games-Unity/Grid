using TMPro;
using UnityEngine;

namespace VictorKrogh.Games.Grid.Debugger
{

    internal class GridXZDebugger : MonoBehaviour, IGridDebugger
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
                for (int z = 0; z < grid.Height; z++)
                {
                    var arrayIndex = GetArrayIndexByCoord(x, z);
                    var worldPositionXZ = GetGridWorldPositionXZ(x, z);

                    m_DebugTextArray[arrayIndex] = Utils.CreateWorldText($"{grid.GetValue(x, z)}", 20, transform, worldPositionXZ + new Vector3(grid.CellSize, 0.0f, grid.CellSize) * 0.5f);
                    m_DebugTextArray[arrayIndex].transform.rotation = Quaternion.Euler(90, 0, 0);

                    Debug.DrawLine(worldPositionXZ, GetGridWorldPositionXZ(x, z + 1), Color.white, s_DebugDrawLineDuration);
                    Debug.DrawLine(worldPositionXZ, GetGridWorldPositionXZ(x + 1, z), Color.white, s_DebugDrawLineDuration);
                }
            }
            Debug.DrawLine(GetGridWorldPositionXZ(0, grid.Height), GetGridWorldPositionXZ(grid.Width, grid.Height), Color.white, s_DebugDrawLineDuration);
            Debug.DrawLine(GetGridWorldPositionXZ(grid.Width, 0), GetGridWorldPositionXZ(grid.Width, grid.Height), Color.white, s_DebugDrawLineDuration);
        }

        public void UpdateText(int x, int z, string text)
        {
            var arrayIndex = GetArrayIndexByCoord(x, z);
            if (m_DebugTextArray != null && m_DebugTextArray[arrayIndex] != null)
            {
                m_DebugTextArray[arrayIndex].text = text;
            }
        }

        private int GetArrayIndexByCoord(int x, int z)
        {
            return z * m_Grid.Width + x;
        }

        private Vector3 GetGridWorldPositionXZ(int x, int z)
        {
            return new Vector3(x, 0.0f, z) * m_Grid.CellSize + m_Grid.OriginPosition;
        }
    }

}
