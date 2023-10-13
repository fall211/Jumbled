using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Manager gameManager;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float acceleration;

    [HideInInspector] public bool isMoving;
    [HideInInspector] public Vector2 movementVector = new Vector2(0f, 0f);

    [HideInInspector] public KeyCode upKey;
    [HideInInspector] public KeyCode downKey;
    [HideInInspector] public KeyCode leftKey;
    [HideInInspector] public KeyCode rightKey;

    public KeyCode[] keys;


    private void Start(){
        gameManager = Manager.instance;

        upKey = KeyCode.W;
        downKey = KeyCode.S;
        leftKey = KeyCode.A;
        rightKey = KeyCode.D;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(upKey)){
            if (movementVector.y < 0f){
                movementVector.y += acceleration * Time.deltaTime * 2f;
            } else {
                movementVector.y += acceleration * Time.deltaTime;
            }
        }
        if (Input.GetKey(downKey)){
            if (movementVector.y > 0f){
                movementVector.y -= acceleration * Time.deltaTime * 2f;
            } else {
                movementVector.y -= acceleration * Time.deltaTime;
            }
        }
        if (Input.GetKey(leftKey)){
            if (movementVector.x > 0f){
                movementVector.x -= acceleration * Time.deltaTime * 2f;
            } else {
                movementVector.x -= acceleration * Time.deltaTime;
            }
        }
        if (Input.GetKey(rightKey)){
            if (movementVector.x < 0f){
                movementVector.x += acceleration * Time.deltaTime * 2f;
            } else {
                movementVector.x += acceleration * Time.deltaTime;
            }
        }

        if (!Input.GetKey(upKey) && !Input.GetKey(downKey) && !Input.GetKey(leftKey) && !Input.GetKey(rightKey)){
            movementVector = Vector2.Lerp(movementVector, Vector2.zero, acceleration * Time.deltaTime);
        }

        if (movementVector.magnitude > 2f){
            movementVector = Vector2.ClampMagnitude(movementVector, 2f);
        }

        // clamp player to screen
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.05f, 0.95f);
        pos.y = Mathf.Clamp(pos.y, 0.05f, 0.95f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        transform.Translate(movementVector * moveSpeed * Time.deltaTime);
    }


    public void ResetPlayer(bool shuffleControls = true){
        transform.position = gameManager.startPosition.position;
        movementVector = Vector2.zero;
        if (shuffleControls) {
            ShuffleControls();
        } else {
            upKey = KeyCode.W;
            downKey = KeyCode.S;
            leftKey = KeyCode.A;
            rightKey = KeyCode.D;
        }
        gameManager.ChangeKeyText();
    }

    public void ShuffleControls(){
        // select 4 random different keys
        List<KeyCode> keyList = new List<KeyCode>(keys);
        List<KeyCode> selectedKeys = new List<KeyCode>();
        for (int i = 0; i < 4; i++){
            int randomIndex = Random.Range(0, keyList.Count);
            selectedKeys.Add(keyList[randomIndex]);
            keyList.RemoveAt(randomIndex);
        }
        upKey = selectedKeys[0];
        downKey = selectedKeys[1];
        leftKey = selectedKeys[2];
        rightKey = selectedKeys[3];
    }

}
