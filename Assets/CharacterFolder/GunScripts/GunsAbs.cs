using System.Collections;
using UnityEngine;

public abstract class GunsAbs : MonoBehaviour, IAudio
{
    
    [SerializeField]
    protected int _bulletCount;
    [SerializeField]
    protected int _maxBullets;
    
    protected int _bulletCharge;
    
    protected int _mediumBullets;
    [SerializeField]
    public int charge;
    [SerializeField]
    protected int _maxCharge;

    [SerializeField]
    protected float gunDmg;

    public LayerMask maskAtack;

    public GameObject entity;

    public GameObject bullet;

    [SerializeField]
    protected float _shootD = 0.2f;
    [SerializeField]
    protected float _lastBullet;

    public bool shooting;

    private AudioSource _audioSource;

    protected virtual void Charge()
    {
        if (Input.GetKeyDown(KeyCode.R) && charge >= 1)
        {

            charge--;

            _mediumBullets = _maxBullets - _bulletCount;

            _bulletCount += _mediumBullets;
        }

    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    protected virtual void Update()
    {
        if (charge >= _maxCharge)
        {
            charge = _maxCharge;
        }

        Shoot();
        Charge();
    }

    protected virtual void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _bulletCount >= 1)
        {
            shooting = true;
            _audioSource.Play();
        }

        else if (Input.GetKeyUp(KeyCode.Mouse0) || _bulletCount <= 0)
        {
            shooting = false;
        }
        if (shooting != true)
        {
            return;
        }
        if (Time.time - _lastBullet > _shootD)
        {
            StartCoroutine(ShootingAuto());          
        }
        _lastBullet = Time.time;
    }

    protected abstract IEnumerator ShootingAuto();
    
    public void ShootPrimaryGun() 
    {
        
    }
    public void ShootSecondaryGun() { }
    public void Death() { }
    public void Hurt() { }
    public void DetenerAudio() { }

    
}
