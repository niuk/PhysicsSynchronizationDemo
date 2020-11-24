using Dullahan;
using BulletSharp.Math;

namespace PhysicsSynchronizationDemo {
    public class Vector3Differ : IDiffer<Vector3, Vector3> {
        public bool Diff(Vector3 left, Vector3 right, out Vector3 diff) {
            // TODO: bound and quantize
            diff = right;
            return left != right;
        }

        public void Patch(ref Vector3 diffable, Vector3 diff) {
            diffable = diff;
        }
    }
}