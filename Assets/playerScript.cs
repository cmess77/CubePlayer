using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

    public Transform camTransform;
    public Quaternion newRotation;
    public float playerTranslateSpeed;
    public Vector3 playerRotateSpeed;
    public Vector3 inputDirection;

    public float jumpMagnitude;

    Rigidbody rb;
    
    bool isJumping;


    void Start() {
        camTransform.parent = transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        // Vector3 input = Vector3.forward * Input.GetAxisRaw("Vertical");
        inputDirection = input.normalized;
        if(Input.GetKeyDown(KeyCode.V)) {
            rb.MoveRotation(Quaternion.Euler(0f,0f,0f));
        }
    }

    void FixedUpdate() {
        if((rb.position.y > 0.48) && (rb.position.y < 0.51)) {
            isJumping = false;
        }

        Quaternion deltaRotation = Quaternion.Euler(inputDirection.x * playerRotateSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
        rb.MovePosition(rb.position + transform.forward * playerTranslateSpeed * inputDirection.z * Time.fixedDeltaTime);  

        if(Input.GetKeyDown(KeyCode.Space) && !isJumping) {
            rb.AddForce(0, jumpMagnitude, 0, ForceMode.VelocityChange);
            isJumping = true;
        }
    }

}
