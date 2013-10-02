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

        public int MinPlayers { get; set; }

        public int MaxPlayers { get; set; }

        public int? MinMinutesToPlay { get; set; }

        public int? MaxMinutesToPlay { get; set; }

        public string BoardGameGeekUrl { get; set; }
    }
}