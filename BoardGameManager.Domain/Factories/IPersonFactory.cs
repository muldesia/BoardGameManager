using BoardGameManager.Domain.Entities;

namespace BoardGameManager.Domain.Factories
{
    public interface IPersonFactory
    {
        Person Create(string name);
    }
}
