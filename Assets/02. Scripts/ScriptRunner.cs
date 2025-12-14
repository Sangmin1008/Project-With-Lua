using System;
using UnityEngine;
using MoonSharp.Interpreter;

public class ScriptRunner : Singleton<ScriptRunner>
{
    private readonly Script _script = new Script();

    protected override void Awake()
    {
        base.Awake();
        
        Script.DefaultOptions.DebugPrint = s => Debug.Log(s);
        _script.Globals["print"] = (Action<DynValue>)CustomPrint;

        UserData.RegisterType<Vector3>();
        _script.Globals["Vector3"] = (Func<float, float, float, Vector3>)((x, y, z) => new Vector3(x, y, z));
        
        UserData.RegisterType<Quaternion>();
        _script.Globals["Quaternion"] = new Table(_script);
        
        _script.Globals.Get("Quaternion").Table["identity"] = Quaternion.identity;
        _script.Globals.Get("Quaternion").Table["Euler"] = (Func<float, float, float, Quaternion>)((x, y, z) => Quaternion.Euler(x, y, z));
        
    }

    private void Start()
    {
        _script.DoString("print('Hello from Lua!')");
    }

    private void CustomPrint(DynValue value)
    {
        Debug.Log(value.ToPrintString());
    }

    public Script GetScript()
    {
        return Instance._script;
    }
}
