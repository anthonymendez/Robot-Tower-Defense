using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector3Int, Node> worldGrid = new Dictionary<Vector3Int, Node>();

	// Use this for initialization
	void Start () {
        LoadBlocks();
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

    // Update is called once per frame
    void Update () {
		
	}
}
