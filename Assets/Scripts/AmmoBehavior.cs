using UnityEngine;
using Photon.Pun;

public class ProjectileBehavior : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PhotonView targetPhotonView = collision.gameObject.GetComponent<PhotonView>();

            if (targetPhotonView != null && !targetPhotonView.IsMine)
            {
                targetPhotonView.RPC("TakeDamage", RpcTarget.AllBuffered, 1);
                PhotonNetwork.Destroy(gameObject);
            }
        }
        else
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
