using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour {
    
    [Tooltip("GameObject will snap to positions of factors of this value.")][Range(1f, 20f)] [SerializeField] float
        gridSize = 10f;

    Vector3 snapPos;

	void Update () {
        PerformSnapPosition();
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
