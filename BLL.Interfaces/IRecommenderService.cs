﻿using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRecommenderService
    {
        public Task<List<GameDTO>> GetPersonalizedRecommendationsAsync(string currentUserId);
    }
}
