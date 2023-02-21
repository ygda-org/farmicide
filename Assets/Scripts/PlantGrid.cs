using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrid : MonoBehaviour {
    public GridTile[,] plantGrid;
    
    public int gridWidth, gridHeight;   // the entire grid's size in number of tiles

    public float tileWidth, tileHeight; // each tile's size in absolute size

    public void InitializeGrid() {
        plantGrid = new GridTile[gridHeight, gridWidth];

        Vector2 firstElementCenter = new(-0.5f*tileWidth*(gridWidth-1), 0.5f*tileHeight*(gridHeight-1));

        for (int col= 0; col < gridWidth; col++) {
            for (int row = 0; row < gridHeight; row++) {
                Vector2 centerCoordinates = new(firstElementCenter.x + col*tileWidth, firstElementCenter.y - row*tileHeight);
                plantGrid[row, col] = new(centerCoordinates);
                print(centerCoordinates);
            }
        }

    }

    public GridTile GetClosestGridTile(GameObject gameObject) {
        Vector2 position = gameObject.transform.position;
        return new GridTile(new Vector2());
    }

    void Awake() {
        InitializeGrid();
    }
}
public class GridTile {
    public Vector2 centerCoordinates {get; set;}
    public Plant plant {get; set;}

    public GridTile(Vector2 centerCoordinates_) {
        centerCoordinates = centerCoordinates_;
        plant = null;
    }



}
