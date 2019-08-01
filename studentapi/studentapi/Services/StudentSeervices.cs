using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentapi.Models;

namespace studentapi.Services
{
    public interface IStudentSeervices
    {
        IEnumerable<Student> GetAll();
        Student Get(int id);
        Student Add(Student NewStudent);
        Student Update(Student updatedStudent);
        void Remove(Student student);
    }
}
