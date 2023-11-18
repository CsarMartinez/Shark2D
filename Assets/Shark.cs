using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shark : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    private List<Transform> _sharkSpawn = new List<Transform>();
    public Transform sharkPrefab;

    public int initialSize = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveSpeed, 0);

        _sharkSpawn = new List<Transform>();

        for(int i = 1; i < this.initialSize; i++)
        {
          _sharkSpawn.Add(this.transform);  
        }
        _sharkSpawn.Add(this.transform);
            
    }


    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(0, moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(0, -moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    private void FixedUpdate()
    {
        for(int i = _sharkSpawn.Count - 1; i>0; i--)
        {
            _sharkSpawn[i].position = _sharkSpawn[i - 1].position;
        }
    }

    private void grown()
    {
        Transform sharkSpawn = Instantiate(this.sharkPrefab);
        sharkSpawn.position = _sharkSpawn[_sharkSpawn.Count - 1].position;

        _sharkSpawn.Add(sharkSpawn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            grown();
        }
        //else if(collision.gameObject.tag == "Tail")
        //{
           
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Tail")
        {
               
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
