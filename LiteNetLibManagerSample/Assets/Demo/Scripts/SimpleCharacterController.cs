using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLibHighLevel;

public class SimpleCharacterController : LiteNetLibBehaviour
{
    Vector3 input;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        if (IsLocalClient)
            transform.Translate(Vector3.ClampMagnitude(input, 1) * 2 * Time.fixedDeltaTime);
    }
}
