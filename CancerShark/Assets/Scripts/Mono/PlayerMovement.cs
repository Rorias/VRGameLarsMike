using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private bool swimmingUp = false;
    private bool swimmingDown = false;

    public CharacterController cc;

    public InputActionReference swimUpReference;
    public InputActionReference swimDownReference;

    private void Awake()
    {
        swimUpReference.action.started += StartSwimUp;
        swimUpReference.action.canceled += EndSwimUp;

        swimDownReference.action.started += StartSwimDown;
        swimDownReference.action.canceled += EndSwimDown;
    }

    private void OnDestroy()
    {
        swimUpReference.action.started -= StartSwimUp;
        swimUpReference.action.canceled -= EndSwimUp;

        swimDownReference.action.started -= StartSwimDown;
        swimDownReference.action.canceled -= EndSwimDown;
    }

    private void Update()
    {
        if (swimmingUp)
        {
            cc.Move(new Vector3(0, 0.05f, 0));
        }

        if (swimmingDown)
        {
            cc.Move(new Vector3(0, -0.05f, 0));
        }
    }

    private void StartSwimUp(InputAction.CallbackContext _context)
    {
        swimmingUp = true;
    }

    private void EndSwimUp(InputAction.CallbackContext _context)
    {
        swimmingUp = false;
    }

    private void StartSwimDown(InputAction.CallbackContext _context)
    {
        swimmingDown = true;
    }

    private void EndSwimDown(InputAction.CallbackContext _context)
    {
        swimmingDown = false;
    }
}
