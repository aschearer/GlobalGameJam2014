namespace Assets
{
    using UnityEngine;

    public class StartNewGame : MonoBehaviour
    {
        public void OnMouseDown()
        {
            Application.LoadLevel("Game");
        }
    }
}
