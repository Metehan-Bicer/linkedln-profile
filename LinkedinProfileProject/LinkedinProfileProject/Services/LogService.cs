using AutoMapper;
using Azure;
using LinkedinProfileProject.Contexts;
using LinkedinProfileProject.Entities;
using LinkedinProfileProject.Interfaces;
using LinkedinProfileProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.NetworkInformation;

namespace LinkedinProfileProject.Services
{
    public class LogService : ILogService
    {
        private readonly LinkedlnProfileContext _context;

        public LogService(LinkedlnProfileContext context)
        {
            _context = context;
        }

        public async Task<int> LogException(string method, Exception exception)
        {
            int logId = 0;

            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    Log log = new Log();
                    await _context.Log.AddAsync(log);
                    log.Method = method;
                    log.Exception = "Message:" + exception.Message + "\n StackTrace" + exception.StackTrace;
                    log.ExceptionDate = DateTime.Now;

                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    logId = log.Id;
                }
                catch (Exception)
                {
                    Console.WriteLine("Message:" + exception.Message + "\n StackTrace" + exception.StackTrace);
                }
            }

            return logId;
        }
    }
}
