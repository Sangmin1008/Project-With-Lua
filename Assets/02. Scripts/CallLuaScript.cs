using System;
using UnityEngine;
using MoonSharp.Interpreter;

public class CallLuaScript : MonoBehaviour
{
    private void Start()
    {
        Script.DefaultOptions.DebugPrint = s => Debug.Log(s);

        string scriptCode = @"
            function hello()
                print('Hello from Lua!')
            end
            hello()
        ";
        
        Script script = new Script();
        script.DoString(scriptCode);
    }
}
