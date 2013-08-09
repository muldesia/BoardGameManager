using System.Data.Entity.ModelConfiguration;
using BoardGameManager.EntityFramework.Entities;

namespace BoardGameManager.EntityFramework.Mappings
{
    public class PersonMappings : EntityTypeConfiguration<Person>
    {
        public PersonMappings()
        {
            this.HasKey(x => x.PersonId);
            this.HasMany(x => x.OwnedBoardGames).WithMany(x => x.Owners);
        }
    }
}