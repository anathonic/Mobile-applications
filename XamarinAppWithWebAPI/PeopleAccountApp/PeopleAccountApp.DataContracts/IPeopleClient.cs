using RestEase;
using System.Threading.Tasks;

namespace PeopleAccountApp.DataContracts
{
    public interface IpeopleClient
    {
        [Post("people")]
        Task AddPersonAsync([Body] Person person);
    }
}
