namespace Zeus.Idp.Configuration
{
    using IdentityServer4;
    using IdentityServer4.Models;
    using IdentityServer4.Test;
    using System.Collections.Generic;
    using System.Security.Claims;

    public class Config
    {
        public static string IdentityServerResources { get; private set; }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource("updateq", "UpdateQ")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                new IdentityResources.Address()
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "updateq",
                    ClientSecrets = new [] { new Secret("$3cr37".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new [] { "updateq" }
                },
                new Client
                {
                    ClientId = "updateq_implicit",
                    ClientName = "UpdateQ Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new []
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                        "updateq"
                    },
                    AllowAccessTokensViaBrowser = true, // Should be {false}
                    RedirectUris = { "http://localhost:49342/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:49342/signin-callback-oidc" }
                },
                //new Client
                //{
                //    ClientId = "updateq_code",
                //    ClientName = "UpdateQ Code Flow",
                //    ClientSecrets = new [] { new Secret("$3cr37".Sha256()) },
                //    AllowedGrantTypes = GrantTypes.Hybrid,
                //    AllowedScopes = new []
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        IdentityServerConstants.StandardScopes.Email,
                //        IdentityServerConstants.StandardScopes.Address,
                //        IdentityServerConstants.StandardScopes.Phone,
                //        "myapp"
                //    },
                //    AllowOfflineAccess = true,
                //    AllowAccessTokensViaBrowser = true, // Should be {false}
                //    RedirectUris = { "http://localhost:57692/signin-oidc" },
                //    PostLogoutRedirectUris = { "http://localhost:57692/signin-callback-oidc" }
                //}
            };
        }

        public static List<TestUser> Users()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "tester@testing.com",
                    Password = "pass",
                    Claims = new []
                    {
                        new Claim("name", "Tester"),
                        new Claim("website", "https://testing.com"),
                        new Claim("email", "tester@testing.com"),
                        new Claim("address", "24 Somewhere str."),
                        new Claim("phone", "+359 123 123 123")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "my@account.com",
                    Password = "pass",
                    Claims = new []
                    {
                        new Claim("name", "MyName"),
                        new Claim("website", "https://website.com"),
                        new Claim("email", "my@account.com"),
                        new Claim("address", "24 Somewhere str."),
                        new Claim("phone", "+359 312 312 313")
                    }
                }
            };
        }
    }
}
