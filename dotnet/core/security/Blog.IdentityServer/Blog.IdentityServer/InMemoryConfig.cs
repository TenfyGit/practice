using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Blog.IdentityServer
{
    public class InMemoryConfig
    {
        /// <summary>
        /// 这个 Authorization Server 保护了哪些 API （资源）
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource("blog.core.api","Blog.Core API") 
            };
        }
        /// <summary>
        /// 哪些客户端 Client（应用） 可以使用这个 Authorization Server
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client()
                {
                    ClientId = "blogvuejs",//客户端ID
                    ClientSecrets = new[]{new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,//这里使用的是通过用户名密码和ClientCredentials来换取token的方式. ClientCredentials允许Client只使用ClientSecrets来获取token. 这比较适合那种没有用户参与的api动作
                    AllowedScopes = new[]{"blog.core.api"}//允许访问的 API 资源
                }
            };
        }

        public static IEnumerable<TestUser> GetUsers()
        {
            return new[]
            {
                new TestUser()
                {
                    SubjectId = "1",
                    Username = "xietengfei",
                    Password = "xietengfei"
                }
            };
        }
    }
}
