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

    float xAxis;
    float yAxis;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        gameObject.GetComponent<Collider>().isTrigger = true;
        basicPosition = transform.localPosition;
        currentPosition = basicPosition;
    }

    private void Update()
    {
        if (isComingBack)
            backToBasicPosition();

        if (Input.GetMouseButton(1))
        {
            xAxis += Input.GetAxis("Mouse X") * 0.1f;
            yAxis += Input.GetAxis("Mouse Y") * 0.1f;
            transform.localEulerAngles += new Vector3(-yAxis, 0, 0);
            transform.parent.localEulerAngles += new Vector3(0, xAxis, 0);
        }
        else
        {
            xAxis = 0;
            yAxis = 0;
        }
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

    private void backToBasicPosition()
    {
        elapsed += Time.deltaTime;
        actualStep = elapsed / duration;
        Debug.Log("Oddalanie: " + actualStep);
        transform.localPosition = Vector3.Lerp(currentPosition, basicPosition, actualStep);

        if (transform.localPosition == basicPosition)
            isComingBack = false;
    }
}
