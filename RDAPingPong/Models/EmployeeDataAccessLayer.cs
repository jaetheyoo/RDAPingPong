using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RDAPingPong.Models
{
    public class EmployeeDataAccessLayer
    {   
        RDAPingPongContext db = new RDAPingPongContext();

        public IEnumerable<TblEmployee> GetAllEmployees() {
            try {
                return db.TblEmployee.ToList();
            } catch {
                throw;
            }
        }

        // ADD new employee record
        public int AddEmployee(TblEmployee employee) {
            try {
                db.TblEmployee.Add(employee);
                db.SaveChanges();
                return 1;
            } catch {
                throw;
            }
        }

        // UPDATE employee record
        public int UpdateEmployee(TblEmployee employee) {
            try {
                db.TblEmployee.Update(employee);
                db.SaveChanges();
                return 1;
            } catch {
                throw;
            }
    }

        // GET details of employee x
        public TblEmployee GetEmployeeData(int id) {
            try {
                TblEmployee emp = db.TblEmployee.Find(id);
                return emp;
            } catch {
                throw;
            }
        }

        // DELETE the record of emp x
        public int DeleteEmployee(int id) {
            try {
                TblEmployee emp = db.TblEmployee.Find(id);
                db.TblEmployee.Remove(emp);
                db.SaveChanges();
                return 1;
            } catch {
                throw;
            }
        }

        // GET list of cities
        public List<TblCities> GetCities() {

            List<TblCities> lstCity = new List<TblCities>();
            lstCity = (from CityList in db.TblCities select CityList).ToList();
            return lstCity;
        }
    }
}
