using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;

namespace Lab5.MAUIData.Services
{
    public class SqlLightDataRepository : IDataRepository
    {
        public Task DeleteGrade(int studentId, int gradeId)
        {
            throw new NotImplementedException();
        }

        public Task<Grade[]> GetStudentGradesAsync(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<Student[]> GetStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
