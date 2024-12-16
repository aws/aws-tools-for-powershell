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
using Amazon.Backup;
using Amazon.Backup.Model;

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// This returns restore jobs that contain the specified protected resource.
    /// 
    ///  
    /// <para>
    /// You must include <c>ResourceArn</c>. You can optionally include <c>NextToken</c>,
    /// <c>ByStatus</c>, <c>MaxResults</c>, <c>ByRecoveryPointCreationDateAfter</c> , and
    /// <c>ByRecoveryPointCreationDateBefore</c>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "BAKRestoreJobsByProtectedResourceList")]
    [OutputType("Amazon.Backup.Model.RestoreJobsListMember")]
    [AWSCmdlet("Calls the AWS Backup ListRestoreJobsByProtectedResource API operation.", Operation = new[] {"ListRestoreJobsByProtectedResource"}, SelectReturnType = typeof(Amazon.Backup.Model.ListRestoreJobsByProtectedResourceResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.RestoreJobsListMember or Amazon.Backup.Model.ListRestoreJobsByProtectedResourceResponse",
        "This cmdlet returns a collection of Amazon.Backup.Model.RestoreJobsListMember objects.",
        "The service call response (type Amazon.Backup.Model.ListRestoreJobsByProtectedResourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBAKRestoreJobsByProtectedResourceListCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ByRecoveryPointCreationDateAfter
        /// <summary>
        /// <para>
        /// <para>Returns only restore jobs of recovery points that were created after the specified
        /// date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ByRecoveryPointCreationDateAfter { get; set; }
        #endregion
        
        #region Parameter ByRecoveryPointCreationDateBefore
        /// <summary>
        /// <para>
        /// <para>Returns only restore jobs of recovery points that were created before the specified
        /// date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ByRecoveryPointCreationDateBefore { get; set; }
        #endregion
        
        #region Parameter ByStatus
        /// <summary>
        /// <para>
        /// <para>Returns only restore jobs associated with the specified job status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Backup.RestoreJobStatus")]
        public Amazon.Backup.RestoreJobStatus ByStatus { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>Returns only restore jobs that match the specified resource Amazon Resource Name (ARN).</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The next item following a partial list of returned items. For example, if a request
        /// ismade to return <c>MaxResults</c> number of items, <c>NextToken</c> allows you to
        /// return more items in your list starting at the location pointed to by the next token.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RestoreJobs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.ListRestoreJobsByProtectedResourceResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.ListRestoreJobsByProtectedResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RestoreJobs";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.ListRestoreJobsByProtectedResourceResponse, GetBAKRestoreJobsByProtectedResourceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ByRecoveryPointCreationDateAfter = this.ByRecoveryPointCreationDateAfter;
            context.ByRecoveryPointCreationDateBefore = this.ByRecoveryPointCreationDateBefore;
            context.ByStatus = this.ByStatus;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Backup.Model.ListRestoreJobsByProtectedResourceRequest();
            
            if (cmdletContext.ByRecoveryPointCreationDateAfter != null)
            {
                request.ByRecoveryPointCreationDateAfter = cmdletContext.ByRecoveryPointCreationDateAfter.Value;
            }
            if (cmdletContext.ByRecoveryPointCreationDateBefore != null)
            {
                request.ByRecoveryPointCreationDateBefore = cmdletContext.ByRecoveryPointCreationDateBefore.Value;
            }
            if (cmdletContext.ByStatus != null)
            {
                request.ByStatus = cmdletContext.ByStatus;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Backup.Model.ListRestoreJobsByProtectedResourceResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.ListRestoreJobsByProtectedResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "ListRestoreJobsByProtectedResource");
            try
            {
                #if DESKTOP
                return client.ListRestoreJobsByProtectedResource(request);
                #elif CORECLR
                return client.ListRestoreJobsByProtectedResourceAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? ByRecoveryPointCreationDateAfter { get; set; }
            public System.DateTime? ByRecoveryPointCreationDateBefore { get; set; }
            public Amazon.Backup.RestoreJobStatus ByStatus { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.Backup.Model.ListRestoreJobsByProtectedResourceResponse, GetBAKRestoreJobsByProtectedResourceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RestoreJobs;
        }
        
    }
}
