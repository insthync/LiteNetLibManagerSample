using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLibHighLevel;

public class CustomNetworkBehaviour : LiteNetLibBehaviour
{
    public SyncFieldInt test1;
    public SyncFieldInt test2;
    public SyncFieldInt test3;

    private void Awake()
    {
        RegisterSyncField(1, test1);
        RegisterSyncField(2, test2);
        RegisterSyncField(3, test3);
        var syncFieldUI = FindObjectOfType<UITestSyncFields>();
        syncFieldUI.behaviour = this;
    }
}
