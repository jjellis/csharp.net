using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentapi.Models;

namespace studentapi.Services
{
    public class StudentService : IStudentSeervices
    {
        
        private List<Student> _students = new List<Student>()
        {
            new Student
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(2010, 1, 1),
                Email = "john.doe@test.com",
                Phone = "555.555.5555"
            },
            new Student
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                BirthDate = new DateTime(2012, 1, 1),
                Email = "jane.smith@test.com",
                Phone = "555.555.5555"
            }
        };
        private int _nextId = 3;

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student Get(int Id)
        {
            return _students.FirstOrDefault(s => s.Id == Id);
        }
        public Student Add(Student newStudent)
        {

            ValidateStudentBirthDate(newStudent);
            newStudent.Id = _nextId++;
            _students.Add(newStudent);
            return newStudent;
        }

        private void ValidateStudentBirthDate(Student newStudent)
        {
            if (newStudent.BirthDate.Year >= DateTime.Now.Year)
            {
                throw new ApplicationException("birthdate cannot be in the future");
            }
            if (DateTime.Now.Year - newStudent.BirthDate.Year > 19)
            {
                throw new ApplicationException("you are to old to be a student");
            }
           
        }

        public Student Update(Student updatedStudent)
        {
            //find student by id
            var currentStudent = _students.FirstOrDefault(s => s.Id == updatedStudent.Id);
            if (currentStudent == null)
                return null;
            currentStudent.FirstName = updatedStudent.FirstName;
            currentStudent.LastName = updatedStudent.LastName;
            currentStudent.BirthDate = updatedStudent.BirthDate;
            currentStudent.Email = updatedStudent.Email;
            currentStudent.Phone = updatedStudent.Phone;

            return currentStudent;
        }

        public void Remove(Student student)
        {
            var currentStudent = _students.FirstOrDefault(s => s.Id == student.Id);
            if (currentStudent != null)
                _students.Remove(student);
            else
            {
                throw new ApplicationException("No student found");
            }
                
        }
    }
}
