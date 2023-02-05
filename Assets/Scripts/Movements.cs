using System;
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
    [SerializeField] bool triggerShake = false;
    Vector2 Velocity; 
    Rigidbody2D rb;
    Animator Anim;
    SpriteRenderer spriteRender;
    

    PhotonView view;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
        Anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (!view.IsMine) return;

            moveHorizontal = Input.GetAxis ("Horizontal");
            moveVertical = Input.GetAxis ("Vertical");

            if(moveHorizontal>0)
            {
                spriteRender.flipX = false;
            }
            else if(moveHorizontal<0)
            {
                spriteRender.flipX = true;
            }


            Velocity = new Vector2(moveHorizontal * mvoement_speed, rb.velocity.y);
            
            if(Input.GetKeyDown(KeyCode.T))
            {
                Anim.Play("punch"); 
            }

            


            if(Input.GetKeyDown(KeyCode.Space))
            {
                Velocity.y += 1f * Jump_force;
            }

            if(moveHorizontal != 0 && moveVertical == 0) {
                //Play your sideways animation
                Anim.SetBool("isRunning",true);
            }
            else
            {
                Anim.SetBool("isRunning",false);
            }

            rb.velocity = Velocity;

        if(triggerShake)
        {
            Camera.main.GetComponent<Shake>().shake_camera();
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			stream.SendNext(spriteRender.flipX);
		}
		else
		{
			spriteRender.flipX = (bool) stream.ReceiveNext();
		}
    }

}
