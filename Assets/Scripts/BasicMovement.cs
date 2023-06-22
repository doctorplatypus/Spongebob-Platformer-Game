using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public int speed = 5;
    bool isFacingRight = true;
    float maxLeft, maxRight;

    // Start is called before the first frame update
    void Start()
    {
        maxLeft = transform.position.x - 3.0f;
        maxRight = transform.position.x + 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        Vector3 rot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);

        if (transform.position.x <= maxLeft && !isFacingRight)
        {
            transform.rotation = Quaternion.Euler(rot);
            isFacingRight = true;
        }
        if (transform.position.x >= maxRight && isFacingRight == true)
        {
            transform.rotation = Quaternion.Euler(rot);
            isFacingRight = false;
        }
    }
}
