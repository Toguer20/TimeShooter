﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManagerTimePos : StackManager
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
        TargetTimePos.Deleted += Reinstantiate;
    }
    void OnDisable()
    {
        TargetTimePos.Deleted -= Reinstantiate;
    }
}
