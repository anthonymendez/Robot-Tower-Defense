using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Block> path;

	// Use this for initialization
	void Start () {
        PrintAllWaypoints();
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void PrintAllWaypoints() {
        foreach (Block b in path) {
            print(b.name);
        }
    }
}
