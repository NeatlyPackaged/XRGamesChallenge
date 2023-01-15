using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //rotator
    public float degreesPerSecond = 20;

    //MoveUp&Down
    //adjust this to change speed
    [SerializeField]
    float speed = 5f;
    //adjust this to change how high it goes
    [SerializeField]
    float height = 0.5f;

    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        //Rotate
        transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);

        //MoveUp&Down
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
