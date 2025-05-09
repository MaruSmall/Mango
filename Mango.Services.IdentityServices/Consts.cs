﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System.Dynamic;

namespace Mango.Services.IdentityServices
{
    public static class Consts
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("mango", "Mango Server"),
                new ApiScope(name: "read", displayName: "Read your data."),
                new ApiScope(name: "write", displayName: "Write your data"),
                new ApiScope(name: "delete", displayName: "Delete your data"),
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                 new Client
                {
                    ClientId = "mango",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    RedirectUris = {"https://localhost:44319/signin-oidc" },
                    PostLogoutRedirectUris ={ "https://localhost:44319/signout-callback-oidc"},
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "mango"
                    }
                }
            };
    }
}
