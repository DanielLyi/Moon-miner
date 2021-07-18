using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    MiningCard miningCard;
    PlayerBalance playerBalance;
    [SerializeField] float speed;
    [SerializeField] float award;
    private float moveinput;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);
    }

    public void SetPlayerBalance(PlayerBalance playerBalance)
    {
        this.playerBalance = playerBalance;
    }

    public void SetMiningCard(MiningCard miningCard)
    {
        this.miningCard = miningCard;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HashCoin"))
        {
            playerBalance.hashcoin += award + miningCard.upgradeLvl / 1000f;
            Destroy(other.gameObject);
        }
    }
}