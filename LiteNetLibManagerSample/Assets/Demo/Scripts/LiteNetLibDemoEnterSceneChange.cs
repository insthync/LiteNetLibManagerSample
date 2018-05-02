using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLibManager;

public class LiteNetLibDemoEnterSceneChange : MonoBehaviour
{
    public LiteNetLibScene scene;

    // Update is called once per frame
    void Update()
    {
        var networkManager = FindObjectOfType<LiteNetLibGameManager>();
        if (networkManager != null && Input.GetKeyDown(KeyCode.F1))
            networkManager.ServerSceneChange(scene.SceneName);
    }
}
