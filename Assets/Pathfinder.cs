using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField] Node startNode, endNode;

    Dictionary<Vector3Int, Node> worldGrid = new Dictionary<Vector3Int, Node>();

	void Start () {
        ColorStartAndEnd();
        LoadBlocks();
	}

    private void ColorStartAndEnd() {
        startNode.setTopColor(Color.red);
        endNode.setTopColor(Color.green);
    }

    private void LoadBlocks() {
        Node[] nodes = FindObjectsOfType<Node>();

        foreach (Node node in nodes) {
            bool isOverLapping = worldGrid.ContainsKey(node.GetGridPos());
            Vector3Int gridPos = node.GetGridPos();

            if (isOverLapping) {
                Debug.LogWarningFormat(
                    "Overlapping blocks at ({0},{1},{2}). Removed one gameobject at runtime.", 
                    gridPos.x,
                    gridPos.y,
                    gridPos.z
                    );
                continue;
            }

            worldGrid.Add(node.GetGridPos(), node);
        }
    }

    
}
