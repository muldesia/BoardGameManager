using System.Data.Entity;
using BoardGameManager.EntityFramework.DbContexts;
using BoardGameManager.EntityFramework.Entities;
using BoardGameManager.EntityFramework.Enums;

namespace BoardGameManager.Application.DatabaseInitializers
{
    public class DropCreateBoardGameDatabaseInitializer : DropCreateDatabaseAlways<BoardGameDbContext>
    {
        protected override void Seed(BoardGameDbContext dbContext)
        {
            var boardGamesToAdd = new[]
            {
                new BoardGame("A Game Of Thrones: The Board Game", 6472, GameType.BaseGame, 3, 5, "http://boardgamegeek.com/boardgame/6472", 120, 180),
                new BoardGame("Dominion", 36218, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/36218", 30, 30),
                new BoardGame("The Starfarers Of Catan", 1897, GameType.BaseGame, 3, 4, "http://boardgamegeek.com/boardgame/1897", 120, 120),
                new BoardGame("War Of The Ring", 9609, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/9609", 180, null),
                new BoardGame("Monopoly", 1406, GameType.BaseGame, 2, 6, "http://boardgamegeek.com/boardgame/1406", null, null),
                new BoardGame("Twilight Imperium : 3rd Edition", 12493, GameType.BaseGame, 3, 6, "http://boardgamegeek.com/boardgame/12493", 180, 240),
                new BoardGame("Twilight Imperium : Shattered Empire", 22821, GameType.Expansion, 3, 8, "http://boardgamegeek.com/boardgameexpansion/22821", 180, 240),
                new BoardGame("Descent : Journeys In The Dark", 17226, GameType.BaseGame, 2, 5, "http://boardgamegeek.com/boardgame/17226", 120, 240),
                new BoardGame("Lost Cities", 50, GameType.BaseGame, 2, 2, "http://boardgamegeek.com/boardgame/50", 20, 40),
                new BoardGame("San Juan", 8217, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/8217", 45, 60),
                new BoardGame("Shadows Over Camelot", 15062, GameType.BaseGame, 3, 7, "http://boardgamegeek.com/boardgame/15062", 60, 80),
                new BoardGame("Domaine", 5737, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/5737", 60, 60),
                new BoardGame("Ticket To Ride Europe", 14996, GameType.BaseGame, 2, 5, "http://boardgamegeek.com/boardgame/14996", 30, 60),
                new BoardGame("Cash n Guns", 19237, GameType.BaseGame, 4, 6, "http://boardgamegeek.com/boardgame/19237", 30, 30),
                new BoardGame("Cash n Guns Yakuza", 30909, GameType.Expansion, 6, 9, "http://boardgamegeek.com/boardgameexpansion/30909", 45, 45),
                new BoardGame("Cranium : 2nd Edition", 891, GameType.BaseGame, 4, 16, "http://boardgamegeek.com/boardgame/891", 60, 60),
                new BoardGame("Starship Catan", 2338, GameType.BaseGame, 2, 2, "http://boardgamegeek.com/boardgame/2338", 60, 60),
                new BoardGame("Kahuna", 394, GameType.BaseGame, 2, 2, "http://boardgamegeek.com/boardgame/394", 30, 40),
                new BoardGame("The Settlers Of Catan Card Game + Expansion", 2915, GameType.Expansion, 2, 2, "http://boardgamegeek.com/boardgameexpansion/2915", 45, 90),
                new BoardGame("Bang!", 3955, GameType.BaseGame, 4, 7, "http://boardgamegeek.com/boardgame/3955", 20, 40),
                new BoardGame("Modern Art", 118, GameType.BaseGame, 3, 5, "http://boardgamegeek.com/boardgame/118", 60, 90),
                new BoardGame("For Sale", 172, GameType.BaseGame, 3, 6, "http://boardgamegeek.com/boardgame/172", 15, 15),
                new BoardGame("Jambo", 12002, GameType.BaseGame, 2, 2, "http://boardgamegeek.com/boardgame/12002", 40, 40),
                new BoardGame("Khronos", 25674, GameType.BaseGame, 2, 5, "http://boardgamegeek.com/boardgame/25674", 90, 90),
                new BoardGame("Dvonn", 2346, GameType.BaseGame, 2, 2, "http://boardgamegeek.com/boardgame/2346", 30, 30),
                new BoardGame("Maharaja", 9440, GameType.BaseGame, 2, 5, "http://boardgamegeek.com/boardgame/9440", 90, null),
                new BoardGame("Tigris And Euphrates", 42, GameType.BaseGame, 3, 4, "http://boardgamegeek.com/boardgame/42", 60, 120),
                new BoardGame("Through The Ages", 25613, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/25613", 120, null),
                new BoardGame("Memoir 44 + Expansions", 10630, GameType.BaseGame, 2, 8, "http://boardgamegeek.com/boardgame/10630", 30, 60),
                new BoardGame("Struggle Of Empires", 9625, GameType.BaseGame, 2, 7, "http://boardgamegeek.com/boardgame/9625", 180, 240),
                new BoardGame("Puerto Rico", 3076, GameType.BaseGame, 3, 5, "http://boardgamegeek.com/boardgame/3076", 90, 150),
                new BoardGame("Twilight Struggle", 12333, GameType.BaseGame, 2, 2, "http://boardgamegeek.com/boardgame/12333", null, null),
                new BoardGame("Caylus", 18602, GameType.BaseGame, 2, 5, "http://boardgamegeek.com/boardgame/18602", 60, 150),
                new BoardGame("The Princes Of Florence", 555, GameType.BaseGame, 3, 5, "http://boardgamegeek.com/boardgame/555", 75, 100),
                new BoardGame("Power Grid", 2651, GameType.BaseGame, 2, 6, "http://boardgamegeek.com/boardgame/2651", 120, 120),
                new BoardGame("Race For The Galaxy", 28143, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/28143", 30, 60),
                new BoardGame("Race For The Galaxy : The Gathering Storm", 34499, GameType.Expansion, 1, 5, "http://boardgamegeek.com/boardgameexpansion/34499", 30, 60),
                new BoardGame("Arkham Horror", 15987, GameType.BaseGame, 1, 8, "http://boardgamegeek.com/boardgame/15987", 120, 240),
                new BoardGame("Carcassonne Hunters And Gatherers", 4390, GameType.BaseGame, 2, 5, "http://boardgamegeek.com/boardgame/4390", 30, 45),
                new BoardGame("Risk", 181, GameType.BaseGame, 2, 6, "http://boardgamegeek.com/boardgame/181", null, null),
                new BoardGame("The Settlers Of Catan", 13, GameType.BaseGame, 3, 4, "http://boardgamegeek.com/boardgame/13", 60, 120),
                new BoardGame("The Settlers Of Catan : Cities And Knights", 926, GameType.Expansion, 3, 4, "http://boardgamegeek.com/boardgameexpansion/926", 60, 120),
                new BoardGame("Pictionary", 2281, GameType.BaseGame, 3, 16, "http://boardgamegeek.com/boardgame/2281", null, null),
                new BoardGame("Stronghold", 45986, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/45986", 120, null),
                new BoardGame("Small World", 40692, GameType.BaseGame, 2, 5, "http://boardgamegeek.com/boardgame/40692", 40, 80),
                new BoardGame("Dungeon Lords", 45315, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/45315", 90, null),
                new BoardGame("Telestrations", 46213, GameType.BaseGame, 4, 12, "http://boardgamegeek.com/boardgame/46213", null, null),
                new BoardGame("Balderdash", 163, GameType.BaseGame, 2, 6, "http://boardgamegeek.com/boardgame/163", 60, 60),
                new BoardGame("Articulate", 6541, GameType.BaseGame, 4, 8, "http://boardgamegeek.com/boardgame/6541", 60, 60),
                new BoardGame("Royal Palace", 38992, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/38992", 60, 60),
                new BoardGame("Werewolf: The Village", 56885, GameType.BaseGame, 8, 18, "http://boardgamegeek.com/boardgame/56885", 30, 30),
                new BoardGame("Diplomacy", 483, GameType.BaseGame, 2, 7, "http://boardgamegeek.com/boardgame/483", 360, 360),
                new BoardGame("Dungeons and Dragons: The Basic Game", 17804, GameType.BaseGame, 2, 5, "http://boardgamegeek.com/boardgame/17804", 90, 90),
                new BoardGame("The Pillars Of The Earth", 24480, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/24480", 120, 120),
                new BoardGame("A Game Of Thrones: The Card Game", 39953, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/39953", 60, 60),
                new BoardGame("Munchkin", 1927, GameType.BaseGame, 3, 6, "http://boardgamegeek.com/boardgame/1927", 90, 90),
                new BoardGame("Citadels", 478, GameType.BaseGame, 2, 7, "http://boardgamegeek.com/boardgame/478", 90, 90),
                new BoardGame("Jenga", 2452, GameType.BaseGame, 2, 8, "http://boardgamegeek.com/boardgame/2452", 20, 20),
                new BoardGame("Ming Dynasty", 31075, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/31075", 90, 90),
                new BoardGame("Forbidden Island", 65244, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/65244", 30, 30),
                new BoardGame("Scrabble", 320, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/320", 90, 90),
                new BoardGame("Taboo", 1111, GameType.BaseGame, 4, 10, "http://boardgamegeek.com/boardgame/1111", 20, 20),
                new BoardGame("Gloom", 12692, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/12692", null, null),
                new BoardGame("Imperial", 24181, GameType.BaseGame, 2, 6, "http://boardgamegeek.com/boardgame/24181", 120, 180),
                new BoardGame("Android Netrunner", 124742, GameType.BaseGame, 2, 2, "http://boardgamegeek.com/boardgame/124742", 30, 60), 
                new BoardGame("Eclipse", 72125, GameType.BaseGame, 2, 6, "http://boardgamegeek.com/boardgame/72125", 60, 180), 
                new BoardGame("Mage Knight", 96848, GameType.BaseGame, 1, 4, "http://boardgamegeek.com/boardgame/96848", 60, 240),
                new BoardGame("Starship Merchants", 114912, GameType.BaseGame, 2, 4, "http://boardgamegeek.com/boardgame/114912", 90, null), 
                new BoardGame("The Resistance: Avalon", 128882, GameType.BaseGame, 5, 10, "http://boardgamegeek.com/boardgame/128882", 30, 30),
                new BoardGame("Dominant Species", 62219, GameType.BaseGame, 2, 6, "http://boardgamegeek.com/boardgame/62219", 180, null),
                new BoardGame("Dominion: Prosperity", 66690, GameType.Expansion, 2, 4, "http://www.boardgamegeek.com/boardgameexpansion/66690/dominion-prosperity", 30, 30)
            };

            var markOMahoney = new Person("Mark O'Mahoney");

            foreach (var boardGame in boardGamesToAdd)
            {
                boardGame.Owners.Add(markOMahoney);
                dbContext.BoardGames.Add(boardGame);
            }

            base.Seed(dbContext);
        }
    }
}