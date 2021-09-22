using FileManager.Infrastructure;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileManager.test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetListsAsyncTest()
        {
            var check = await HttpClientUtils.GetListsAsync<object>("https://dog-facts-api.herokuapp.com/api/v1/resources/dogs/all", null);
            Assert.NotNull(check);
        }
        [Test]
        public async Task GetListsAsyncWithQueries()
        {
            Dictionary<string, string> test = new Dictionary<string, string>();
            var check = await HttpClientUtils.GetListsAsync<object>("https://dog-facts-api.herokuapp.com/api/v1/resources/dogs/all", null);
            Assert.NotNull(check);
        }
    }
}