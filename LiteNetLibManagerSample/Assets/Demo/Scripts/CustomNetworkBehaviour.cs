using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLibHighLevel;

public class CustomNetworkBehaviour : LiteNetLibBehaviour
{
    public LiteNetLibSyncField<NetFieldInt, int> test1 = new LiteNetLibSyncField<NetFieldInt, int>();
    public SyncFieldInt test2;
    public SyncFieldInt test3;
    public SyncListInt testList1;

    private void Awake()
    {
        RegisterNetFunction("test1", new LiteNetLibFunction<NetFieldInt>(ServerFunctionCallback));
        RegisterNetFunction("test2", new LiteNetLibFunction<NetFieldInt>(TargetFunctionCallback));
        RegisterNetFunction("test3", new LiteNetLibFunction<NetFieldInt>(AllFunctionCallback));
        var syncFieldUI = FindObjectOfType<UITestSyncFields>();
        syncFieldUI.behaviour = this;
    }

    public void SendServerFunction()
    {
        Debug.LogError("SendServerFunction()");
        CallNetFunction("test1", FunctionReceivers.Server, 1);
    }

    public void SendTargetFunction()
    {
        Debug.LogError("SendTargetFunction()");
        CallNetFunction("test2", ConnectId, 2);
    }

    public void SendAllFunction()
    {
        Debug.LogError("SendAllFunction()");
        CallNetFunction("test3", FunctionReceivers.All, 3);
    }

    public void ServerFunctionCallback(NetFieldInt param1)
    {
        Debug.LogError("ServerFunctionCallback(" + (int)param1 + ")");
    }

    public void TargetFunctionCallback(NetFieldInt param1)
    {
        Debug.LogError("TargetFunctionCallback(" + (int)param1 + ")");
    }

    public void AllFunctionCallback(NetFieldInt param1)
    {
        Debug.LogError("AllFunctionCallback(" + (int)param1 + ")");
    }
}
