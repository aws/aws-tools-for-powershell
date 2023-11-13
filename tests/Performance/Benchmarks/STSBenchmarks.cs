using BenchmarkDotNet.Attributes;
using Performance.Helpers;

namespace Performance.Benchmarks
{
    public class STSBenchmarks : BenchmarkBase
    {

        private readonly string RoleName = "perftests" + Guid.NewGuid().ToString("N");


        private string[] _modulesToImport = { "AWS.Tools.Common", "AWS.Tools.SecurityToken" };
        public override string[] ModulesToImport { get { return _modulesToImport; } }

        #region AssumeRole
        [GlobalSetup(Target = nameof(AssumeRole))]
        public void GlobalSetupForAssumeRole()
        {
            string createIAMRoleScript = File.ReadAllText(FileHelper.GetPowerShellScriptPath("STSGlobalSetupForAssumeRole.ps1"));
            var parameters = new Dictionary<string, object> {
                {"RoleName", RoleName}
            };
            var results = InvokePowerShellScript(createIAMRoleScript, parameters);
        }

        [GlobalCleanup(Target = nameof(AssumeRole))]
        public void GlobalCleanupForAssumeRole()
        {
            string deleteIAMRoleScript = File.ReadAllText(FileHelper.GetPowerShellScriptPath("STSGlobalCleanupForAssumeRole.ps1"));
            var parameters = new Dictionary<string, object> {
                {"RoleName", RoleName}
            };
            var results = InvokePowerShellScript(deleteIAMRoleScript, parameters);
        }

        [Benchmark]
        public void AssumeRole()
        {
            string assumeRoleScript = File.ReadAllText(FileHelper.GetPowerShellScriptPath("STSAssumeRoleBenchmarks.ps1"));
            var parameters = new Dictionary<string, object> {
                {"RoleName", RoleName}
            };
            var results = InvokePowerShellScript(assumeRoleScript, parameters);
        }
        #endregion

        #region GetCallerIdentity
        [Benchmark]
        public void GetCallerIdentity()
        {
            string getParameter = "$result = Get-STSCallerIdentity";
            InvokePowerShellScript(getParameter);
        }
        #endregion
    }
}
