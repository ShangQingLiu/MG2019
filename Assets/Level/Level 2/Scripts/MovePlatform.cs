using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{

    public GameObject[] movePoints;
    public float velocity;

    private Rigidbody2D _body;
    private int _next;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _next = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //点集数量至少要有2个
        if (movePoints.Length <= 1)
            return;
        //移动到点位置时，更新下一个移动点位置
        if (Vector3.Distance(transform.position, movePoints[_next].transform.position) < 1)
            _next = (_next == movePoints.Length - 1) ? 0 : _next + 1;

        Vector2 direction = Vector3.Normalize(movePoints[_next].transform.position - transform.position);
        _body.MovePosition(_body.position + direction * velocity * Time.fixedDeltaTime);

    }

}
