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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Initiates the process of creating a preview showing the effects that running a specified
    /// Automation runbook would have on the targeted resources.
    /// </summary>
    [Cmdlet("Start", "SSMExecutionPreview", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager StartExecutionPreview API operation.", Operation = new[] {"StartExecutionPreview"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.StartExecutionPreviewResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleSystemsManagement.Model.StartExecutionPreviewResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.StartExecutionPreviewResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartSSMExecutionPreviewCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DocumentName
        /// <summary>
        /// <para>
        /// <para>The name of the Automation runbook to run. The result of the execution preview indicates
        /// what the impact would be of running this runbook.</para>
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
        /// <para>The version of the Automation runbook to run. The default value is <c>$DEFAULT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DocumentVersion { get; set; }
        #endregion
        
        #region Parameter Automation_Parameter
        /// <summary>
        /// <para>
        /// <para>Information about parameters that can be specified for the preview operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionInputs_Automation_Parameters")]
        public System.Collections.Hashtable Automation_Parameter { get; set; }
        #endregion
        
        #region Parameter Automation_TargetLocation
        /// <summary>
        /// <para>
        /// <para>Information about the Amazon Web Services Regions and Amazon Web Services accounts
        /// targeted by the Automation execution preview operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionInputs_Automation_TargetLocations")]
        public Amazon.SimpleSystemsManagement.Model.TargetLocation[] Automation_TargetLocation { get; set; }
        #endregion
        
        #region Parameter Automation_TargetLocationsURL
        /// <summary>
        /// <para>
        /// <para>A publicly accessible URL for a file that contains the <c>TargetLocations</c> body.
        /// Currently, only files in presigned Amazon S3 buckets are supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionInputs_Automation_TargetLocationsURL")]
        public System.String Automation_TargetLocationsURL { get; set; }
        #endregion
        
        #region Parameter Automation_TargetMap
        /// <summary>
        /// <para>
        /// <para>A key-value mapping of document parameters to target resources. Both Targets and TargetMaps
        /// can't be specified together.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionInputs_Automation_TargetMaps")]
        public System.Collections.Hashtable[] Automation_TargetMap { get; set; }
        #endregion
        
        #region Parameter Automation_TargetParameterName
        /// <summary>
        /// <para>
        /// <para>The name of the parameter used as the target resource for the rate-controlled execution.
        /// Required if you specify targets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionInputs_Automation_TargetParameterName")]
        public System.String Automation_TargetParameterName { get; set; }
        #endregion
        
        #region Parameter Automation_Target
        /// <summary>
        /// <para>
        /// <para>Information about the resources that would be included in the actual runbook execution,
        /// if it were to be run. Both Targets and TargetMaps can't be specified together.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionInputs_Automation_Targets")]
        public Amazon.SimpleSystemsManagement.Model.Target[] Automation_Target { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExecutionPreviewId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.StartExecutionPreviewResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.StartExecutionPreviewResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExecutionPreviewId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DocumentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SSMExecutionPreview (StartExecutionPreview)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.StartExecutionPreviewResponse, StartSSMExecutionPreviewCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DocumentName = this.DocumentName;
            #if MODULAR
            if (this.DocumentName == null && ParameterWasBound(nameof(this.DocumentName)))
            {
                WriteWarning("You are passing $null as a value for parameter DocumentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DocumentVersion = this.DocumentVersion;
            if (this.Automation_Parameter != null)
            {
                context.Automation_Parameter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Automation_Parameter.Keys)
                {
                    object hashValue = this.Automation_Parameter[hashKey];
                    if (hashValue == null)
                    {
                        context.Automation_Parameter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.Automation_Parameter.Add((String)hashKey, valueSet);
                }
            }
            if (this.Automation_TargetLocation != null)
            {
                context.Automation_TargetLocation = new List<Amazon.SimpleSystemsManagement.Model.TargetLocation>(this.Automation_TargetLocation);
            }
            context.Automation_TargetLocationsURL = this.Automation_TargetLocationsURL;
            if (this.Automation_TargetMap != null)
            {
                context.Automation_TargetMap = new List<Dictionary<System.String, List<System.String>>>();
                foreach (var hashTable in this.Automation_TargetMap)
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
                    context.Automation_TargetMap.Add(d);
                }
            }
            context.Automation_TargetParameterName = this.Automation_TargetParameterName;
            if (this.Automation_Target != null)
            {
                context.Automation_Target = new List<Amazon.SimpleSystemsManagement.Model.Target>(this.Automation_Target);
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
            var request = new Amazon.SimpleSystemsManagement.Model.StartExecutionPreviewRequest();
            
            if (cmdletContext.DocumentName != null)
            {
                request.DocumentName = cmdletContext.DocumentName;
            }
            if (cmdletContext.DocumentVersion != null)
            {
                request.DocumentVersion = cmdletContext.DocumentVersion;
            }
            
             // populate ExecutionInputs
            var requestExecutionInputsIsNull = true;
            request.ExecutionInputs = new Amazon.SimpleSystemsManagement.Model.ExecutionInputs();
            Amazon.SimpleSystemsManagement.Model.AutomationExecutionInputs requestExecutionInputs_executionInputs_Automation = null;
            
             // populate Automation
            var requestExecutionInputs_executionInputs_AutomationIsNull = true;
            requestExecutionInputs_executionInputs_Automation = new Amazon.SimpleSystemsManagement.Model.AutomationExecutionInputs();
            Dictionary<System.String, List<System.String>> requestExecutionInputs_executionInputs_Automation_automation_Parameter = null;
            if (cmdletContext.Automation_Parameter != null)
            {
                requestExecutionInputs_executionInputs_Automation_automation_Parameter = cmdletContext.Automation_Parameter;
            }
            if (requestExecutionInputs_executionInputs_Automation_automation_Parameter != null)
            {
                requestExecutionInputs_executionInputs_Automation.Parameters = requestExecutionInputs_executionInputs_Automation_automation_Parameter;
                requestExecutionInputs_executionInputs_AutomationIsNull = false;
            }
            List<Amazon.SimpleSystemsManagement.Model.TargetLocation> requestExecutionInputs_executionInputs_Automation_automation_TargetLocation = null;
            if (cmdletContext.Automation_TargetLocation != null)
            {
                requestExecutionInputs_executionInputs_Automation_automation_TargetLocation = cmdletContext.Automation_TargetLocation;
            }
            if (requestExecutionInputs_executionInputs_Automation_automation_TargetLocation != null)
            {
                requestExecutionInputs_executionInputs_Automation.TargetLocations = requestExecutionInputs_executionInputs_Automation_automation_TargetLocation;
                requestExecutionInputs_executionInputs_AutomationIsNull = false;
            }
            System.String requestExecutionInputs_executionInputs_Automation_automation_TargetLocationsURL = null;
            if (cmdletContext.Automation_TargetLocationsURL != null)
            {
                requestExecutionInputs_executionInputs_Automation_automation_TargetLocationsURL = cmdletContext.Automation_TargetLocationsURL;
            }
            if (requestExecutionInputs_executionInputs_Automation_automation_TargetLocationsURL != null)
            {
                requestExecutionInputs_executionInputs_Automation.TargetLocationsURL = requestExecutionInputs_executionInputs_Automation_automation_TargetLocationsURL;
                requestExecutionInputs_executionInputs_AutomationIsNull = false;
            }
            List<Dictionary<System.String, List<System.String>>> requestExecutionInputs_executionInputs_Automation_automation_TargetMap = null;
            if (cmdletContext.Automation_TargetMap != null)
            {
                requestExecutionInputs_executionInputs_Automation_automation_TargetMap = cmdletContext.Automation_TargetMap;
            }
            if (requestExecutionInputs_executionInputs_Automation_automation_TargetMap != null)
            {
                requestExecutionInputs_executionInputs_Automation.TargetMaps = requestExecutionInputs_executionInputs_Automation_automation_TargetMap;
                requestExecutionInputs_executionInputs_AutomationIsNull = false;
            }
            System.String requestExecutionInputs_executionInputs_Automation_automation_TargetParameterName = null;
            if (cmdletContext.Automation_TargetParameterName != null)
            {
                requestExecutionInputs_executionInputs_Automation_automation_TargetParameterName = cmdletContext.Automation_TargetParameterName;
            }
            if (requestExecutionInputs_executionInputs_Automation_automation_TargetParameterName != null)
            {
                requestExecutionInputs_executionInputs_Automation.TargetParameterName = requestExecutionInputs_executionInputs_Automation_automation_TargetParameterName;
                requestExecutionInputs_executionInputs_AutomationIsNull = false;
            }
            List<Amazon.SimpleSystemsManagement.Model.Target> requestExecutionInputs_executionInputs_Automation_automation_Target = null;
            if (cmdletContext.Automation_Target != null)
            {
                requestExecutionInputs_executionInputs_Automation_automation_Target = cmdletContext.Automation_Target;
            }
            if (requestExecutionInputs_executionInputs_Automation_automation_Target != null)
            {
                requestExecutionInputs_executionInputs_Automation.Targets = requestExecutionInputs_executionInputs_Automation_automation_Target;
                requestExecutionInputs_executionInputs_AutomationIsNull = false;
            }
             // determine if requestExecutionInputs_executionInputs_Automation should be set to null
            if (requestExecutionInputs_executionInputs_AutomationIsNull)
            {
                requestExecutionInputs_executionInputs_Automation = null;
            }
            if (requestExecutionInputs_executionInputs_Automation != null)
            {
                request.ExecutionInputs.Automation = requestExecutionInputs_executionInputs_Automation;
                requestExecutionInputsIsNull = false;
            }
             // determine if request.ExecutionInputs should be set to null
            if (requestExecutionInputsIsNull)
            {
                request.ExecutionInputs = null;
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
        
        private Amazon.SimpleSystemsManagement.Model.StartExecutionPreviewResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.StartExecutionPreviewRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "StartExecutionPreview");
            try
            {
                return client.StartExecutionPreviewAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DocumentName { get; set; }
            public System.String DocumentVersion { get; set; }
            public Dictionary<System.String, List<System.String>> Automation_Parameter { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.TargetLocation> Automation_TargetLocation { get; set; }
            public System.String Automation_TargetLocationsURL { get; set; }
            public List<Dictionary<System.String, List<System.String>>> Automation_TargetMap { get; set; }
            public System.String Automation_TargetParameterName { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Target> Automation_Target { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.StartExecutionPreviewResponse, StartSSMExecutionPreviewCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExecutionPreviewId;
        }
        
    }
}
