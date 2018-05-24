using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    Vector3Int gridPos;
    const int gridSize = 10;

    void Awake() {
        gridPos = GetGridPos();
    }

    public int GetGridSize() { return gridSize; }

    public Vector3Int GetGridPos() {
        Vector3Int newGridPos = new Vector3Int(
            Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
            Mathf.RoundToInt(transform.position.y / gridSize) * gridSize,
            Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
        );

        return newGridPos;
    }

    public void setTopColor(Color newColor) {
        Transform top = transform.Find("Top");
        MeshRenderer topMeshRenderer = top.GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = newColor;
    }
}
