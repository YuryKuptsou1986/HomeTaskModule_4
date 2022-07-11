using FluentValidation;

namespace CartService.BLL.Entities.Insert
{
    public class CartInsertViewModelValidator : AbstractValidator<CartInsertViewModel>
    {
        public CartInsertViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Can not be null or empty");
            RuleFor(x => x.Item).NotNull().NotEmpty().WithMessage("Item can not be empty");
            RuleFor(x => x.Item).SetValidator(new ItemInsertViewModelValidator());
        }
    }
}
