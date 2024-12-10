using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;

namespace Lab5.MAUIData.Services
{
    public class ApiDataRepository : IDataRepository
    {
        private readonly IStudentApiClient _studentApiClient;

        public ApiDataRepository(IStudentApiClient apiClient)
        {
            _studentApiClient = apiClient;
        }

        public async Task DeleteGrade(int studentId, int gradeId)
        {
            await _studentApiClient
                .DeleteItemAsync($"{StudentApiConstants.StudentsUrl}/{studentId}/{StudentApiConstants.GradesUrl}/{gradeId}");
        }

        public async Task<Grade[]> GetStudentGradesAsync(int studentId)
        {
            var result = await _studentApiClient
                .GetItemsAsync<Grade>($"{StudentApiConstants.StudentsUrl}/{studentId}/{StudentApiConstants.GradesUrl}");
            return result;
        }

        public async Task<Student[]> GetStudentsAsync()
        {
           var result =  await _studentApiClient.GetItemsAsync<Student>(StudentApiConstants.StudentsUrl);
           return result;
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _studentApiClient.UpdateItem<Student>($"{StudentApiConstants.StudentsUrl}/{student.Id}", student);
        }
    }
}
