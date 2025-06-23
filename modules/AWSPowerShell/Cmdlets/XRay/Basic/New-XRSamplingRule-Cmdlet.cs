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
using Amazon.XRay;
using Amazon.XRay.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.XR
{
    /// <summary>
    /// Creates a rule to control sampling behavior for instrumented applications. Services
    /// retrieve rules with <a href="https://docs.aws.amazon.com/xray/latest/api/API_GetSamplingRules.html">GetSamplingRules</a>,
    /// and evaluate each rule in ascending order of <i>priority</i> for each request. If
    /// a rule matches, the service records a trace, borrowing it from the reservoir size.
    /// After 10 seconds, the service reports back to X-Ray with <a href="https://docs.aws.amazon.com/xray/latest/api/API_GetSamplingTargets.html">GetSamplingTargets</a>
    /// to get updated versions of each in-use rule. The updated rule contains a trace quota
    /// that the service can use instead of borrowing from the reservoir.
    /// </summary>
    [Cmdlet("New", "XRSamplingRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.XRay.Model.SamplingRuleRecord")]
    [AWSCmdlet("Calls the AWS X-Ray CreateSamplingRule API operation.", Operation = new[] {"CreateSamplingRule"}, SelectReturnType = typeof(Amazon.XRay.Model.CreateSamplingRuleResponse))]
    [AWSCmdletOutput("Amazon.XRay.Model.SamplingRuleRecord or Amazon.XRay.Model.CreateSamplingRuleResponse",
        "This cmdlet returns an Amazon.XRay.Model.SamplingRuleRecord object.",
        "The service call response (type Amazon.XRay.Model.CreateSamplingRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewXRSamplingRuleCmdlet : AmazonXRayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SamplingRule_Attribute
        /// <summary>
        /// <para>
        /// <para>Matches attributes derived from the request.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SamplingRule_Attributes")]
        public System.Collections.Hashtable SamplingRule_Attribute { get; set; }
        #endregion
        
        #region Parameter SamplingRule_FixedRate
        /// <summary>
        /// <para>
        /// <para>The percentage of matching requests to instrument, after the reservoir is exhausted.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Double? SamplingRule_FixedRate { get; set; }
        #endregion
        
        #region Parameter SamplingRule_Host
        /// <summary>
        /// <para>
        /// <para>Matches the hostname from a request URL.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SamplingRule_Host { get; set; }
        #endregion
        
        #region Parameter SamplingRule_HTTPMethod
        /// <summary>
        /// <para>
        /// <para>Matches the HTTP method of a request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SamplingRule_HTTPMethod { get; set; }
        #endregion
        
        #region Parameter SamplingRule_Priority
        /// <summary>
        /// <para>
        /// <para>The priority of the sampling rule.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? SamplingRule_Priority { get; set; }
        #endregion
        
        #region Parameter SamplingRule_ReservoirSize
        /// <summary>
        /// <para>
        /// <para>A fixed number of matching requests to instrument per second, prior to applying the
        /// fixed rate. The reservoir is not used directly by services, but applies to all services
        /// using the rule collectively.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? SamplingRule_ReservoirSize { get; set; }
        #endregion
        
        #region Parameter SamplingRule_ResourceARN
        /// <summary>
        /// <para>
        /// <para>Matches the ARN of the Amazon Web Services resource on which the service runs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SamplingRule_ResourceARN { get; set; }
        #endregion
        
        #region Parameter SamplingRule_RuleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the sampling rule. Specify a rule by either name or ARN, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamplingRule_RuleARN { get; set; }
        #endregion
        
        #region Parameter SamplingRule_RuleName
        /// <summary>
        /// <para>
        /// <para>The name of the sampling rule. Specify a rule by either name or ARN, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamplingRule_RuleName { get; set; }
        #endregion
        
        #region Parameter SamplingRule_ServiceName
        /// <summary>
        /// <para>
        /// <para>Matches the <c>name</c> that the service uses to identify itself in segments.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SamplingRule_ServiceName { get; set; }
        #endregion
        
        #region Parameter SamplingRule_ServiceType
        /// <summary>
        /// <para>
        /// <para>Matches the <c>origin</c> that the service uses to identify its type in segments.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SamplingRule_ServiceType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map that contains one or more tag keys and tag values to attach to an X-Ray sampling
        /// rule. For more information about ways to use tags, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services resources</a> in the <i>Amazon Web Services General Reference</i>.</para><para>The following restrictions apply to tags:</para><ul><li><para>Maximum number of user-applied tags per resource: 50</para></li><li><para>Maximum tag key length: 128 Unicode characters</para></li><li><para>Maximum tag value length: 256 Unicode characters</para></li><li><para>Valid values for key and value: a-z, A-Z, 0-9, space, and the following characters:
        /// _ . : / = + - and @</para></li><li><para>Tag keys and values are case sensitive.</para></li><li><para>Don't use <c>aws:</c> as a prefix for keys; it's reserved for Amazon Web Services
        /// use.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.XRay.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter SamplingRule_URLPath
        /// <summary>
        /// <para>
        /// <para>Matches the path from a request URL.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SamplingRule_URLPath { get; set; }
        #endregion
        
        #region Parameter SamplingRule_Version
        /// <summary>
        /// <para>
        /// <para>The version of the sampling rule format (<c>1</c>).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? SamplingRule_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SamplingRuleRecord'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.XRay.Model.CreateSamplingRuleResponse).
        /// Specifying the name of a property of type Amazon.XRay.Model.CreateSamplingRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SamplingRuleRecord";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-XRSamplingRule (CreateSamplingRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.XRay.Model.CreateSamplingRuleResponse, NewXRSamplingRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.SamplingRule_Attribute != null)
            {
                context.SamplingRule_Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SamplingRule_Attribute.Keys)
                {
                    context.SamplingRule_Attribute.Add((String)hashKey, (System.String)(this.SamplingRule_Attribute[hashKey]));
                }
            }
            context.SamplingRule_FixedRate = this.SamplingRule_FixedRate;
            #if MODULAR
            if (this.SamplingRule_FixedRate == null && ParameterWasBound(nameof(this.SamplingRule_FixedRate)))
            {
                WriteWarning("You are passing $null as a value for parameter SamplingRule_FixedRate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SamplingRule_Host = this.SamplingRule_Host;
            #if MODULAR
            if (this.SamplingRule_Host == null && ParameterWasBound(nameof(this.SamplingRule_Host)))
            {
                WriteWarning("You are passing $null as a value for parameter SamplingRule_Host which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SamplingRule_HTTPMethod = this.SamplingRule_HTTPMethod;
            #if MODULAR
            if (this.SamplingRule_HTTPMethod == null && ParameterWasBound(nameof(this.SamplingRule_HTTPMethod)))
            {
                WriteWarning("You are passing $null as a value for parameter SamplingRule_HTTPMethod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SamplingRule_Priority = this.SamplingRule_Priority;
            #if MODULAR
            if (this.SamplingRule_Priority == null && ParameterWasBound(nameof(this.SamplingRule_Priority)))
            {
                WriteWarning("You are passing $null as a value for parameter SamplingRule_Priority which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SamplingRule_ReservoirSize = this.SamplingRule_ReservoirSize;
            #if MODULAR
            if (this.SamplingRule_ReservoirSize == null && ParameterWasBound(nameof(this.SamplingRule_ReservoirSize)))
            {
                WriteWarning("You are passing $null as a value for parameter SamplingRule_ReservoirSize which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SamplingRule_ResourceARN = this.SamplingRule_ResourceARN;
            #if MODULAR
            if (this.SamplingRule_ResourceARN == null && ParameterWasBound(nameof(this.SamplingRule_ResourceARN)))
            {
                WriteWarning("You are passing $null as a value for parameter SamplingRule_ResourceARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SamplingRule_RuleARN = this.SamplingRule_RuleARN;
            context.SamplingRule_RuleName = this.SamplingRule_RuleName;
            context.SamplingRule_ServiceName = this.SamplingRule_ServiceName;
            #if MODULAR
            if (this.SamplingRule_ServiceName == null && ParameterWasBound(nameof(this.SamplingRule_ServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter SamplingRule_ServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SamplingRule_ServiceType = this.SamplingRule_ServiceType;
            #if MODULAR
            if (this.SamplingRule_ServiceType == null && ParameterWasBound(nameof(this.SamplingRule_ServiceType)))
            {
                WriteWarning("You are passing $null as a value for parameter SamplingRule_ServiceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SamplingRule_URLPath = this.SamplingRule_URLPath;
            #if MODULAR
            if (this.SamplingRule_URLPath == null && ParameterWasBound(nameof(this.SamplingRule_URLPath)))
            {
                WriteWarning("You are passing $null as a value for parameter SamplingRule_URLPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SamplingRule_Version = this.SamplingRule_Version;
            #if MODULAR
            if (this.SamplingRule_Version == null && ParameterWasBound(nameof(this.SamplingRule_Version)))
            {
                WriteWarning("You are passing $null as a value for parameter SamplingRule_Version which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.XRay.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.XRay.Model.CreateSamplingRuleRequest();
            
            
             // populate SamplingRule
            var requestSamplingRuleIsNull = true;
            request.SamplingRule = new Amazon.XRay.Model.SamplingRule();
            Dictionary<System.String, System.String> requestSamplingRule_samplingRule_Attribute = null;
            if (cmdletContext.SamplingRule_Attribute != null)
            {
                requestSamplingRule_samplingRule_Attribute = cmdletContext.SamplingRule_Attribute;
            }
            if (requestSamplingRule_samplingRule_Attribute != null)
            {
                request.SamplingRule.Attributes = requestSamplingRule_samplingRule_Attribute;
                requestSamplingRuleIsNull = false;
            }
            System.Double? requestSamplingRule_samplingRule_FixedRate = null;
            if (cmdletContext.SamplingRule_FixedRate != null)
            {
                requestSamplingRule_samplingRule_FixedRate = cmdletContext.SamplingRule_FixedRate.Value;
            }
            if (requestSamplingRule_samplingRule_FixedRate != null)
            {
                request.SamplingRule.FixedRate = requestSamplingRule_samplingRule_FixedRate.Value;
                requestSamplingRuleIsNull = false;
            }
            System.String requestSamplingRule_samplingRule_Host = null;
            if (cmdletContext.SamplingRule_Host != null)
            {
                requestSamplingRule_samplingRule_Host = cmdletContext.SamplingRule_Host;
            }
            if (requestSamplingRule_samplingRule_Host != null)
            {
                request.SamplingRule.Host = requestSamplingRule_samplingRule_Host;
                requestSamplingRuleIsNull = false;
            }
            System.String requestSamplingRule_samplingRule_HTTPMethod = null;
            if (cmdletContext.SamplingRule_HTTPMethod != null)
            {
                requestSamplingRule_samplingRule_HTTPMethod = cmdletContext.SamplingRule_HTTPMethod;
            }
            if (requestSamplingRule_samplingRule_HTTPMethod != null)
            {
                request.SamplingRule.HTTPMethod = requestSamplingRule_samplingRule_HTTPMethod;
                requestSamplingRuleIsNull = false;
            }
            System.Int32? requestSamplingRule_samplingRule_Priority = null;
            if (cmdletContext.SamplingRule_Priority != null)
            {
                requestSamplingRule_samplingRule_Priority = cmdletContext.SamplingRule_Priority.Value;
            }
            if (requestSamplingRule_samplingRule_Priority != null)
            {
                request.SamplingRule.Priority = requestSamplingRule_samplingRule_Priority.Value;
                requestSamplingRuleIsNull = false;
            }
            System.Int32? requestSamplingRule_samplingRule_ReservoirSize = null;
            if (cmdletContext.SamplingRule_ReservoirSize != null)
            {
                requestSamplingRule_samplingRule_ReservoirSize = cmdletContext.SamplingRule_ReservoirSize.Value;
            }
            if (requestSamplingRule_samplingRule_ReservoirSize != null)
            {
                request.SamplingRule.ReservoirSize = requestSamplingRule_samplingRule_ReservoirSize.Value;
                requestSamplingRuleIsNull = false;
            }
            System.String requestSamplingRule_samplingRule_ResourceARN = null;
            if (cmdletContext.SamplingRule_ResourceARN != null)
            {
                requestSamplingRule_samplingRule_ResourceARN = cmdletContext.SamplingRule_ResourceARN;
            }
            if (requestSamplingRule_samplingRule_ResourceARN != null)
            {
                request.SamplingRule.ResourceARN = requestSamplingRule_samplingRule_ResourceARN;
                requestSamplingRuleIsNull = false;
            }
            System.String requestSamplingRule_samplingRule_RuleARN = null;
            if (cmdletContext.SamplingRule_RuleARN != null)
            {
                requestSamplingRule_samplingRule_RuleARN = cmdletContext.SamplingRule_RuleARN;
            }
            if (requestSamplingRule_samplingRule_RuleARN != null)
            {
                request.SamplingRule.RuleARN = requestSamplingRule_samplingRule_RuleARN;
                requestSamplingRuleIsNull = false;
            }
            System.String requestSamplingRule_samplingRule_RuleName = null;
            if (cmdletContext.SamplingRule_RuleName != null)
            {
                requestSamplingRule_samplingRule_RuleName = cmdletContext.SamplingRule_RuleName;
            }
            if (requestSamplingRule_samplingRule_RuleName != null)
            {
                request.SamplingRule.RuleName = requestSamplingRule_samplingRule_RuleName;
                requestSamplingRuleIsNull = false;
            }
            System.String requestSamplingRule_samplingRule_ServiceName = null;
            if (cmdletContext.SamplingRule_ServiceName != null)
            {
                requestSamplingRule_samplingRule_ServiceName = cmdletContext.SamplingRule_ServiceName;
            }
            if (requestSamplingRule_samplingRule_ServiceName != null)
            {
                request.SamplingRule.ServiceName = requestSamplingRule_samplingRule_ServiceName;
                requestSamplingRuleIsNull = false;
            }
            System.String requestSamplingRule_samplingRule_ServiceType = null;
            if (cmdletContext.SamplingRule_ServiceType != null)
            {
                requestSamplingRule_samplingRule_ServiceType = cmdletContext.SamplingRule_ServiceType;
            }
            if (requestSamplingRule_samplingRule_ServiceType != null)
            {
                request.SamplingRule.ServiceType = requestSamplingRule_samplingRule_ServiceType;
                requestSamplingRuleIsNull = false;
            }
            System.String requestSamplingRule_samplingRule_URLPath = null;
            if (cmdletContext.SamplingRule_URLPath != null)
            {
                requestSamplingRule_samplingRule_URLPath = cmdletContext.SamplingRule_URLPath;
            }
            if (requestSamplingRule_samplingRule_URLPath != null)
            {
                request.SamplingRule.URLPath = requestSamplingRule_samplingRule_URLPath;
                requestSamplingRuleIsNull = false;
            }
            System.Int32? requestSamplingRule_samplingRule_Version = null;
            if (cmdletContext.SamplingRule_Version != null)
            {
                requestSamplingRule_samplingRule_Version = cmdletContext.SamplingRule_Version.Value;
            }
            if (requestSamplingRule_samplingRule_Version != null)
            {
                request.SamplingRule.Version = requestSamplingRule_samplingRule_Version.Value;
                requestSamplingRuleIsNull = false;
            }
             // determine if request.SamplingRule should be set to null
            if (requestSamplingRuleIsNull)
            {
                request.SamplingRule = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.XRay.Model.CreateSamplingRuleResponse CallAWSServiceOperation(IAmazonXRay client, Amazon.XRay.Model.CreateSamplingRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS X-Ray", "CreateSamplingRule");
            try
            {
                return client.CreateSamplingRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> SamplingRule_Attribute { get; set; }
            public System.Double? SamplingRule_FixedRate { get; set; }
            public System.String SamplingRule_Host { get; set; }
            public System.String SamplingRule_HTTPMethod { get; set; }
            public System.Int32? SamplingRule_Priority { get; set; }
            public System.Int32? SamplingRule_ReservoirSize { get; set; }
            public System.String SamplingRule_ResourceARN { get; set; }
            public System.String SamplingRule_RuleARN { get; set; }
            public System.String SamplingRule_RuleName { get; set; }
            public System.String SamplingRule_ServiceName { get; set; }
            public System.String SamplingRule_ServiceType { get; set; }
            public System.String SamplingRule_URLPath { get; set; }
            public System.Int32? SamplingRule_Version { get; set; }
            public List<Amazon.XRay.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.XRay.Model.CreateSamplingRuleResponse, NewXRSamplingRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SamplingRuleRecord;
        }
        
    }
}
