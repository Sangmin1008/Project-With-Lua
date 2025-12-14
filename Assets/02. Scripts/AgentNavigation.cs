using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class AgentNavigation : MonoBehaviour
{
    [SerializeField] private string goalTag = "Goal";
    [SerializeField] private GameObject backpack;

    private readonly List<GameObject> _collectedGoals = new();
    private GameObject _currentGoal;
    private List<GameObject> _goals;
    private NavMeshAgent _agent;

    private void Awake()
    {
        GameManager.OnGameStart += OnGameStart;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnDestroy()
    {
        GameManager.OnGameStart -= OnGameStart;
    }

    private void OnGameStart()
    {
        _goals = GameObject.FindGameObjectsWithTag(goalTag).ToList();
        UpdateDestination();
    }

    private void UpdateDestination()
    {
        _goals.RemoveAll(goal => _collectedGoals.Contains(goal));
        if (_goals.Count == 0)
            return;
        
        _currentGoal = _goals[UnityEngine.Random.Range(0, _goals.Count)];
        
        if (!_agent.SetDestination(_currentGoal.transform.position))
            Debug.LogError("Goal이 존재하지 않음");
    }
    
    private void AddToBackpack(Transform other)
    {
        var goalTransform = other;
        goalTransform.SetParent(backpack.transform);
        goalTransform.localPosition = UnityEngine.Random.insideUnitSphere * 0.5f;
        goalTransform.localRotation = UnityEngine.Random.rotation;
    }

    private void HandleGoal(Collider other)
    {
        _collectedGoals.Add(other.gameObject);
        AddToBackpack(other.gameObject.transform);
        
        if (other.gameObject == _currentGoal)
            UpdateDestination();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(goalTag))
        {
            HandleGoal(other);
        }
    }
}
