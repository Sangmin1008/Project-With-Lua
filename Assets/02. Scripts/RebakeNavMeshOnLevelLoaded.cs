using System;
using Unity.AI.Navigation;
using UnityEngine;

public class RebakeNavMeshOnLevelLoaded : MonoBehaviour
{
    private void Awake()
    {
        GameManager.OnLevelLoaded += OnLevelLoaded;
    }


    private void OnLevelLoaded()
    {
        NavMeshSurface surface = GetComponent<NavMeshSurface>();
        surface.BuildNavMesh();
    }
}
