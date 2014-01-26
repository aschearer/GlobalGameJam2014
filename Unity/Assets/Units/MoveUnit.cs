namespace Assets.Units
{
    using System;

    using UnityEngine;

    public class MoveUnit : MonoBehaviour
    {
        public Vector3 Velocity = new Vector3(0, 0, 1);

        private float targetAngle;

        public void Rotate(float targetAngle)
        {
            this.targetAngle = targetAngle;
        }

        public void Update()
        {
            var currentAngle = this.transform.rotation.eulerAngles.y;
            if (Math.Abs(this.targetAngle - currentAngle) > 0.005f)
            {
                currentAngle = Mathf.LerpAngle(currentAngle, this.targetAngle, Time.deltaTime * 2);
                this.transform.rotation = Quaternion.Euler(0, currentAngle, 0);
            }


            var position = this.transform.position;
            position += this.transform.rotation * this.Velocity * Time.deltaTime;
            this.rigidbody.MovePosition(position);
        }
    }
}
