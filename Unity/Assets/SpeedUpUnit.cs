namespace Assets.Units
{
	using Assets.Store;
	
	using UnityEngine;
	
	public class SpeedUpUnit : MonoBehaviour
	{
		private int unitLayer;

	    private bool isOn;
		
		public void Start()
		{
			this.unitLayer = LayerMask.NameToLayer("Units");
		}

	    public void TurnOn()
	    {
	        this.isOn = true;
	    }
		
		public void OnTriggerEnter(Collider other)
		{
		    if (!this.isOn)
		    {
		        return;
		    }

			if (other.gameObject.layer == this.unitLayer)
			{
				other.gameObject.SendMessage("SpeedUp");
			}
		}
	}
}
