using BoardGameManager.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardGameManager.Web.ViewModels
{
    public class BoardGameViewModel
    {
        public int BoardGameId { get; set; }

        public string Name { get; set; }

        public int BoardGameGeekId { get; set; }

        public GameType GameType { get; set; }

        public int MinPlayers { get; set; }

        public int MaxPlayers { get; set; }

        public Uri BoardGameGeekReviewUri { get; set; }

        public Uri BoardGameGeekSmallImageUri { get; set; }

        public Uri BoardGameGeekMediumImageUri { get; set; }

        public int? MinMinutesToPlay { get; set; }

        public int? MaxMinutesToPlay { get; set; }
    }
}