using System.Collections;
using System.Threading.Tasks;
using TimeTableUI.Models.VMs;

namespace TimeTableUI.Contracts
{
    public interface IClassRepository : IBaseRepository<ClassVM>
    {
        void GenerateTimeTable(string url);
        void WriteToJson(string url);
    }
}
