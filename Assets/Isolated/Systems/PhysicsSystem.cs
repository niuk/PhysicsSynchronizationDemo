using Dullahan.ECS;

namespace PhysicsSynchronizationDemo {
    public abstract class PhysicsSystem : ISystem {
        public abstract int tick { get; }

        public virtual void Tick() {
            throw new System.NotImplementedException();
        }
    }
}