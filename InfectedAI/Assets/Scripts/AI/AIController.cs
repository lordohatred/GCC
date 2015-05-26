using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

    public int seekDistance;
    public int playerMinDistance;

    private Vector3 target;
    private Vector3 player;
    private NavMeshAgent agent;

    void Start () {
        agent = gameObject.GetComponent<NavMeshAgent> ();
        FindNewTarget (seekDistance);
    }

    void MoveToTarget () {
        agent.SetDestination (target);
    }

    void FindNewTarget (int distance) {
        target = transform.position + new Vector3 (Random.Range(-distance, distance), 0, Random.Range(-distance, distance));
    }

    void Update () {
        player = GameObject.Find ("Player").transform.position;
        if (target == null)
            FindNewTarget (5);
        else {
            if (Vector3.Distance (transform.position, target) < 1) {
                FindNewTarget (seekDistance);
            } else
                MoveToTarget ();
        }
        if (agent.velocity.sqrMagnitude < 0.3f)
            FindNewTarget (seekDistance);
        if (Vector3.Distance (transform.position, player) < playerMinDistance) {
            target = player;
            agent.speed = 1.5f;
        }
        if (target != player)
            agent.speed = 1.0f;
    }
}
