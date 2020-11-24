using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StackManager : MonoBehaviour
{
    private int _numberOfObjects;
    protected int startingNumObjects;
    protected int incrementNumObjects;
    public Stack<GameObject> GameObjList;
    private float _timeToWait = 2f;
    public GameObject prefab;
    private int _objectsInGame = 0; //or not
    private Animator _animator;
    private bool raised = false;
    public int ObjectsInGame { get => _objectsInGame; set => _objectsInGame = value; }
    public int StartingNumObjects { get => startingNumObjects; }
    public int IncrementNumObjects { get => incrementNumObjects; }
    public int NumberOfObjects { get => _numberOfObjects; set => _numberOfObjects = value; }

    public virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        GameObjList = new Stack<GameObject>();
    }
    public virtual void Reinstantiate(GameObject go)
    {
        Push(go);
        StartCoroutine(WaitABit());
    }
    public virtual IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(_timeToWait);
        if (_objectsInGame < _numberOfObjects)
        {
            if (Peek() != null)
            {
                Pop();
            }
            else
            {
                Instantiate(prefab);
            }
            _objectsInGame++;
        }
    }
    public virtual void Push(GameObject go)
    {
        _objectsInGame--;
        go.SetActive(false);
        GameObjList.Push(go);
    }
    public virtual void Pop()
    {
        GameObjList.Peek().SetActive(true);
        GameObjList.Pop();
    }
    public virtual GameObject Peek()
    {
        return (GameObjList.Peek());
    }
    void Update()
    {
        if (Time.time > GameManager.gm.startRaiseState && !raised)
        {
            _animator.SetTrigger("raiseDif");
            raised = true;
        }
    }
}
