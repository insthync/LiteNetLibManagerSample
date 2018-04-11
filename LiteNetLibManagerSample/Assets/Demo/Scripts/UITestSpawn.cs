using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITestSpawn : MonoBehaviour
{
    public InputField spawnX;
    public InputField spawnY;
    public InputField spawnZ;

    public void OnClickSpawn()
    {
        var prefab = CustomNetworkManager.Singleton.Assets.spawnablePrefabs[0].gameObject;
        CustomNetworkManager.Singleton.Assets.NetworkSpawn(prefab, new Vector3(float.Parse(spawnX.text), float.Parse(spawnY.text), float.Parse(spawnZ.text)), Quaternion.identity);
    }
}
