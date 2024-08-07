using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Context;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.DataAccessLayer
{
    public class EmpServiceDal:IEmpServiceDal
    {
        private readonly ApplicationDBContext _context;

        public EmpServiceDal(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ResponseEntity<List<EmpDetailsEntity>>> GetAllEmpDetails()
        {
            var employee = await _context.EmployeeDetails.Where(e => e.IsActive).ToListAsync();
            return new ResponseEntity<List<EmpDetailsEntity>>
            {
                Result = employee,
                IsSuccess = true,
                ResponseMessage = "Datas Retrieved Successfully!",
                StatusMessage = HttpStatusCode.OK.ToString(),
                StatusCode = StatusCodes.Status200OK,
            };
        }
        public async Task<ResponseEntity<int>> PostEmployeeData(EmpDetailsResponseEntity EmpDet)
        {
            try
            {
                var existingdata = await _context.EmployeeDetails
                  .Where(x => x.EmpDetailId == EmpDet.EmpDetailId).FirstOrDefaultAsync();
                var postEmp = new EmpDetailsEntity();
                if (existingdata != null)
                {
                    existingdata.EmpDetailId = EmpDet.EmpDetailId;
                    existingdata.EmpName = EmpDet.EmpName;
                    existingdata.EmpCode = EmpDet.EmpCode;
                    existingdata.EmpDept = EmpDet.EmpDept;
                    existingdata.EmpNumber = EmpDet.EmpNumber;
                    existingdata.EmpAddress = EmpDet.EmpAddress;
                    existingdata.EmpGender= EmpDet.EmpGender;
                    existingdata.EmpDOB= EmpDet.EmpDOB;
                    existingdata.EmpDesignation= EmpDet.EmpDesignation;
                    existingdata.EmpSkills= EmpDet.EmpSkills;
                    existingdata.EmpJoinedOn = EmpDet.EmpJoinedOn;
                    existingdata.EmpPersonalEmail= EmpDet.EmpPersonalEmail;
                    existingdata.IsActive = EmpDet.IsActive;
                    _context.EmployeeDetails.UpdateRange(existingdata);
                }
                else
                {
                    postEmp.EmpName = EmpDet.EmpName;
                    postEmp.EmpCode = EmpDet.EmpCode;
                    postEmp.EmpDept = EmpDet.EmpDept;
                    postEmp.EmpNumber = EmpDet.EmpNumber;
                    postEmp.EmpAddress = EmpDet.EmpAddress;
                    postEmp.EmpGender = EmpDet.EmpGender;
                    postEmp.EmpDOB = EmpDet.EmpDOB;
                    postEmp.EmpDesignation = EmpDet.EmpDesignation;
                    postEmp.EmpSkills = EmpDet.EmpSkills;
                    postEmp.EmpJoinedOn = EmpDet.EmpJoinedOn;
                    postEmp.EmpPersonalEmail = EmpDet.EmpPersonalEmail;
                    postEmp.IsActive = EmpDet.IsActive;
                   
                    _context.EmployeeDetails.AddRange(postEmp);
                }
                await _context.SaveChangesAsync(default);
                int empId = existingdata?.EmpDetailId ?? postEmp.EmpDetailId;
                return new ResponseEntity<int>
                {
                    Result =empId,
                    IsSuccess = true,
                    ResponseMessage = existingdata == null ? "Data Created successfully." : "Data Updated successfully.",
                    StatusMessage = HttpStatusCode.OK.ToString(),
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new ResponseEntity<int>
                {
                    Result = 0,
                    IsSuccess = false,
                    ResponseMessage = ex.Message,
                    StatusMessage = HttpStatusCode.InternalServerError.ToString(),
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }
        }
        public async Task<ResponseEntity<List<EmpDetailsEntity>>> DeleteEmployeeData(int id)
        {
            var response = new ResponseEntity<List<EmpDetailsEntity>>();

            try
            {
                var employee = await _context.EmployeeDetails.FindAsync(id);

                if (employee == null)
                {
                    response.Result = null;
                    response.IsSuccess = false;
                    response.StatusMessage = "Employee not found";
                    response.StatusCode = 404;
                    response.ResponseMessage = "The employee with the provided ID does not exist.";
                    return response;
                }

                employee.IsActive = false;
                _context.Entry(employee).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                response.Result = new List<EmpDetailsEntity> { employee };
                response.IsSuccess = true;
                response.StatusMessage = "Success";
                response.StatusCode = 200;
                response.ResponseMessage = "Employee deactivated successfully";
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.IsSuccess = false;
                response.StatusMessage = "Error";
                response.StatusCode = 500;
                response.ResponseMessage = $"Error deactivating employee: {ex.Message}";
            }

            return response;

        }
        public async Task<ResponseEntity<List<EmpDetailsEntity>>> GetEmpDetailById(int id)
        {
            var response = new ResponseEntity<List<EmpDetailsEntity>>();
            var emp = await _context.EmployeeDetails.Where(e => e.IsActive && e.EmpDetailId == id).FirstOrDefaultAsync();
            if (emp == null)
        {
            response.Result = null;
            response.IsSuccess = false;
            response.StatusMessage = "Employee not found";
            response.StatusCode = 404;
            response.ResponseMessage = "The employee with the provided ID does not exist.";
        }
        else
        {
            response.Result = new List<EmpDetailsEntity> { emp };
            response.IsSuccess = true;
            response.StatusMessage = "Success";
            response.StatusCode = 200;
            response.ResponseMessage = "Employee details retrieved successfully.";
        }
            return response;
        }
    }
}
