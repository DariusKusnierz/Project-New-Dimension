using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CameraBehave : MonoBehaviour
{
    Vector3 basicPosition, currentPosition;
    void Start()
    {
        gameObject.GetComponent<Collider>().isTrigger = true;
        basicPosition = transform.localPosition;
        //basicPosition = new Vector3(1.4f, 2.1f);
        currentPosition = basicPosition;
        transform.localPosition = currentPosition;
        Debug.Log("Start: "+currentPosition);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(currentPosition);
        transform.localPosition = Vector3.Lerp(currentPosition, new Vector3(0.8f, 1.5f), 100000);
    }

    private void OnTriggerExit(Collider other)
    {
        currentPosition = transform.position;
        transform.localPosition = Vector3.Lerp(currentPosition, basicPosition, 100000);
    }
}
