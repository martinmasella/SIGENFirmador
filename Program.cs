using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGENFirmador
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigureAssemblyResolver();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        private static void ConfigureAssemblyResolver()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                var assemblyName = new AssemblyName(args.Name).Name;
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                var projectRoot = Path.GetFullPath(Path.Combine(baseDir, "..", ".."));

                var candidates = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { "Microsoft.Extensions.Logging", Path.Combine(projectRoot, "packages", "Microsoft.Extensions.Logging.10.0.0", "lib", "net462", "Microsoft.Extensions.Logging.dll") },
                    { "Microsoft.Extensions.Logging.Abstractions", Path.Combine(projectRoot, "packages", "Microsoft.Extensions.Logging.Abstractions.10.0.0", "lib", "net462", "Microsoft.Extensions.Logging.Abstractions.dll") },
                    { "Microsoft.Extensions.DependencyInjection", Path.Combine(projectRoot, "packages", "Microsoft.Extensions.DependencyInjection.10.0.0", "lib", "net462", "Microsoft.Extensions.DependencyInjection.dll") },
                    { "Microsoft.Extensions.DependencyInjection.Abstractions", Path.Combine(projectRoot, "packages", "Microsoft.Extensions.DependencyInjection.Abstractions.10.0.0", "lib", "net462", "Microsoft.Extensions.DependencyInjection.Abstractions.dll") },
                    { "Microsoft.Extensions.Options", Path.Combine(projectRoot, "packages", "Microsoft.Extensions.Options.10.0.0", "lib", "net462", "Microsoft.Extensions.Options.dll") },
                    { "Microsoft.Extensions.Primitives", Path.Combine(projectRoot, "packages", "Microsoft.Extensions.Primitives.10.0.0", "lib", "net462", "Microsoft.Extensions.Primitives.dll") },
                    { "System.Diagnostics.DiagnosticSource", Path.Combine(projectRoot, "packages", "System.Diagnostics.DiagnosticSource.10.0.0", "lib", "net462", "System.Diagnostics.DiagnosticSource.dll") },
                    { "System.Memory", Path.Combine(projectRoot, "packages", "System.Memory.4.6.3", "lib", "netstandard2.0", "System.Memory.dll") },
                    { "System.Buffers", Path.Combine(projectRoot, "packages", "System.Buffers.4.6.1", "lib", "netstandard2.0", "System.Buffers.dll") },
                    { "System.Runtime.CompilerServices.Unsafe", Path.Combine(projectRoot, "packages", "System.Runtime.CompilerServices.Unsafe.6.1.2", "lib", "netstandard2.0", "System.Runtime.CompilerServices.Unsafe.dll") },
                    { "System.ValueTuple", Path.Combine(projectRoot, "packages", "System.ValueTuple.4.6.1", "lib", "netstandard2.0", "System.ValueTuple.dll") },
                    { "System.Numerics.Vectors", Path.Combine(projectRoot, "packages", "System.Numerics.Vectors.4.6.1", "lib", "netstandard2.0", "System.Numerics.Vectors.dll") },
                    { "System.Threading.Tasks.Extensions", Path.Combine(projectRoot, "packages", "System.Threading.Tasks.Extensions.4.6.3", "lib", "netstandard2.0", "System.Threading.Tasks.Extensions.dll") },
                    { "Microsoft.Bcl.AsyncInterfaces", Path.Combine(projectRoot, "packages", "Microsoft.Bcl.AsyncInterfaces.10.0.0", "lib", "netstandard2.0", "Microsoft.Bcl.AsyncInterfaces.dll") }
                };

                if (candidates.TryGetValue(assemblyName, out var packagePath) && File.Exists(packagePath))
                {
                    return Assembly.LoadFrom(packagePath);
                }

                var localPath = Path.Combine(baseDir, assemblyName + ".dll");
                return File.Exists(localPath) ? Assembly.LoadFrom(localPath) : null;
            };
        }
    }
}
