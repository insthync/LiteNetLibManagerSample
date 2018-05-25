﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLibManager;

public class LiteNetLibDemoCharacter : LiteNetLibBehaviour
{
    public SyncFieldInt hp;
    public int bulletType;
    public int maxHp = 100;
    public float rotateSpeed = 150f;
    public float moveSpeed = 5f;
    public LiteNetLibDemoBullet[] bullets;

    private void Awake()
    {
        bulletType = 0;
    }

    private void Start()
    {
        if (IsOwnerClient)
        {
            var followCam = FindObjectOfType<FollowCameraControls>();
            followCam.target = transform;
        }
        if (IsServer)
            hp.Value = maxHp;
    }

    public override void OnSetup()
    {
        base.OnSetup();
        RegisterNetFunction("Shoot", new LiteNetLibFunction<NetFieldInt>((bulletType) => SpawnBullet(bulletType)));
        RegisterNetFunction("RespawnAtPoint", new LiteNetLibFunction<NetFieldVector3>((position) => RespawnAtPoint(position)));
    }

    private void Update()
    {
        if (IsOwnerClient)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);

            if (Input.GetKeyDown(KeyCode.Alpha1))
                bulletType = 0;

            if (Input.GetKeyDown(KeyCode.Alpha2))
                bulletType = 1;

            if (Input.GetKeyDown(KeyCode.Alpha3))
                bulletType = 2;

            if (Input.GetKeyDown(KeyCode.Space))
                Shoot();

            LiteNetLibDemoUIGameplay.Singleton.SetActiveBulletType(bulletType);
            LiteNetLibDemoUIGameplay.Singleton.SetHp(hp.Value);
        }
        if (IsServer && hp.Value <= 0)
            Respawn();
    }

    public void SpawnBullet(int bulletType)
    {
        if (!IsServer || bulletType < 0 || bulletType >= bullets.Length)
            return;
        var bullet = bullets[bulletType];
        var bulletIdentity = Manager.Assets.NetworkSpawn(bullet.gameObject, transform.position, transform.rotation);
        var bulletComp = bulletIdentity.GetComponent<LiteNetLibDemoBullet>();
        bulletComp.attacker = this;
    }

    public void RespawnAtPoint(Vector3 position)
    {
        transform.position = position;
    }

    public void Shoot()
    {
        CallNetFunction("Shoot", FunctionReceivers.Server, bulletType);
    }

    void Respawn()
    {
        hp.Value = maxHp;
        CallNetFunction("RespawnAtPoint", ConnectId, Manager.Assets.GetPlayerSpawnPosition());
    }
}