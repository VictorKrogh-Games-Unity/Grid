# Grid
Grid system for XY and XZ - with editor visuals

## Install
Either add the repository as a submodule, using the following command `git submodule add https://github.com/VictorKrogh-Games-Unity/Grid.git Assets/VictorKrogh.Games`
Or by downloading the [Unity Package here](https://github.com/VictorKrogh-Games-Unity/Grid/releases/tag/1.0).

## How to use GridXY
Example code:
```csharp
using UnityEngine;
using VictorKrogh.Games.Grid;
using VictorKrogh.Games.Grid.Debugger;

public class GridXYTest : MonoBehaviour
{
    [SerializeField] private int m_Width = 10;
    [SerializeField] private int m_Height = 10;
    [SerializeField] private float m_CellSize = 5.0f;
    [SerializeField] private Vector3 m_Origin = new Vector3(0.0f, 0.0f, 0.0f);

    private GridXY<int> m_Grid;
    private IGridDebugger m_GridDebugger;

    private void Start()
    {
        m_GridDebugger = GetComponent<IGridDebugger>();
        m_Grid = new GridXY<int>(m_Width, m_Height, m_CellSize, m_Origin, m_GridDebugger);
    }
}

```

## How to use GridXZ
Example code:
```csharp
using UnityEngine;
using VictorKrogh.Games.Grid;
using VictorKrogh.Games.Grid.Debugger;

public class GridXZTest : MonoBehaviour
{
    [SerializeField] private int m_Width = 10;
    [SerializeField] private int m_Height = 10;
    [SerializeField] private float m_CellSize = 5.0f;
    [SerializeField] private Vector3 m_Origin = new Vector3(0.0f, 0.0f, 0.0f);

    private GridXZ<int> m_Grid;
    private IGridDebugger m_GridDebugger;

    private void Start()
    {
        m_GridDebugger = GetComponent<IGridDebugger>();
        m_Grid = new GridXZ<int>(m_Width, m_Height, m_CellSize, m_Origin, m_GridDebugger);
    }
}
```
