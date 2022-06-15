using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToggiBehave : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animation;

    [SerializeField]
    GameObject player;

    [SerializeField]
    float distanceToSearch = 5f;

    [SerializeField]
    GameObject goTo;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animation = GetComponent<Animator>();
        agent.SetDestination(goTo.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerNear()) 
        {
            agent.isStopped = false;
            animation.SetFloat("Speed", 1f);
        }
        else
        {
            agent.isStopped = true;
            animation.SetFloat("Speed", 0);


        }

        if (agent.stoppingDistance >= Vector3.Distance(goTo.transform.position, transform.position))
        {
            animation.SetFloat("Speed", 0);
            GetComponent<ToggiBehave>().enabled = false;
        }
    }

    bool isPlayerNear()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= distanceToSearch)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void lookToPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        Debug.LogWarning(rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceToSearch);
    }

}
