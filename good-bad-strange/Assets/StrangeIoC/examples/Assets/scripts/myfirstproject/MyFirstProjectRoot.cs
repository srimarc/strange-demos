using strange.extensions.context.impl;
using UnityEngine;

namespace strange.examples.myfirstproject
{
	public class MyFirstProjectRoot : ContextView
	{
	    void Awake()
	    {
			context = new MyFirstContext(this, true);
	        context.Start();
	    }
	}
}