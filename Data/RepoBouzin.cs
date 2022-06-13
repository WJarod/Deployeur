using System.Threading.Tasks;
using System.Diagnostics;
using Bouzin.Models;

namespace Bouzin.Data
{
    public class RepoBouzin : IBouzin
    {

        private readonly Process _cmd;

        public RepoBouzin(Process cmd){_cmd = cmd;}

        public string BuildContainer(Container container)
        {
            configCMD();
            _cmd.StartInfo.FileName = "cmd.exe";
            _cmd.StartInfo.Arguments = $"cd dist/dockerfiles/{container.imgName} && docker build -t {container.imgName} .";
            _cmd.Start();
            _cmd.WaitForExit();
            return  "Container built";
        }

        public string StartContainer(Container container)
        {
            configCMD();
            _cmd.StartInfo.FileName = "cmd.exe";
            _cmd.StartInfo.Arguments = $"docker run -dti --name {container.name} -p {container.port}:{container.port} {container.imgName}:latest";
            _cmd.Start();
            _cmd.WaitForExit();
            return  "Container started";
        }

        public async Task<string> StartBouzin(Discovery discovery)
        {
            //Create new container
            Container container = new Container();
            container.id = "1";
            container.name = "service1";
            container.imgName = "node12";
            container.dockerFile = "node12";
            container.discoveryURL = discovery.url;
            container.port = 6001;
            
            //BuildContainer
            BuildContainer(container);

            //StartContainer
            StartContainer(container);

            discovery.containers.Add(container);

            return "Bouzin started";
        }

        private string configCMD()
        {
            _cmd.StartInfo.FileName = "cmd.exe";
            _cmd.StartInfo.RedirectStandardInput = true;
            _cmd.StartInfo.RedirectStandardOutput = true;
            _cmd.StartInfo.CreateNoWindow = true;
            _cmd.StartInfo.UseShellExecute = false;

            return "CMD configured";
        }
    }
}