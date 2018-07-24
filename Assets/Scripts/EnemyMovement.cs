using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [Header("Speed")]
    [SerializeField] float nodePerSecond = 0.5f;

    [Header("Properties")]
    [SerializeField] Collider collisionMesh;

    [Header("Particle Systems")]
    [SerializeField] ParticleSystem goalHitParticlePrefab;

    void Start () {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Node> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Node> path) {
        foreach (Node b in path) {
            bool isLastNode = b == path[path.Count - 1];
            //transform.position = b.transform.position;

            float elapsedTime = 0f;
            while (elapsedTime < nodePerSecond) {
                elapsedTime += Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, b.transform.position, elapsedTime/nodePerSecond);
                yield return new WaitForEndOfFrame();
            }

            if (isLastNode) {
                HandleReachingGoal();
            }

            yield return new WaitForSeconds(nodePerSecond);
        }
    }

    private void HandleReachingGoal() {
        HandleGoalHitParticleSystem();
        Destroy(gameObject, nodePerSecond);
    }

    private void HandleGoalHitParticleSystem() {
        ParticleSystem goalHitParticles = Instantiate(goalHitParticlePrefab, transform.position, Quaternion.identity);
        //goalHitParticles.transform.parent = goalHitParticles;
        goalHitParticles.Play();
        Destroy(goalHitParticles.gameObject, goalHitParticles.main.duration);
    }
}
