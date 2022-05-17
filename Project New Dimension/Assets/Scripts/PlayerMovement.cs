using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 2;

    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var direction = Vector3.zero;
        direction += Vector3.left * Input.GetAxis("Vertical");
        //direction += Vector3.forward * Input.GetAxis("Horizontal");
        transform.rotation *= Quaternion.Euler(Vector3.up * Input.GetAxis("Horizontal"));
        transform.position += rigidbody.rotation * direction * speed * Time.deltaTime;

    }
}
