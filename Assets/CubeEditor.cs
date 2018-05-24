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
        Vector3 gridPos = node.GetGridPos();
        int gridSize = node.GetGridSize();
        TextMesh coordinateLabel = GetComponentInChildren<TextMesh>();
        String coordLabel = String.Format("{0},{1}", gridPos.x / gridSize, gridPos.z / gridSize);

        coordinateLabel.text = coordLabel;
        gameObject.name = coordLabel;
    }

    private void SnapToGrid() {
        transform.position = node.GetGridPos();
    }

    
}
