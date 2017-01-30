using CodingTest.EntityModels.Identity;
using CodingTest.IRepositories.Core;
using CodingTest.ViewModels.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CodingTest.IDomainServices.AutoMapper;
using CodingTest.EntityModels;

namespace CodingTest.DomainServices.IdentityStores
{
    public class CustomUserStore : IUserLoginStore<IdentityUserViewModel, long>, 
        IUserClaimStore<IdentityUserViewModel, long>, 
        IUserPasswordStore<IdentityUserViewModel, long>, 
        IUserSecurityStampStore<IdentityUserViewModel, long>, 
        IUserStore<IdentityUserViewModel, long>, IDisposable 
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomUserStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #region IUserStore<IdentityUserViewModel, long> Members
        public Task CreateAsync(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");

            var model = GetUserModel(viewModel);

            unitOfWork.UserRepository.Add(model);
            unitOfWork.UserNewsLetterRepository.Add(new UserNewsLetterEntityModel { NewsLetterIds = viewModel.NewsLetterIds });
            return unitOfWork.CommitAsync();
        }

        public Task DeleteAsync(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");

            var model = GetUserModel(viewModel);

            unitOfWork.UserRepository.Delete(model);
            return unitOfWork.CommitAsync();
        }

        public Task<IdentityUserViewModel> FindByIdAsync(long userId)
        {
            var model = unitOfWork.UserRepository.FindById(userId);
            return Task.FromResult<IdentityUserViewModel>(GetIdentityUserViewModel(model));
        }

        public Task<IdentityUserViewModel> FindByNameAsync(string email)
        {
            var model = unitOfWork.UserRepository.FindByEmail(email);
            return Task.FromResult<IdentityUserViewModel>(GetIdentityUserViewModel(model));
        }

        public Task UpdateAsync(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException("user");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            unitOfWork.UserRepository.Update(model);
            return unitOfWork.CommitAsync();
        }
        #endregion

        #region IUserClaimStore<IdentityUserViewModel, long> Members
        public Task AddClaimAsync(IdentityUserViewModel viewModel, Claim claim)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            if (claim == null)
                throw new ArgumentNullException("claim");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            var claimEntityModel = new ClaimEntityModel
            {
                ClaimType = claim.Type,
                ClaimValue = claim.Value,
                User = model
            };
            model.Claims.Add(claimEntityModel);

            unitOfWork.UserRepository.Update(model);
            return unitOfWork.CommitAsync();
        }

        public Task<IList<Claim>> GetClaimsAsync(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            return Task.FromResult<IList<Claim>>(model.Claims.Select(x => new Claim(x.ClaimType, x.ClaimValue)).ToList());
        }

        public Task RemoveClaimAsync(IdentityUserViewModel viewModel, Claim claim)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            if (claim == null)
                throw new ArgumentNullException("claim");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            var claimEntityModel = model.Claims.FirstOrDefault(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value);
            model.Claims.Remove(claimEntityModel);

            unitOfWork.UserRepository.Update(model);
            return unitOfWork.CommitAsync();
        }
        #endregion

        #region IUserLoginStore<IdentityUserViewModel, long> Members
        public Task AddLoginAsync(IdentityUserViewModel viewModel, UserLoginInfo login)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            if (login == null)
                throw new ArgumentNullException("login");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");


            unitOfWork.UserRepository.Update(model);
            return unitOfWork.CommitAsync();
        }

        public Task<IdentityUserViewModel> FindAsync(UserLoginInfo login)
        {
            if (login == null)
                throw new ArgumentNullException("login");

            var identityUser = default(IdentityUserViewModel);

            return Task.FromResult<IdentityUserViewModel>(identityUser);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            return Task.FromResult(default(IList<UserLoginInfo>));
        }

        public Task RemoveLoginAsync(IdentityUserViewModel viewModel, UserLoginInfo login)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            if (login == null)
                throw new ArgumentNullException("login");

            var model = unitOfWork.UserRepository.FindById(viewModel.Id);
            if (model == null)
                throw new ArgumentException("IdentityUserViewModel does not correspond to a User entity.", "user");

            unitOfWork.UserRepository.Update(model);
            return unitOfWork.CommitAsync();
        }
        #endregion

        #region IUserRoleStore<IdentityUserViewModel, long> Members

        #endregion

        #region IUserPasswordStore<IdentityUserViewModel, long> Members
        public Task<string> GetPasswordHashAsync(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            return Task.FromResult<string>(viewModel.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            return Task.FromResult<bool>(!string.IsNullOrWhiteSpace(viewModel.PasswordHash));
        }

        public Task SetPasswordHashAsync(IdentityUserViewModel viewModel, string passwordHash)
        {
            viewModel.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }
        #endregion

        #region IUserSecurityStampStore<IdentityUserViewModel, long> Members
        public Task<string> GetSecurityStampAsync(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("user");
            return Task.FromResult<string>(viewModel.SecurityStamp);
        }

        public Task SetSecurityStampAsync(IdentityUserViewModel viewModel, string stamp)
        {
            viewModel.SecurityStamp = stamp;
            return Task.FromResult(0);
        }
        #endregion

        #region Private Methods
        private UserEntityModel GetUserModel(IdentityUserViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            var model = viewModel.ToEntityModel<UserEntityModel, IdentityUserViewModel>();
            model.UserId = viewModel.Id;
            return model;
        }

        private IdentityUserViewModel GetIdentityUserViewModel(UserEntityModel model)
        {
            if (model == null)
                return null;

            var viewModel = model.ToViewModel<UserEntityModel, IdentityUserViewModel>();
            viewModel.Id = model.UserId;
            return viewModel;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UserStore() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
        #endregion
    }
}
