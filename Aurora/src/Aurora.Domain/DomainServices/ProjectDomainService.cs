﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Aurora.DataAccess.Interfaces;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Infrastructure.Interfaces;
using Aurora.Infrastructure.Models.WriteModels;
using Microsoft.Data.Entity;

namespace Aurora.Domain.DomainServices
{
    public sealed class ProjectDomainService : EntityService<ProjectEntity>, IProjectDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryFactory<UserProjectEntity> _userProjectRepositoryFactory;

        public ProjectDomainService(IRepositoryFactory<ProjectEntity> repositoryFactory, IUnitOfWork unitOfWork, IRepositoryFactory<UserProjectEntity> userProjectRepositoryFactory) 
            : base(repositoryFactory, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userProjectRepositoryFactory = userProjectRepositoryFactory;
        }

        public void CreateProject(ProjectCreateWriteModel project, string creatorId)
        {
            var projectEntity = new ProjectEntity
            {
                Name = project.Name,
                Description = project.Description,
                MemberToken = project.MemberToken,
                Members = project.Members.Select(m => new UserProjectEntity
                {
                    UserId = m.Id
                }).ToList()
            };

            projectEntity.Members.Add(new UserProjectEntity {UserId = creatorId, IsActivated = true, IsDeafult = true});

            WriteRepository.Add(projectEntity);
        }

        public async Task ActivateProjectMemberAsync(Guid memberToken, string userId)
        {
            var userProjectReadRepository = _userProjectRepositoryFactory.GetRead(_unitOfWork);
            var userProjectWriteRepository = _userProjectRepositoryFactory.GetWrite(_unitOfWork);

            var projectMember = await userProjectReadRepository.Query.SingleOrDefaultAsync(pm => pm.UserId == userId && pm.Project.MemberToken == memberToken);

            projectMember.IsActivated = true;
            projectMember.IsDeafult = true;

            userProjectWriteRepository.Update(projectMember);
        }

        public void SetDefaultUserProject(int projectId, string userId)
        {
            var writeUserProjectRepository = _userProjectRepositoryFactory.GetWrite(_unitOfWork);

            var userProject = new UserProjectEntity
            {
                ProjectId = projectId,
                UserId = userId,
                IsDeafult = true
            };

            writeUserProjectRepository.UpdateAttached(userProject, up => up.IsDeafult);
        }
    }
}
