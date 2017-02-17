using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridGenerator : MonoBehaviour {
    [Header("New Grid Position Offset")]
    [SerializeField, Range(-50,50)]
    private int xOffset;
    [SerializeField, Range(-50, 50)]
    private int yOffset = -10;
    [SerializeField, Range(-50, 50)]
    private int zOffset = -35;

    [SerializeField]
    private GameObject grid;

    private GameObject lastSpawnedGrid;

    private Queue<GameObject> grids = new Queue<GameObject>();


	// Use this for initialization
	void Start () {
        for (int i = 0; i < 10; i++)
        {
            cloneGrid();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void cloneGrid()
    {
        if (lastSpawnedGrid != null)
        {
            GameObject newGrid = Object.Instantiate(grid);
            newGrid.transform.position = new Vector3(lastSpawnedGrid.transform.position.x + xOffset, lastSpawnedGrid.transform.position.y + yOffset, lastSpawnedGrid.transform.position.z + zOffset);
            lastSpawnedGrid = newGrid;
            grids.Enqueue(newGrid);
        }
        else
        {
            GameObject newGrid = Object.Instantiate(grid);
            newGrid.transform.position = new Vector3(0, 0, 0);
            lastSpawnedGrid = newGrid;
            grids.Enqueue(newGrid);
        }

    }
}
