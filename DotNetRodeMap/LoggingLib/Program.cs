using System;
using System.Text;
using Serilog;
using Serilog.Core;

namespace LoggingLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File("Log.txt", outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss}] [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                                         rollingInterval: RollingInterval.Day,//日志按日保存，这样会在文件名称后自动加上日期后缀
                                         rollOnFileSizeLimit: true,          // 限制单个文件的最大长度    
                                         encoding: Encoding.UTF8,            // 文件字符编码     
                                         retainedFileCountLimit: 10,         // 最大保存文件数     
                                         fileSizeLimitBytes: 10 * 1024)      // 最大单个文件长度
                .CreateLogger();
            //Do:
            Log.Verbose("The time is:{0}", DateTime.Now.ToString("yyyy:MM:dd"));

            Log.Information("Hello World");
            Log.Information("AAA");
            Log.Information("BBB");
        }
    }

}
