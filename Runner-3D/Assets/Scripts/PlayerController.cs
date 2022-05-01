using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController character;
    [SerializeField] private float speed = 1f;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.position += Vector3.forward * Time.deltaTime*speed;
           // character.Move(Vector3.forward * Time.deltaTime * speed); 
        }
    }
}
