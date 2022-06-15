using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Attack : MonoBehaviour
{
    [SerializeField]
    bool isPlayer = false;

    [SerializeField]
    int basicAttackCooldown = 2;

    int actualBasicAttackCooldown;
    BoxCollider attackArea;

    Animator animationOfAttack;

    void Start()
    {
        /*
        attackArea = gameObject.GetComponent<BoxCollider>();
        attackArea.isTrigger = true;
        attackArea.center += Vector3.right * -0.7f;
        attackArea.size = Vector3.one * 0.75f;
        */

        animationOfAttack = GetComponentInChildren<Animator>();
        actualBasicAttackCooldown = basicAttackCooldown;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isPlayer && actualBasicAttackCooldown >= basicAttackCooldown)
        {
            
            BasicAttack();
        }
    }

    void BasicAttack()
    {
        animationOfAttack.SetTrigger("Attack");
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown()
    {
        while (actualBasicAttackCooldown>0)
        {
            actualBasicAttackCooldown--;
            //Debug.Log(actualBasicAttackCooldown);
            yield return new WaitForSeconds(1f);
        }
        actualBasicAttackCooldown = basicAttackCooldown;
    }
}
