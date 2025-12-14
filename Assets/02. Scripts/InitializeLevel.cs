using System;
using System.IO;
using MoonSharp.Interpreter;
using UnityEngine;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField] private string luaScriptFileName = "level_0";
    [SerializeField] private LevelPieces levelPieces;

    private string _luaScript;
    private Script _script = new Script();
    

    private bool LoadScriptContents()
    {
        string path = Path.Combine(Application.streamingAssetsPath, luaScriptFileName + ".lua");
        if (File.Exists(path))
        {
            _luaScript = File.ReadAllText(path);
            Debug.Log("Loaded LUA Script: " + luaScriptFileName);
            return true;
        }
        
        Debug.LogError("Failed to find LUA script!");
        return false;
    }

    private void RunScript()
    {
        _script.DoString(_luaScript);
    }

    public void Start()
    {
        SetupLuaVariables();
        if (LoadScriptContents())
            RunScript();
        GameManager.Instance.LevelLoaded();
    }

    private void SetupLuaVariables()
    {
        _script = ScriptRunner.Instance.GetScript();
        
        _script.Globals["levelPieces"] = levelPieces.LevelPieceNames;
        _script.Globals["SpawnLevelPiece"] = (Action<string, Vector3, Quaternion>)SpawnLevelPiece;
    }

    public void SpawnLevelPiece(string pieceName, Vector3 position, Quaternion rotation)
    {
        var prefab = levelPieces.GetPrefabByName(pieceName);
        if (prefab != null) 
            Instantiate(prefab, position, rotation);
        else
        {
            Debug.LogError($"Prefab {pieceName} not found!");
        }
    }
}
