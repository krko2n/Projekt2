using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2.Files
{
    public interface IFile
    {
        string filePath  { get; set; }

        //void CopyTo(IFile entity);
    }
}
