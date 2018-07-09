using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public bool visited = false;
    public Node visitedFrom;
    public bool isPlaceable = true;

    Vector2Int gridPos;
    const int gridSize = 10;

    void Awake() {
        gridPos = GetGridPos();
    }

    public int GetGridSize() { return gridSize; }

    public Vector2Int GetGridPos() {
        Vector2Int newGridPos = new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );

        gridPos = newGridPos;
        return gridPos;
    }

    public void setTopColor(Color newColor) {
        Transform top = transform.Find("Top");
        MeshRenderer topMeshRenderer = top.GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = newColor;
    }

    void OnMouseOver() {
        if (isPlaceable && Input.GetMouseButtonDown(0)) {
            print(gameObject.name);
        }
    }
}
