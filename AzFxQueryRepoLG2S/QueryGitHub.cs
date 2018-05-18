using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace AzFxQueryRepoLG2S
{
    public static class QueryGitHub
    {
        [FunctionName("QueryGitHub")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            try
            {
                log.Info("C# HTTP trigger function processed a request.");
                var args = new GitHubArgs(req);
                var data = GitHubCommits.GetCommitData(args);
                return data == null
                    ? req.CreateResponse(HttpStatusCode.NoContent, "No data")
                    : req.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return req.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            } 
        }
    }
}
