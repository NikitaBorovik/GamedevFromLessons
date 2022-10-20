using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField]
    private List<MonoBehaviour> subscibersList;

    private List<IInputSystemListener> listenersList;

    private bool isInited;

    private void Start()
    {
        listenersList = new List<IInputSystemListener>();

        foreach (MonoBehaviour subscriber in subscibersList)
        {
            IInputSystemListener subscriberInterface = subscriber as IInputSystemListener;
            if(subscriberInterface != null)
            {
                listenersList.Add(subscriberInterface);
            }
            else
            {
                Debug.LogError("Type cast error, subscriber need to implement IInputSystemListener interface");
            }
        }
        isInited = true;
    }

    void Update()
    {
        if(isInited)
        {
            //mouse
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Input.mousePosition;
                foreach(IInputSystemListener listener in listenersList)
                {
                    listener.UserClick(mousePosition);
                }
            }

            if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {

            }

            //universal - wasd, arrows, controller
            float movementV = Input.GetAxis("Vertical");
            float movementH = Input.GetAxis("Horizontal");

            if (movementV != 0 || movementH != 0)
            {
                Vector3 movementDirection = new Vector3(movementH, 0, movementV);
                movementDirection.Normalize();

                foreach (IInputSystemListener listener in listenersList)
                {
                    listener.UserMovement(movementDirection);
                }
            }
        }
    }
}
