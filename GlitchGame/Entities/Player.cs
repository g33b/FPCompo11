﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using SFML.Graphics;
using SFML.Window;

namespace GlitchGame.Entities
{
    public class Player : Ship
    {
        public override int DrawOrder { get { return 10; } }
        public override byte RadarType { get { return 1; } }

        public Player(Vector2 position)
            : base(position, "ship.png")
        {
            
        }

        public override void Update()
        {
            Shooting = false;
            Thruster = 0;
            AngularThruster = 0;

            if (Program.HasFocus)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                    Thruster -= 1;

                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                    Thruster += 1;

                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                    AngularThruster -= 1;

                if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                    AngularThruster += 1;

                if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                    Shooting = true;
            }

            base.Update();
        }
    }
}
