using System.Net.Http;
using TimeTableUI.Contracts;
using TimeTableUI.Models.VMs;
using TimeTableUI.Services;

namespace TimeTableUI.Services
{
    public class CourseRepository: BaseRepository<CourseVM>, ICourseRepository
    {
        private readonly IHttpClientFactory _client;

        public CourseRepository(IHttpClientFactory client) : base(client)
        {
            _client = client;
        }
    }
}


