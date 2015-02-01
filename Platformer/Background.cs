using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
namespace Platformer
{
	public class Background
	{
		
		private GraphicsContext gc;
		private Sprite cables, cables2;
		private Sprite bg;
		
		public Background (GraphicsContext graphics)
		{
			gc = graphics;
			
			
			Texture2D tex = new Texture2D("/Application/Assets/background.png", false);
			bg = new Sprite(gc, tex);
			bg.Position.X =0;
			bg.Position.Y = 0;
			 
			tex = new Texture2D("/Application/Assets/cables.png", false);
			cables = new Sprite(gc, tex);
			cables.Position.X = 0;
			cables.Position.Y = 0;
			cables2 = new Sprite(gc, tex);
			cables2.Position.X = cables.Width;
			cables2.Position.Y = 0;
			
		  
		}
		
		public void update()
		{
			
			cables.Position.X-=2;
			cables2.Position.X-=2;
			
			if(cables.Position.X < -cables2.Width)
			{
				cables.Position.X = 0;
				cables2.Position.X = cables.Width;
			}
		}
		
		public void Draw()
		{
			
			bg.Render();
			
			cables.Render();
			cables2.Render();
		}
	}
}

