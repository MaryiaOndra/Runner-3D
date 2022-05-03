using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Level
{
    public class LevelCreator : MonoBehaviour
    {
        [SerializeField] private LevelData levelData;
        private GameObject _parentObject;

        private void Start()
        {
            _parentObject = new GameObject("Platforms");
            _parentObject.transform.parent = transform;


            var startPlatform = Instantiate(levelData.startPlatform, _parentObject.transform);
            var middlePlatform = Instantiate(levelData.middlePlatform, _parentObject.transform);
            var finishPlatform = Instantiate(levelData.finishPlatform, _parentObject.transform);



            var rightOffcet = startPlatform.EndRightPoint.position - middlePlatform.StartRightPoint.position;
            middlePlatform.transform.position += rightOffcet;

            var finishOffcet = middlePlatform.EndRightPoint.position - finishPlatform.StartRightPoint.position;
            finishPlatform.transform.position += finishOffcet;
            //middlePlatform.StartLeftPoint.transform.position = startPlatform.EndLeftPoint.transform.position;
            //middlePlatform.StartRightPoint.transform.position = startPlatform.EndRightPoint.transform.position;

            //finishPlatform.StartRightPoint.transform.position =
            //    middlePlatform.EndRightPoint.transform.position;
            //finishPlatform.StartLeftPoint.transform.position =
            //    middlePlatform.EndLeftPoint.transform.position;
        }
    }
}
