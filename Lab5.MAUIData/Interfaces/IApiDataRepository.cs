using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.MAUIData.Models;

namespace Lab5.MAUIData.Interfaces
{
    public interface IApiDataRepository
    {
        Task<Student[]> GetStudentsAsync();
    }
}
