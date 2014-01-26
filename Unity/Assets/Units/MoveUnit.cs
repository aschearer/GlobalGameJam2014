namespace Assets.Units
{
    using UnityEngine;

    public class MoveUnit : MonoBehaviour
    {
        public Vector3 Velocity = new Vector3(0, 0, 1);

        public void Update()
        {
            var position = this.transform.position;
            position += this.transform.rotation * this.Velocity * Time.deltaTime;
            this.rigidbody.MovePosition(position);
        }
    }
}
