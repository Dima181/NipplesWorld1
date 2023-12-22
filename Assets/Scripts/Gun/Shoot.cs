using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    /*
    public float fireRate = 0.2f; // частота выстрелов
    public float bulletSpeed = 50f; // скорость пули
    public GameObject bulletPrefab; // префаб пули
    public Transform bulletSpawnPoint; // точка, откуда вылетает пуля
   // public AudioClip gunshotSound; // звук выстрела

    private AudioSource audioSource; // компонент AudioSource для воспроизведения звука выстрела
    private float nextFireTime; // время, когда можно сделать следующий выстрел

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // получаем компонент AudioSource пистолета
     //   audioSource.clip = gunshotSound; // устанавливаем звук выстрела
    }

    void Update()
    {
        // проверяем, можно ли сделать следующий выстрел
        if (Time.time > nextFireTime)
        {
            // если нажата клавиша Fire1, то стреляем
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                // создаем экземпляр пули
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

                // добавляем силу, чтобы пуля полетела вперед
                bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);

                // устанавливаем время следующего выстрела
                nextFireTime = Time.time + fireRate;

                // воспроизводим звук выстрела
             //   audioSource.Play();
            }
        }
    }
    */
}
