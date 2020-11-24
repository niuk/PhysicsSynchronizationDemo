/* THIS IS A GENERATED FILE. DO NOT EDIT. */
using Dullahan;

namespace PhysicsSynchronizationDemo {
    public class TransformComponent : PhysicsSynchronizationDemo.ITransformComponent {
        public Entity entity { get; private set; }

        public TransformComponent(Entity entity) {
            this.entity = entity;
            entity.transformComponent = this;
        }

        private readonly Ring<int> position_ticks = new Ring<int>();
        private readonly Ring<BulletSharp.Math.Vector3> position_states = new Ring<BulletSharp.Math.Vector3>();
        private readonly Ring<Maybe<BulletSharp.Math.Vector3>> position_diffs = new Ring<Maybe<BulletSharp.Math.Vector3>>();
        public BulletSharp.Math.Vector3 position {
            get {
                return position_states.PeekEnd();
            }

            set {
                if (position_ticks.Count > 0 && position_ticks.PeekEnd() == entity.world.tick) {
                    position_states.PopEnd();
                    position_ticks.PopEnd();
                }

                var differ = new PhysicsSynchronizationDemo.Vector3Differ();
                for (int i = 0; i < position_states.Count; ++i) {
                    int index = position_states.Start + i;
                    if (differ.Diff(position_states[index], value, out BulletSharp.Math.Vector3 diff)) {
                        position_diffs[index] = new Maybe<BulletSharp.Math.Vector3>.Just(diff);
                    } else {
                        position_diffs[index] = new Maybe<BulletSharp.Math.Vector3>.Nothing();
                    }
                }

                position_states.PushEnd(value);
                position_ticks.PushEnd(entity.world.tick);

                while (position_diffs.Count > 0 && position_diffs.PeekEnd() == null) {
                    position_ticks.PopEnd();
                    position_states.PopEnd();
                    position_diffs.PopEnd();
                }
            }
        }

        private readonly Ring<int> rotation_ticks = new Ring<int>();
        private readonly Ring<BulletSharp.Math.Quaternion> rotation_states = new Ring<BulletSharp.Math.Quaternion>();
        private readonly Ring<Maybe<BulletSharp.Math.Quaternion>> rotation_diffs = new Ring<Maybe<BulletSharp.Math.Quaternion>>();
        public BulletSharp.Math.Quaternion rotation {
            get {
                return rotation_states.PeekEnd();
            }

            set {
                if (rotation_ticks.Count > 0 && rotation_ticks.PeekEnd() == entity.world.tick) {
                    rotation_states.PopEnd();
                    rotation_ticks.PopEnd();
                }

                var differ = new PhysicsSynchronizationDemo.QuaternionDiffer();
                for (int i = 0; i < rotation_states.Count; ++i) {
                    int index = rotation_states.Start + i;
                    if (differ.Diff(rotation_states[index], value, out BulletSharp.Math.Quaternion diff)) {
                        rotation_diffs[index] = new Maybe<BulletSharp.Math.Quaternion>.Just(diff);
                    } else {
                        rotation_diffs[index] = new Maybe<BulletSharp.Math.Quaternion>.Nothing();
                    }
                }

                rotation_states.PushEnd(value);
                rotation_ticks.PushEnd(entity.world.tick);

                while (rotation_diffs.Count > 0 && rotation_diffs.PeekEnd() == null) {
                    rotation_ticks.PopEnd();
                    rotation_states.PopEnd();
                    rotation_diffs.PopEnd();
                }
            }
        }

        private readonly Ring<int> scale_ticks = new Ring<int>();
        private readonly Ring<BulletSharp.Math.Vector3> scale_states = new Ring<BulletSharp.Math.Vector3>();
        private readonly Ring<Maybe<BulletSharp.Math.Vector3>> scale_diffs = new Ring<Maybe<BulletSharp.Math.Vector3>>();
        public BulletSharp.Math.Vector3 scale {
            get {
                return scale_states.PeekEnd();
            }

            set {
                if (scale_ticks.Count > 0 && scale_ticks.PeekEnd() == entity.world.tick) {
                    scale_states.PopEnd();
                    scale_ticks.PopEnd();
                }

                var differ = new PhysicsSynchronizationDemo.Vector3Differ();
                for (int i = 0; i < scale_states.Count; ++i) {
                    int index = scale_states.Start + i;
                    if (differ.Diff(scale_states[index], value, out BulletSharp.Math.Vector3 diff)) {
                        scale_diffs[index] = new Maybe<BulletSharp.Math.Vector3>.Just(diff);
                    } else {
                        scale_diffs[index] = new Maybe<BulletSharp.Math.Vector3>.Nothing();
                    }
                }

                scale_states.PushEnd(value);
                scale_ticks.PushEnd(entity.world.tick);

                while (scale_diffs.Count > 0 && scale_diffs.PeekEnd() == null) {
                    scale_ticks.PopEnd();
                    scale_states.PopEnd();
                    scale_diffs.PopEnd();
                }
            }
        }

    }
}
