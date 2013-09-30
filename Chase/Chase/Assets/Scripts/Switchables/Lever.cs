using UnityEngine;
using System.Collections;

public class Lever : Switch {

	private bool switched = false;
	
	protected new void toggleAll()
	{
		if (!switched)
		{
			base.toggleAll();
			switched = true;
		}
	}
}
