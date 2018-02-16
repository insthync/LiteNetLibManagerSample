using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITestSyncFields : MonoBehaviour
{
    public CustomNetworkBehaviour behaviour;
    public CustomNetworkBehaviour2 behaviour2;
    public CustomNetworkBehaviour behaviour3;
    public InputField field1;
    public InputField field2;
    public InputField field3;
    public Text value1;
    public Text value2;
    public Text value3;

    private void Update()
    {
        value1.text = ((int)behaviour.test1).ToString("N0");
        value2.text = ((int)behaviour2.a).ToString("N0");
        value3.text = ((int)behaviour3.test2).ToString("N0");
    }

    public void OnClickUpdateFields()
    {
        behaviour.test1.Value = int.Parse(field1.text);
        behaviour2.a.Value = int.Parse(field2.text);
        behaviour3.test2.Value = int.Parse(field3.text);
    }
}
