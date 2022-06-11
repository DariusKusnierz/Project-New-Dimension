using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CameraBehave : MonoBehaviour
{
    Vector3 basicPosition, currentPosition;

    [SerializeField]
    Vector3 lowPosition = new Vector3(0.8f, 1.5f);

    [SerializeField]
    float duration = 1f;
    float elapsed = 0;
    float actualStep;

    [SerializeField]
    bool isComingBack = false;

    void Start()
    {
        gameObject.GetComponent<Collider>().isTrigger = true;
        basicPosition = transform.localPosition;
        currentPosition = basicPosition;
    }

    private void Update()
    {
        if (!isComingBack) return;

        elapsed += Time.deltaTime;
        actualStep = elapsed / duration;
        Debug.Log("Oddalanie: " + actualStep);
        transform.localPosition = Vector3.Lerp(currentPosition, basicPosition, actualStep);

        if(transform.localPosition == basicPosition)
            isComingBack = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        elapsed = 0;
        currentPosition = transform.localPosition;
        isComingBack = false;
    }

    private void OnTriggerStay(Collider other)
    {
        elapsed += Time.deltaTime;

        actualStep = elapsed / duration;
        Debug.Log("Przybli¿anie: "+actualStep);
        transform.localPosition = Vector3.Lerp(currentPosition, lowPosition, actualStep);
    }

    private void OnTriggerExit(Collider other)
    {
        currentPosition = transform.localPosition;
        isComingBack = true;
        elapsed = 0;
    }
}
