using AspProjekat.Domain;

namespace AspProjekat.DataAccess
{
	public class CustomerUseCase
	{
        public int CustomerId { get; set; }
        public int UseCaseId { get; set; }
        public virtual Customer Customer {get; set; }  
        public virtual UseCase UseCase { get; set; }
    }
}