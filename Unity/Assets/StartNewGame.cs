namespace Assets
{
    using UnityEngine;

    public class StartNewGame : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Application.LoadLevel("Game");
            }
        }
    }
}
