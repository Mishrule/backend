using System.Net.Http;
using TimeTableUI.Contracts;
using TimeTableUI.Models.VMs;
using TimeTableUI.Services;

namespace TimeTableUI.Services
{
    public class LecturerRepository: BaseRepository<RootLecturerVM>, ILecturerRepository
    {
        private readonly IHttpClientFactory _client;

        public LecturerRepository(IHttpClientFactory client):base(client)
        {
            _client = client;
        }
    }
}

