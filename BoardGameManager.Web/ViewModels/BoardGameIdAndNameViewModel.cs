namespace BoardGameManager.Web.ViewModels
{
    public class BoardGameIdAndNameViewModel
    {
        public BoardGameIdAndNameViewModel(int boardGameId, string name)
        {
            BoardGameId = boardGameId;
            Name = name;
        }

        public int BoardGameId { get; set; } 
        public string Name { get; set; }
    }
}