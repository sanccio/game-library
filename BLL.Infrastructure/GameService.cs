﻿using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class GameService : IGameService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(GameDTO game)
        {
            var gameEntity = _mapper.Map<GameDTO, Game>(game);

            await _unitOfWork.GameRepository.InsertAsync(gameEntity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var game = await _unitOfWork.GameRepository.GetByIdAsync(id);

            _unitOfWork.GameRepository.Delete(game);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(GameDTO game)
        {
            var gameEntity = _mapper.Map<GameDTO, Game>(game);

            _unitOfWork.GameRepository.Delete(gameEntity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<GameDTO>> GetAllAsync()
        {
            var games = await _unitOfWork.GameRepository.GetAllAsync().ToListAsync();

            return _mapper.Map<IEnumerable<Game>, IEnumerable<GameDTO>>(games);
        }

        public async Task<GameDTO> GetByIdAsync(int id)
        {
            var game = await _unitOfWork.GameRepository.GetByIdAsync(id);

            return _mapper.Map<Game, GameDTO>(game);
        }

        public async Task UpdateAsync(GameDTO game)
        {
            var gameEntity = _mapper.Map<GameDTO, Game>(game);
            _unitOfWork.GameRepository.Update(gameEntity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<GameDTO>> Search(string searchString)
        {
            var games = await GetAllAsync();

            return games.Where(g => g.Name.ToUpper().Contains(searchString.ToUpper()));
        }

        public async Task<IEnumerable<GameDTO>> FilterByGenre(string gameGenre)
        {
            var games = await GetAllAsync();
            var result = games.Where(g => g.Genre != null && g.Genre.ToUpper().Contains(gameGenre.ToUpper()));
            return result;
        }

        public async Task AddGameWithGenreAsync(GameDTO game, List<string> selectedGenres)
        {
            var gameEntity = _mapper.Map<GameDTO, Game>(game);

            await _unitOfWork.GameRepository.InsertAsync(gameEntity);
            await _unitOfWork.SaveChangesAsync();

            for (int i = 0; i < selectedGenres.Count; i++)
            {
                int GenreId = int.Parse(selectedGenres[i]);
                AddGenreToGame(gameEntity.Id, GenreId);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public async void AddGenreToGame(int GameId, int GenreId)
        {
            GameDTO game = await GetByIdAsync(GameId);
            GameGenreDTO gameGenre = new();

            gameGenre.GameId = GameId;
            gameGenre.GenreId = GenreId;

            var gameGenreEntity = _mapper.Map<GameGenreDTO, GameGenre>(gameGenre);
            await _unitOfWork.GameGenresRepository.InsertAsync(gameGenreEntity);
        }

        public async Task<IEnumerable<UserCollectionDTO>> GetGamesByCollectionId(int CollectionId)
        {
            var userCollectionsEntities = await _unitOfWork.UserCollectionRepository.GetAllAsync().ToListAsync();
            var userCollectionGames = userCollectionsEntities.Where(g => g.CollectionId == CollectionId).ToList();
            
            return _mapper.Map<IEnumerable<UserCollection>, IEnumerable<UserCollectionDTO>>(userCollectionGames);
        }

        public async Task AddRatingToGame(string UserId, int GameId, int Rating)
        {
            Rating rating = new();
            rating.ApplicationUserId = UserId;
            rating.GameId = GameId;
            rating.GameRating = Rating;

            await _unitOfWork.RatingRepository.InsertAsync(rating);
            await _unitOfWork.SaveChangesAsync();
        }

        public int GetGameRatingsNumber(int gameId)
        {
            var ratingsNumber = _unitOfWork.RatingRepository.GetAllAsync().Result.Where(r => r.GameId == gameId).Count();

            return ratingsNumber;
        }

        public int CalculateGameRatingScore(int gameId)
        {
            var ratings = _unitOfWork.RatingRepository.GetAllAsync().Result.Where(r => r.GameId == gameId);

            int ratingSum = 0;
            int ratingScore = 0;

            foreach (var rating in ratings)
            {
                ratingSum += rating.GameRating;
            }

            if (ratings.Any())
            {
                ratingScore = ratingSum / ratings.Count();
            }

            return ratingScore;
        }

    }
}
