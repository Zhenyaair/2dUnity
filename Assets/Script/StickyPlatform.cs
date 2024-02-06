using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    //private void OnCollisionEnter2D (Collision2D collision)
    //{
    //    if (collision.gameObject.name == "Player")
    //    {
    //        collision.gameObject.transform.SetParent(transform,true);// or (transform)
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "Player")
    //    {
    //        collision.gameObject.transform.SetParent(transform, false); // or (null)
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);// or (transform)
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);// or (transform)
        }
    }
}
