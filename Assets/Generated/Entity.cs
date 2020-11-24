/* THIS IS A GENERATED FILE. DO NOT EDIT. */
using Dullahan;

namespace PhysicsSynchronizationDemo {
    public class Entity {
        public World world { get; private set; }

        private Entity entity => this;

        public Entity(World world) {
            this.world = world;
        }

        private readonly Ring<int> transformComponent_ticks = new Ring<int>();
        private readonly Ring<PhysicsSynchronizationDemo.ITransformComponent> transformComponent_states = new Ring<PhysicsSynchronizationDemo.ITransformComponent>();
        private readonly Ring<Maybe<PhysicsSynchronizationDemo.ITransformComponent>> transformComponent_diffs = new Ring<Maybe<PhysicsSynchronizationDemo.ITransformComponent>>();
        public PhysicsSynchronizationDemo.ITransformComponent transformComponent {
            get {
                return transformComponent_states.PeekEnd();
            }

            set {
                if (transformComponent_ticks.Count > 0 && transformComponent_ticks.PeekEnd() == entity.world.tick) {
                    transformComponent_states.PopEnd();
                    transformComponent_ticks.PopEnd();
                }

                var differ = new ReferenceDiffer<PhysicsSynchronizationDemo.ITransformComponent>();
                for (int i = 0; i < transformComponent_states.Count; ++i) {
                    int index = transformComponent_states.Start + i;
                    if (differ.Diff(transformComponent_states[index], value, out PhysicsSynchronizationDemo.ITransformComponent diff)) {
                        transformComponent_diffs[index] = new Maybe<PhysicsSynchronizationDemo.ITransformComponent>.Just(diff);
                    } else {
                        transformComponent_diffs[index] = new Maybe<PhysicsSynchronizationDemo.ITransformComponent>.Nothing();
                    }
                }

                transformComponent_states.PushEnd(value);
                transformComponent_ticks.PushEnd(entity.world.tick);

                while (transformComponent_diffs.Count > 0 && transformComponent_diffs.PeekEnd() == null) {
                    transformComponent_ticks.PopEnd();
                    transformComponent_states.PopEnd();
                    transformComponent_diffs.PopEnd();
                }
            }
        }

    }
}
