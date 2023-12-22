using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarterAssets
{

    public class SwordMove : MonoBehaviour
    {
        [SerializeField] private int damage;

        [SerializeField] private Transform playerPoint = null;
        [SerializeField] private Transform parentPoint = null;
        [SerializeField] private Transform parentPoint1 = null;

        // [SerializeField] private Transform mainCamera = null;
        [SerializeField] private float speed = 0;

        private StarterAssetsInputs _input;
        [SerializeField] private Animator animator;
        [Inject] private CharacterInputController characterInputController { get; set; }

        private bool isAttack;

        private void Start()
        {
            _input = GetComponentInParent<StarterAssetsInputs>();
        }

        // Update is called once per frame
        void Update()
        {
            var controllerInput = characterInputController.InputButtonCheckMelee();
            if (controllerInput == 0)
            {
                if (_input.sprint == false && isAttack == false)
                {
                    transform.SetParent(null);
                    transform.position = Vector3.Lerp(transform.position, playerPoint.position, Time.deltaTime);
                }
                else
                {
                    if (isAttack == false)
                    {
                        SwordSwitch(parentPoint);
                    }
                    else
                    {
                        SwordSwitch(parentPoint1);
                    }
                }
            }
            else
            {
                if(isAttack == false)
                    Attack(controllerInput);
            }
        }
        
        private void SwordSwitch(Transform parent)
        {
            transform.position = parent.position;
            transform.rotation = parent.rotation;

            transform.SetParent(parent);
        }

        private void Attack(int animation)
        {
            isAttack = true;
            animator.SetInteger("Attack", animation);
            StartCoroutine(AttackReset());
        }

        private IEnumerator AttackReset()
        {
            yield return new WaitForSeconds(0.1f);
            animator.SetInteger("Attack", 0);
            StartCoroutine(AttackEnd());
        }
        private IEnumerator AttackEnd()
        {
            yield return new WaitForSeconds(1.75f);
            isAttack = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Enemy")
            {
                other.GetComponent<LosingHealth>().TakeDamage(damage);
                Debug.Log($"Damage{damage}");
            }
        }

    }
}