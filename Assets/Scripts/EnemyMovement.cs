using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Node> path;

	// Use this for initialization
	void Start () {
        //StartCoroutine(FollowPath());
    }
	
	// Update is called once per frame
	void Update () {

    }

    //IEnumerator FollowPath() {
    //    print("Starting Patrol");
    //    yield return new WaitForSeconds(1f);
    //    foreach (Node b in path) {
    //        transform.position = b.transform.position;
    //        print("Visiting block: " + b.name);
    //        yield return new WaitForSeconds(1f);
    //    }
    //    print("Patrol Ended");
    //}
}
