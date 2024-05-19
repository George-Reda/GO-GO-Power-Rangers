using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public int forwardspeed;
    private int desiredLane = 1;
    public float laneDistance = 4;
    public float jumpForce;
    public float Gravity = -20;
    public Material NewMaterial;
    public static Renderer renderer;
    public static bool multiplier = false;
    public static bool shield = false;
    public GameObject shield2;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        renderer = GetComponent<Renderer>();

    }
    // Update is called once per frame
    void Update()

    {
        if (!PlayerManager.IsGameStarted)
        {
            return;
        }
        else

        {

            if (renderer.material.color == Color.green)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    PlayerManager.NumberOfGreenCoins -= 1;
                    multiplier = true;
                }
                if (PlayerManager.NumberOfGreenCoins == 0)
                {
                    renderer.material.color = Color.white;
                }
            }
            if (renderer.material.color == Color.blue)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    PlayerManager.NumberOfBlueCoins -= 1;
                    shield2.SetActive(true);
                     shield= true;
                }
                if (PlayerManager.NumberOfBlueCoins == 0)
                {
                    renderer.material.color = Color.white;
                }
            }
            if (renderer.material.color == Color.red && PlayerManager.NumberOfRedCoins == 0)
            {
                renderer.material.color = Color.white;

            }
                if (PlayerManager.pause)
            {
                direction.z = 0;
            }
            else if (!PlayerManager.pause)
            {
                direction.z = forwardspeed;
            }
            

            if ((PlayerManager.NumberOfRedCoins >= 5) && (Input.GetKeyDown(KeyCode.J)))

            {
                
                PlayerManager.NumberOfRedCoins = 4;
                renderer.material.color = Color.red;
            }
            if ((PlayerManager.NumberOfBlueCoins >= 5) && (Input.GetKeyDown(KeyCode.L)))
            {
                
                PlayerManager.NumberOfBlueCoins = 4;
                renderer.material.color = Color.blue;
            }
            if ((PlayerManager.NumberOfGreenCoins>=5) && (Input.GetKeyDown(KeyCode.K)))
            {
             
                PlayerManager.NumberOfGreenCoins = 4;
               renderer.material.color = Color.green;
            }
            
            if (Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D))
            {
                desiredLane++;
                if (desiredLane == 3)
                {
                    desiredLane = 2;
                }

            }
            if (controller.isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Jump();

                }


            }
            else
            {
                direction.y += Gravity * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                desiredLane--;
                if (desiredLane == -1)
                {
                    desiredLane = 0;
                }

            }
            if ((Input.GetKeyDown(KeyCode.Space)) && (renderer.material.color == Color.red))
            {
                PlayerManager.NumberOfRedCoins -= 1;
                GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach (GameObject obstacle in obstacles)
                {
                    Destroy(obstacle);
                }
            }

            

            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
            if (desiredLane == 0)
            {
                targetPosition += Vector3.left * laneDistance;
            }
            if (desiredLane == 2)
            {
                targetPosition += Vector3.right * laneDistance;
            }

            transform.position = targetPosition;
            controller.center = controller.center;
        }
    }
    private void FixedUpdate()
    {
        if (!PlayerManager.IsGameStarted)
        {
            return;
        }
        else
        {
            controller.Move(direction * Time.fixedDeltaTime);
        }
    }
    private void Jump()
    {
        return;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            if (shield)
            {
                shield2.SetActive(false);
                shield = false;
                PlayerManager.gameOver = false;
                Destroy(hit.gameObject);
                
            }
            else
            {
                PlayerManager.gameOver = true;
                FindObjectOfType<AudioManager>().PlaySound("Game_Over");
                Destroy(hit.gameObject);
            }
        }

    }
}
