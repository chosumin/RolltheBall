using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole_location : MonoBehaviour {
    float screenX;
    float screenY;
    private float changeX;
    private float changeZ;
    private void Start()
    {
        screenX = GameManager.screenX;
        screenY = GameManager.screenY;
        transform.localScale = new Vector3(screenY / 20f, 1, screenY / 20f);
        changeX = Random.Range(-screenX + (screenY / 40f), screenX - (screenY / 40f));
        changeZ = Random.Range(-screenY + (screenY / 40f), screenY - (screenY / 40f));
        transform.position = new Vector3(changeZ, 0.1f, changeX);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (GameManager.gs == Gamestate.generate) //생성 단계에 충돌하면 위치 변경
        {
            if (collision.gameObject.name == "Sphere" || collision.gameObject.name == "Cube" || collision.gameObject.name == "Bighole")
            {
                changeX = Random.Range(-screenX + (screenY / 40f), screenX - (screenY / 40f));
                changeZ = Random.Range(-screenY + (screenY / 40f), screenY - (screenY / 40f));
                transform.position = new Vector3(changeZ, 0.1f, changeX);
            }
        }
    }

    void Update()
    {
        if(GameManager.gs == Gamestate.end)
        {
            Destroy(transform.gameObject);
        }
    }
}
