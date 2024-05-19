using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlueOrbs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(20 * Time.deltaTime, 0, 0);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (PlayerController.renderer.material.color != Color.blue)
            {
                if (PlayerController.multiplier)
                {
                    PlayerManager.Total_Score += 5;
                    PlayerManager.NumberOfBlueCoins += 2;
                    PlayerController.multiplier = false;
                }
                else
                {
                    PlayerManager.NumberOfBlueCoins += 1;
                    PlayerManager.Total_Score += 1;
                }
                FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
                Destroy(gameObject);

            }
            else if (PlayerController.renderer.material.color == Color.blue)
            {
                PlayerManager.Total_Score += 2;
                FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
                Destroy(gameObject);

            }
           
                

        }
    }
}
