using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

public class CharacterEffectController : MonoBehaviour
{
    [SerializeField] private GameObject _runSmoke;
    [SerializeField] private GameObject _mineShock;

    enum EffectStatus
    {
        RunSmoke,
        MineShock,
    }

    private Dictionary<EffectStatus, GameObject> effectObjects = new Dictionary<EffectStatus, GameObject>();

    void RemoveAll()
    {
        foreach (var effectset in effectObjects)
        {
            Destroy(effectset.Value);
        }
        effectObjects.Clear();
    }

    public void ResetEffect()
    {
        RemoveAll();
    }
    
    public void Smoke()
    {
        // RemoveAll();
        if (!effectObjects.ContainsKey(EffectStatus.RunSmoke))
        {
            var instance = GameObject.Instantiate(_runSmoke) as GameObject;
            effectObjects.Add(EffectStatus.RunSmoke, instance);
            SetTransform(instance);
        }
    }


    public void Mine()
    {
        RemoveAll();
        var instance = GameObject.Instantiate(_mineShock) as GameObject;
        effectObjects.Add(EffectStatus.MineShock, instance);
        SetTransform(instance);
    }

    void SetTransform(GameObject obj)
    {
        obj.transform.parent = this.gameObject.transform;
        obj.transform.position = this.gameObject.transform.position;
    }
}
