namespace Assets.Units
{
    using System;
    using System.Collections;

    using UnityEngine;

    using Random = UnityEngine.Random;

    public class MoveUnit : MonoBehaviour
    {
        public float StartSpeed = 10;

        public float MaxSpeed = 30;

        public float SpeedIncrement = 10;

        public float DisplayOffset = 1f;

        private float speed;
        
        private Vector3 velocity;

        private GameObject model;

        private float targetAngle;

        private float startTime;

        public void Start()
        {
            this.targetAngle = this.transform.rotation.eulerAngles.y;
            model = this.transform.Find("Model").gameObject;
            model.transform.localPosition = new Vector3(Random.Range(-DisplayOffset, DisplayOffset),
                                                        0.5f, 
                                                        Random.Range(-DisplayOffset, DisplayOffset));
            startTime = Time.time;
            speed = StartSpeed;
            velocity = new Vector3(0, 0, speed);
        }

        public void SpeedUp()
        {
            speed += SpeedIncrement;
            speed = Mathf.Min(MaxSpeed, speed);
        }

        public void Rotate(float targetAngle)
        {
            targetAngle = (targetAngle + 360) % 360;
            var currentAngle = (this.transform.rotation.eulerAngles.y + 360) % 360;
            var delta = Math.Abs(currentAngle - targetAngle);
            if (Math.Abs(delta - 180) < 10)
            {
                this.transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            }

            this.targetAngle = targetAngle;
        }

        public void Update()
        {
            this.velocity.z = speed;

            var currentAngle = this.transform.rotation.eulerAngles.y;
            if (Mathf.Abs(this.targetAngle - currentAngle) > 0.005f)
            {
                currentAngle = Mathf.LerpAngle(currentAngle, this.targetAngle, Time.deltaTime * 2 * (this.speed / this.StartSpeed));
                this.transform.rotation = Quaternion.Euler(0, currentAngle, 0);
            }

            var position = this.transform.position;
            position += this.transform.rotation * this.velocity * Time.deltaTime;
            this.rigidbody.MovePosition(position);

            model.transform.localPosition = new Vector3(model.transform.localPosition.x,
                                                        Mathf.Sin((Time.time - startTime) * 10) * 0.5f + 0.5f, 
                                                          model.transform.localPosition.z);
        }
    }
}
