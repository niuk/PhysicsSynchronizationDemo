/* THIS IS A GENERATED FILE. DO NOT EDIT. */
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhysicsSynchronizationDemo {
    public class PhysicsSystem_Implementation : PhysicsSynchronizationDemo.PhysicsSystem {
        private int _tick = 0;
        public override int tick => _tick;

        public override void Tick() {
            ++_tick;
            base.Tick();
        }

    }
}
