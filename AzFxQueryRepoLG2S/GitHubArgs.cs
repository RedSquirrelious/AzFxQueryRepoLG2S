using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AzFxQueryRepoLG2S
{
    public class GitHubArgs
    {
        public string RemoteRepoPath { get; private set; }
        public string LocalRepoPath { get; private set; }

        public GitHubArgs(HttpRequestMessage req)
        {
            var queryPairs = req.GetQueryNameValuePairs();
            var qp = queryPairs.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            GetQueryArgs(qp);
        }

        private void GetQueryArgs(IReadOnlyDictionary<string, string> dict)
        {
            if (!dict.ContainsKey("localRepoPath"))
            {
                throw new ArgumentException("Missing local repository path");

            }

            if (!dict.ContainsKey("remoteRepoPath"))
            {
                throw new ArgumentException("Missing remote repository path");

            }

            RemoteRepoPath = dict["remoteRepoPath"];
            LocalRepoPath = dict["localRepoPath"];
        }
    }
}
