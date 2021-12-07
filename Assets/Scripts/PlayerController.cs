using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private Transform CameraTransform;

    private Vector3 direction = Vector3.zero;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetButton("Vertical"))
        {
            transform.rotation = Quaternion.Euler(0, CameraTransform.rotation.eulerAngles.y, 0);
        }

        if(Input.GetButton("Horizontal") )
        {
            float radians = Mathf.Asin(Input.GetAxis("Horizontal"));

            transform.rotation = Quaternion.Euler(0, radians * Mathf.Rad2Deg, 0);
        }
        */
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(direction * Speed * Time.deltaTime);
    }
}
