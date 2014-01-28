﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace GlitchGame
{
    public static class Assets
    {
        private static readonly Dictionary<string, Texture> Textures = new Dictionary<string, Texture>();
        private static readonly Dictionary<string, SoundBuffer> Buffers = new Dictionary<string, SoundBuffer>();
        private static readonly List<Sound> Sounds = new List<Sound>();
        private static readonly Dictionary<string, int> SoundCounters = new Dictionary<string, int>();
         
        public static string BaseLocation = "Data/";

        public static Texture LoadTexture(string name)
        {
            Texture texture;

            if (Textures.TryGetValue(name, out texture))
                return texture;

            texture = new Texture(Path.Combine(BaseLocation, name));
            //texture.Smooth = true;
            Textures.Add(name, texture);

            return texture;
        }

        public static SoundBuffer LoadSound(string name)
        {
            SoundBuffer soundBuffer;

            if (!Buffers.TryGetValue(name, out soundBuffer))
            {
                soundBuffer = new SoundBuffer(Path.Combine(BaseLocation, name));
                Buffers.Add(name, soundBuffer);
            }

            return soundBuffer;
        }

        public static void PlaySound(string name, Vector2f position)
        {
            const float maxDist = 2000;
            const float maxVol = 15;
            const float pitchVariation = 0.15f;

            Sounds.RemoveAll(snd => snd.Status != SoundStatus.Playing);

            var dist = Util.Distance(Program.Camera.Position, position);
            var volume = Util.Clamp(1 - (dist / maxDist), 0, 1);

            if (volume <= 0)
                return;

            if (Sounds.Count >= 10)
                return;

            int count;
            if (!SoundCounters.TryGetValue(name, out count))
                count = 0;

            if (count > 0)
                return;

            SoundCounters[name] = count + 1;

            var sound = new Sound(LoadSound(name));
            sound.Volume = maxVol * volume;
            sound.Pitch = 1 + ((float)Program.Random.NextDouble() * 2 - 1) * pitchVariation;

            sound.Play();
            Sounds.Add(sound);
        }

        public static void ResetSoundCounters()
        {
            foreach (var k in SoundCounters.Keys.ToList())
            {
                SoundCounters[k] = 0;
            }
        }
    }
}
