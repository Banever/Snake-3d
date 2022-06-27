using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    enum Direction
    {
        up,
        down,
        left,
        right
    }

    Direction direction;

    public List<Transform> Tail = new List<Transform>();
    public GameObject FruitPrefab;
    public GameObject Leftside;
    public GameObject Rightside;
    public GameObject Topside;
    public GameObject Bottomside;

    public float framerate = 0.2f;
    // Declare the framerate
    public float step = 1.6f;
    // Distance traveler in x time

    public GameObject TailPrefab;



    void Start()
    {
        InvokeRepeating("Move", framerate, framerate);
        // We want to repeat the methot at the same time and repetitions as framerate
    }

    private void Move()
    {
        Lastposition = transform.position;

        Vector3 nextPosition = Vector3.zero;
        if (direction == Direction.up)
            nextPosition = Vector3.up;
        else if (direction == Direction.down)
            nextPosition = Vector3.down;
        else if (direction == Direction.left)
            nextPosition = Vector3.left;
        else if (direction == Direction.right)
            nextPosition = Vector3.right;
        nextPosition *= step;
        transform.position += nextPosition;

        Tailmovement();
    }

    Vector3 Lastposition;
    private void Tailmovement()
    {
        for (int i = 0; i < Tail.Count; i++)
        {
            Vector3 Temp = Tail[i].position;
            Tail[i].position = Lastposition;
            Lastposition = Temp;

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            direction = Direction.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            direction = Direction.down;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            direction = Direction.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            direction = Direction.right;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Block"))
        {
            print("Game Over");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game over");
        }

        else if (col.CompareTag("Fruit"))
        {
            Tail.Add(Instantiate(TailPrefab, Tail[Tail.Count - 1].position, Quaternion.identity).transform);
            Destroy(col.gameObject);
            Fruit();
            ScoreManager.instance.AddPoint();
            
        }

        void Fruit()
        {
            Vector2 Position = new Vector2(Random.Range(Leftside.transform.position.x, Rightside.transform.position.x), Random.Range(Topside.transform.position.y, Bottomside.transform.position.y));

            Instantiate(FruitPrefab, Position, Quaternion.identity);
        }
    }
}
