using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Automator
{
    class Git
    {
        private CMD _cmd;

        public Git(string startupDir = null)
        {
            _cmd = new CMD();
            if (!string.IsNullOrWhiteSpace(startupDir))
            {
                _cmd.Run(string.Format("cd {0}", startupDir));
            }
        }

        public void Clear()
        {
            _cmd.Run("@echo off");
            _cmd.Run("cls");
        }

        public void Init()
        {
            _cmd.Run("git init");
        }
        public void Add(string filePath = ".")
        {
            _cmd.Run(string.Format("git add {0}", filePath));
        }

        public void Commit(string message)
        {
            _cmd.Run(string.Format("git commit -m \"{0}\"", message));
        }

        public void Commit(string message, string date)
        {
            _cmd.Run(string.Format("set GIT_COMMITTER_DATE=\"{0}\"", date));
            _cmd.Run(string.Format("set GIT_AUTHOR_DATE=\"{0}\"", date));
            Commit(message);
        }

        public void RemoteAdd(string name = "origin", string url = "https://github.com/Ambratolm/test")
        {
            _cmd.Run(string.Format("git remote add {0} {1}", name, url));
        }

        public void BranchMove(string name = "main")
        {
            _cmd.Run(string.Format("git branch -m {0}", name));
        }

        public void Push(string remote = "origin", string branch = "main")
        {
            _cmd.Run(string.Format("git push {0} {1}", remote, branch));
        }
    }
}
