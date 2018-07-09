using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField] Node startNode, endNode;

    Dictionary<Vector2Int, Node> worldGrid = new Dictionary<Vector2Int, Node>();

    private List<Node> path = new List<Node>();

    public List<Node> GetPath() {
        if (path.Count == 0) {
            CalculatePath();
        }

        return path;
    }

    private void CalculatePath() {
        ColorStartAndEnd();
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
    }

    Vector2Int[] directions = {
        // X and Z axis respectively
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

    Queue<Node> nodeQueue = new Queue<Node>();
    Node currentNode;

    private void ColorStartAndEnd() {
        // todo consider moving out
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

    private void BreadthFirstSearch() {
        nodeQueue.Clear();

        nodeQueue.Enqueue(startNode);
        while (nodeQueue.Count != 0) {
            currentNode = nodeQueue.Dequeue();

            if (currentNode.visited)
                continue;
            
            currentNode.visited = true;

            if (endNode.Equals(currentNode)) {
                break;
            }

            ExploreNeighbors();
        }

        ColorBreadcrumbs();
    }

    private void CreatePath() {
        path.Add(endNode);

        Node previous = endNode.visitedFrom;
        while (!previous.Equals(startNode)) {
            path.Add(previous);
            previous = previous.visitedFrom;
        }

        path.Add(startNode);
        path.Reverse();
    }

    private void ColorBreadcrumbs() {
        currentNode = endNode.visitedFrom;
        while(currentNode.visitedFrom != null) {
            currentNode.setTopColor(Color.blue);
            currentNode = currentNode.visitedFrom;
        }
    }

    private void ExploreNeighbors() {
        foreach(Vector2Int direction in directions) {
            Vector2Int newPos = currentNode.GetGridPos() + direction;

            if (worldGrid.ContainsKey(newPos)) {
                QueueNeighbor(newPos);
            }
        }
    }

    private void QueueNeighbor(Vector2Int newPos) {
        Node neighborNode;
        worldGrid.TryGetValue(newPos, out neighborNode);
        if (!neighborNode.visited && !nodeQueue.Contains(neighborNode)) {
            neighborNode.visitedFrom = currentNode;
            nodeQueue.Enqueue(neighborNode);
        }
    }

}
