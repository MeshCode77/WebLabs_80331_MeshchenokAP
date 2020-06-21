using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Services
{
    public class FileLoggerProvider<T> : ILoggerProvider
    {
        // путь к файлу логирования
        private string _filepath;
        /// <summary>
        /// Констркутор
        /// </summary>
        /// <param name="path">путь к файлу логирования</param>
        public FileLoggerProvider(string path)
        {
            _filepath = path;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger<T>(_filepath);
        }
        public void Dispose()
        {
        }
    }
}
