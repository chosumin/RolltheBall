using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_move : MonoBehaviour
{
    float screenX;
    float screenY;
    private Vector3 move;
    private float playerX;
    private float playerZ;
    public float speed;
    float changeX;
    float changeZ;
    private void Start()
    { 
        speed = Random.Range(6.0f, 12.0f);
        screenX = GameManager.screenX;
        screenY = GameManager.screenX;
        transform.localScale = new Vector3(screenX / 4f, screenX / 4f, screenX / 4f);
        changeX = Random.Range(-screenX, screenX);
        changeZ = Random.Range(-screenY, screenY);
        transform.position = new Vector3(changeZ, screenX/ 4f, changeX);
        
    }
    void Update()
    {
        if (GameManager.gs == Gamestate.ing)
        {
            move = Vector3.zero;
            move.x = -Input.acceleration.y;
            move.z = Input.acceleration.x;
            if (move.sqrMagnitude > 1)
                move.Normalize();
            transform.Translate(move * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().WakeUp();
        if (GameManager.gs == Gamestate.generate) //생성 단계에 충돌하면 위치 변경
        {
            if (collision.gameObject.name == "Sphere" || collision.gameObject.name == "Cube" || collision.gameObject.name == "Bighole")
            {
                changeX = Random.Range(-screenX + screenX / 4.0f, screenX - screenX / 4.0f);
                changeZ = Random.Range(-screenY + screenX / 4.0f, screenY - screenX / 4.0f);
                transform.position = new Vector3(changeX, -5f + screenX / 4f, changeZ);
            }
        }
        else if(GameManager.gs == Gamestate.ing)
        {
            if(collision.gameObject.name == "targethole") //구체, 구멍 충돌
            {
                Destroy(this.gameObject);
                if(collision.transform.parent.GetComponent<MeshRenderer>().material.color == this.GetComponent<MeshRenderer>().material.color)
                {
                    GameManager.count--;
                }
                else if (collision.transform.parent.GetComponent<MeshRenderer>().material.color != this.GetComponent<MeshRenderer>().material.color)
                {

                    GameManager.gs = Gamestate.death;
                }
            }
        }
    }
}
