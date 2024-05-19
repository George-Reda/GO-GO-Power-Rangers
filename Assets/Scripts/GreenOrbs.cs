using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenOrbs : MonoBehaviour
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
            if (PlayerController.renderer.material.color != Color.green)
            {
                PlayerManager.NumberOfGreenCoins += 1;
                PlayerManager.Total_Score += 1;

            }
            else 
            {
                if (PlayerController.multiplier)
                {
                    PlayerManager.Total_Score += 10;
                    PlayerController.multiplier = false;
                }
                else
                {
                    PlayerManager.Total_Score += 2;
                }
                
              

            }

            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
            Destroy(gameObject);

        }
    }
}
