using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AWSPowerShellGenerator.Utils
{
    /// <summary>
    /// Maintains a collection of cmdlet aliases suitable to writing to a script file
    /// once all cmdlets have been generated
    /// </summary>
    internal class AliasStore
    {
        private Dictionary<string, HashSet<string>> _cmdletAliases = new Dictionary<string, HashSet<string>>();

        AliasStore() { }

        static AliasStore _this;
        public static AliasStore Instance
        {
            get
            {
                if (_this == null)
                    _this = new AliasStore();
                return _this;
            }
        }

        public void AddAlias(string cmdletName, string alias)
        {
            HashSet<string> aliasSet;
            if (!_cmdletAliases.ContainsKey(cmdletName))
            {
                aliasSet = new HashSet<string>();
                _cmdletAliases.Add(cmdletName, aliasSet);
            }
            else
                aliasSet = _cmdletAliases[cmdletName];

            if (!aliasSet.Contains(alias, StringComparer.InvariantCultureIgnoreCase))
                aliasSet.Add(alias);
        }

        public void AddAliases(string cmdletName, IEnumerable<string> aliases)
        {
            foreach (string alias in aliases)
            {
                AddAlias(cmdletName, alias);
            }
        }

        public string Serialize()
        {
            StringWriter sw = new StringWriter();
            foreach (string cmdletName in _cmdletAliases.Keys)
            {
                HashSet<string> aliases = _cmdletAliases[cmdletName];
                foreach (string alias in aliases)
                {
                    sw.WriteLine("Set-Alias -Name {0} -Value {1}", alias, cmdletName);
                }
            }

            return sw.ToString();
        }
    }
}
