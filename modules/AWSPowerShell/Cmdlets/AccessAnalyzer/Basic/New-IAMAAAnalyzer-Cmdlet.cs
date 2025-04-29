/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using System.Threading;
using Amazon.AccessAnalyzer;
using Amazon.AccessAnalyzer.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IAMAA
{
    /// <summary>
    /// Creates an analyzer for your account.
    /// </summary>
    [Cmdlet("New", "IAMAAAnalyzer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IAM Access Analyzer CreateAnalyzer API operation.", Operation = new[] {"CreateAnalyzer"}, SelectReturnType = typeof(Amazon.AccessAnalyzer.Model.CreateAnalyzerResponse))]
    [AWSCmdletOutput("System.String or Amazon.AccessAnalyzer.Model.CreateAnalyzerResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AccessAnalyzer.Model.CreateAnalyzerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewIAMAAAnalyzerCmdlet : AmazonAccessAnalyzerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnalyzerName
        /// <summary>
        /// <para>
        /// <para>The name of the analyzer to create.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AnalyzerName { get; set; }
        #endregion
        
        #region Parameter ArchiveRule
        /// <summary>
        /// <para>
        /// <para>Specifies the archive rules to add for the analyzer. Archive rules automatically archive
        /// findings that meet the criteria you define for the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ArchiveRules")]
        public Amazon.AccessAnalyzer.Model.InlineArchiveRule[] ArchiveRule { get; set; }
        #endregion
        
        #region Parameter AnalysisRule_Exclusion
        /// <summary>
        /// <para>
        /// <para>A list of rules for the analyzer containing criteria to exclude from analysis. Entities
        /// that meet the rule criteria will not generate findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UnusedAccess_AnalysisRule_Exclusions")]
        public Amazon.AccessAnalyzer.Model.AnalysisRuleCriteria[] AnalysisRule_Exclusion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs to apply to the analyzer. You can use the set of Unicode
        /// letters, digits, whitespace, <c>_</c>, <c>.</c>, <c>/</c>, <c>=</c>, <c>+</c>, and
        /// <c>-</c>.</para><para>For the tag key, you can specify a value that is 1 to 128 characters in length and
        /// cannot be prefixed with <c>aws:</c>.</para><para>For the tag value, you can specify a value that is 0 to 256 characters in length.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of analyzer to create. Only <c>ACCOUNT</c>, <c>ORGANIZATION</c>, <c>ACCOUNT_UNUSED_ACCESS</c>,
        /// and <c>ORGANIZATION_UNUSED_ACCESS</c> analyzers are supported. You can create only
        /// one analyzer per account per Region. You can create up to 5 analyzers per organization
        /// per Region.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AccessAnalyzer.Type")]
        public Amazon.AccessAnalyzer.Type Type { get; set; }
        #endregion
        
        #region Parameter UnusedAccess_UnusedAccessAge
        /// <summary>
        /// <para>
        /// <para>The specified access age in days for which to generate findings for unused access.
        /// For example, if you specify 90 days, the analyzer will generate findings for IAM entities
        /// within the accounts of the selected organization for any access that hasn't been used
        /// in 90 or more days since the analyzer's last scan. You can choose a value between
        /// 1 and 365 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UnusedAccess_UnusedAccessAge")]
        public System.Int32? UnusedAccess_UnusedAccessAge { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A client token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AccessAnalyzer.Model.CreateAnalyzerResponse).
        /// Specifying the name of a property of type Amazon.AccessAnalyzer.Model.CreateAnalyzerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AnalyzerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IAMAAAnalyzer (CreateAnalyzer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AccessAnalyzer.Model.CreateAnalyzerResponse, NewIAMAAAnalyzerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnalyzerName = this.AnalyzerName;
            #if MODULAR
            if (this.AnalyzerName == null && ParameterWasBound(nameof(this.AnalyzerName)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalyzerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ArchiveRule != null)
            {
                context.ArchiveRule = new List<Amazon.AccessAnalyzer.Model.InlineArchiveRule>(this.ArchiveRule);
            }
            context.ClientToken = this.ClientToken;
            if (this.AnalysisRule_Exclusion != null)
            {
                context.AnalysisRule_Exclusion = new List<Amazon.AccessAnalyzer.Model.AnalysisRuleCriteria>(this.AnalysisRule_Exclusion);
            }
            context.UnusedAccess_UnusedAccessAge = this.UnusedAccess_UnusedAccessAge;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.AccessAnalyzer.Model.CreateAnalyzerRequest();
            
            if (cmdletContext.AnalyzerName != null)
            {
                request.AnalyzerName = cmdletContext.AnalyzerName;
            }
            if (cmdletContext.ArchiveRule != null)
            {
                request.ArchiveRules = cmdletContext.ArchiveRule;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.AccessAnalyzer.Model.AnalyzerConfiguration();
            Amazon.AccessAnalyzer.Model.UnusedAccessConfiguration requestConfiguration_configuration_UnusedAccess = null;
            
             // populate UnusedAccess
            var requestConfiguration_configuration_UnusedAccessIsNull = true;
            requestConfiguration_configuration_UnusedAccess = new Amazon.AccessAnalyzer.Model.UnusedAccessConfiguration();
            System.Int32? requestConfiguration_configuration_UnusedAccess_unusedAccess_UnusedAccessAge = null;
            if (cmdletContext.UnusedAccess_UnusedAccessAge != null)
            {
                requestConfiguration_configuration_UnusedAccess_unusedAccess_UnusedAccessAge = cmdletContext.UnusedAccess_UnusedAccessAge.Value;
            }
            if (requestConfiguration_configuration_UnusedAccess_unusedAccess_UnusedAccessAge != null)
            {
                requestConfiguration_configuration_UnusedAccess.UnusedAccessAge = requestConfiguration_configuration_UnusedAccess_unusedAccess_UnusedAccessAge.Value;
                requestConfiguration_configuration_UnusedAccessIsNull = false;
            }
            Amazon.AccessAnalyzer.Model.AnalysisRule requestConfiguration_configuration_UnusedAccess_configuration_UnusedAccess_AnalysisRule = null;
            
             // populate AnalysisRule
            var requestConfiguration_configuration_UnusedAccess_configuration_UnusedAccess_AnalysisRuleIsNull = true;
            requestConfiguration_configuration_UnusedAccess_configuration_UnusedAccess_AnalysisRule = new Amazon.AccessAnalyzer.Model.AnalysisRule();
            List<Amazon.AccessAnalyzer.Model.AnalysisRuleCriteria> requestConfiguration_configuration_UnusedAccess_configuration_UnusedAccess_AnalysisRule_analysisRule_Exclusion = null;
            if (cmdletContext.AnalysisRule_Exclusion != null)
            {
                requestConfiguration_configuration_UnusedAccess_configuration_UnusedAccess_AnalysisRule_analysisRule_Exclusion = cmdletContext.AnalysisRule_Exclusion;
            }
            if (requestConfiguration_configuration_UnusedAccess_configuration_UnusedAccess_AnalysisRule_analysisRule_Exclusion != null)
            {
                requestConfiguration_configuration_UnusedAccess_configuration_UnusedAccess_AnalysisRule.Exclusions = requestConfiguration_configuration_UnusedAccess_configuration_UnusedAccess_AnalysisRule_analysisRule_Exclusion;
                requestConfiguration_configuration_UnusedAccess_configuration_UnusedAccess_AnalysisRuleIsNull = false;
            }
             // determine if requestConfiguration_configuration_UnusedAccess_configuration_UnusedAccess_AnalysisRule should be set to null
            if (requestConfiguration_configuration_UnusedAccess_configuration_UnusedAccess_AnalysisRuleIsNull)
            {
                requestConfiguration_configuration_UnusedAccess_configuration_UnusedAccess_AnalysisRule = null;
            }
            if (requestConfiguration_configuration_UnusedAccess_configuration_UnusedAccess_AnalysisRule != null)
            {
                requestConfiguration_configuration_UnusedAccess.AnalysisRule = requestConfiguration_configuration_UnusedAccess_configuration_UnusedAccess_AnalysisRule;
                requestConfiguration_configuration_UnusedAccessIsNull = false;
            }
             // determine if requestConfiguration_configuration_UnusedAccess should be set to null
            if (requestConfiguration_configuration_UnusedAccessIsNull)
            {
                requestConfiguration_configuration_UnusedAccess = null;
            }
            if (requestConfiguration_configuration_UnusedAccess != null)
            {
                request.Configuration.UnusedAccess = requestConfiguration_configuration_UnusedAccess;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.AccessAnalyzer.Model.CreateAnalyzerResponse CallAWSServiceOperation(IAmazonAccessAnalyzer client, Amazon.AccessAnalyzer.Model.CreateAnalyzerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IAM Access Analyzer", "CreateAnalyzer");
            try
            {
                return client.CreateAnalyzerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AnalyzerName { get; set; }
            public List<Amazon.AccessAnalyzer.Model.InlineArchiveRule> ArchiveRule { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.AccessAnalyzer.Model.AnalysisRuleCriteria> AnalysisRule_Exclusion { get; set; }
            public System.Int32? UnusedAccess_UnusedAccessAge { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.AccessAnalyzer.Type Type { get; set; }
            public System.Func<Amazon.AccessAnalyzer.Model.CreateAnalyzerResponse, NewIAMAAAnalyzerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
