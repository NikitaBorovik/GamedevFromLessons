using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputSystemListener
{
    void UserClick(Vector3 position);
    void UserMovement(Vector3 movement);

    void UserJump();
}
