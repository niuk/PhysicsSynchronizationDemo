using BulletSharp.Math;
using Dullahan;

namespace PhysicsSynchronizationDemo {
    public class QuaternionDiffer : IDiffer<Quaternion, Quaternion> {
        public bool Diff(Quaternion left, Quaternion right, out Quaternion diff) {
            // TODO: smallest of three
            diff = right;
            return left != right;
        }

        public void Patch(ref Quaternion diffable, Quaternion diff) {
            diffable = diff;
        }
    }
}