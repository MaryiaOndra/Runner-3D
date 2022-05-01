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

    private int _nextPositionIndex;
    private Transform _nextPointTransform;
    private bool _isFinish;

    private void Start()
    {
        waypoints.Insert(0, StartWaypoint);
        waypoints.Insert(waypoints.Count, FinishWaypoint);
        _nextPointTransform = StartWaypoint.transform;
        player.transform.position = _nextPointTransform.position;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !_isFinish)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        if (Vector3.Distance(player.transform.position, _nextPointTransform.position)
            <= 0.1f)
        {
            _nextPositionIndex++;

            if (_nextPositionIndex > waypoints.Count)
            {
                _isFinish = true;
                Debug.Log("YOU WIN!");
            }
            _nextPointTransform = waypoints[_nextPositionIndex].gameObject.transform;
        }
        else
        {
            player.position = Vector3.MoveTowards(player.transform.position,
                _nextPointTransform.position, speed * Time.deltaTime);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(_nextPointTransform.position), Time.deltaTime * 10f);
        }
    }
}
