using UnityEngine;
using Photon.Pun;

public class BasicMovement : MonoBehaviour
{
    public float speed;

    Rigidbody rb;
    PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();
    }

    void FixedUpdate()
    {
        // Only move the player object if it's the local users player
        if (photonView.IsMine)
        {
            Move();
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 newVector = new Vector3(horizontal, 0, vertical);

        rb.position += newVector;
    }
}