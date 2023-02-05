using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{   

    [SerializeField] LayerMask detectable;
    [SerializeField] float distanceFromPlayer = 1f;
    [SerializeField] float PunchPower = 5f;
    [SerializeField] bool OnHitting = false;
    SpriteRenderer spriteRender;
    [SerializeField] GameObject target = null;

    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }
    bool OnLeft()
    {
        RaycastHit2D hit =  Physics2D.Raycast(gameObject.transform.position + new Vector3(-distanceFromPlayer,0f,0f), Vector2.left, .2f, detectable);
        if (hit.collider != null)
        {
            target = hit.transform.gameObject;
            // Debug.Log("found left");
        }
        else
        {
            target = null;
        } 
        return hit;
    }
    bool OnRight()
    {
        RaycastHit2D hit =  Physics2D.Raycast(gameObject.transform.position + new Vector3(distanceFromPlayer,0f,0f), Vector2.right, .2f, detectable);
        if (hit.collider != null)
        {
            target = hit.transform.gameObject;
            // Debug.Log("found right");
        }
        else
        {
            target = null;
        } 
        return hit;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawRay(gameObject.transform.position + new Vector3(-distanceFromPlayer,0f,0f),Vector2.left);
        Gizmos.DrawRay(gameObject.transform.position + new Vector3(distanceFromPlayer,0f,0f), Vector2.right);
    }

    void FixedUpdate()
    {
        if(OnLeft() &&  (spriteRender.flipX == true))
        {
            if(target != null)
            {
                if(OnHitting)
                {
                    target.GetComponent<Rigidbody2D>().AddForce(Vector2.left*PunchPower*2);
                    target.GetComponent<Rigidbody2D>().AddForce(Vector2.up*PunchPower*0.2f);

                    Debug.Log("Colliding Left");
                }
                // Debug.Log("Colliding Left");
            }
            
        }

        else if(OnRight() &&  (spriteRender.flipX == false))
        {
            if(target != null)
            {
                if(OnHitting)
                {
                    target.GetComponent<Rigidbody2D>().AddForce(Vector2.right*PunchPower*2);
                    target.GetComponent<Rigidbody2D>().AddForce(Vector2.up*PunchPower*0.2f);
                    Debug.Log("Colliding Left");
                }
                //  Debug.Log("Colliding Right");
            }
           
        }
    }
}
