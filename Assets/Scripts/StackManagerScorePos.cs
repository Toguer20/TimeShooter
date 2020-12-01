using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManagerScorePos : StackManager
{
    public override void Awake()
    {
        base.Awake();
        NumberOfObjects = 1;
        startingNumObjects = 1;
        incrementNumObjects = -1;
        while (ObjectsInGame < NumberOfObjects)
        {
            Instantiate(prefab);
            ObjectsInGame++;
        }
    }
    void OnEnable()
    {
        TargetScorePos.Deleted += Reinstantiate;
    }
    void OnDisable()
    {
        TargetScorePos.Deleted -= Reinstantiate;
    }
}
