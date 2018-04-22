using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System;
using Assets._Scripts.AttachedToObjects.Weapons;

public class PlayerShooting : MonoBehaviour
{
    public float LoadedBullets { private set; get; }
    public bool Reloading { get; set; }

    public GameObject cloneBullet;
    public GameObject WeaponAttached;

    private Firearm weapon;
    private Transform bulletSpawn;

    private Text reloadText;
    private Text reloadingText;

    private float BetweenShootsTimer = 0f;

    private void Awake()
    {
        //create weapon dictionary wrapper
        if (WeaponAttached.transform.name == "Pistol")
        {
            weapon = WeaponAttached.GetComponent<Pistol>();
        }

        bulletSpawn = GameObject.Find("BulletSpawnPoint").GetComponent<Transform>();
        reloadText = GameObject.Find("ReloadText").GetComponent<Text>();
        reloadingText = GameObject.Find("ReloadingText").GetComponent<Text>();;
    }

    void Start()
    {
        LoadedBullets = weapon.MaximumMagazineCapacity;
        reloadingText.enabled = false;
        reloadText.enabled = false;
    }

    void Update()
    {
        AutoReloading(false);
        BetweenShootsTimer += Time.deltaTime;
    }

    private void AutoReloading(bool activated)
    {
        if (LoadedBullets == 0 && activated)
        {
            Reload();
        }

        if (LoadedBullets == 0 && !activated)
        {
            reloadText.enabled = true;
        }
    }

    public void Reload()
    {
        if (LoadedBullets == weapon.MaximumMagazineCapacity)   //max loaded
        {
            return;
        }

        reloadText.enabled = false;         //disable reload request text
        reloadingText.enabled = true;       //enable reloading information text

        if (!IsInvoking("InsertBullet"))    
        {
            InvokeRepeating("InsertBullet", 0f, weapon.BulletInsertTime);
        }
    }

    private void InsertBullet()
    {
        if(LoadedBullets == weapon.MaximumMagazineCapacity)  //RepeatInvoking till full loaded 
        {
            InteruptBulletInsertion();
            return;
        }

        LoadedBullets++;
        weapon.ReloadSound.Play();
    }

    private void InteruptBulletInsertion()
    {
        CancelInvoke("InsertBullet");
        reloadingText.enabled = false;
    }

    public void Shoot()
    {
        if (IsInvoking("InsertBullet"))
        {
            return;
        }

        if (LoadedBullets <= 0)
        {
            return;
        }

        if (BetweenShootsTimer > weapon.ShootCooldownTime)
        {
            Instantiate(cloneBullet, bulletSpawn.transform.position, Quaternion.identity);
            weapon.ShootSound.Play();
            LoadedBullets--;
            BetweenShootsTimer = 0f;
        }
    }

}
