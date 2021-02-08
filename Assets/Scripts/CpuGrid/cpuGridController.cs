using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cpuGridController : MonoBehaviour
{
    private int[] gridCounter; // Almacena el numero de particulas por celda.
    public List<Vector3> particlePositions; // Posiciones de las particulas;
    public float cellSize;
    public float countX, countY, countZ;
    void Start()
    {
        gridCounter = new int[100];
    }

    // Update is called once per frame
    void Update()
    {
        //InitGrid();
        DrawGrid();
    }

    private void InitGrid()
    {
        gridCounter.Initialize();
    }

    private int getCellIndex(Vector3 particlePosition)
    {
        float x = Mathf.Floor(particlePosition.x) / cellSize;
        float y = Mathf.Floor(particlePosition.y) / cellSize;
        float z = Mathf.Floor(particlePosition.z) / cellSize;
        return 1;
        //return y * countX + x
    }

    public void DrawGrid()
    {
        for (int j = 0; j < countY; j++)
        {
            for (int i = 0; i <= countX; i++) // pinta las celdas en el eje X.
            {
                Debug.DrawLine(new Vector3(i * cellSize, j * cellSize, 0.0f), new Vector3(i * cellSize, j * cellSize, cellSize * countZ), Color.red);
            }

            for (int i = 0; i <= countZ; i++) // Dibuja las celdas en el eje Z.
            {
                Debug.DrawLine(new Vector3(0.0f, j * cellSize, i * cellSize), new Vector3(countX * cellSize, j * cellSize, i * cellSize), Color.blue);
            }
        }
    }
}
