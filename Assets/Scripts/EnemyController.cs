using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    
    public float speed = 5f;
    public float fleeDistance = 10f;
    public float startFleeingDistance = 15f;

    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    void Update()
    {
        if (player == null) return;
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer < startFleeingDistance)
            {
                Flee();
            }
        }
    }

    void Flee()
    {
        Vector3 dirToPlayer = transform.position - player.position;

        Vector3 newPos = transform.position + dirToPlayer.normalized* fleeDistance;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(newPos, out hit, 5f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
