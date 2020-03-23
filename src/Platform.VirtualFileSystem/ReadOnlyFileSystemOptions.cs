namespace Platform.VirtualFileSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ReadOnlyFileSystemOptions : FileSystemOptions
    {
        private static volatile ReadOnlyFileSystemOptions ReadOnlyDefaultOptions;

        public static ReadOnlyFileSystemOptions ReadOnlyDefault
        {
            get
            {
                if (ReadOnlyDefaultOptions == null)
                {
                    lock (typeof(ReadOnlyFileSystemOptions))
                    {
                        if (ReadOnlyDefaultOptions == null)
                        {
                            //var nodeServiceProviderTypes = new List<Type>(ConfigurationSection.Default.NodeServiceProviders);

                            //nodeServiceProviderTypes.Add(typeof(CoreNodeServicesProvider));

                            //ReadOnlyFileSystemOptions.ReadOnlyDefaultOptions = new ReadOnlyFileSystemOptions(typeof(DefaultNodeCache), nodeServiceProviderTypes, ConfigurationSection.Default.NodeResolutionFilters.Select(c => c.Type).ToList(), ConfigurationSection.Default.NodeOperationFilters.Select(c => c.Type).ToList(), new List<Type>(), new FileSystemVariablesCollection(), true);
                            ReadOnlyFileSystemOptions.ReadOnlyDefaultOptions = new ReadOnlyFileSystemOptions();
                        }
                    }
                }

                return ReadOnlyFileSystemOptions.ReadOnlyDefaultOptions;
            }
        }

        public override bool ReadOnly { get { return true; } }

        internal ReadOnlyFileSystemOptions() : base(FileSystemOptions.Default.NodeCacheType, FileSystemOptions.Default.NodeServiceProviderTypes, FileSystemOptions.Default.NodeResolutionFilterTypes, FileSystemOptions.Default.NodeOperationFilterTypes, FileSystemOptions.Default.AccessPermissionVerifierTypes, FileSystemOptions.Default.Variables, true)
        {
        }
    }
}
