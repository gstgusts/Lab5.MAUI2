using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;

namespace Lab5.MAUIData.Services
{
    public class ApiDataRepository : IApiDataRepository
    {
        private readonly IStudentApiClient _studentApiClient;

        public ApiDataRepository(IStudentApiClient apiClient)
        {
            _studentApiClient = apiClient;
        }

        public async Task<Student[]> GetStudentsAsync()
        {
           var result =  await _studentApiClient.GetItemsAsync<Student>(StudentApiConstants.StudentsUrl);
           return result;
        }
    }
}
