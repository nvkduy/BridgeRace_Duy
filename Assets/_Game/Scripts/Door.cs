using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
namespace DoorScript
{

    public class Door : MonoBehaviour
    {
        [SerializeField] private Floor floor;
        [SerializeField] private Transform brickParent2;
        [SerializeField] BoxCollider boxCollider;
        public bool open { get; set; }
        public float smooth = 1.0f;
        float DoorOpenAngle = 90f;
        float DoorCloseAngle = 0.0f;
        // Use this for initialization


        // Update is called once per frame
        void Update()
        {
            if (open)
            {
                var target = Quaternion.Euler(0, DoorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);

            }
            else
            {
                var target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * 5 * smooth);

            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                open = true;
                floor.SpawnBrick(brickParent2);
                boxCollider.enabled = false;
            }
        }

    }
}