using UnityEngine;

namespace VictorKrogh.Games.CircuitDefender.Grid
{
    
    public interface IGridDebugger
    {
        void Setup<TGridItem>(GridBase<TGridItem> grid);
        void UpdateText(int x, int y, string text);
    }

}
