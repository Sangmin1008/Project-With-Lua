using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static event Action OnLevelLoaded;
    public static event Action OnGameStart;

    public void LevelLoaded()
    {
        OnLevelLoaded?.Invoke();
        OnGameStart?.Invoke();
    }
}
