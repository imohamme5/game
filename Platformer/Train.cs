using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

namespace Platformer
{
	public class Train
	{
		private Sprite train;
		private GraphicsContext gc;
		
		public float TrainXposition
		{
			get {return train.Position.X;}
		}
		
		public Train(GraphicsContext graphics, int x, int y)
		{
			gc = graphics;
			Texture2D tex = new Texture2D("/Application/Assets/trains.png", false);
			train = new Sprite(gc, tex);
			
			train.Position.X = x;
			train.Position.Y = y;
		}
		
		public void Update()
		{
			train.Position.X -= 6;
		}
		
		public void Draw()
		{
			train.Render();
		}
	}
}

