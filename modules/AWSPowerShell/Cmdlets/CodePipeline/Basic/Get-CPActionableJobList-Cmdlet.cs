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
using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CP
{
    /// <summary>
    /// Returns information about any jobs for CodePipeline to act on. <c>PollForJobs</c>
    /// is valid only for action types with "Custom" in the owner field. If the action type
    /// contains <c>AWS</c> or <c>ThirdParty</c> in the owner field, the <c>PollForJobs</c>
    /// action returns an error.
    /// 
    ///  <important><para>
    /// When this API is called, CodePipeline returns temporary credentials for the S3 bucket
    /// used to store artifacts for the pipeline, if the action requires access to that S3
    /// bucket for input or output artifacts. This API also returns any secret values defined
    /// for the action.
    /// </para></important>
    /// </summary>
    [Cmdlet("Get", "CPActionableJobList")]
    [OutputType("Amazon.CodePipeline.Model.Job")]
    [AWSCmdlet("Calls the AWS CodePipeline PollForJobs API operation.", Operation = new[] {"PollForJobs"}, SelectReturnType = typeof(Amazon.CodePipeline.Model.PollForJobsResponse), LegacyAlias="Get-CPActionableJobs")]
    [AWSCmdletOutput("Amazon.CodePipeline.Model.Job or Amazon.CodePipeline.Model.PollForJobsResponse",
        "This cmdlet returns a collection of Amazon.CodePipeline.Model.Job objects.",
        "The service call response (type Amazon.CodePipeline.Model.PollForJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCPActionableJobListCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActionTypeId_Category
        /// <summary>
        /// <para>
        /// <para>A category defines what kind of action can be taken in the stage, and constrains the
        /// provider type for the action. Valid categories are limited to one of the following
        /// values. </para><ul><li><para>Source</para></li><li><para>Build</para></li><li><para>Test</para></li><li><para>Deploy</para></li><li><para>Invoke</para></li><li><para>Approval</para></li><li><para>Compute</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodePipeline.ActionCategory")]
        public Amazon.CodePipeline.ActionCategory ActionTypeId_Category { get; set; }
        #endregion
        
        #region Parameter MaxBatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of jobs to return in a poll for jobs call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxBatchSize { get; set; }
        #endregion
        
        #region Parameter ActionTypeId_Owner
        /// <summary>
        /// <para>
        /// <para>The creator of the action being called. There are three valid values for the <c>Owner</c>
        /// field in the action category section within your pipeline structure: <c>AWS</c>, <c>ThirdParty</c>,
        /// and <c>Custom</c>. For more information, see <a href="https://docs.aws.amazon.com/codepipeline/latest/userguide/reference-pipeline-structure.html#actions-valid-providers">Valid
        /// Action Types and Providers in CodePipeline</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodePipeline.ActionOwner")]
        public Amazon.CodePipeline.ActionOwner ActionTypeId_Owner { get; set; }
        #endregion
        
        #region Parameter ActionTypeId_Provider
        /// <summary>
        /// <para>
        /// <para>The provider of the service being called by the action. Valid providers are determined
        /// by the action category. For example, an action in the Deploy category type might have
        /// a provider of CodeDeploy, which would be specified as <c>CodeDeploy</c>. For more
        /// information, see <a href="https://docs.aws.amazon.com/codepipeline/latest/userguide/reference-pipeline-structure.html#actions-valid-providers">Valid
        /// Action Types and Providers in CodePipeline</a>.</para>
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
        public System.String ActionTypeId_Provider { get; set; }
        #endregion
        
        #region Parameter QueryParam
        /// <summary>
        /// <para>
        /// <para>A map of property names and values. For an action type with no queryable properties,
        /// this value must be null or an empty map. For an action type with a queryable property,
        /// you must supply that property as a key in the map. Only jobs whose action configuration
        /// matches the mapped value are returned.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable QueryParam { get; set; }
        #endregion
        
        #region Parameter ActionTypeId_Version
        /// <summary>
        /// <para>
        /// <para>A string that describes the action version.</para>
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
        public System.String ActionTypeId_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Jobs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodePipeline.Model.PollForJobsResponse).
        /// Specifying the name of a property of type Amazon.CodePipeline.Model.PollForJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Jobs";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodePipeline.Model.PollForJobsResponse, GetCPActionableJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActionTypeId_Category = this.ActionTypeId_Category;
            #if MODULAR
            if (this.ActionTypeId_Category == null && ParameterWasBound(nameof(this.ActionTypeId_Category)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionTypeId_Category which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActionTypeId_Owner = this.ActionTypeId_Owner;
            #if MODULAR
            if (this.ActionTypeId_Owner == null && ParameterWasBound(nameof(this.ActionTypeId_Owner)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionTypeId_Owner which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActionTypeId_Provider = this.ActionTypeId_Provider;
            #if MODULAR
            if (this.ActionTypeId_Provider == null && ParameterWasBound(nameof(this.ActionTypeId_Provider)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionTypeId_Provider which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActionTypeId_Version = this.ActionTypeId_Version;
            #if MODULAR
            if (this.ActionTypeId_Version == null && ParameterWasBound(nameof(this.ActionTypeId_Version)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionTypeId_Version which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxBatchSize = this.MaxBatchSize;
            if (this.QueryParam != null)
            {
                context.QueryParam = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.QueryParam.Keys)
                {
                    context.QueryParam.Add((String)hashKey, (System.String)(this.QueryParam[hashKey]));
                }
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
            var request = new Amazon.CodePipeline.Model.PollForJobsRequest();
            
            
             // populate ActionTypeId
            var requestActionTypeIdIsNull = true;
            request.ActionTypeId = new Amazon.CodePipeline.Model.ActionTypeId();
            Amazon.CodePipeline.ActionCategory requestActionTypeId_actionTypeId_Category = null;
            if (cmdletContext.ActionTypeId_Category != null)
            {
                requestActionTypeId_actionTypeId_Category = cmdletContext.ActionTypeId_Category;
            }
            if (requestActionTypeId_actionTypeId_Category != null)
            {
                request.ActionTypeId.Category = requestActionTypeId_actionTypeId_Category;
                requestActionTypeIdIsNull = false;
            }
            Amazon.CodePipeline.ActionOwner requestActionTypeId_actionTypeId_Owner = null;
            if (cmdletContext.ActionTypeId_Owner != null)
            {
                requestActionTypeId_actionTypeId_Owner = cmdletContext.ActionTypeId_Owner;
            }
            if (requestActionTypeId_actionTypeId_Owner != null)
            {
                request.ActionTypeId.Owner = requestActionTypeId_actionTypeId_Owner;
                requestActionTypeIdIsNull = false;
            }
            System.String requestActionTypeId_actionTypeId_Provider = null;
            if (cmdletContext.ActionTypeId_Provider != null)
            {
                requestActionTypeId_actionTypeId_Provider = cmdletContext.ActionTypeId_Provider;
            }
            if (requestActionTypeId_actionTypeId_Provider != null)
            {
                request.ActionTypeId.Provider = requestActionTypeId_actionTypeId_Provider;
                requestActionTypeIdIsNull = false;
            }
            System.String requestActionTypeId_actionTypeId_Version = null;
            if (cmdletContext.ActionTypeId_Version != null)
            {
                requestActionTypeId_actionTypeId_Version = cmdletContext.ActionTypeId_Version;
            }
            if (requestActionTypeId_actionTypeId_Version != null)
            {
                request.ActionTypeId.Version = requestActionTypeId_actionTypeId_Version;
                requestActionTypeIdIsNull = false;
            }
             // determine if request.ActionTypeId should be set to null
            if (requestActionTypeIdIsNull)
            {
                request.ActionTypeId = null;
            }
            if (cmdletContext.MaxBatchSize != null)
            {
                request.MaxBatchSize = cmdletContext.MaxBatchSize.Value;
            }
            if (cmdletContext.QueryParam != null)
            {
                request.QueryParam = cmdletContext.QueryParam;
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
        
        private Amazon.CodePipeline.Model.PollForJobsResponse CallAWSServiceOperation(IAmazonCodePipeline client, Amazon.CodePipeline.Model.PollForJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodePipeline", "PollForJobs");
            try
            {
                return client.PollForJobsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.CodePipeline.ActionCategory ActionTypeId_Category { get; set; }
            public Amazon.CodePipeline.ActionOwner ActionTypeId_Owner { get; set; }
            public System.String ActionTypeId_Provider { get; set; }
            public System.String ActionTypeId_Version { get; set; }
            public System.Int32? MaxBatchSize { get; set; }
            public Dictionary<System.String, System.String> QueryParam { get; set; }
            public System.Func<Amazon.CodePipeline.Model.PollForJobsResponse, GetCPActionableJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Jobs;
        }
        
    }
}
