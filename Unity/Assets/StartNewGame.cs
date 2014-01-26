namespace Assets
{
    using UnityEngine;

    public class StartNewGame : MonoBehaviour
    {
        public void OnMouseDown()
        {
			Debug.Log("FOOOOO");
            Application.LoadLevel("Game");
        }
    }
}
