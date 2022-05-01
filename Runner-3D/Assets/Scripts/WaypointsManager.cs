using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
    [SerializeField] private Waypoint StartWaypoint;
    [SerializeField] private Waypoint FinishWaypoint;
    [SerializeField] private List<Waypoint> waypoints;
    [Space]
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            player.position += Vector3.forward * Time.deltaTime * speed;
            // character.Move(Vector3.forward * Time.deltaTime * speed); 
        }
    }
}
