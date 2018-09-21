using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMove : MonoBehaviour {

    public float walkAcceleration = 5;
    public GameObject playerCamera;

    public string movementX;
    public string movementZ;
    Rigidbody rigid;

	void Start () {
        rigid = GetComponent<Rigidbody>();
    }

	void Update () {
        //Rigidbody.AddRelativeForce(Input.GetAxis("Horizontal") * walkAcceleration, 0, Input.GetAxis("Vertical") * walkAcceleration);
        float moveX = Input.GetAxis(movementX);
        float moveZ = Input.GetAxis(movementZ);


        Vector3 moveVector = new Vector3(moveX, 0, moveZ) * (Time.deltaTime * walkAcceleration);
        this.transform.Translate(moveVector, Space.World);
        rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

    }
}
