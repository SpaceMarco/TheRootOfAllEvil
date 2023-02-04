using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mathf = UnityEngine.Mathf;
using Photon.Pun;

public class Movements : MonoBehaviour
{
    float moveHorizontal;
    float moveVertical;
    float lerp_acc = 0.5f;
    [SerializeField] float mvoement_speed;
    [SerializeField] float Jump_force;
    Vector2 Velocity; 
    Rigidbody2D rb;

    PhotonView view;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
    }


    void Update()
    {
        if(view.IsMine)
        {
            moveHorizontal = Input.GetAxis ("Horizontal");
            moveVertical = Input.GetAxis ("Vertical");

            Velocity = new Vector2(moveHorizontal * mvoement_speed, rb.velocity.y);
            
            if(Input.GetKeyDown(KeyCode.T))
            {
                Camera.main.GetComponent<Shake>().shake_camera();
            }


            if(Input.GetKeyDown(KeyCode.Space))
            {
                Velocity.y += 1f * Jump_force;
            }
            rb.velocity = Velocity;
        }
    }

}
