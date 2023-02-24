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
            }
        }

    }

    private bool PositionIsInGrid(Vector2 position) {
        return -(gridWidth*tileWidth)/2f <= position.x && position.x <= (gridWidth*tileWidth)/2f &&
               -(gridHeight*tileHeight)/2f <= position.y && position.y <= (gridHeight*tileHeight)/2f;
    }

    public Vector2 PositionToGridCoordinate(Vector2 position) {
        // if (!PositionIsInGrid(position)) return new(0,0);

        // double check if this actually works (doesn't work)
        // Vector2 gridCoordinate = new((int)(position.x/tileWidth), (int)(position.y/tileHeight));
        return new();
    }
    public GridTile GetClosestGridTile(GameObject gameObject) {
        Vector2 position = gameObject.transform.position;
        if (PositionIsInGrid(position)) {
            // return positionToGridCoordinate(position);
        }
        else {

        }
        return new GridTile(new Vector2());
    }

    void Awake() {
        InitializeGrid();
    }
}
public class GridTile {
    public Vector2 centerCoordinates;
    public Plant plant;

    public GridTile(Vector2 centerCoordinates_) {
        centerCoordinates = centerCoordinates_;
        plant = null;
    }



}
