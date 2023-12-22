using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private Rigidbody rb;
    private Transform helperBot;

    private void Start()
    {
        Invoke("OnDestroy", 7);
    }

    void Update()
    {
        // �������� �����������, � ������� ������ �������
        Vector3 moveDirection = transform.forward;

        // ���������� ������ � �����������, � ������� �� �������
        transform.position += moveDirection * speed * Time.deltaTime;
    }


    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<LosingHealth>().TakeDamage(damage);
            OnDestroy();
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }

}
