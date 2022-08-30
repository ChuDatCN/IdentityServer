// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.
using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources    =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>                         // Khai báo các API  cần được bảo vệ
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
            };

        public static IEnumerable<Client> Clients => // Khai báo các kiểu tài khoản Client 
            new Client[]                               // Phân quyền truy cập resource cho các domain khác nhau tại đây.    
            {
                new Client
                {
                    ClientId = "umbraco-backoffice",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowAccessTokensViaBrowser = true,
                    AlwaysIncludeUserClaimsInIdToken = false,
                    RequirePkce = true,
                    RedirectUris =              { "https://localhost:44362/signin-oidc"},
                    //PostLogoutRedirectUris =  { "https://localhost:44362/signout-callback-oidc" },
                    AllowedScopes =
                    { 
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "roles"
                    }
                },

                new Client
                {
                    ClientId = "umbraco-backoffice1",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    //AllowedGrantTypes = GrantTypes.Hybrid,
                    //RequirePkce = false,
                    //AllowAccessTokensViaBrowser = true,
                    RedirectUris =           { "https://localhost:44321/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:44321/" },
                    FrontChannelLogoutUri =    "https://localhost:44321/signout-oidc",

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role"

                    }
                },

                new Client
                {
                    ClientId = "umbraco-backoffice3",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    //AllowedGrantTypes = GrantTypes.Hybrid,
                    //RequirePkce = false,
                    //AllowAccessTokensViaBrowser = true,
                    RedirectUris =           { "https://localhost:44313/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:44313/" },
                    FrontChannelLogoutUri =    "https://localhost:44313/signout-oidc",

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role"

                    }
                },

                new Client
                {
                    ClientId = "Umbraco-SSO",
                    ClientName = "Umbraco membership area",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    AllowedScopes = { "openid", "profile", "email" },
                    RequirePkce = true
                }
            };
            
    }
}