using PathCreation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
    [SerializeField] private Transform StartWaypoint;
    [SerializeField] private Transform FinishWaypoint;
    [SerializeField] private List<Transform> waypoints;
    [Space]
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    private int _nextPositionIndex;
    private Vector3 _nextPointTransform;
    private bool _isFinish;
    private VertexPath _vertexPath;
    float distanceTravelled;

    private void Start()
    {
        waypoints.Insert(0, StartWaypoint);
        waypoints.Insert(waypoints.Count, FinishWaypoint);
        _nextPointTransform = StartWaypoint.transform.position;
        player.transform.position = _nextPointTransform;

        Vector3[] waypointsArray = new Vector3[waypoints.Count];

        for (int i = 0; i < waypoints.Count; i++)
        {
            waypointsArray[i] = waypoints[i].position;
        }

        _vertexPath = GeneratePath(waypointsArray, false);
    }

    private VertexPath GeneratePath(Vector3[] points, bool closedPath)
    {
        BezierPath bezierPath = new BezierPath(points, closedPath, PathSpace.xyz);
        return new VertexPath(bezierPath, transform);
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
        if (_vertexPath != null)
        {
            distanceTravelled += speed * Time.deltaTime;
            player.position = _vertexPath.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
            player.rotation = _vertexPath.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
        }

        //if (Vector3.Distance(player.transform.position, _nextPointTransform)
        //    <= 0.1f)
        //{
        //    _nextPositionIndex++;

        //    if (_nextPositionIndex > waypoints.Count)
        //    {
        //        _isFinish = true;
        //        Debug.Log("YOU WIN!");
        //    }
        //    _nextPointTransform = waypoints[_nextPositionIndex];
        //}
        //else
        //{


        //    //player.position = Vector3.MoveTowards(player.transform.position,
        //    //    _nextPointTransform, speed * Time.deltaTime);
        //    //Vector3 newPos = new Vector3(_nextPointTransform.x, player.transform.position.y, _nextPointTransform.z);
        //    //player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(newPos), Time.deltaTime * 10f);
        //}
    }
}
