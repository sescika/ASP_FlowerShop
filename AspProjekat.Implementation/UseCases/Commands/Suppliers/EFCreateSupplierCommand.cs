using AspProjekat.Application.DTO.Suppliers;
using AspProjekat.Application.Exceptions;
using AspProjekat.Application.UseCases.Commands.Suppliers;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using AspProjekat.Implementation.Validators.Suppliers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Implementation.UseCases.Commands.Suppliers
{
	public class EFCreateSupplierCommand : EfUseCase, ICreateSupplierCommand
	{
		private CreateSupplierDtoValidator _validator;

		public EFCreateSupplierCommand(FlowershopContext context, CreateSupplierDtoValidator validatior) : base(context)
		{
			_validator = validatior;
		}

		public int Id => 6;

		public string Name => "Create Supplier";

		public void Execute(CreateSupplierDto data)
		{
			_validator.ValidateAndThrow(data);

			Supplier supplierToAdd = new Supplier
			{
				Name = data.Name,
				SupplierCity = data.City,
				SupplierState = data.State,
				SupplierZipCode = data.ZipCode,
				SupplierPhone = data.PhoneNumber,
				SupplierEmail = data.Email,
				SupplierAddress = data.Address
			};

			Context.Suppliers.Add(supplierToAdd);
			Context.SaveChanges();
		}
	}
}
