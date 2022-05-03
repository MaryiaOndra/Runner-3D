using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Level", fileName = "LevelData")]
public class LevelData : ScriptableObject
{
    public PlatformLocator startPlatform;
    public PlatformLocator middlePlatform;
    public PlatformLocator finishPlatform;
}
