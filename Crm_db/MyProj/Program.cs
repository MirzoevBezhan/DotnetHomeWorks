using Infastructure.Services;

StudentsService studentsService = new StudentsService();
System.Console.WriteLine(studentsService.DeleteStudent(2));