﻿using GlitchGame.Entities;
using GlitchGame.Entities.Projectiles;
using Microsoft.Xna.Framework;
using SFML.Graphics;

namespace GlitchGame.Weapons
{
    public sealed class LaserGun : Weapon
    {
        private const float Speed = 40f;

        public override float MaxCooldown { get { return 0.15f; } }
        public override float EnergyCost { get { return 5; } }

        public LaserGun(Ship parent) : base(parent)
        {
            Icon = new Sprite(Assets.LoadTexture("wep_laser.png")).Center();
        }

        public override void Shoot()
        {
            Program.Entities.AddLast(new Laser(Parent, Left * Parent.Size, new Vector2(0, -Speed)));
            Program.Entities.AddLast(new Laser(Parent, Right * Parent.Size, new Vector2(0, -Speed)));

            Assets.PlaySound("shoot_laser.wav", Parent.Position);
        }
    }
}