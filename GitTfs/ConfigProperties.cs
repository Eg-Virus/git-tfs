using System;
using Sep.Git.Tfs.Util;

namespace Sep.Git.Tfs
{
    // Like Globals, but for values that can be set in the git config
    // or overridden by some other means, like from the command line.
    public class ConfigProperties
    {
        ConfigPropertyLoader _loader;

        public ConfigProperties(ConfigPropertyLoader loader)
        {
            _loader = loader;
        }

        public void PersistAllOverrides()
        {
            _loader.PersistAllOverrides();
        }
        
        public int BatchSize
        {
            set { _loader.Override(GitTfsConstants.BatchSize, value); }
            get { return _loader.Get(GitTfsConstants.BatchSize, 100); }
        }

        public long? InitialChangeset
        {
            set
            {
                _loader.Override(GitTfsConstants.InitialChangeset, value ?? -1);
            }
            get
            {
                long? initialChangeset = _loader.Get<long>(GitTfsConstants.InitialChangeset, -1);
                return initialChangeset == -1 ? null : initialChangeset;
            }
        }

    }
}
