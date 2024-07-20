using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitSelected = new List<GameObject>();

    private static UnitSelections _instance;

    public static UnitSelections Instance {  get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(_instance);
        }
        else
        {
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unitToAdd)
    {

    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {

    }

    public void DragSelect(GameObject unitToAdd)
    {

    }

    public void DeselectAll()
    {

    }

    public void Deselect(GameObject unitToDeselect)
    {

    }

}
