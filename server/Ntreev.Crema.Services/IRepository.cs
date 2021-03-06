﻿//Released under the MIT License.
//
//Copyright (c) 2018 Ntreev Soft co., Ltd.
//
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
//documentation files (the "Software"), to deal in the Software without restriction, including without limitation the 
//rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit 
//persons to whom the Software is furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the 
//Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
//WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
//COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
//OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ntreev.Crema.ServiceModel;
using Ntreev.Crema.Data;

namespace Ntreev.Crema.Services
{
    public interface IRepository
    {
        void Add(string path);

        void Add(string path, string contents);

        void Modify(string path, string contents);

        void Move(string srcPath, string toPath);

        void Delete(params string[] paths);

        void Copy(string srcPath, string toPath);

        DateTime Commit(string path, string message, IEnumerable<LogPropertyInfo> properties);

        void Revert(string path);

        void Revert(string path, long revision);

        void BeginTransaction(string path, string name);

        void EndTransaction(string path);

        void CancelTransaction(string path);

        void GetBranchInfo(string path, out long revision, out string source, out long sourceRevision);

        long GetRevision(string path);

        LogInfo[] GetLog(string path, long revision, int count);

        Uri GetUri(string path, long revision);

        IDictionary<string, string> Status(string path);

        string Export(Uri uri, string exportPath);

        long Revision { get; }
    }
}
