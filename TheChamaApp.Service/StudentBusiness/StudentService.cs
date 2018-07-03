using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Service.StudentBusiness
{
    public class StudentService : Base.ServiceBase
    {
        #region # Propriedades

        private readonly IStudentApplication _StudentApplication;
        private readonly ICourseApplication _CourseApplication;
        private readonly IRellationshipStudentCourseApplication _RellationshipStudentCourseApplication;

        #endregion

        #region # Constructor

        public StudentService(IStudentApplication studentApplication
            , ICourseApplication courseApplication
            , IRellationshipStudentCourseApplication rellationshipStudentCourseApplication)
        {
            _CourseApplication = courseApplication;
            _StudentApplication = studentApplication;
            _RellationshipStudentCourseApplication = rellationshipStudentCourseApplication;
        }

        #endregion

        #region # Methods

        /// <summary>
        /// Cria um estudante e associa o mesmo ao curso
        /// </summary>
        /// <param name="StudentViewModel"></param>
        /// <param name="Mensagem"></param>
        public Infra.CrossCutting.ViewModel.StudentViewModel CreatedStudentAndRellationCourse(Infra.CrossCutting.ViewModel.StudentViewModel StudentViewModel
        )
        {
            string Mensagem = string.Empty;
            var StudentColletion = _StudentApplication.GetAll().Where(m => m.FirstName == StudentViewModel.FirstName && m.LastName == StudentViewModel.LastName).ToList();
            if (StudentColletion.Count == 0)
            {
                try
                {
                    #region # created student
                    var StudentEntity = new Domain.Entities.Student()
                    {
                        Age = StudentViewModel.Age,
                        FirstName = StudentViewModel.FirstName,
                        LastName = StudentViewModel.LastName
                    };
                    _StudentApplication.Add(StudentEntity);

                    var CourseEntity = _CourseApplication.GetAll().Where(m => m.CourseId == StudentViewModel.Course.CourseId).Single();
                    var RellationCourseStudentColletion = _RellationshipStudentCourseApplication.GetAll().Where(m => m.CourseId == CourseEntity.CourseId).ToList();
                    if (RellationCourseStudentColletion.Count == 0)
                    {
                        var RellationCourseStudentEntity = new Domain.Entities.RellationshipStudentCourse()
                        {
                            CourseId = CourseEntity.CourseId,
                            StudentId = StudentEntity.StudentId
                        };
                        _RellationshipStudentCourseApplication.Add(RellationCourseStudentEntity);
                        Mensagem = "Student Successful into App";
                    }
                    else
                    {
                        if (RellationCourseStudentColletion.Count < CourseEntity.MaxNumberOfStudent)
                        {
                            var RellationCourseStudentEntity = new Domain.Entities.RellationshipStudentCourse()
                            {
                                CourseId = CourseEntity.CourseId,
                                StudentId = StudentEntity.StudentId
                            };
                            _RellationshipStudentCourseApplication.Add(RellationCourseStudentEntity);
                            Mensagem = "Student Successful into App";
                        }
                        else
                        {
                            Mensagem = "This Course with max of student";
                        }
                    }

                    #endregion
                }
                catch (Exception Ex)
                {

                    Mensagem = string.Format("Erro:{0}",Ex.Message);
                }

                
            }
            else {
                // old student with other course
            }
            StudentViewModel.ResultActionMensagem = Mensagem;
            return StudentViewModel;
        }

        /// <summary>
        /// Obtem a media de idade dos alunos
        /// </summary>
        /// <returns></returns>
        public float CalcMediaAgeStudent()
        {
            float FResult = 0;
            decimal Ages = 0;
            var QResult = from A in _StudentApplication.GetAll().GroupBy(m => m.Age).ToList()
                          select new Domain.Entities.Student();
            foreach (var item in QResult)
            {
                Ages += Convert.ToDecimal(item.Age);
            }
            FResult = (float)Convert.ToDouble(Ages / QResult.Count());
            return FResult;
        }

        #endregion
    }
}
