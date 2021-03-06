﻿using LoonyVM;

namespace GlitchGame.Devices
{
    public class Guns : IDevice
    {
        public byte Id { get { return 13; } }
        public bool InterruptRequest { get { return false; } }

        public bool Shooting { get; private set; }

        public void HandleInterrupt(VirtualMachine machine)
        {
            Shooting = machine.Registers[0] != 0;
        }

        public void HandleInterruptRequest(VirtualMachine machine)
        {

        }
    }
}
