using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperBot : MonoBehaviour
{

    [SerializeField] private Transform playerPoint = null;
   // [SerializeField] private Transform mainCamera = null;
    [SerializeField] private float speed = 0;

    [SerializeField] private float range;
    [SerializeField] private LayerMask enemyLayerMask;

    void Start()
    {
        
    }

    
    void Update()
    {
        Collider[] enemisc = Physics.OverlapSphere(gameObject.transform.position, range, enemyLayerMask);
        for (int i = 0; i < enemisc.Length; i++)
        {
            Vector3 lookInEnemy = new Vector3(enemisc[i].transform.position.x, enemisc[i].transform.position.y + 1, enemisc[i].transform.position.z);
            transform.LookAt(lookInEnemy);
            //Vector3 directionToEnemy = enemisc[i].transform.position - gameObject.transform.position;
            //Quaternion rotationToEnemy = Quaternion.LookRotation(directionToEnemy);
            //gameObject.transform.rotation = Quaternion.Euler(rotationToEnemy.eulerAngles.x - 2, rotationToEnemy.eulerAngles.y, rotationToEnemy.eulerAngles.z);
        }
        if(enemisc.Length == 0)
        {
            transform.rotation = transform.parent.rotation;
           //transform.rotation = Quaternion.Euler(GetComponentInParent<Transform>().position.x, GetComponentInParent<Transform>().position.y, GetComponentInParent<Transform>().position.z);
        }
       
        transform.position = Vector3.Lerp(transform.position, playerPoint.position,  Time.deltaTime);
    }
}
