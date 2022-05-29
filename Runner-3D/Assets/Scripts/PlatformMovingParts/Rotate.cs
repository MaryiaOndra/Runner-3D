using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Axe axe;
    [SerializeField] private float speed;

    private Vector3 rotationAxe = new();
    private void Start()
    {
        rotationAxe = ChooseAxe();
    }

    private Vector3 ChooseAxe()
    {
        switch (axe)
        {
            case Axe.x:
                return  Vector3.right;
            case Axe.y:
                return  Vector3.up;
            case Axe.z:
                return  Vector3.forward;
            default: return Vector3.zero;;
        }
    }

    private void Update()
    {
        transform.RotateAround(transform.position, rotationAxe, speed * Time.deltaTime );
    }

    public enum Axe
    {
        x,
        y,
        z
    }
}
