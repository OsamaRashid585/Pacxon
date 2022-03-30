using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 0.1f;
    public Tilemap tile;
    public Tile _tileSprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnGridMovement();
        Physics2D.IgnoreLayerCollision(6, 7);
    }
    // moveplayerongrid
    private void OnGridMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce((Vector2.right * speed), ForceMode2D.Impulse);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            CreateTile();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce((Vector2.left * speed), ForceMode2D.Impulse);
            transform.rotation = Quaternion.Euler(0, 0, 180);
            CreateTile();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce((Vector2.up * speed), ForceMode2D.Impulse);
            transform.rotation = Quaternion.Euler(0, 0, 90);
            CreateTile();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce((Vector2.down * speed), ForceMode2D.Impulse);
            transform.rotation = Quaternion.Euler(0, 0, -90);
            CreateTile();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
    // create tile at player position
    void CreateTile()
    {
        int xPos = Mathf.RoundToInt(transform.position.x)-1;
        int YPos = Mathf.RoundToInt(transform.position.y)-1;
        tile.SetTile(new Vector3Int(xPos, YPos, 0), _tileSprite);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManger.life--;
        }
    }
}
