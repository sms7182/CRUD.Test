using IdentityServer4.Models;

namespace Car.IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("myresourceapi","My Resource API")
                {
                    Scopes={"apiscope"}
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId="secret_client_id",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={"apiscope"}
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                 new ApiScope(name: "apiscope",   displayName: "Read your data."),
                 
            };
        }
    }
}
