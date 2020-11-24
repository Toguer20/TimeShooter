using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LimitCubeSetter : MonoBehaviour
{
    //public const float OFFSET =7.47003f;
    public float limitXPos;
    public float limitXNeg;
    public float limitYPos;
    public float limitYNeg; // suelo
    public float limitZPos;
    public float limitZNeg;
    private float _A, _B, _C;
    private BoxCollider _rightPosX;
    private BoxCollider _leftNegX;
    private BoxCollider _upPosY;
    private BoxCollider _downNegY;
    private BoxCollider _frontPosZ;
    private BoxCollider _backNegZ;
    public float cube = 0;
    public static LimitCubeSetter Instance;
    private float _thikness = 2f;

    /*public float LimitXPos { get => limitXPos; set => limitXPos = value; }
    public float LimitXNeg { get => limitXNeg; set => limitXNeg = value; }
    public float LimitYPos { get => limitYPos; set => limitYPos = value; }
    public float LimitYNeg { get => limitYNeg; set => limitYNeg = value; }
    public float LimitZPos { get => limitZPos; set => limitZPos = value; }
    public float LimitZNeg { get => limitZNeg; set => limitZNeg = value; }*/

    void Start()
    {
        _rightPosX = gameObject.AddComponent<BoxCollider>();
        _rightPosX.isTrigger = true;
        _leftNegX = gameObject.AddComponent<BoxCollider>();
        _leftNegX.isTrigger = true;
        _upPosY = gameObject.AddComponent<BoxCollider>();
        _upPosY.isTrigger = true;
        _downNegY = gameObject.AddComponent<BoxCollider>();
        _downNegY.isTrigger = true;
        _frontPosZ = gameObject.AddComponent<BoxCollider>();
        _frontPosZ.isTrigger = true;
        _backNegZ = gameObject.AddComponent<BoxCollider>();
        _backNegZ.isTrigger = true;
        Instance = this;
        if (cube > 0) //asign all the dimensions at once. 
        {
            limitXPos = cube;
            limitXNeg = -cube;
            limitYPos = cube;
            limitYNeg = -cube; // suelo
            limitZPos = cube;
            limitZNeg = -cube;
        }
        _A = limitXPos - limitXNeg;
        _B = limitYPos - limitYNeg;
        _C = limitZPos - limitZNeg;
        _rightPosX.size = new Vector3(_thikness, _B, _C);
        _rightPosX.center = new Vector3(limitXPos, limitYPos, 0);
        _leftNegX.size = new Vector3(_thikness, _B, _C);
        _leftNegX.center = new Vector3(limitXNeg, limitYPos, 0);
        _upPosY.size = new Vector3(_A, _thikness, _C);
        _upPosY.center = new Vector3(0, 2f * limitYPos, 0);
        _downNegY.size = new Vector3(_A, _thikness, _C);
        _downNegY.center = new Vector3(0, limitYPos + limitYNeg, 0);
        _frontPosZ.size = new Vector3(_A, _B, _thikness);
        _frontPosZ.center = new Vector3(0, limitYPos, limitZNeg);
        _backNegZ.size = new Vector3(_A, _B, _thikness);
        _backNegZ.center = new Vector3(0, limitYPos, limitZPos);
    }
}