using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bullet;
    public bool canShoot;
    public float timeBetweenShots = 1;
    private float timeUntilNextShot;
    public AudioClip bulletSound;


    public PlayerController pc;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeUntilNextShot)
        {
            canShoot = true;
        }
        if (Input.GetMouseButtonDown(0) && canShoot && pc.isDead == false)
        {
            canShoot = false;
            timeUntilNextShot = Time.time + timeBetweenShots;
            Instantiate(bullet, this.transform.position, this.transform.rotation);
            AudioSource.PlayClipAtPoint(bulletSound, transform.position);

        }
    }
}