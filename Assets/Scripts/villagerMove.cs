
using UnityEngine;
using UnityEngine.AI;

public class villagerMove : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform nextPosition;
    public State nextAction;

    public float distanceToStopMoving = 30f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(nextPosition != null)
        {
            navMeshAgent.destination = nextPosition.position;
            GetComponent<villagerInfo>().currentState = State.Travelling;

            navMeshAgent.stoppingDistance = distanceToStopMoving;
                        
            if(navMeshAgent.remainingDistance <= distanceToStopMoving)
            {
                nextPosition = null;
                GetComponent<villagerInfo>().currentState = nextAction;
            }
        }
    }
}
