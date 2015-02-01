using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.UI; // for adding label to the screen
using System.Diagnostics; //Accesses stop watch class

namespace Platformer
{
	public class AppMain
	{
		
		private static GraphicsContext graphics;
		private static Background bg;
		private static List<Train> enemies; //Enemy is the class. Enemies is the variable
		
		private static Stopwatch clock;
		private static long startTime;
		private static long stopTime;
		private static long timeDelta;
		private static Random rand;
		private static long EnemyTimer;
		
		public static void Main (string[] args)
		{
			Initialize ();

			while (true) {
				startTime = clock.ElapsedMilliseconds;//how much time since clock has started
				SystemEvents.CheckEvents (); //checks for new events that may be happening like button presses or taps to the screen
				SystemEvents.CheckEvents ();
				Update ();
				Draw ();
				stopTime = clock.ElapsedMilliseconds;
				timeDelta = stopTime - startTime; // shows how long it took for my gameloop to run
			}
		}

		public static void Initialize ()
		{
			// Set up the graphics system
			graphics = new GraphicsContext ();
			bg = new Background(graphics);
			rand = new Random();
			enemies = new List<Train>(); // creating the list
			
			clock = new Stopwatch(); //create clock object
			clock.Start(); // start clock
			EnemyTimer = 0;
		
		}
		
			public static void TrainLogic()
		{
			int seconds = rand.Next(3001, 8000);
			EnemyTimer += timeDelta; //how much time has gone since I last handled the enemys
			if(EnemyTimer > seconds) // if more than 3 seconds
			{
				EnemyTimer -= seconds; //resets the Timer so it starts counting up again
				
				Train t; // creating a local variable that is an instance of the enemy class
				 
				
				//int speed = rand.Next(1, 6); // using random from 1 - 5
		
				int w =  rand.Next(1,400);
				int h = 150;
								
				
				t = new Train(graphics, graphics.Screen.Rectangle.Width + w, graphics.Screen.Rectangle.Height/2 + h);
				enemies.Add(t);
		
				
			}
	
			
			foreach(Train t in enemies)//for each enemy in my collection
			{
				t.Update(); //update everything in the list
			}
			
			for(int i = enemies.Count - 1; i >= 0; i--)
			{
				if(enemies[i].TrainXposition < -750)
				{
				enemies.Remove(enemies[i]); //removing each enemy in my collection
				}
			}
			
		}
		
		public static void Update ()
		{
			// Query gamepad for current state
			var gamePadData = GamePad.GetData (0);
			TrainLogic();
			bg.update();
		}
		
	 

		public static void Draw ()
		{
			// Clear the screen
			graphics.SetClearColor (0.0f, 0.0f, 0.0f, 0.0f);
			graphics.Clear ();
			
			
			bg.Draw();
			
			foreach(Train t in enemies)//for each enemy in my collection. can call the variable 'e' anything i like. enemies is the list
			{
				t.Draw(); //update everything in the list
			}

			// Present the screen
			graphics.SwapBuffers ();
		}
	}
}
