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
        RegisterSyncField("test1", test1);
        RegisterSyncField("test2", test2);
        RegisterSyncField("test3", test3);
        RegisterNetFunction("test1", new LiteNetLibFunction<FunctionParameterInt>(ServerFunctionCallback));
        RegisterNetFunction("test2", new LiteNetLibFunction<FunctionParameterInt>(TargetFunctionCallback));
        RegisterNetFunction("test3", new LiteNetLibFunction<FunctionParameterInt>(AllFunctionCallback));
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

    public void ServerFunctionCallback(FunctionParameterInt param1)
    {
        Debug.LogError("ServerFunctionCallback(" + (int)param1 + ")");
    }

    public void TargetFunctionCallback(FunctionParameterInt param1)
    {
        Debug.LogError("TargetFunctionCallback(" + (int)param1 + ")");
    }

    public void AllFunctionCallback(FunctionParameterInt param1)
    {
        Debug.LogError("AllFunctionCallback(" + (int)param1 + ")");
    }
}
