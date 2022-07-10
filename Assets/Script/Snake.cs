using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{ 
    
    enum Direction
    {
        forward,
        back,
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
        // We want to repeat the method at the same time and repetitions as framerate
    }
    private void Move()
    {

        Lastposition = transform.position;

        Vector3 nextPosition = Vector3.zero;
        if (direction == Direction.forward)
            nextPosition = Vector3.forward;
        else if (direction == Direction.back)
            nextPosition = Vector3.back;
        else if (direction == Direction.up)
            nextPosition = Vector3.up;
        if (direction == Direction.down)
            nextPosition = Vector3.down;
        if (direction == Direction.left)
            nextPosition = Vector3.left;
        if (direction == Direction.right)
            nextPosition = Vector3.right;
        nextPosition *= step;
        transform.position += nextPosition;

        Tailmovement();
    }
    Vector3 Lastposition;
    private Vector3 rotationAngle;

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
<<<<<<< HEAD
            direction = Direction.forward;
         else if (Input.GetKeyDown(KeyCode.DownArrow))
            direction = Direction.back;
        else if (Input.GetKeyDown(KeyCode.W))
            direction = Direction.up;
        else if (Input.GetKeyDown(KeyCode.S))
            direction = Direction.down;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            direction = Direction.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            direction = Direction.right;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Block"))
=======
>>>>>>> d20c2975cb721e19164f75bc4ea8c3ea1380ad50
        {
            if (direction != Direction.down)
                direction = Direction.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (direction != Direction.up)
                direction = Direction.down;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (direction != Direction.right)
                direction = Direction.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (direction != Direction.left)
                direction = Direction.right;
        }
    }
        private void OntriggerEnter(Collider col)
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
                Vector3 Position = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(4f, -3.4f));

                Instantiate(FruitPrefab, Position, Quaternion.identity);
            }
        }
    }
