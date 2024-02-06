using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Snake : MonoBehaviour
{
    public GameObject[] points;
    private int activePoint;
    public float smoothSpeed;
    public float speed;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void CheckPoint()
    {
        if (transform.position == points[activePoint].transform.position)
        {
            activePoint++;
            if (activePoint == points.Length)
            {
                activePoint = 0;
            }
            
        }
    }

    private void Follow()
    {

        Vector3 targetPosition = new Vector3(points[activePoint].transform.position.x, points[activePoint].transform.position.y, transform.position.z);
        Vector3 direction = targetPosition - transform.position; // Направление к целевой позиции
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Вычисляем угол в радианах и конвертируем в градусы
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Поворачиваем объект в заданное направление
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * smoothSpeed); // Применяем плавное вращение
        //rb.MoveRotation(angle);
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[activePoint].transform.position, speed * Time.fixedDeltaTime);
    }



    void FixedUpdate()
    {
        CheckPoint();
        Move();
        Follow();
    }
}
