using UnityEngine;
using Photon.Pun;

public class PlayerShoot : MonoBehaviourPun
{
    public GameObject ammo;
    public Transform firePoint;
    public float ammoSpeed = 5;

    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject projectile = PhotonNetwork.Instantiate(ammo.name, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = firePoint.forward * ammoSpeed;
        }
    }
}
