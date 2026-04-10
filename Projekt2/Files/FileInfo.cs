using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2.Files
{
    [Table("file")]
    public class File : IFile
    {
        [Key]
        [Column("filePath")]
        public string filePath { get; set; }

        

        public File()
        {
            filePath = "C://";
        }
        

        //public void CopyTo(IFile entity)
        //{
            
        //}
    }
}
