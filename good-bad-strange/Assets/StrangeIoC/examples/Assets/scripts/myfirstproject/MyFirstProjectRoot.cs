using strange.extensions.context.impl;
using UnityEngine;

namespace strange.examples.myfirstproject
{
	


public class MyFirstProjectRoot : ContextView
{
    void Awake()
    {
        context = new TestContext(this, true);
        context.Start();
    }
}
 
	public class TestContext : CrossContext
    {
        public TestContext(object view, bool autoStartup) : base(view, autoStartup)
        {
        }
 
        protected override void mapBindings()
        {
            base.mapBindings();
 
            injectionBinder.Bind<IMapConfig>().ToValue(new MapConfig());
            injectionBinder.Bind<IMap>().To<Map>().ToSingleton();
            injectionBinder.Bind<IRenderer>().To<Renderer>().ToSingleton();
        }
 
        public override void Launch()
        {
            base.Launch();
 
            var m = injectionBinder.GetInstance<IMap>() as IMap;
            var r = injectionBinder.GetInstance<IRenderer>() as Renderer;
			
			
        }
    }
 
    public interface IMapConfig
    {}
 
    public class MapConfig : IMapConfig
    {}
 
    public interface IMap
    {
    }
 
    public class Map : IMap
    {
		public Map()
		{
			UnityEngine.Debug.LogWarning("Test map " + this.GetHashCode());
		}
		
		[Construct]
        public Map(IMapConfig config)
        {
            UnityEngine.Debug.LogWarning("Test map " + this.GetHashCode());
        }
    }
 
    public interface IRenderer
    {
    }
 
    public class Renderer : IRenderer
    {
        public Renderer(IMap map)
        {
        }
    }
	
}