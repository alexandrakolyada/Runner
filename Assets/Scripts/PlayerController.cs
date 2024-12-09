using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour //дозволяє використовувати методи Unity
{
    private CharacterController controller;
    private Vector3 dir; //вектор для зберігання напрямку руху персонажа
    [SerializeField] private int speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;

    private int lineToMove = 1;
    public float lineDistance = 4;

    void Start()
    {
        controller = GetComponent<CharacterController>(); //Отримання компонента CharacterController, прикріпленого до персонажа
    }

    private void Update()
    {
        if (SwipeController.swipeRight)
        {
            if (lineToMove < 2)
                lineToMove++;
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0)
                lineToMove--;
        }

        if (SwipeController.swipeUp)
        {
            if  (controller.isGrounded)
            Jump();
        }

        //створення нової позиції після переміщення
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        //Переміщення по доріжках(вліво чи вправо)
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistance; // Рух ліворуч на lineDistance одиниць
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistance; // Рух праворуч на lineDistance одиниць

        transform.position = targetPosition; // Оновлення позиції персонажа

    }

    private void Jump()
    {
        dir.y = jumpForce;
    }

    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        controller.Move(dir * Time.fixedDeltaTime); //Переміщення персонажа на основі напрямку з урахуванням часу між кадрами 
    }
}
