namespace Assets.Units
{
    using UnityEngine;

    public class MoveUnit : MonoBehaviour
    {
        public void Update()
        {
            var position = this.transform.position;
            position.x += Time.deltaTime * 1;
            this.rigidbody.MovePosition(position);
        }
    }
}
