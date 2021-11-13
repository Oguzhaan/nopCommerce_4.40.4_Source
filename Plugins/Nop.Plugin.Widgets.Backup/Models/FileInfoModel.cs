using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.Backup.Models
{
    public class FileInfoModel
    {
        public string fileName { get; set; }
        public string fileSize { get; set; }
        public string fileUrl { get; set; }
        public long Length { get; set; }
    }
}
