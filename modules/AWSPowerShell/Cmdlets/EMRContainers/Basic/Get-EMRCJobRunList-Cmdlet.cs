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
using Amazon.EMRContainers;
using Amazon.EMRContainers.Model;

namespace Amazon.PowerShell.Cmdlets.EMRC
{
    /// <summary>
    /// Lists job runs based on a set of parameters. A job run is a unit of work, such as
    /// a Spark jar, PySpark script, or SparkSQL query, that you submit to Amazon EMR on EKS.
    /// </summary>
    [Cmdlet("Get", "EMRCJobRunList")]
    [OutputType("Amazon.EMRContainers.Model.JobRun")]
    [AWSCmdlet("Calls the Amazon EMR Containers ListJobRuns API operation.", Operation = new[] {"ListJobRuns"}, SelectReturnType = typeof(Amazon.EMRContainers.Model.ListJobRunsResponse))]
    [AWSCmdletOutput("Amazon.EMRContainers.Model.JobRun or Amazon.EMRContainers.Model.ListJobRunsResponse",
        "This cmdlet returns a collection of Amazon.EMRContainers.Model.JobRun objects.",
        "The service call response (type Amazon.EMRContainers.Model.ListJobRunsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEMRCJobRunListCmdlet : AmazonEMRContainersClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CreatedAfter
        /// <summary>
        /// <para>
        /// <para>The date and time after which the job runs were submitted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedAfter { get; set; }
        #endregion
        
        #region Parameter CreatedBefore
        /// <summary>
        /// <para>
        /// <para>The date and time before which the job runs were submitted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedBefore { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The states of the job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("States")]
        public System.String[] State { get; set; }
        #endregion
        
        #region Parameter VirtualClusterId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual cluster for which to list the job run. </para>
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
        public System.String VirtualClusterId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of job runs that can be listed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of job runs to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobRuns'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EMRContainers.Model.ListJobRunsResponse).
        /// Specifying the name of a property of type Amazon.EMRContainers.Model.ListJobRunsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobRuns";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VirtualClusterId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VirtualClusterId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VirtualClusterId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.EMRContainers.Model.ListJobRunsResponse, GetEMRCJobRunListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VirtualClusterId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CreatedAfter = this.CreatedAfter;
            context.CreatedBefore = this.CreatedBefore;
            context.MaxResult = this.MaxResult;
            context.Name = this.Name;
            context.NextToken = this.NextToken;
            if (this.State != null)
            {
                context.State = new List<System.String>(this.State);
            }
            context.VirtualClusterId = this.VirtualClusterId;
            #if MODULAR
            if (this.VirtualClusterId == null && ParameterWasBound(nameof(this.VirtualClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter VirtualClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EMRContainers.Model.ListJobRunsRequest();
            
            if (cmdletContext.CreatedAfter != null)
            {
                request.CreatedAfter = cmdletContext.CreatedAfter.Value;
            }
            if (cmdletContext.CreatedBefore != null)
            {
                request.CreatedBefore = cmdletContext.CreatedBefore.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.State != null)
            {
                request.States = cmdletContext.State;
            }
            if (cmdletContext.VirtualClusterId != null)
            {
                request.VirtualClusterId = cmdletContext.VirtualClusterId;
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
        
        private Amazon.EMRContainers.Model.ListJobRunsResponse CallAWSServiceOperation(IAmazonEMRContainers client, Amazon.EMRContainers.Model.ListJobRunsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EMR Containers", "ListJobRuns");
            try
            {
                #if DESKTOP
                return client.ListJobRuns(request);
                #elif CORECLR
                return client.ListJobRunsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? CreatedAfter { get; set; }
            public System.DateTime? CreatedBefore { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String Name { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> State { get; set; }
            public System.String VirtualClusterId { get; set; }
            public System.Func<Amazon.EMRContainers.Model.ListJobRunsResponse, GetEMRCJobRunListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobRuns;
        }
        
    }
}
