// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace ECommerce.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources =>
                   new ApiResource[]
                   {
                        new ApiResource("Resources_Catalog")
                        {
                            Scopes={"Catalog_FullPermission" }
                        },
                         new ApiResource("Resources_Order")
                        {
                            Scopes={ "Order_FullPermission" }
                        },
                          new ApiResource("Resources_Discount")
                        {
                            Scopes={ "Discount_FullPermission" }
                        },
                           new ApiResource("Resources_Basket")
                        {
                            Scopes={ "Basket_FullPermission" }
                        },
                            new ApiResource("Resources_Payment")
                        {
                            Scopes={ "Payment_FullPermission" }
                        },
                            new ApiResource("Resources_Photo_Stock")
                        {
                            Scopes={ "Photo_Stock_FullPermission" }
                        },
                    new ApiResource(IdentityServerConstants.LocalApi.ScopeName)


                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
               new ApiScope("Catalog_FullPermission","Katalog API için tam yetkili erişim."),
                new ApiScope("Order_FullPermission", "sipariş api için tam yetkili erişim"),
                new ApiScope("Discount_FullPermission", "indirim api için tam yetkili erişim"),
                new ApiScope("Basket_FullPermission", "sepet api için tam yetkili erişim"),
                new ApiScope("Payment_FullPermission", "ödeme api için tam yetkili erişim"),
                new ApiScope("Photo_Stock_FullPermission", "fotoğraf api için tam yetkili erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "mvcclient",
                    ClientName = "asp.netcoremvc",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedScopes = { "Catalog_FullPermission", "Order_FullPermission", "Discount_FullPermission", "Basket_FullPermission", "Payment_FullPermission", "Photo_Stock_FullPermission",IdentityServerConstants.LocalApi.ScopeName } 
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "scope2" }
                },
            };
    }
}