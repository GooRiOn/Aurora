using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aurora.Infrastructure.Helpers;
using Aurora.Web.Services;
using Xunit;

namespace Aurora.Tests.Tests
{
    public class GravatarTests
    {
        private readonly HttpService _httpService;

        public GravatarTests()
        {
            _httpService = new HttpService();
        }

        [Fact]
        public async Task check_if_gravatar_helper_creates_correct_url()
        {
            var userUrl = GravatarHelper.CreateGravatarUrl("Test");

            var content = await _httpService.GetByteArrayAsync(userUrl);

            Assert.NotNull(content);
        }
    }
}
