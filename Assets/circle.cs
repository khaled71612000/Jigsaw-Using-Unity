using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    [SerializeField]
    private Transform bearPlace;
    private Vector2 intPos;
    private float deltax, deltay;
    private static bool locked;


    void Start()
    {
        intPos = transform.position;    
    }

    
    void Update()
    {
        if(Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltax = touchPos.x - transform.position.x;
                        deltay = touchPos.y - transform.position.y;

                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - deltax, touchPos.y - deltay);

                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - bearPlace.position.x) <= 0.5f&&
                        Mathf.Abs(transform.position.y - bearPlace.position.y) <= 0.5f )
                    {
                        transform.position = new Vector2(bearPlace.position.x, bearPlace.position.y);
                        locked = true;
                    }else
                    {
                        transform.position = new Vector2(intPos.x, intPos.y);

                    }
                    break;
            }
        }
    }
}
