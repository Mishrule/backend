﻿using System.Net.Http;
using TimeTableUI.Contracts;
using TimeTableUI.Models.VMs;

namespace TimeTableUI.Services
{
    public class GroupRepository : BaseRepository<GroupVM>, IGroupRepository
    {
        private readonly IHttpClientFactory _client;

        public GroupRepository(IHttpClientFactory client) : base(client)
        {
            _client = client;
        }
    }
}
