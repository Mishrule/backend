using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TimeTableUI.Contracts;
using TimeTableUI.Models.VMs;

namespace TimeTableUI.Services
{
    public class RoomRepository: BaseRepository<RoomVM> , IRoomRepository
    {
        private readonly IHttpClientFactory _client;

        public RoomRepository(IHttpClientFactory client) : base(client)
        {
            _client = client;
        }

    }
}
