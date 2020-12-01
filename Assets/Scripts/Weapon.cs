using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _maxMagazine;
    private int _currentMagazine;
    private Stack<Bullet> _bulletStack;
    private AudioSource _audio;
    private Animator _animator;

    public void Awake()
    {
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _bulletStack = new Stack<Bullet>(_maxMagazine*2);
        _currentMagazine= _maxMagazine;
        for (int i = 0; i < (_maxMagazine*2); i++)
        {
            var bullet = Instantiate(_bulletPrefab);
            bullet.Owner = this;
            _bulletStack.Push(bullet);
            bullet.gameObject.SetActive(false);
        }
    }

    public void Shoot(Vector3 target)
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Base"))
        {
            if (_currentMagazine > 0)
            {
                var bullet = _bulletStack.Pop();
                bullet.gameObject.SetActive(true);
                bullet.transform.position = _shootPoint.position;
                bullet.transform.LookAt(target);
                _currentMagazine--;
            //    GameManager.gm.setAmmoCanvas(_currentMagazine);
                _animator.SetTrigger("Shoot");
            }
            else
            {
                _animator.SetTrigger("NoAmmo");
            }
        }
    }

    public void GetBackBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bulletStack.Push(bullet);
    }

    public void Reload()
    {
        if (_currentMagazine < _maxMagazine && _animator.GetCurrentAnimatorStateInfo(0).IsName("Base"))
        {
            _currentMagazine = _maxMagazine;
            _animator.SetTrigger("Reload");
            GameManager.gm.setAmmoCanvas(_currentMagazine);
        }
    }

    public void PlayWeaponSound(string whichSound)
    {
        switch (whichSound)
        {
            case "Shoot":
                _audio.PlayOneShot(AudioManager.Instance.revolverShoot);
                break;
            case "NoAmmo":
                _audio.PlayOneShot(AudioManager.Instance.revolverNoAmo);
                break;
            case "Spin":
                _audio.clip = AudioManager.Instance.revolverSpin;
                _audio.Play();
                break;
            case "ReloadEnd":
                _audio.clip = AudioManager.Instance.revolverReloadEnd;
                _audio.Play();
                break;
            case "ReloadAmmo":
                _audio.clip = AudioManager.Instance.revolverReloadAmmo;
                _audio.Play();
                break;
        }
    }
}