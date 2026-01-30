using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

enum SceneEnum
{
    Level0,
    Level1,
    Level2,
}

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private List<SceneAsset> scenes;
}
