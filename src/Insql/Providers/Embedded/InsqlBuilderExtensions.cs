﻿using Insql.Providers;
using Insql.Providers.EmbeddedXml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;

namespace Insql
{
    public static partial class InsqlBuilderExtensions
    {
        public static IInsqlBuilder AddEmbeddedXml(this IInsqlBuilder builder)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IInsqlDescriptorProvider, EmbeddedDescriptorProvider>());
            builder.Services.TryAdd(ServiceDescriptor.Singleton<IConfigureOptions<EmbeddedDescriptorOptions>, EmbeddedDescriptorOptionsSetup>());

            return builder;
        }

        public static IInsqlBuilder AddEmbeddedXml(this IInsqlBuilder builder, Action<EmbeddedDescriptorOptions> configure)
        {
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            builder.AddEmbeddedXml();

            builder.Services.Configure(configure);

            return builder;
        }
    }
}
