using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    public float roamRadius = 20f;
    public float roamTimer = 10f;
    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = roamTimer;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= roamTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, roamRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }
}