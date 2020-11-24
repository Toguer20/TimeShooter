using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManagerTimeNeg : StackManager
{
    public override void Awake()
    {
        base.Awake();
        NumberOfObjects = 3;
        startingNumObjects = 3;
        incrementNumObjects = +3;
        while (ObjectsInGame < NumberOfObjects)
        {
            Instantiate(prefab);
            ObjectsInGame++;
        }
    }
    void OnEnable()
    {
        TargetTimeNeg.Deleted += Reinstantiate;
    }
    void OnDisable()
    {
        TargetTimeNeg.Deleted -= Reinstantiate;
    }
}
