﻿using Abp.Application.Navigation;

namespace Acme.PhoneBook.Web.Views.Shared.Components.TopMenu
{
    public class TopMenuViewModel
    {
        public UserMenu MainMenu { get; set; }

        public string ActiveMenuItemName { get; set; }
    }
}