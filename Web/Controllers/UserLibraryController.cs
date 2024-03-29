﻿using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Authorize]
    public class UserLibraryController : Controller
    {
        readonly IUserGameLibraryService _userGameLibraryService;
        readonly IGameService _gameService;

        public UserLibraryController(IUserGameLibraryService gameUserLibraryService, IGameService gameService)
        {
            _userGameLibraryService = gameUserLibraryService;
            _gameService = gameService;
        }

        public async Task<IActionResult> IndexUserLibrary()
        {
            var userLibrary = await _userGameLibraryService.GetAllByUserIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(userLibrary);
        }

        public async Task<IActionResult> AddGameToUserLibrary(int id, int? pageNumber, string actionName, string searchString, int? gameGenreId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _userGameLibraryService.AddGameToUserLibraryAsync(id, userId);

            return RedirectToAction(actionName, "Game", new { pageNumber, searchString, gameGenreId});
        }

        public async Task<IActionResult> IsGamePassed(int id, bool isPassed)
        {
            await _userGameLibraryService.IsGamePassedAsync(id, isPassed);

            return RedirectToAction(nameof(IndexUserLibrary));
        }

        public async Task<IActionResult> RemoveGame(int id)
        {
            await _userGameLibraryService.DeleteByIdAsync(id);

            return RedirectToAction(nameof(IndexUserLibrary));
        }
    }
}
