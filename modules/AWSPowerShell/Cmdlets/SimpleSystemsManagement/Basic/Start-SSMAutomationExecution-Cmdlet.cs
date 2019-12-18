/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Initiates execution of an Automation document.
    /// </summary>
    [Cmdlet("Start", "SSMAutomationExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager StartAutomationExecution API operation.", Operation = new[] {"StartAutomationExecution"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.StartAutomationExecutionResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleSystemsManagement.Model.StartAutomationExecutionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.StartAutomationExecutionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartSSMAutomationExecutionCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter DocumentName
        /// <summary>
        /// <para>
        /// <para>The name of the Automation document to use for this execution.</para>
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
        public System.String DocumentName { get; set; }
        #endregion
        
        #region Parameter DocumentVersion
        /// <summary>
        /// <para>
        /// <para>The version of the Automation document to use for this execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DocumentVersion { get; set; }
        #endregion
        
        #region Parameter MaxConcurrency
        /// <summary>
        /// <para>
        /// <para>The maximum number of targets allowed to run this task in parallel. You can specify
        /// a number, such as 10, or a percentage, such as 10%. The default value is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaxConcurrency { get; set; }
        #endregion
        
        #region Parameter MaxError
        /// <summary>
        /// <para>
        /// <para>The number of errors that are allowed before the system stops running the automation
        /// on additional targets. You can specify either an absolute number of errors, for example
        /// 10, or a percentage of the target set, for example 10%. If you specify 3, for example,
        /// the system stops running the automation when the fourth error is received. If you
        /// specify 0, then the system stops running the automation on additional targets after
        /// the first error result is returned. If you run an automation on 50 resources and set
        /// max-errors to 10%, then the system stops running the automation on additional targets
        /// when the sixth error is received.</para><para>Executions that are already running an automation when max-errors is reached are allowed
        /// to complete, but some of these executions may fail as well. If you need to ensure
        /// that there won't be more than max-errors failed executions, set max-concurrency to
        /// 1 so the executions proceed one at a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxErrors")]
        public System.String MaxError { get; set; }
        #endregion
        
        #region Parameter Mode
        /// <summary>
        /// <para>
        /// <para>The execution mode of the automation. Valid modes include the following: Auto and
        /// Interactive. The default mode is Auto.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.ExecutionMode")]
        public Amazon.SimpleSystemsManagement.ExecutionMode Mode { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A key-value map of execution parameters, which match the declared parameters in the
        /// Automation document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter TargetLocation
        /// <summary>
        /// <para>
        /// <para>A location is a combination of AWS Regions and/or AWS accounts where you want to run
        /// the Automation. Use this action to start an Automation in multiple Regions and multiple
        /// accounts. For more information, see <a href="http://docs.aws.amazon.com/systems-manager/latest/userguide/systems-manager-automation-multiple-accounts-and-regions.html">Executing
        /// Automations in Multiple AWS Regions and Accounts</a> in the <i>AWS Systems Manager
        /// User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetLocations")]
        public Amazon.SimpleSystemsManagement.Model.TargetLocation[] TargetLocation { get; set; }
        #endregion
        
        #region Parameter TargetMap
        /// <summary>
        /// <para>
        /// <para>A key-value mapping of document parameters to target resources. Both Targets and TargetMaps
        /// cannot be specified together.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetMaps")]
        public System.Collections.Hashtable[] TargetMap { get; set; }
        #endregion
        
        #region Parameter TargetParameterName
        /// <summary>
        /// <para>
        /// <para>The name of the parameter used as the target resource for the rate-controlled execution.
        /// Required if you specify targets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetParameterName { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>A key-value mapping to target resources. Required if you specify TargetParameterName.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Targets")]
        public Amazon.SimpleSystemsManagement.Model.Target[] Target { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>User-provided idempotency token. The token must be unique, is case insensitive, enforces
        /// the UUID format, and can't be reused.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AutomationExecutionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.StartAutomationExecutionResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.StartAutomationExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AutomationExecutionId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DocumentName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DocumentName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DocumentName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DocumentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SSMAutomationExecution (StartAutomationExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.StartAutomationExecutionResponse, StartSSMAutomationExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DocumentName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.DocumentName = this.DocumentName;
            #if MODULAR
            if (this.DocumentName == null && ParameterWasBound(nameof(this.DocumentName)))
            {
                WriteWarning("You are passing $null as a value for parameter DocumentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DocumentVersion = this.DocumentVersion;
            context.MaxConcurrency = this.MaxConcurrency;
            context.MaxError = this.MaxError;
            context.Mode = this.Mode;
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    object hashValue = this.Parameter[hashKey];
                    if (hashValue == null)
                    {
                        context.Parameter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.Parameter.Add((String)hashKey, valueSet);
                }
            }
            if (this.TargetLocation != null)
            {
                context.TargetLocation = new List<Amazon.SimpleSystemsManagement.Model.TargetLocation>(this.TargetLocation);
            }
            if (this.TargetMap != null)
            {
                context.TargetMap = new List<Dictionary<System.String, List<System.String>>>();
                foreach (var hashTable in this.TargetMap)
                {
                    var d = new Dictionary<System.String, List<System.String>>();
                    foreach (var hashKey in hashTable.Keys)
                    {
                        object hashValue = hashTable[hashKey];
                        if (hashValue == null)
                        {
                            d.Add((String)hashKey, null);
                            continue;
                        }
                        var enumerable = SafeEnumerable(hashValue);
                        var valueSet = new List<System.String>();
                        foreach (var s in enumerable)
                        {
                            valueSet.Add((System.String)s);
                        }
                        d.Add((String)hashKey, valueSet);
                    }
                    context.TargetMap.Add(d);
                }
            }
            context.TargetParameterName = this.TargetParameterName;
            if (this.Target != null)
            {
                context.Target = new List<Amazon.SimpleSystemsManagement.Model.Target>(this.Target);
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
            var request = new Amazon.SimpleSystemsManagement.Model.StartAutomationExecutionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DocumentName != null)
            {
                request.DocumentName = cmdletContext.DocumentName;
            }
            if (cmdletContext.DocumentVersion != null)
            {
                request.DocumentVersion = cmdletContext.DocumentVersion;
            }
            if (cmdletContext.MaxConcurrency != null)
            {
                request.MaxConcurrency = cmdletContext.MaxConcurrency;
            }
            if (cmdletContext.MaxError != null)
            {
                request.MaxErrors = cmdletContext.MaxError;
            }
            if (cmdletContext.Mode != null)
            {
                request.Mode = cmdletContext.Mode;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.TargetLocation != null)
            {
                request.TargetLocations = cmdletContext.TargetLocation;
            }
            if (cmdletContext.TargetMap != null)
            {
                request.TargetMaps = cmdletContext.TargetMap;
            }
            if (cmdletContext.TargetParameterName != null)
            {
                request.TargetParameterName = cmdletContext.TargetParameterName;
            }
            if (cmdletContext.Target != null)
            {
                request.Targets = cmdletContext.Target;
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
        
        private Amazon.SimpleSystemsManagement.Model.StartAutomationExecutionResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.StartAutomationExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "StartAutomationExecution");
            try
            {
                #if DESKTOP
                return client.StartAutomationExecution(request);
                #elif CORECLR
                return client.StartAutomationExecutionAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.String ClientToken { get; set; }
            public System.String DocumentName { get; set; }
            public System.String DocumentVersion { get; set; }
            public System.String MaxConcurrency { get; set; }
            public System.String MaxError { get; set; }
            public Amazon.SimpleSystemsManagement.ExecutionMode Mode { get; set; }
            public Dictionary<System.String, List<System.String>> Parameter { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.TargetLocation> TargetLocation { get; set; }
            public List<Dictionary<System.String, List<System.String>>> TargetMap { get; set; }
            public System.String TargetParameterName { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Target> Target { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.StartAutomationExecutionResponse, StartSSMAutomationExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AutomationExecutionId;
        }
        
    }
}
