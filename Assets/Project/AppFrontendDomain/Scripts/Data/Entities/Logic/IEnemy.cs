using UnityEngine;

namespace Project.AppFrontendDomain.Pang.Data.Entities
{
    public interface IEnemy : IEntity
    {
        Transform Transform { get; }
        float Speed { get; }
    }
}