using UnityEngine;
using System.Collections;

public class CursorChara : MonoBehaviour {

    private Vector3 position;
    private Vector3 screenToWorldPointPosition;
    private Vector3 direction;
    public float speed;

    void Start()
    {
        Cursor.visible = false;
    }
	
	void Update ()
    {
        position = Input.mousePosition;

        position.x += 10f;

        position.z = 10f;

        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        direction = screenToWorldPointPosition - transform.position;
        if(direction.x <= 1 && direction.x >= 1)
        {
            direction.x = 0;
        }
        if (direction.y <= 1 && direction.y >= 1)
        {
            direction.y = 0;
        }

        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
