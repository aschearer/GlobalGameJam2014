namespace Assets
{
    using UnityEngine;

    public class ReturnToTitle : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.LoadLevel("Title");
            }
        }
    }
}
