using AspProjekat.Application.DTO.Customers;
using AspProjekat.Application.UseCases.Commands.Customers;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using AspProjekat.Implementation.Validators.Customers;
using BCrypt.Net;
using FluentValidation;


namespace AspProjekat.Implementation.UseCases.Commands.Customers
{
	public class EfRegisterCustomerCommand : EfUseCase, IRegisterCustomerCommand
	{
		private RegisterCustomerDtoValidator _validator;

		public EfRegisterCustomerCommand(FlowershopContext context, RegisterCustomerDtoValidator validatior) : base(context)
		{
			_validator = validatior;
		}

		public int Id => 8;

		public string Name => "Register Customer";

		public void Execute(RegisterCustomerDto data)
		{
		
			_validator.ValidateAndThrow(data);
			string hashedPassword = BCrypt.Net.BCrypt.HashPassword(data.Password);
			Customer c = new Customer
			{
				Name = data.Name,
				LastName = data.LastName,
				Address = data.Address,
				Password = hashedPassword,
				City = data.City,
				Email = data.Email,
				State = data.State,
				ZipCode = data.ZipCode,
				Username = data.Username,
			};

			Context.Customers.Add(c);
			Context.SaveChanges();
		}
	}
}
