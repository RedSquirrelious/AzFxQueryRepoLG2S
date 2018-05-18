using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace AzFxQueryRepoLG2S
{
    public static class GitHubCommits
    {
        public static List<Reference> GetCommitData(GitHubArgs args)
        {
            var destination = Repository.Init(args.LocalRepoPath);
            var repo = new Repository(destination);
            return repo.Network.ListReferences(args.RemoteRepoPath).ToList();
        }
    }
}
