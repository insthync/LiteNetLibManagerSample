using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using LiteNetLibHighLevel;

public class SimpleCharacterController : LiteNetLibBehaviour
{
    Vector3 input;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwnerClient)
        {
            input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
                    agent.SetDestination(hit.point);
            }
        }
    }

    private void FixedUpdate()
    {
        if (IsOwnerClient)
        {
            if (agent == null)
                transform.Translate(Vector3.ClampMagnitude(input, 1) * 2 * Time.fixedDeltaTime);
        }
    }
}
