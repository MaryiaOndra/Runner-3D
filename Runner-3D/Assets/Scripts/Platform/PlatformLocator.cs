using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLocator : MonoBehaviour
{
    [SerializeField] private Transform startLeftPoint;
    [SerializeField] private Transform startRightPoint;
    [SerializeField] private Transform endLeftPoint;
    [SerializeField] private Transform endRightPoint;

    public Transform StartLeftPoint => startLeftPoint;
    public Transform StartRightPoint => startRightPoint;
    public Transform EndLeftPoint => endLeftPoint;
    public Transform EndRightPoint => endRightPoint;
}
