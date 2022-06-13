using System.Threading.Tasks;
using Bouzin.Models;

namespace Bouzin.Data
{
    public interface IBouzin
    {
        //Build docker container
        string BuildContainer(Container container);

        //Start docker container
        string StartContainer(Container container);

        //Start Bouzin  
        Task<string> StartBouzin(Discovery discovery);
    }
}