using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField] Node startNode, endNode;

    Dictionary<Vector2Int, Node> worldGrid = new Dictionary<Vector2Int, Node>();
    Vector2Int[] directions = {
        // X and Z axis respectively
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

	void Start () {
        ColorStartAndEnd();
        LoadBlocks();
        ExploreNeighbors();
    }

    private void ColorStartAndEnd() {
        startNode.setTopColor(Color.red);
        endNode.setTopColor(Color.green);
    }

    private void LoadBlocks() {
        Node[] nodes = FindObjectsOfType<Node>();

        foreach (Node node in nodes) {
            bool isOverLapping = worldGrid.ContainsKey(node.GetGridPos());
            Vector2Int gridPos = node.GetGridPos();

            if (isOverLapping) {
                Debug.LogWarningFormat(
                    "Overlapping blocks at ({0},{1}). Removed one gameobject at runtime.", 
                    gridPos.x,
                    gridPos.y
                    );
                continue;
            }

            worldGrid.Add(node.GetGridPos(), node);
        }
    }

    private void ExploreNeighbors() {
        foreach(Vector2Int direction in directions) {
            Vector2Int newPos = startNode.GetGridPos() + direction;
            if (worldGrid.ContainsKey(newPos)) {
                Node neighborNode;
                worldGrid.TryGetValue(newPos, out neighborNode);
                neighborNode.setTopColor(Color.blue);
            }
        }
    }

    
}
