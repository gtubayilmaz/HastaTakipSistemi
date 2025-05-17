using KlinikWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Yonetici")]
public class AdminController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IActionResult> Index()
    {
        var users = _userManager.Users.ToList();
        var roles = _roleManager.Roles.Select(r => r.Name).ToList();

        var model = new List<UserRoleViewModel>();

        foreach (var user in users)
        {
            var userRole = await _userManager.GetRolesAsync(user);
            model.Add(new UserRoleViewModel
            {
                UserId = user.Id,
                UserEmail = user.Email,
                CurrentRole = userRole.FirstOrDefault() ?? "YOK",
                AvailableRoles = roles
            });
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AssignRole(string userId, string selectedRole)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var currentRoles = await _userManager.GetRolesAsync(user);

        await _userManager.RemoveFromRolesAsync(user, currentRoles);
        await _userManager.AddToRoleAsync(user, selectedRole);

        return RedirectToAction("Index");
    }
}
