using BulletSharp.Math;
using Dullahan.ECS;

namespace PhysicsSynchronizationDemo {
    public interface ITransformComponent : IComponent {
        Vector3 position { get; set; }
        Quaternion rotation { get; set; }
        Vector3 scale { get; set; }
    }
}