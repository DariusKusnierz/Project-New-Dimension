using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    float speed;
    Inventory inventory;
    Animator animationOfMovement;

    KeyCode lastPlayerKeyDown = KeyCode.None;
    Vector3 directionOfDash;

    bool isDashing = false;
    float elapsedDash = 0f;
    float actualStepOfDash;

    [SerializeField]
    float durationOfDash = 1f;

    Vector3 currentPosition;
    Vector3 targetPosition;

    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        inventory = Inventory.instance;
        animationOfMovement = GetComponentInChildren<Animator>();
        StartCoroutine(ResetLastPlayerKeyDown());
    }

    void Update()
    {
        if (isDashing)
        {
            Dash();
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.gameObject.SetActive(!inventory.gameObject.active);
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            } 

        }

        TryDash();

        speed = Input.GetKey(KeyCode.LeftShift) ? 5 : 2.5f;
        animationOfMovement.SetFloat("Speed", speed * Input.GetAxis("Vertical") / 5);
        var direction = Vector3.zero;
        direction += Vector3.left * Input.GetAxis("Vertical");
        //direction += Vector3.forward * Input.GetAxis("Horizontal");
        transform.rotation *= Quaternion.Euler(Vector3.up * Input.GetAxis("Horizontal")*2);
        transform.position += rigidbody.rotation * direction * speed * Time.deltaTime;

    }

    private void TryDash()
    {
        if(lastPlayerKeyDown != KeyCode.None)
        {
            if (Input.GetKeyDown(lastPlayerKeyDown))
            {
                lastPlayerKeyDown = KeyCode.None;

                currentPosition = transform.position;
                targetPosition = transform.position + rigidbody.rotation * directionOfDash * 2.5f;

                Dash();
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            lastPlayerKeyDown = KeyCode.W;
            directionOfDash = Vector3.left * Input.GetAxisRaw("Vertical");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            lastPlayerKeyDown = KeyCode.A;
            directionOfDash = Vector3.forward * Input.GetAxisRaw("Horizontal");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            lastPlayerKeyDown = KeyCode.S;
            directionOfDash = Vector3.left * Input.GetAxisRaw("Vertical");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            lastPlayerKeyDown = KeyCode.D;
            directionOfDash = Vector3.forward * Input.GetAxisRaw("Horizontal");
        }
    }

    public void Dash()
    {
        isDashing = true;

        elapsedDash += Time.deltaTime;
        actualStepOfDash = elapsedDash / durationOfDash;

        transform.position = Vector3.Lerp(currentPosition, targetPosition, actualStepOfDash);

        if (transform.position == targetPosition)
        {
            elapsedDash = 0;
            isDashing = false;
        }
    }

    IEnumerator ResetLastPlayerKeyDown()
    {
        while (true)
        {
            lastPlayerKeyDown = KeyCode.None;

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        elapsedDash = 0;
        isDashing = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.name == "Terrain")
        {
            targetPosition += Vector3.up * 0.2f;
        }
    }

}
