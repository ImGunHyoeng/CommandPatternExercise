using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Command buttonForward;
    Command buttonBackward;
    Command buttonLeft;
    Command buttonRight;
    Command buttonMoveTo;
    Vector2 mouseScreenPosition;
    Vector3 mouseWorldPosition;
    List<Command> commands;
    bool isReplaying;

    public int moveDistance;
    // Start is called before the first frame update
    void Start()
    {
        commands=new List<Command>();
        isReplaying = false;
    }
    IEnumerator Replay()
    {
        commands[0].undo();
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < commands.Count; i++)
        {
            commands[i].execute();
            yield return new WaitForSeconds(0.5f);
        }
        isReplaying = false;
    }
    // Update is called once per frame
    void Update()
    {   
        if (isReplaying)
            return;
        if (Input.GetMouseButtonDown(1))
        {
            isReplaying = true;
            StartCoroutine(Replay());
            return;
        }
        mouseScreenPosition = Input.mousePosition;
        if (Input.GetKeyDown(KeyCode.W))
        {
            buttonForward= new MoveForwardCommand(this.gameObject, moveDistance, 0);
            buttonForward.execute();
            commands.Add(buttonForward);
            return;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            buttonLeft = new MoveLeftCommand(this.gameObject, 0, moveDistance);
            buttonLeft.execute();
            commands.Add(buttonLeft);
            return;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            buttonBackward = new MoveBackwardCommand(this.gameObject, -moveDistance, 0);
            buttonBackward.execute();
            commands.Add(buttonBackward);
            return;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            buttonRight = new MoveRightCommand(this.gameObject, 0, -moveDistance);
            buttonRight.execute();
            commands.Add(buttonRight); 
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit hit))
            {
                buttonMoveTo = new MoveToCommand(this.gameObject, hit.point.x, hit.point.z);
                buttonMoveTo.execute();
                commands.Add(buttonMoveTo);
            }
            return;
        }

    }
}
