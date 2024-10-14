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
using Amazon.LaunchWizard;
using Amazon.LaunchWizard.Model;

namespace Amazon.PowerShell.Cmdlets.LWIZ
{
    /// <summary>
    /// Lists the workload deployment patterns for a given workload name. You can use the
    /// <a href="https://docs.aws.amazon.com/launchwizard/latest/APIReference/API_ListWorkloads.html">ListWorkloads</a>
    /// operation to discover the available workload names.
    /// </summary>
    [Cmdlet("Get", "LWIZWorkloadDeploymentPatternList")]
    [OutputType("Amazon.LaunchWizard.Model.WorkloadDeploymentPatternDataSummary")]
    [AWSCmdlet("Calls the AWS Launch Wizard ListWorkloadDeploymentPatterns API operation.", Operation = new[] {"ListWorkloadDeploymentPatterns"}, SelectReturnType = typeof(Amazon.LaunchWizard.Model.ListWorkloadDeploymentPatternsResponse))]
    [AWSCmdletOutput("Amazon.LaunchWizard.Model.WorkloadDeploymentPatternDataSummary or Amazon.LaunchWizard.Model.ListWorkloadDeploymentPatternsResponse",
        "This cmdlet returns a collection of Amazon.LaunchWizard.Model.WorkloadDeploymentPatternDataSummary objects.",
        "The service call response (type Amazon.LaunchWizard.Model.ListWorkloadDeploymentPatternsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLWIZWorkloadDeploymentPatternListCmdlet : AmazonLaunchWizardClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter WorkloadName
        /// <summary>
        /// <para>
        /// <para>The name of the workload.</para>
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
        public System.String WorkloadName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return for this request. To get the next page of items,
        /// make another request with the token returned in the output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token returned from a previous paginated request. Pagination continues from the
        /// end of the items returned by the previous request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WorkloadDeploymentPatterns'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LaunchWizard.Model.ListWorkloadDeploymentPatternsResponse).
        /// Specifying the name of a property of type Amazon.LaunchWizard.Model.ListWorkloadDeploymentPatternsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WorkloadDeploymentPatterns";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkloadName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkloadName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkloadName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LaunchWizard.Model.ListWorkloadDeploymentPatternsResponse, GetLWIZWorkloadDeploymentPatternListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkloadName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.WorkloadName = this.WorkloadName;
            #if MODULAR
            if (this.WorkloadName == null && ParameterWasBound(nameof(this.WorkloadName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkloadName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LaunchWizard.Model.ListWorkloadDeploymentPatternsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.WorkloadName != null)
            {
                request.WorkloadName = cmdletContext.WorkloadName;
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
        
        private Amazon.LaunchWizard.Model.ListWorkloadDeploymentPatternsResponse CallAWSServiceOperation(IAmazonLaunchWizard client, Amazon.LaunchWizard.Model.ListWorkloadDeploymentPatternsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Launch Wizard", "ListWorkloadDeploymentPatterns");
            try
            {
                #if DESKTOP
                return client.ListWorkloadDeploymentPatterns(request);
                #elif CORECLR
                return client.ListWorkloadDeploymentPatternsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String WorkloadName { get; set; }
            public System.Func<Amazon.LaunchWizard.Model.ListWorkloadDeploymentPatternsResponse, GetLWIZWorkloadDeploymentPatternListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WorkloadDeploymentPatterns;
        }
        
    }
}
