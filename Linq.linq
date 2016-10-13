<Query Kind="Statements">
  <Connection>
    <ID>22270af3-aa68-4561-aa72-99a657d18665</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//Q1
var theresults = from x in Skills
where x.RequiresTicket == true
select new{
			x.Description,
			Employees = from y in EmployeeSkills where x.SkillID == y.SkillID
							select new{
							Name = y.Employee.LastName + " " + y.Employee.FirstName,
							Level = y.Level,
							YearsExperience = y.YearsOfExperience
							
							}
 
			};
theresults.Dump();
//Q2
var theresults = from x in Skills
orderby x.Description
select new{
			x.Description,
};
theresults.Dump();
//Q3
var theresults = from x in Skills
				where x.EmployeeSkills.Count() == 0 
				select new{
					x.Description,

				};
theresults.Dump();
//Q4 doesnot work, and I dont understand why there is no data in Schedules and
//different PlacementContractID has different total of NumberOfEmployees
//only PlacementContractID == 3 the sum will be same as showing exmple on website
var theresults = from x in Shifts
where x.PlacementContractID == 3 
				select new{
				x.DayOfWeek,
				sum = Shifts.Sum(y => y.NumberOfEmployees)
								};
				

				
theresults.Dump();
//Q5
var maxyear = (from x in EmployeeSkills
				select x.YearsOfExperience).Max();

var theresults = from x in EmployeeSkills
				where x.YearsOfExperience == maxyear 
				select new{
					Name = x.Employee.FirstName + " " + x.Employee.LastName
				};
theresults.Dump();