using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //StartCoroutine(FollowPath());
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Node> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Node> path) {
        print("Starting Patrol");
        yield return new WaitForSeconds(1f);
        foreach (Node b in path) {
            transform.position = b.transform.position;
            print("Visiting block: " + b.name);
            yield return new WaitForSeconds(1f);
        }
        print("Patrol Ended");
    }
}
