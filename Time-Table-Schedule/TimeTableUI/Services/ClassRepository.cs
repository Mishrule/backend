using System.Net.Http;
using TimeTableUI.Contracts;
using TimeTableUI.Models.VMs;

namespace TimeTableUI.Services
{
    public class ClassRepository : BaseRepository<ClassVM>, IClassRepository
    {
        private readonly IHttpClientFactory _client;

        public ClassRepository(IHttpClientFactory client) : base(client)
        {
            _client = client;
        }
    }
}
