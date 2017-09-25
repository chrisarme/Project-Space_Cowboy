using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Vector3 bulletScale;

    void Setup()
    {
        
    }

    void Update()
    {
        //bulletPrefab = GameObject.FindWithTag("Bullet");
        bulletSpawn = GameObject.FindWithTag("Bullet").transform;

        /*if (!isLocalPlayer)
        {
            return;
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }


    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var newBullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        bulletScale = newBullet.transform.localScale;
        bulletScale.x = .2f;
        bulletScale.y = .2f;
        bulletScale.z = .2f;

        newBullet.transform.localScale = bulletScale;


        // Add velocity to the bullet
        newBullet.GetComponent<Rigidbody>().isKinematic = false;

        newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * 20;

        // Destroy the bullet after 2 seconds
        Destroy(newBullet, 2.0f);
    }

   /* public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }*/
}
