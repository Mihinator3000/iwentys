﻿using Iwentys.Features.Assignments.Services;
using Iwentys.Features.Study.Services;
using Iwentys.Features.Study.SubjectAssignments.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Iwentys.Features.Study.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIwentysStudyFeatureServices(this IServiceCollection services)
        {
            services.AddScoped<StudentService>();
            services.AddScoped<StudyService>();
            services.AddScoped<SubjectActivityService>();
            services.AddScoped<SubjectService>();

            return services;
        }

        public static IServiceCollection AddIwentysAssignmentFeatureServices(this IServiceCollection services)
        {
            services.AddScoped<AssignmentService>();

            return services;
        }

        public static IServiceCollection AddIwentysSubjectAssignmentFeatureServices(this IServiceCollection services)
        {
            services.AddScoped<SubjectAssignmentService>();

            return services;
        }
    }
}