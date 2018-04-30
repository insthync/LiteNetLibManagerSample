using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiteNetLibDemoUIGameplay : MonoBehaviour {
    public static LiteNetLibDemoUIGameplay Singleton { get; private set; }
    public Toggle[] activeBulletTypes;
    public Text hp;

    private void Awake()
    {
        Singleton = this;
    }

    public void SetActiveBulletType(int bulletType)
    {
        foreach (var activeBulletType in activeBulletTypes)
            activeBulletType.isOn = false;

        if (bulletType >= 0 && bulletType < activeBulletTypes.Length)
            activeBulletTypes[bulletType].isOn = true;
    }

    public void SetHp(int amount)
    {
        hp.text = amount.ToString("N0");
    }
}
