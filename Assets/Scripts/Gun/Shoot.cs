using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    /*
    public float fireRate = 0.2f; // ������� ���������
    public float bulletSpeed = 50f; // �������� ����
    public GameObject bulletPrefab; // ������ ����
    public Transform bulletSpawnPoint; // �����, ������ �������� ����
   // public AudioClip gunshotSound; // ���� ��������

    private AudioSource audioSource; // ��������� AudioSource ��� ��������������� ����� ��������
    private float nextFireTime; // �����, ����� ����� ������� ��������� �������

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // �������� ��������� AudioSource ���������
     //   audioSource.clip = gunshotSound; // ������������� ���� ��������
    }

    void Update()
    {
        // ���������, ����� �� ������� ��������� �������
        if (Time.time > nextFireTime)
        {
            // ���� ������ ������� Fire1, �� ��������
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                // ������� ��������� ����
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

                // ��������� ����, ����� ���� �������� ������
                bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);

                // ������������� ����� ���������� ��������
                nextFireTime = Time.time + fireRate;

                // ������������� ���� ��������
             //   audioSource.Play();
            }
        }
    }
    */
}
