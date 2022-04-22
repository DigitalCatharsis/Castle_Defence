using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;  //

[DefaultExecutionOrder(-1)]  //edit -> project setting -> script execution order

public class InputManager : Singleton<InputManager>
{

    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;
    private TouchControls touchControls;
     
    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Start()
    {
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);   //when we starting pressing down on the screen      ctx:https://docs.unity3d.com/ScriptReference/ContextMenu.htmls
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);   //when we ending pressing down on the screen      ctx:https://docs.unity3d.com/ScriptReference/ContextMenu.htmls
    }


    private void StartTouch(InputAction.CallbackContext context)     //InputAction.CallbackContext:https://docs.unity3d.com/Packages/com.unity.inputsystem%401.0/api/UnityEngine.InputSystem.InputAction.CallbackContext.html
    { //this context return the information about our touch
        Debug.Log("Touch started" + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        if (OnStartTouch != null)
        {
            OnStartTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
        }
    }
    private void EndTouch(InputAction.CallbackContext context)     //InputAction.CallbackContext:https://docs.unity3d.com/Packages/com.unity.inputsystem%401.0/api/UnityEngine.InputSystem.InputAction.CallbackContext.html
    {
        Debug.Log("Touch ended" + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        if (OnEndTouch != null)
        {
            OnEndTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
        }
    }

}
