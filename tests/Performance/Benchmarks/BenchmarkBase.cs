using System.Collections.ObjectModel;
using System.Management.Automation;

namespace Performance.Benchmarks
{
    public abstract class BenchmarkBase
    {
        public abstract string[] ModulesToImport { get; }
        public virtual string Region { get; } = "us-west-2";

        private PowerShell CreateNewPowerShellInstance()
        {
            var modulesToImportString = $"Import-Module '{String.Join("','", ModulesToImport)}'";
            var psInstance = PowerShell.Create();
            psInstance.AddScript("$ErrorActionPreference = 'STOP'");
            psInstance.AddScript("try{Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy Unrestricted}catch{}");
            psInstance.AddScript(modulesToImportString);
            psInstance.AddScript($"Set-DefaultAWSRegion {Region}");
            return psInstance;
        }

        public Collection<PSObject> InvokePowerShellScript(string Script, Dictionary<string, object> Parameters = null)
        {
            var psInstance = CreateNewPowerShellInstance();
            psInstance.AddScript(Script);
            if (Parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in Parameters)
                {
                    psInstance.AddParameter(parameter.Key, parameter.Value);
                }
            }
            var results = psInstance.Invoke();
            psInstance.Dispose();
            return results;
        }
    }
}