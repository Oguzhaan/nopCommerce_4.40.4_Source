using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.Backup.Models
{
    public interface ISetBackup
    {
        string  Set(IHostingEnvironment hostingEnvironment,bool local = false);
    }
}
