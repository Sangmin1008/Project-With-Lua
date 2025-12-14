using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelPieces", menuName = "Scriptable Objects/Level Pieces", order = 1)]
public class LevelPieces : ScriptableObject
{
    [SerializeField] private List<GameObject> levelPieces = new List<GameObject>();
    
    private readonly List<string> _levelPieceNames = new List<string>();
    private Dictionary<string, GameObject> _levelPiecesDict;

    public List<string> LevelPieceNames => _levelPieceNames;
    public Dictionary<string, GameObject> LevelPiecesDict => _levelPiecesDict;

    private void OnEnable()
    {
        _levelPiecesDict = new Dictionary<string, GameObject>();
        foreach (var piece in levelPieces)
        {
            _levelPieceNames.Add(piece.name);
            _levelPiecesDict.Add(piece.name, piece);
        }
    }

    public GameObject GetPrefabByName(string pieceName)
    {
        return _levelPiecesDict.GetValueOrDefault(pieceName);
    }
}
