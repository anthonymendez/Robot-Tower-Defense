using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [Header("Speed")]
    [SerializeField] float nodePerSecond = 2f;

    [Header("Properties")]
    [SerializeField] Collider collisionMesh;

	void Start () {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Node> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Node> path) {
        foreach (Node b in path) {
            transform.position = b.transform.position;
            yield return new WaitForSeconds(nodePerSecond);
        }
    }
}
