﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameManager.Domain.Services
{
    public class BoardGameGeekGameDetails
    {
        public Uri SmallBoardGameImage { get; set; }

        public Uri MediumBoardGameImage { get; set; }

        public string Description { get; set; }
    }
}
