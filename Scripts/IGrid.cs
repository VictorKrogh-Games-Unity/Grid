using UnityEngine;

namespace VictorKrogh.Games.CircuitDefender.Grid
{
    public interface IGrid
    {
        int Width { get; }
        int Height { get; }
        float CellSize { get; }
        Vector3 OriginPosition { get; }
    }
}
