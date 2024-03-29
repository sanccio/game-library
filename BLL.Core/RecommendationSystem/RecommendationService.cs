﻿using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Interfaces.RecommendationSystem;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Core.RecommendationSystem
{
    public class RecommendationService : IRecommendationService
    {
        readonly IMapper _mapper;
        readonly IGameService _gameService;
        readonly IUserService _userService;
        readonly IUserBasedRecommendationService _userBasedRecommendationService;
        readonly ITopGameRecommendationService _topGameRecommendationService;

        public RecommendationService(
            IMapper mapper, 
            IGameService gameService, 
            IUserService userService, 
            IUserBasedRecommendationService userBasedRecommendationService, 
            ITopGameRecommendationService topGameRecommendationService)
        {
            _mapper = mapper;
            _gameService = gameService;
            _userService = userService;
            _userBasedRecommendationService = userBasedRecommendationService;
            _topGameRecommendationService = topGameRecommendationService;
        }

        public async Task<IEnumerable<RecommendedGameDTO>> GetAgregatedRecommendationsAsync(int totalCount, double minAverageRating, string currentUserId)
        {
            var userBasedRecs = (await GetUserBasedRecommendationsAsync(currentUserId, new RecommendationOptions())).ToList();

            if (userBasedRecs.Count >= totalCount)
            {
                return userBasedRecs.Take(totalCount);
            }

            var topGamesRecs = await GetTopRatedGamesRecommendationsAsync(minAverageRating, currentUserId);
            
            var distinctTopGames = topGamesRecs
                .ExceptBy(userBasedRecs.Select(rg => rg.Id), rg => rg.Id);

            var topGamesToSupplement = distinctTopGames
                .Take(totalCount - userBasedRecs.Count);

            userBasedRecs.AddRange(topGamesToSupplement);

            return userBasedRecs;
        }

        public async Task<IEnumerable<RecommendedGameDTO>> GetUserBasedRecommendationsAsync(string currentUserId, RecommendationOptions options)
        {
            ApplicationUserDTO targetUserDTO = _userService.GetUserById(currentUserId);
            IEnumerable<ApplicationUserDTO> usersDTO = _userService.GetAllUsers();

            List<ComparedUserModel> neighbors = _userBasedRecommendationService
                .GetNearestNeighbors(targetUserDTO, usersDTO, options.MinAverageOfUserRatings, options.UsersCount);

            List<GameDTO> recommendedGamesDTO = await _userBasedRecommendationService
                .RetrieveNeighborsGamesForRecommendations(currentUserId, neighbors, options.MinAverageRating, options.EnableRandomOrder);

            List<RecommendedGameDTO> recommendationsDTO = SpecifyRecommendationType(recommendedGamesDTO, RecommendationType.ForYou);

            return recommendationsDTO;
        }

        public async Task<IEnumerable<RecommendedGameDTO>> GetTopRatedGamesRecommendationsAsync(double minAverageRating, string userId, int? count = null)
        {
            var gamesDTO = await _gameService.GetAllAsync();

            IEnumerable<GameDTO> gamesNotRatedByUser = _topGameRecommendationService.GetGamesNotRatedByUser(userId, gamesDTO);

            List<GameDTO> randomTopRatedGames = _topGameRecommendationService.GetRandomTopRatedGames(minAverageRating, gamesNotRatedByUser, count);

            List<RecommendedGameDTO> topRatedGamesRecs = SpecifyRecommendationType(randomTopRatedGames, RecommendationType.TopRated);

            return topRatedGamesRecs;
        }

        private List<RecommendedGameDTO> SpecifyRecommendationType(List<GameDTO> gamesDTO, RecommendationType recommendationType)
        {
            var recommendedGamesDTO = _mapper.Map<List<GameDTO>, List<RecommendedGameDTO>>(gamesDTO);

            recommendedGamesDTO.ForEach(g => g.RecommendationType = recommendationType);

            return recommendedGamesDTO;
        }
    }
}
