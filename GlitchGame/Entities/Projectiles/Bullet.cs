﻿using GlitchGame.Devices;
using Microsoft.Xna.Framework;
using SFML.Window;

namespace GlitchGame.Entities.Projectiles
{
    public abstract class Bullet : Projectile
    {
        public override RadarValue Radar { get { return RadarValue.Bullet; } }

        protected Bullet(Ship parent, Vector2 offset, Vector2 speed, string texture)
            : base(parent, texture, parent.Size)
        {
            Sprite.Origin = new Vector2f(Sprite.Texture.Size.X / 2f, 0);

            Body = Util.CreateBullet(Parent.Body, offset, parent.Size, (a, b, contact) =>
            {
                if (b.Body.UserData is Bullet)
                    return false;

                var ship = b.Body.UserData as Ship;

                if (ship == Parent)
                    return false;

                if (ship != null && !Dead)
                    Hit(ship);

                Dead = true;
                return true;
            });

            Body.LinearVelocity = Parent.Body.LinearVelocity + Body.GetWorldVector(speed);
            Body.UserData = this;
        }
    }
}