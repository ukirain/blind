using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Vector3 targetPosition;
    public bool is_dialog;
    public Animator anim;
    public float speedByMouse = 2;
    public float speedByKeyboard = 1;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && is_dialog == false)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            targetPosition.x = transform.position.x + speedByKeyboard;
            targetPosition.y = transform.position.y;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            targetPosition.x = transform.position.x - speedByKeyboard;
            targetPosition.y = transform.position.y;
        }
        targetPosition.y = 0;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speedByMouse);
        anim.SetBool("walking", transform.position.x != targetPosition.x);
        if (transform.position.x > targetPosition.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            
        }
        if (transform.position.x < targetPosition.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;  
        }
        if (!anim.GetBool("walking")) //чтобы герой не отражался, стоя на месте
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
