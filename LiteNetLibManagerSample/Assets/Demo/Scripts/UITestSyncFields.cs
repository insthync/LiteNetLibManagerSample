using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITestSyncFields : MonoBehaviour {
    public CustomNetworkBehaviour behaviour;
    public InputField field1;
    public InputField field2;
    public InputField field3;
    public Text value1;
    public Text value2;
    public Text value3;

    private void Update()
    {
        value1.text = ((int)behaviour.test1).ToString("N0");
        value2.text = ((int)behaviour.test2).ToString("N0");
        value3.text = ((int)behaviour.test3).ToString("N0");
    }

    public void OnClickUpdateFields()
    {
        behaviour.test1.Value = int.Parse(field1.text);
        behaviour.test2.Value = int.Parse(field2.text);
        behaviour.test3.Value = int.Parse(field3.text);
    }
}
