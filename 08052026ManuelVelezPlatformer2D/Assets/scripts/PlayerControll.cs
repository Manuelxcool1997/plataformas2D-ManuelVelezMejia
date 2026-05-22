using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class PlayerControll : MonoBehaviour
{
    Charactercontroller2D charactercontroller2D;
    [SerializeField] InputActionReference move;
     [SerializeField] InputActionReference jump;
     Life life;
   [SerializeField] Transform startPosition;
      [SerializeField] InputActionReference punch;// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        charactercontroller2D=GetComponent<Charactercontroller2D>();
         
         life=GetComponent<Life>();
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
     void OnEnable()
    {
        move.action.Enable();
        punch.action.Enable();
        jump.action.Enable();
        move.action.performed+=OnMove;
        move.action.started+=OnMove;
        move.action.canceled+=OnMove;

        punch.action.performed+=OnPunch;
         jump.action.performed+=OnJump;
         life.OnLifeDepleted.AddListener(OnLifeDepleted);
    }

    void OnDisable()
    {
        move.action.Disable();
        punch.action.Disable();
        jump.action.Disable();
        move.action.performed-=OnMove;
        move.action.started-=OnMove;
        move.action.canceled-=OnMove;

        punch.action.performed-=OnPunch;
         jump.action.performed-=OnJump;
             life.OnLifeDepleted.RemoveListener(OnLifeDepleted);
    }

    private void OnLifeDepleted(float arg0)
    {
        gameObject.SetActive(false);
        Invoke(nameof(Resurrect),3f);
    }
    void Resurrect()
    {
        gameObject.SetActive(true);
        gameObject.transform.position=startPosition.position;
        life.Restart();
    }

    Vector2 rawMove;
    void OnMove(InputAction.CallbackContext obj)
    {
        rawMove=obj.ReadValue<Vector2>();
         charactercontroller2D.SetRawmove(rawMove);
    }
     void OnPunch(InputAction.CallbackContext obj)
    {
        Debug.Log("punch");
        charactercontroller2D.Punch();
    }
      public void OnJump(InputAction.CallbackContext obj)
    {
        charactercontroller2D.Jump();
    }
}
