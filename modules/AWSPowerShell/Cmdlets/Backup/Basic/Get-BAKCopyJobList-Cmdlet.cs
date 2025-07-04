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
using Amazon.Backup;
using Amazon.Backup.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Returns metadata about your copy jobs.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "BAKCopyJobList")]
    [OutputType("Amazon.Backup.Model.CopyJob")]
    [AWSCmdlet("Calls the AWS Backup ListCopyJobs API operation.", Operation = new[] {"ListCopyJobs"}, SelectReturnType = typeof(Amazon.Backup.Model.ListCopyJobsResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.CopyJob or Amazon.Backup.Model.ListCopyJobsResponse",
        "This cmdlet returns a collection of Amazon.Backup.Model.CopyJob objects.",
        "The service call response (type Amazon.Backup.Model.ListCopyJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBAKCopyJobListCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ByAccountId
        /// <summary>
        /// <para>
        /// <para>The account ID to list the jobs from. Returns only copy jobs associated with the specified
        /// account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByAccountId { get; set; }
        #endregion
        
        #region Parameter ByCompleteAfter
        /// <summary>
        /// <para>
        /// <para>Returns only copy jobs completed after a date expressed in Unix format and Coordinated
        /// Universal Time (UTC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ByCompleteAfter { get; set; }
        #endregion
        
        #region Parameter ByCompleteBefore
        /// <summary>
        /// <para>
        /// <para>Returns only copy jobs completed before a date expressed in Unix format and Coordinated
        /// Universal Time (UTC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ByCompleteBefore { get; set; }
        #endregion
        
        #region Parameter ByCreatedAfter
        /// <summary>
        /// <para>
        /// <para>Returns only copy jobs that were created after the specified date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ByCreatedAfter { get; set; }
        #endregion
        
        #region Parameter ByCreatedBefore
        /// <summary>
        /// <para>
        /// <para>Returns only copy jobs that were created before the specified date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ByCreatedBefore { get; set; }
        #endregion
        
        #region Parameter ByDestinationVaultArn
        /// <summary>
        /// <para>
        /// <para>An Amazon Resource Name (ARN) that uniquely identifies a source backup vault to copy
        /// from; for example, <c>arn:aws:backup:us-east-1:123456789012:backup-vault:aBackupVault</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByDestinationVaultArn { get; set; }
        #endregion
        
        #region Parameter ByMessageCategory
        /// <summary>
        /// <para>
        /// <para>This is an optional parameter that can be used to filter out jobs with a MessageCategory
        /// which matches the value you input.</para><para>Example strings may include <c>AccessDenied</c>, <c>SUCCESS</c>, <c>AGGREGATE_ALL</c>,
        /// and <c>INVALIDPARAMETERS</c>.</para><para>View <a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/monitoring.html">Monitoring</a>
        /// for a list of accepted strings.</para><para>The the value ANY returns count of all message categories.</para><para><c>AGGREGATE_ALL</c> aggregates job counts for all message categories and returns
        /// the sum.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByMessageCategory { get; set; }
        #endregion
        
        #region Parameter ByParentJobId
        /// <summary>
        /// <para>
        /// <para>This is a filter to list child (nested) jobs based on parent job ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByParentJobId { get; set; }
        #endregion
        
        #region Parameter ByResourceArn
        /// <summary>
        /// <para>
        /// <para>Returns only copy jobs that match the specified resource Amazon Resource Name (ARN).
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByResourceArn { get; set; }
        #endregion
        
        #region Parameter ByResourceType
        /// <summary>
        /// <para>
        /// <para>Returns only backup jobs for the specified resources:</para><ul><li><para><c>Aurora</c> for Amazon Aurora</para></li><li><para><c>CloudFormation</c> for CloudFormation</para></li><li><para><c>DocumentDB</c> for Amazon DocumentDB (with MongoDB compatibility)</para></li><li><para><c>DynamoDB</c> for Amazon DynamoDB</para></li><li><para><c>EBS</c> for Amazon Elastic Block Store</para></li><li><para><c>EC2</c> for Amazon Elastic Compute Cloud</para></li><li><para><c>EFS</c> for Amazon Elastic File System</para></li><li><para><c>FSx</c> for Amazon FSx</para></li><li><para><c>Neptune</c> for Amazon Neptune</para></li><li><para><c>RDS</c> for Amazon Relational Database Service</para></li><li><para><c>Redshift</c> for Amazon Redshift</para></li><li><para><c>S3</c> for Amazon Simple Storage Service (Amazon S3)</para></li><li><para><c>SAP HANA on Amazon EC2</c> for SAP HANA databases on Amazon Elastic Compute Cloud
        /// instances</para></li><li><para><c>Storage Gateway</c> for Storage Gateway</para></li><li><para><c>Timestream</c> for Amazon Timestream</para></li><li><para><c>VirtualMachine</c> for VMware virtual machines</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByResourceType { get; set; }
        #endregion
        
        #region Parameter ByState
        /// <summary>
        /// <para>
        /// <para>Returns only copy jobs that are in the specified state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Backup.CopyJobState")]
        public Amazon.Backup.CopyJobState ByState { get; set; }
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
        /// is made to return MaxResults number of items, NextToken allows you to return more
        /// items in your list starting at the location pointed to by the next token. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CopyJobs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.ListCopyJobsResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.ListCopyJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CopyJobs";
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
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.ListCopyJobsResponse, GetBAKCopyJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ByAccountId = this.ByAccountId;
            context.ByCompleteAfter = this.ByCompleteAfter;
            context.ByCompleteBefore = this.ByCompleteBefore;
            context.ByCreatedAfter = this.ByCreatedAfter;
            context.ByCreatedBefore = this.ByCreatedBefore;
            context.ByDestinationVaultArn = this.ByDestinationVaultArn;
            context.ByMessageCategory = this.ByMessageCategory;
            context.ByParentJobId = this.ByParentJobId;
            context.ByResourceArn = this.ByResourceArn;
            context.ByResourceType = this.ByResourceType;
            context.ByState = this.ByState;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Backup.Model.ListCopyJobsRequest();
            
            if (cmdletContext.ByAccountId != null)
            {
                request.ByAccountId = cmdletContext.ByAccountId;
            }
            if (cmdletContext.ByCompleteAfter != null)
            {
                request.ByCompleteAfter = cmdletContext.ByCompleteAfter.Value;
            }
            if (cmdletContext.ByCompleteBefore != null)
            {
                request.ByCompleteBefore = cmdletContext.ByCompleteBefore.Value;
            }
            if (cmdletContext.ByCreatedAfter != null)
            {
                request.ByCreatedAfter = cmdletContext.ByCreatedAfter.Value;
            }
            if (cmdletContext.ByCreatedBefore != null)
            {
                request.ByCreatedBefore = cmdletContext.ByCreatedBefore.Value;
            }
            if (cmdletContext.ByDestinationVaultArn != null)
            {
                request.ByDestinationVaultArn = cmdletContext.ByDestinationVaultArn;
            }
            if (cmdletContext.ByMessageCategory != null)
            {
                request.ByMessageCategory = cmdletContext.ByMessageCategory;
            }
            if (cmdletContext.ByParentJobId != null)
            {
                request.ByParentJobId = cmdletContext.ByParentJobId;
            }
            if (cmdletContext.ByResourceArn != null)
            {
                request.ByResourceArn = cmdletContext.ByResourceArn;
            }
            if (cmdletContext.ByResourceType != null)
            {
                request.ByResourceType = cmdletContext.ByResourceType;
            }
            if (cmdletContext.ByState != null)
            {
                request.ByState = cmdletContext.ByState;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.Backup.Model.ListCopyJobsResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.ListCopyJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "ListCopyJobs");
            try
            {
                return client.ListCopyJobsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ByAccountId { get; set; }
            public System.DateTime? ByCompleteAfter { get; set; }
            public System.DateTime? ByCompleteBefore { get; set; }
            public System.DateTime? ByCreatedAfter { get; set; }
            public System.DateTime? ByCreatedBefore { get; set; }
            public System.String ByDestinationVaultArn { get; set; }
            public System.String ByMessageCategory { get; set; }
            public System.String ByParentJobId { get; set; }
            public System.String ByResourceArn { get; set; }
            public System.String ByResourceType { get; set; }
            public Amazon.Backup.CopyJobState ByState { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Backup.Model.ListCopyJobsResponse, GetBAKCopyJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CopyJobs;
        }
        
    }
}
