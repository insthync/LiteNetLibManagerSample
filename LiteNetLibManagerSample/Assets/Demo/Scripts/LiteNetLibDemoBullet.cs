using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLibManager;

public class LiteNetLibDemoBullet : LiteNetLibBehaviour
{
    public int damage = 5;
    public float moveSpeed = 5;
    public float lifeTime = 10f;
    public LiteNetLibDemoCharacter attacker;
    private void Start()
    {
        NetworkDestroy(lifeTime);
    }

    private void Update()
    {
        if (!IsServer)
            return;
        
        GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsServer)
            return;
        var character = other.gameObject.GetComponent<LiteNetLibDemoCharacter>();
        if (character == null || character == attacker)
            return;
        character.hp.Value -= damage;
        NetworkDestroy();
    }
}
