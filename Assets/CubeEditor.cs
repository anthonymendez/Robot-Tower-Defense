using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {
    
    [Header("Snapping Settings")]
    [Tooltip("GameObject will snap to positions of factors of this value.")][Range(1f, 20f)] [SerializeField] float
        gridSize = 10f;

    Vector3 snapPos;
    TextMesh coordinateLabel;

    void Start() {
        coordinateLabel = GetComponentInChildren<TextMesh>();
    }

	void Update () {
        PerformSnapPosition();
        UpdateLabel();
    }

    private void UpdateLabel() {
        if (coordinateLabel == null)
            return;

        String coordLabel = String.Format("{0},{1}", snapPos.x / gridSize, snapPos.z / gridSize);
        coordinateLabel.text = coordLabel;
        gameObject.name = coordLabel;
    }

    private void PerformSnapPosition() {
        CalculateSnapPosition();
        SetSnapPosition();
    }

    private void SetSnapPosition() {
        // Set position to snap position
        transform.position = snapPos;
    }

    private void CalculateSnapPosition() {
        // Calculate closest position of a factor of 10f
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = Mathf.RoundToInt(transform.position.y / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
    }
}
