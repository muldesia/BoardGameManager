using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGameManager.EntityFramework.Entities;

namespace BoardGameManager.EntityFramework.Mappings
{
    public class BoardGameMappings : EntityTypeConfiguration<BoardGame>
    {
        public BoardGameMappings()
        {
            this.HasKey(x => x.BoardGameId);
            this.HasMany(x => x.Owners).WithMany(x => x.OwnedBoardGames);
        }
    }
}
