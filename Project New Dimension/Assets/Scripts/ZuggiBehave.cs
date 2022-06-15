using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZuggiBehave : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animation;

    [SerializeField]
    GameObject player;
    float distanceToSearch = 15f;

    //bool isAttacking = false;
    [SerializeField]
    float attackCooldown = 1.5f;
    [SerializeField]
    float actualAttackCooldown;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animation = GetComponent<Animator>();
        actualAttackCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (actualAttackCooldown != 0 || animation.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return;

        searchPlayer();
    }

    void searchPlayer()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        
        if(distance <= distanceToSearch)
        {
            lookToPlayer();
            if(distance <= agent.stoppingDistance)
            {
                //isAttacking = true;
                actualAttackCooldown = attackCooldown;
                animation.SetFloat("Speed", 0);
                animation.SetTrigger("Attack");
                StartCoroutine(AttackCooldown());
            }
            else
            {
                agent.SetDestination(player.transform.position);
                animation.SetFloat("Speed", 1f);
            }
        }
    }

    void lookToPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceToSearch);
    }

    IEnumerator AttackCooldown()
    {
        while (actualAttackCooldown > 0)
        {
            actualAttackCooldown -= 0.5f;
            //Debug.Log(actualBasicAttackCooldown);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
