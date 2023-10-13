using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{

    [SerializeField] private Manager gameManager;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private float maxTilt;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, -playerController.movementVector.x * maxTilt);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Obstacle"){
            gameManager.GameOver();
            
        }
        if (other.gameObject.tag == "Finish"){
            gameManager.Finish();
        }
    }
}
