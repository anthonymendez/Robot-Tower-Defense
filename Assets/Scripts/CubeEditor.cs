using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Node))]
public class CubeEditor : MonoBehaviour {

    Node node;

    void Awake() {
        node = GetComponent<Node>();
    }

	void Update () {
        SnapToGrid();
        UpdateLabel();
    }

    private void UpdateLabel() {
        Vector2 gridPos = node.GetGridPos();
        TextMesh coordinateLabel = GetComponentInChildren<TextMesh>();
        String coordLabel = String.Format("{0},{1}", gridPos.x, gridPos.y);

        coordinateLabel.text = coordLabel;
        gameObject.name = coordLabel;
    }

    private void SnapToGrid() {
        Vector2Int gridPos = node.GetGridPos();
        int gridSize = node.GetGridSize();
        transform.position = new Vector3(
            gridPos.x * gridSize,
            0f,
            gridPos.y * gridSize
            );

    }

    
}
