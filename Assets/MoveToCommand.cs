using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveToCommand : Command
{
    private GameObject unit;
    private float x_before;
    private float z_before;
    private float x;
    private float z;
    public MoveToCommand(GameObject _unit, float _x, float _z)
    {
        unit = _unit;
        x = _x;
        z = _z;
    }
    public override void execute()
    {
        x_before = unit.transform.position.x;
        z_before = unit.transform.position.z;
        
        Vector3 targetPosition = new Vector3(x, 0, z);
        unit.transform.position = targetPosition;
    }
    public override void undo()
    {
        Vector3 targetPosition = new Vector3(x_before, 0, z_before);
        unit.transform.position = targetPosition;
    }
}
