using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public float speed;
    public float distance;
    public float range;
    public int damage;
    public LayerMask whatIsSolid;
    private Vector2 startPos;


    private void Start()
    {
        startPos = transform.position;

    }

    private void Update()
    {
      
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Ground"))
            {
                hitInfo.collider.GetComponent<BlockDamageSystem>().TakeDamage(damage);
            }

            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Vector2 dist = (Vector2)transform.position - startPos;
        if (dist.magnitude > range)
        {
            Destroy(gameObject);
        }
    }

}


