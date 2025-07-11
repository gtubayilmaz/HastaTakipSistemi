﻿namespace KlinikWeb.Models
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string CurrentRole { get; set; }
        public string SelectedRole { get; set; }
        public List<string> AvailableRoles { get; set; }
    }

}
