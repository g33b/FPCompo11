﻿using GlitchGame.Weapons;
using Microsoft.Xna.Framework;

namespace GlitchGame.Entities
{
    public sealed class Enemy : Computer
    {
        public Enemy(Vector2 position)
            : base(position, 1, 1, "enemy")
        {
            var r = Program.Random.NextDouble();

            if (r <= 0.75f)
                Weapon = new LaserGun(this);
            else
                Weapon = new NerfGun(this);

            MaxHealth = 1000;
            Health = MaxHealth;
            MaxEnergy = 500;
            Energy = MaxEnergy;

            HealthRegenRate = 5;
            EnergyRegenRate = 15;

            DamageTakenMultiplier = 1;
            DamageMultiplier = 1;
            SpeedMultiplier = 1;
        }
    }
}
