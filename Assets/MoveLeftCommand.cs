using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCommand : Command
{
    private GameObject unit;
    private float x_before;
    private float z_before;
    private float x;
    private float z;
    public MoveLeftCommand(GameObject curObject, float _x, float _z)
    {
        unit = curObject;
        x = _x;
        z = _z;
    }
    public override void execute()
    {
  
        x_before = unit.transform.position.x;
        z_before = unit.transform.position.z;
        Vector3 targetPosition = new Vector3(unit.transform.position.x + x, 0, unit.transform.position.z + z);
        unit.transform.position = targetPosition;
    }
    public override void undo()
    {
        Vector3 targetPosition = new Vector3(x_before, 0, z_before);
        unit.transform.position = targetPosition;
    }
}
