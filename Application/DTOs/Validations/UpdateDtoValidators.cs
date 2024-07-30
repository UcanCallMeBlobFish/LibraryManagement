using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Validations
{
    public class EditorUpdateDtoValidator : AbstractValidator<EditorUpdateDto>
    {
        public EditorUpdateDtoValidator()
        {
            RuleFor(x => x.EditorName).NotEmpty().WithMessage("EditorName is required.");
        }
    }

    public class CustomerUpdateDtoValidator : AbstractValidator<CustomerUpdateDto>
    {
        public CustomerUpdateDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid Email is required.");
          
        }
    }

    public class CheckoutUpdateDtoValidator : AbstractValidator<CheckoutUpdateDto>
    {
        public CheckoutUpdateDtoValidator()
        {
            RuleFor(x => x.IsReturned).NotNull().WithMessage("IsReturned is required.");
            RuleFor(x => x.CheckoutDate).NotEmpty().WithMessage("CheckoutDate is required.");
            RuleFor(x => x.ReturnDate).NotEmpty().WithMessage("ReturnDate is required.");
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId is required.");
        }
    }

    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(x => x.CategoryName).NotNull().WithMessage("CategoryName is required.");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }

    public class BookOnShelvesUpdateDtoValidator : AbstractValidator<BookOnShelvesUpdateDto>
    {
        public BookOnShelvesUpdateDtoValidator()
        {
            RuleFor(x => x.Edition).NotEmpty().WithMessage("Edition is required.");
            RuleFor(x => x.Condition).NotNull().WithMessage("Condition is required.");
            RuleFor(x => x.UserNote).NotEmpty().WithMessage("UserNote is required.");
            RuleFor(x => x.BookId).GreaterThan(0).WithMessage("BookId must be greater than 0.");
            RuleFor(x => x.EditorId).GreaterThan(0).WithMessage("EditorId must be greater than 0.");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }

    

    public class BookUpdateDtoValidator : AbstractValidator<BookUpdateDto>
    {
        public BookUpdateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("CategoryId must be greater than 0.");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }

    public class AuthorUpdateDtoValidator : AbstractValidator<AuthorUpdateDto>
    {
        public AuthorUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }

    public class AlertUpdateDtoValidator : AbstractValidator<AlertUpdateDto>
    {
        public AlertUpdateDtoValidator()
        {
            RuleFor(x => x.UserTo).NotEmpty().WithMessage("UserTo is required.");
            RuleFor(x => x.SentDate).NotEmpty().WithMessage("SentDate is required.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is required.");
            RuleFor(x => x.Text).NotEmpty().WithMessage("Text is required.");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }

}
