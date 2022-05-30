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

    void Start()
    {
        attackArea = gameObject.GetComponent<BoxCollider>();
        attackArea.isTrigger = true;
        attackArea.center += Vector3.right * -0.7f;
        attackArea.size = Vector3.one * 0.75f;

        actualBasicAttackCooldown = basicAttackCooldown;
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(gameObject.name + " widzi " + other.name);
        if (Input.GetMouseButtonDown(0) && isPlayer && actualBasicAttackCooldown >= basicAttackCooldown)
        {
            other.GetComponent<HP>().TakeHP();
            //Debug.Log("ATACK!!! on " + other.name);
            StartCoroutine(AttackCooldown());
        }

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
