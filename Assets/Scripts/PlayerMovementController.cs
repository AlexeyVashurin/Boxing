using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementController : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float speed = 10f;
    [SerializeField] private DynamicJoystick dynamicJoystick;
    
    private PlayerAnimationController animationController;
    
    private Vector3 velocity;
    private float gravity = -9.8f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        
        animationController = GetComponent<PlayerAnimationController>();
    }

    void Update()
    {
        float x = dynamicJoystick.Horizontal;
        float y = dynamicJoystick.Vertical;

        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        animationController.AnimateMove(x,y);
    }
}
