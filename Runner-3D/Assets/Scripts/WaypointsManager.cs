using PathCreation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Runner.Level.Player;
using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;

    private PathCreator _pathCreator;
    private bool _isStopped;
    
    private void Awake()
    {
        _pathCreator = GetComponent<PathCreator>();
        Debug.Log(_pathCreator.path.GetPoint(0));
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _isStopped = false;
            player.Move(_pathCreator.path);
        }
        else if(!_isStopped)
        {
            _isStopped = true;
            player.Stop();
        }
    }
}
