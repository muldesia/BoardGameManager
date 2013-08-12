using System.Data.Entity;
using BoardGameManager.EntityFramework.DbContexts;
using BoardGameManager.EntityFramework.Entities;

namespace BoardGameManager.Application.DatabaseInitializers
{
    public class DropCreateBoardGameDatabaseInitializer : DropCreateDatabaseAlways<BoardGameContext>
    {
        protected override void Seed(BoardGameContext context)
        {
            var boardGamesToAdd = new BoardGame[]
            {
                new BoardGame("A Game Of Thrones: The Board Game", 3, 5, 120, 180, "http://boardgamegeek.com/boardgame/6472/a-game-of-thrones"),
                new BoardGame("Dominion", 2, 4, 30, 30, "http://boardgamegeek.com/boardgame/36218/dominion"),
                new BoardGame("The Starfarers Of Catan", 3, 4, 120, 120, "http://boardgamegeek.com/boardgame/1897/starfarers-of-catan"),
                new BoardGame("War Of The Ring", 2, 4, 180, null, "http://boardgamegeek.com/boardgame/9609/war-of-the-ring-first-edition"),
                new BoardGame("Monopoly", 2, 6, null, null, "http://boardgamegeek.com/boardgame/1406/monopoly"),
                new BoardGame("Twilight Imperium : 3rd Edition", 3, 6, 180, 240, "http://boardgamegeek.com/boardgame/12493/twilight-imperium-third-edition"),
                new BoardGame("Twilight Imperium : Shattered Empire", 3, 8, 180, 240, "http://boardgamegeek.com/boardgameexpansion/22821/twilight-imperium-third-edition-shattered-empire"),
                new BoardGame("Descent : Journeys In The Dark", 2, 5, 120, 240, "http://boardgamegeek.com/boardgame/17226/descent-journeys-in-the-dark"),
                new BoardGame("Pandemic", 2, 4, 45, 45, "http://boardgamegeek.com/boardgame/30549/pandemic"),
                new BoardGame("Lost Cities", 2, 2, 20, 40, "http://boardgamegeek.com/boardgame/50/lost-cities"),
                new BoardGame("San Juan", 2, 4, 45, 60, "http://boardgamegeek.com/boardgame/8217/san-juan"),
                new BoardGame("Shadows Over Camelot", 3, 7, 60, 80, "http://boardgamegeek.com/boardgame/15062/shadows-over-camelot"),
                new BoardGame("Domaine", 2, 4, 60, 60, "http://boardgamegeek.com/boardgame/5737/domaine"),
                new BoardGame("Ticket To Ride Europe", 2, 5, 30, 60, "http://boardgamegeek.com/boardgame/14996/ticket-to-ride-europe"),
                new BoardGame("Cash n Guns", 4, 6, 30, 30, "http://boardgamegeek.com/boardgame/19237/cash-n-guns"),
                new BoardGame("Cash n Guns Yakuza", 6, 9, 45, 45, "http://boardgamegeek.com/boardgameexpansion/30909/cash-n-guns-yakuzas"),
                new BoardGame("Cranium : 2nd Edition", 4, 16, 60, 60, "http://boardgamegeek.com/boardgame/891/cranium"),
                new BoardGame("Starship Catan", 2, 2, 60, 60, "http://boardgamegeek.com/boardgame/2338/starship-catan"),
                new BoardGame("Kahuna", 2, 2, 30, 40, "http://boardgamegeek.com/boardgame/394/kahuna"),
                new BoardGame("The Settlers Of Catan Card Game + Expansion", 2, 2, 45, 90, "http://boardgamegeek.com/boardgameexpansion/2915/catan-card-game-expansion-set"),
                new BoardGame("Bang!", 4, 7, 20, 40, "http://boardgamegeek.com/boardgame/3955/bang"),
                new BoardGame("Modern Art", 3, 5, 60, 90, "http://boardgamegeek.com/boardgame/118/modern-art"),
                new BoardGame("For Sale", 3, 6, 15, 15, "http://boardgamegeek.com/boardgame/172/for-sale"),
                new BoardGame("Jambo", 2, 2, 40, 40, "http://boardgamegeek.com/boardgame/12002/jambo"),
                new BoardGame("Khronos", 2, 5, 90, 90, "http://boardgamegeek.com/boardgame/25674/khronos"),
                new BoardGame("Dvonn", 2, 2, 30, 30, "http://boardgamegeek.com/boardgame/2346/dvonn"),
                new BoardGame("Maharaja", 2, 5, 90, null, "http://boardgamegeek.com/boardgame/9440/maharaja-the-game-of-palace-building-in-india"),
                new BoardGame("Tigris And Euphrates", 3, 4, 60, 120, "http://boardgamegeek.com/boardgame/42/tigris-euphrates"),
                new BoardGame("Through The Ages", 2, 4, 120,null, "http://boardgamegeek.com/boardgame/25613/through-the-ages-a-story-of-civilization"),
                new BoardGame("Memoir 44 + Expansions", 2, 8, 30, 60, "http://boardgamegeek.com/boardgame/10630/memoir-44"),
                new BoardGame("Struggle Of Empires", 2, 7, 180, 240, "http://boardgamegeek.com/boardgame/9625/struggle-of-empires"),
                new BoardGame("Puerto Rico", 3, 5, 90, 150, "http://boardgamegeek.com/boardgame/3076/puerto-rico"),
                new BoardGame("Twilight Struggle", 2, 2, null, null, "http://boardgamegeek.com/boardgame/12333/twilight-struggle"),
                new BoardGame("Caylus", 2, 5, 60, 150, "http://boardgamegeek.com/boardgame/18602/caylus"),
                new BoardGame("The Princes Of Florence", 3, 5, 75, 100, "http://boardgamegeek.com/boardgame/555/the-princes-of-florence"),
                new BoardGame("Power Grid", 2, 6, 120, 120, "http://boardgamegeek.com/boardgame/2651/power-grid"),
                new BoardGame("Race For The Galaxy", 2, 4, 30, 60, "http://boardgamegeek.com/boardgame/28143/race-for-the-galaxy"),
                new BoardGame("Race For The Galaxy : The Gathering Storm", 1, 5, 30, 60, "http://boardgamegeek.com/boardgameexpansion/34499/race-for-the-galaxy-the-gathering-storm"),
                new BoardGame("Arkham Horror", 1, 8, 120, 240, "http://boardgamegeek.com/boardgame/15987/arkham-horror"),
                new BoardGame("Carcassonne Hunters And Gatherers", 2, 5, 30, 45, "http://boardgamegeek.com/boardgame/4390/carcassonne-hunters-and-gatherers"),
                new BoardGame("Risk", 2, 6, null, null, "http://boardgamegeek.com/boardgame/181/risk"),
                new BoardGame("The Settlers Of Catan", 3, 4, 60, 120, "http://boardgamegeek.com/boardgame/13/the-settlers-of-catan"),
                new BoardGame("The Settlers Of Catan : Cities And Knights", 3, 4, 60, 120, "http://boardgamegeek.com/boardgameexpansion/926/catan-cities-knights"),
                new BoardGame("Pictionary", 3, 16, null, null, "http://boardgamegeek.com/boardgame/2281/pictionary"),
                new BoardGame("Stronghold", 2, 4, 120, null, "http://boardgamegeek.com/boardgame/45986/stronghold"),
                new BoardGame("Small World", 2, 5, 40, 80, "http://boardgamegeek.com/boardgame/40692/small-world"),
                new BoardGame("Dungeon Lords", 2, 4, 90, null, "http://boardgamegeek.com/boardgame/45315/dungeon-lords"),
                new BoardGame("Telestrations", 4, 12, null, null, "http://boardgamegeek.com/boardgame/46213/telestrations"),
                new BoardGame("Balderdash", 2, 6, 60, 60, "http://boardgamegeek.com/boardgame/163/balderdash"),
                new BoardGame("Articulate", 4, 8, 60, 60, "http://boardgamegeek.com/boardgame/6541/articulate"),
                new BoardGame("Royal Palace", 2, 4, 60, 60, "http://boardgamegeek.com/boardgame/38992/royal-palace"),
                new BoardGame("Werewolf: The Village", 8, 18, 30, 30, "http://boardgamegeek.com/boardgame/56885/werewolves-of-millers-hollow-the-village"),
                new BoardGame("Diplomacy", 2, 7, 360, 360, "http://boardgamegeek.com/boardgame/483/diplomacy"),
                new BoardGame("Dungeons and Dragons: The Basic Game", 2, 5, 90, 90, "http://boardgamegeek.com/boardgame/17804/dungeons-dragons-basic-game"),
                new BoardGame("The Pillars Of The Earth", 2, 4, 120, 120, "http://boardgamegeek.com/boardgame/24480/the-pillars-of-the-earth"),
                new BoardGame("A Game Of Thrones: The Card Game", 2, 4, 60, 60, "http://boardgamegeek.com/boardgame/39953/a-game-of-thrones-the-card-game"),
                new BoardGame("Munchkin", 3, 6, 90, 90, "http://boardgamegeek.com/boardgame/1927/munchkin"),
                new BoardGame("Citadels", 2, 7, 90, 90, "http://boardgamegeek.com/boardgame/478/citadels"),
                new BoardGame("Jenga", 2, 8, 20, 20, "http://boardgamegeek.com/boardgame/2452/jenga"),
                new BoardGame("Ming Dynasty", 2, 4, 90, 90, "http://boardgamegeek.com/boardgame/31075/ming-dynasty"),
                new BoardGame("Forbidden Island", 2, 4, 30, 30, "http://boardgamegeek.com/boardgame/65244/forbidden-island"),
                new BoardGame("Scrabble", 2, 4, 90, 90, "http://boardgamegeek.com/boardgame/320/scrabble"),
                new BoardGame("Taboo", 4, 10, 20, 20, "http://boardgamegeek.com/boardgame/1111/taboo"),
                new BoardGame("Gloom", 2, 4, null, null, "http://www.boardgamegeek.com/boardgame/12692/gloom"),
                new BoardGame("Imperial", 2, 6, 120, 180, "http://www.boardgamegeek.com/boardgame/24181/imperial"),
                new BoardGame("Android Netrunner", 2, 2, 30, 60, "http://boardgamegeek.com/boardgame/124742/android-netrunner"), 
                new BoardGame("Eclipse", 2, 6, 60, 180, "http://boardgamegeek.com/boardgame/72125/eclipse"), 
                new BoardGame("Mage Knight", 1, 4, 60, 240, "http://boardgamegeek.com/boardgame/96848/mage-knight-board-game"),
                new BoardGame("Starship Merchants", 2, 3, 90, null, "http://boardgamegeek.com/boardgame/114912/starship-merchants"), 
                new BoardGame("The Resistance: Avalon", 5, 10, 30, 30, "http://boardgamegeek.com/boardgame/128882/the-resistance-avalon"),
                new BoardGame("Dominant Species", 2, 6, 180, null, "http://boardgamegeek.com/boardgame/62219/dominant-species")
            };

            var markOMahoney = new Person("Mark O'Mahoney");

            foreach (var boardGame in boardGamesToAdd)
            {
                boardGame.Owners.Add(markOMahoney);
                context.BoardGames.Add(boardGame);
            }

            base.Seed(context);
        }
    }
}