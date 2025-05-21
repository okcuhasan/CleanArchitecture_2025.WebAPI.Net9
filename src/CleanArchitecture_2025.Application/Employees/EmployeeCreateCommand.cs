using CleanArchitecture_2025.Domain.Employees;
using FluentValidation;
using GenericRepository;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace CleanArchitecture_2025.Application.Employees
{
    public sealed record EmployeeCreateCommand
    (
        string FirstName,
        string LastName,
        DateOnly BirhOfDate,
        decimal Salary,
        PersonalInformation PersonalInformation,
        Address? Address
    ) : IRequest<Result<string>>;

    public sealed class EmployeeCreateCommandValidator : AbstractValidator<EmployeeCreateCommand>
    {
        public EmployeeCreateCommandValidator()
        {
            RuleFor(e => e.FirstName).MinimumLength(3).WithMessage("Ad alanı en az 3 karakter olmalıdır");
            RuleFor(e => e.LastName).MinimumLength(3).WithMessage("Soyad alanı en az 3 karakter olmalıdır");
            RuleFor(e => e.PersonalInformation.TCNo).MinimumLength(11).WithMessage("Geçerli bir TC Numarası yazın")
                .MaximumLength(11).WithMessage("Geçerli bir TC Numarası yazın");
        }
    }

    internal sealed class EmployeeCreateCommandHandler(
        IEmployeeRepository employeeRepository,IUnitOfWork unitOfWork) : IRequestHandler<EmployeeCreateCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
        {
            bool isEmployeeExist = await employeeRepository.AnyAsync(e => e.PersonalInformation.TCNo == request.PersonalInformation.TCNo);
            if (isEmployeeExist)
                return Result<string>.Failure("Bu TC numarası daha önce kaydedilmiş");

            Employee employee = request.Adapt<Employee>();
            employeeRepository.Add(employee);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Personel kaydı başarıyla tamamlandı";
        }
    }
}
