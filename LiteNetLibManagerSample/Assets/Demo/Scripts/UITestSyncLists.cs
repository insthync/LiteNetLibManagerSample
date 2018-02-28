using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITestSyncLists : MonoBehaviour
{
    public CustomNetworkBehaviour behaviour;
    public InputField indexField;
    public InputField valueField;
    int tempIndex;
    int tempValue;

    void SetTempValues()
    {
        tempIndex = int.Parse(indexField.text);
        tempValue = int.Parse(valueField.text);
    }

    public void OnClickAdd()
    {
        SetTempValues();
        behaviour.testList1.Add(tempValue);
    }

    public void OnClickInsert()
    {
        SetTempValues();
        behaviour.testList1.Insert(tempIndex, tempValue);
    }

    public void OnClickSet()
    {
        SetTempValues();
        behaviour.testList1.Set(tempIndex, tempValue);
    }

    public void OnClickRemove()
    {
        SetTempValues();
        behaviour.testList1.RemoveAt(tempIndex);
    }

    public void OnClickClear()
    {
        behaviour.testList1.Clear();
    }

    public void OnClickPrint()
    {
        var list = behaviour.testList1;
        foreach (var item in list)
        {
            Debug.LogError(item + "\n");
        }
    }
}
