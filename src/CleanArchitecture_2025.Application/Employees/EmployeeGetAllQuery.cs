﻿using CleanArchitecture_2025.Domain.Abstractions;
using CleanArchitecture_2025.Domain.Employees;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace CleanArchitecture_2025.Application.Employees
{
    public sealed record EmployeeGetAllQuery() : IRequest<IQueryable<EmployeeGetAllQueryResponse>>;

    public sealed class EmployeeGetAllQueryResponse : EntityDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateOnly BirthOfDate { get; set; }
        public decimal Salary { get; set; }
        public string TCNo { get; set; } = default!;
    }

    internal sealed class EmployeeGetAllQueryHandler(
        IEmployeeRepository employeeRepository) : IRequestHandler<EmployeeGetAllQuery, IQueryable<EmployeeGetAllQueryResponse>>
    {
        public Task<IQueryable<EmployeeGetAllQueryResponse>> Handle(EmployeeGetAllQuery request, CancellationToken cancellationToken)
        {
            var response = employeeRepository.GetAll();
            var selectedResponse = response.Select(e => new EmployeeGetAllQueryResponse
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Salary = e.Salary,
                BirthOfDate = e.BirthOfDate,
                CreateAt = e.CreateAt,
                DeleteAt = e.DeleteAt,
                Id = e.Id,
                IsDeleted = e.IsDeleted,
                TCNo = e.PersonalInformation.TCNo,
                UpdateAt = e.UpdateAt
            }).AsQueryable();

            return Task.FromResult(selectedResponse);
        }
    }
}
