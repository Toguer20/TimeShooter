using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInstantiater : MonoBehaviour //mejorar fixedupdate
{
    private Vector3 _originalPosition;
    private Vector3 _direction;
    public float _speed; // mejorar
    private float _maxSpeed;
    private float _minSpeed = 1.5f;
    private LimitCubeSetter _lv; //instantiate
    private float _nextChange = 0;
    private float _cooldown = 1f;
    private float _sign = 1f;
    private float _timeValue = 3f;
    private readonly float _nerf = 0.02f;
    private float _minTime = 1.5f;
    private float _maxTime = 3f;
    //private MoveBehaviour mb;
    private float _reScaleY; //the cube is too high and some targets are too far
    private float _lessThanLimit;
    void Awake()
    {
        _lv = LimitCubeSetter.Instance;
        if (_lv != null)
        {
            //this.enabled = true;
            //mb = GetComponent<MoveBehaviour>();
            //Debug.Log(mb);
            _timeValue = Random.Range(_minTime, _maxTime);
            _reScaleY = _lv.limitYPos / 3f;
            _lessThanLimit = _lv.cube / 5f;
            _originalPosition = new Vector3(Random.Range(_lv.limitXNeg+ _lessThanLimit, _lv.limitXPos-_lessThanLimit), 
                Random.Range(0+ _lessThanLimit, 2f * (_lv.limitYPos-_reScaleY)- _lessThanLimit), 
                Random.Range(_lv.limitZNeg+ _lessThanLimit, _lv.limitZPos- _lessThanLimit)); //random original position
            transform.position = _originalPosition;
            float halfX = (_lv.limitXPos - _lv.limitXNeg) / 2; // function of limits (colliders);
            float halfY = (_lv.limitYPos - _lv.limitYNeg) / 2;
            float halfZ = (_lv.limitZPos - _lv.limitZNeg) / 2;
            if (transform.position.y > halfY)
                transform.Rotate(new Vector3(90f, 0, 0));   //hardCode
            //transform.localScale = new Vector3 (3f, 3f, 3f);
            float[] maxCandidates = { (_lv.limitXPos - _originalPosition.x), 
                (_originalPosition.x - _lv.limitXNeg), 
                (2f * (_lv.limitYPos- _reScaleY) - _originalPosition.y),
                (_originalPosition.y), (_lv.limitZPos - _originalPosition.z),
                (_originalPosition.z - _lv.limitZNeg) };
            float mx = Mathf.Max(maxCandidates); //mx is the nearest component to the respective limit
            int i = 0;
            bool found;
            do
            {
                found = mx == maxCandidates[i] ? true : false;
                i++;
            } while (i < 6 && !found); // i-1 is the component nearest to the respective limit 
            _maxSpeed = halfZ / _timeValue;
            if (i < 2) //if the space is a cube we can delete the if/else if from the code.
            {
                _maxSpeed = halfX / _timeValue;
            }
            else if (i < 4)
            {
                _maxSpeed = halfY / _timeValue;
            }
            switch (i)
            {
                case 1: //maxCandidates[0]...
                    _direction = Vector3.left; //( -1f, 0, 0); // if its closer to the limit, moves in the opposite direction.
                    _speed = _lv.limitXPos - _originalPosition.x != 0 ? Mathf.Lerp(_minSpeed, _maxSpeed, 
                        ((_lv.limitXPos - _originalPosition.x) - halfX) / halfX) : _maxSpeed; // lerp returns a value between maxSpeed and minSpeed depending on the distance to the limit, the farest the lowest.
                    break;
                case 2:
                    _direction = Vector3.right; //(1f, 0, 0);
                    _speed = _originalPosition.x - _lv.limitXNeg != 0 ? Mathf.Lerp(_minSpeed, _maxSpeed, 
                        ((_originalPosition.x - _lv.limitXNeg) - halfX) / halfX) : _maxSpeed;
                    break;
                case 3:
                    _direction = -Vector3.up;//( 0, -1f, 0);
                    _speed = _lv.limitYPos - _originalPosition.y != 0 ? Mathf.Lerp(_minSpeed, _maxSpeed, 
                        ((_lv.limitYPos - _originalPosition.y) - halfY) / halfY) : _maxSpeed;
                    break;
                case 4:
                    _direction = Vector3.up; //(0, 1f, 0);
                    _speed = _originalPosition.y - _lv.limitYNeg != 0 ? Mathf.Lerp(_minSpeed, _maxSpeed, 
                        ((_originalPosition.y - _lv.limitYNeg) - halfY) / halfY) : _maxSpeed;
                    break;
                case 5:
                    _direction = Vector3.back;//( 0, 0, -1f);
                    _speed = _lv.limitZPos - _originalPosition.z != 0 ? Mathf.Lerp(_minSpeed, _maxSpeed, 
                        ((_lv.limitZPos - _originalPosition.z) - halfZ) / halfZ) : _maxSpeed;
                    break;
                case 6:
                    _direction = Vector3.forward;//( 0, 0, 1f);
                    _speed = _originalPosition.z - _lv.limitZPos != 0 ? Mathf.Lerp(_minSpeed, _maxSpeed,
                        ((_originalPosition.z - _lv.limitZPos) - halfZ) / halfZ) : _maxSpeed;
                    break;
            }
            //mb.Speed = _speed;
        }
        else
            StartCoroutine(TryAgain());
    }
    void OnEnable()
    {
        Awake();
    }
    IEnumerator TryAgain()
    {
        yield return new WaitForSeconds(0.02f);
        Awake();
    }
    void FixedUpdate()
    {
        //if (mb != null)
            //mb.Move(_direction * _sign * _nerf);
        //else 
        transform.position += _direction * _sign * _nerf * _speed;
        if (Time.time % _timeValue <= _nerf && Time.time > _nextChange)
        {
            _sign = -_sign;
            _nextChange = Time.time + _cooldown;
        }
    }
}
