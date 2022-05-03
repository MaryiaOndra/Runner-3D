using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Platform
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Start()
        {
            transform.DOLocalMoveX(transform.position.x * -1, speed).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
