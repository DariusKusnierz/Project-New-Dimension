using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    float speed;
    Inventory inventory;
    Animator animationOfMovement;

    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        inventory = Inventory.instance;
        animationOfMovement = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) inventory.gameObject.SetActive(!inventory.gameObject.active);

        speed = Input.GetKey(KeyCode.LeftShift) ? 5 : 2.5f;
        animationOfMovement.SetFloat("Speed", speed * Input.GetAxis("Vertical") / 5);
        var direction = Vector3.zero;
        direction += Vector3.left * Input.GetAxis("Vertical");
        //direction += Vector3.forward * Input.GetAxis("Horizontal");
        transform.rotation *= Quaternion.Euler(Vector3.up * Input.GetAxis("Horizontal"));
        transform.position += rigidbody.rotation * direction * speed * Time.deltaTime;

    }
}
