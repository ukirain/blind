using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector3 targetPosition;
    public bool is_dialog;
    public Sprite stand;
    public Animator anim;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && is_dialog == false)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        } 
        targetPosition.y = 0;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * 20);
        if (transform.position.x == targetPosition.x)
        {
            anim.enabled = false;
            this.GetComponent<SpriteRenderer>().sprite = stand;    
        }
        if (transform.position.x > targetPosition.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            anim.enabled = true;
        }
        if (transform.position.x < targetPosition.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            anim.enabled = true;
        }
    }
}
