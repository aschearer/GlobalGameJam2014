namespace Assets.Units
{
	using Assets.Store;
	
	using UnityEngine;
	
	public class SpeedUpUnit : MonoBehaviour
	{
		private int unitLayer;
		
		public void Start()
		{
			this.unitLayer = LayerMask.NameToLayer("Units");
		}
		
		public void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.layer == this.unitLayer)
			{
				other.gameObject.SendMessage("SpeedUp");
			}
		}
	}
}
