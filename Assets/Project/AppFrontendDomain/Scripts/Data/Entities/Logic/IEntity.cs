namespace Project.AppFrontendDomain.Pang.Data.Entities
{
    public interface IEntity
    {
        void Death();

        void Hit();

        int Lives { get; }
    }
}