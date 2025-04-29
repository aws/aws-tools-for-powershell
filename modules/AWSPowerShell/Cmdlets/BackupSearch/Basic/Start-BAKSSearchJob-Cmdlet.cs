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
using Amazon.BackupSearch;
using Amazon.BackupSearch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAKS
{
    /// <summary>
    /// This operation creates a search job which returns recovery points filtered by SearchScope
    /// and items filtered by ItemFilters.
    /// 
    ///  
    /// <para>
    /// You can optionally include ClientToken, EncryptionKeyArn, Name, and/or Tags.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "BAKSSearchJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BackupSearch.Model.StartSearchJobResponse")]
    [AWSCmdlet("Calls the AWS Backup Search StartSearchJob API operation.", Operation = new[] {"StartSearchJob"}, SelectReturnType = typeof(Amazon.BackupSearch.Model.StartSearchJobResponse))]
    [AWSCmdletOutput("Amazon.BackupSearch.Model.StartSearchJobResponse",
        "This cmdlet returns an Amazon.BackupSearch.Model.StartSearchJobResponse object containing multiple properties."
    )]
    public partial class StartBAKSSearchJobCmdlet : AmazonBackupSearchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SearchScope_BackupResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that uniquely identifies the backup resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchScope_BackupResourceArns")]
        public System.String[] SearchScope_BackupResourceArn { get; set; }
        #endregion
        
        #region Parameter SearchScope_BackupResourceTag
        /// <summary>
        /// <para>
        /// <para>These are one or more tags on the backup (recovery point).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchScope_BackupResourceTags")]
        public System.Collections.Hashtable SearchScope_BackupResourceTag { get; set; }
        #endregion
        
        #region Parameter SearchScope_BackupResourceType
        /// <summary>
        /// <para>
        /// <para>The resource types included in a search.</para><para>Eligible resource types include S3 and EBS.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SearchScope_BackupResourceTypes")]
        public System.String[] SearchScope_BackupResourceType { get; set; }
        #endregion
        
        #region Parameter BackupResourceCreationTime_CreatedAfter
        /// <summary>
        /// <para>
        /// <para>This timestamp includes recovery points only created after the specified time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchScope_BackupResourceCreationTime_CreatedAfter")]
        public System.DateTime? BackupResourceCreationTime_CreatedAfter { get; set; }
        #endregion
        
        #region Parameter BackupResourceCreationTime_CreatedBefore
        /// <summary>
        /// <para>
        /// <para>This timestamp includes recovery points only created before the specified time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchScope_BackupResourceCreationTime_CreatedBefore")]
        public System.DateTime? BackupResourceCreationTime_CreatedBefore { get; set; }
        #endregion
        
        #region Parameter ItemFilters_EBSItemFilter
        /// <summary>
        /// <para>
        /// <para>This array can contain CreationTimes, FilePaths, LastModificationTimes, or Sizes objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ItemFilters_EBSItemFilters")]
        public Amazon.BackupSearch.Model.EBSItemFilter[] ItemFilters_EBSItemFilter { get; set; }
        #endregion
        
        #region Parameter EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The encryption key for the specified search job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Include alphanumeric characters to create a name for this search job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ItemFilters_S3ItemFilter
        /// <summary>
        /// <para>
        /// <para>This array can contain CreationTimes, ETags, ObjectKeys, Sizes, or VersionIds objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ItemFilters_S3ItemFilters")]
        public Amazon.BackupSearch.Model.S3ItemFilter[] ItemFilters_S3ItemFilter { get; set; }
        #endregion
        
        #region Parameter SearchScope_SourceResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that uniquely identifies the source resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchScope_SourceResourceArns")]
        public System.String[] SearchScope_SourceResourceArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>List of tags returned by the operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Include this parameter to allow multiple identical calls for idempotency.</para><para>A client token is valid for 8 hours after the first request that uses it is completed.
        /// After this time, any request with the same token is treated as a new request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BackupSearch.Model.StartSearchJobResponse).
        /// Specifying the name of a property of type Amazon.BackupSearch.Model.StartSearchJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BAKSSearchJob (StartSearchJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BackupSearch.Model.StartSearchJobResponse, StartBAKSSearchJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.EncryptionKeyArn = this.EncryptionKeyArn;
            if (this.ItemFilters_EBSItemFilter != null)
            {
                context.ItemFilters_EBSItemFilter = new List<Amazon.BackupSearch.Model.EBSItemFilter>(this.ItemFilters_EBSItemFilter);
            }
            if (this.ItemFilters_S3ItemFilter != null)
            {
                context.ItemFilters_S3ItemFilter = new List<Amazon.BackupSearch.Model.S3ItemFilter>(this.ItemFilters_S3ItemFilter);
            }
            context.Name = this.Name;
            if (this.SearchScope_BackupResourceArn != null)
            {
                context.SearchScope_BackupResourceArn = new List<System.String>(this.SearchScope_BackupResourceArn);
            }
            context.BackupResourceCreationTime_CreatedAfter = this.BackupResourceCreationTime_CreatedAfter;
            context.BackupResourceCreationTime_CreatedBefore = this.BackupResourceCreationTime_CreatedBefore;
            if (this.SearchScope_BackupResourceTag != null)
            {
                context.SearchScope_BackupResourceTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SearchScope_BackupResourceTag.Keys)
                {
                    context.SearchScope_BackupResourceTag.Add((String)hashKey, (System.String)(this.SearchScope_BackupResourceTag[hashKey]));
                }
            }
            if (this.SearchScope_BackupResourceType != null)
            {
                context.SearchScope_BackupResourceType = new List<System.String>(this.SearchScope_BackupResourceType);
            }
            #if MODULAR
            if (this.SearchScope_BackupResourceType == null && ParameterWasBound(nameof(this.SearchScope_BackupResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter SearchScope_BackupResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SearchScope_SourceResourceArn != null)
            {
                context.SearchScope_SourceResourceArn = new List<System.String>(this.SearchScope_SourceResourceArn);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.BackupSearch.Model.StartSearchJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EncryptionKeyArn != null)
            {
                request.EncryptionKeyArn = cmdletContext.EncryptionKeyArn;
            }
            
             // populate ItemFilters
            var requestItemFiltersIsNull = true;
            request.ItemFilters = new Amazon.BackupSearch.Model.ItemFilters();
            List<Amazon.BackupSearch.Model.EBSItemFilter> requestItemFilters_itemFilters_EBSItemFilter = null;
            if (cmdletContext.ItemFilters_EBSItemFilter != null)
            {
                requestItemFilters_itemFilters_EBSItemFilter = cmdletContext.ItemFilters_EBSItemFilter;
            }
            if (requestItemFilters_itemFilters_EBSItemFilter != null)
            {
                request.ItemFilters.EBSItemFilters = requestItemFilters_itemFilters_EBSItemFilter;
                requestItemFiltersIsNull = false;
            }
            List<Amazon.BackupSearch.Model.S3ItemFilter> requestItemFilters_itemFilters_S3ItemFilter = null;
            if (cmdletContext.ItemFilters_S3ItemFilter != null)
            {
                requestItemFilters_itemFilters_S3ItemFilter = cmdletContext.ItemFilters_S3ItemFilter;
            }
            if (requestItemFilters_itemFilters_S3ItemFilter != null)
            {
                request.ItemFilters.S3ItemFilters = requestItemFilters_itemFilters_S3ItemFilter;
                requestItemFiltersIsNull = false;
            }
             // determine if request.ItemFilters should be set to null
            if (requestItemFiltersIsNull)
            {
                request.ItemFilters = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate SearchScope
            var requestSearchScopeIsNull = true;
            request.SearchScope = new Amazon.BackupSearch.Model.SearchScope();
            List<System.String> requestSearchScope_searchScope_BackupResourceArn = null;
            if (cmdletContext.SearchScope_BackupResourceArn != null)
            {
                requestSearchScope_searchScope_BackupResourceArn = cmdletContext.SearchScope_BackupResourceArn;
            }
            if (requestSearchScope_searchScope_BackupResourceArn != null)
            {
                request.SearchScope.BackupResourceArns = requestSearchScope_searchScope_BackupResourceArn;
                requestSearchScopeIsNull = false;
            }
            Dictionary<System.String, System.String> requestSearchScope_searchScope_BackupResourceTag = null;
            if (cmdletContext.SearchScope_BackupResourceTag != null)
            {
                requestSearchScope_searchScope_BackupResourceTag = cmdletContext.SearchScope_BackupResourceTag;
            }
            if (requestSearchScope_searchScope_BackupResourceTag != null)
            {
                request.SearchScope.BackupResourceTags = requestSearchScope_searchScope_BackupResourceTag;
                requestSearchScopeIsNull = false;
            }
            List<System.String> requestSearchScope_searchScope_BackupResourceType = null;
            if (cmdletContext.SearchScope_BackupResourceType != null)
            {
                requestSearchScope_searchScope_BackupResourceType = cmdletContext.SearchScope_BackupResourceType;
            }
            if (requestSearchScope_searchScope_BackupResourceType != null)
            {
                request.SearchScope.BackupResourceTypes = requestSearchScope_searchScope_BackupResourceType;
                requestSearchScopeIsNull = false;
            }
            List<System.String> requestSearchScope_searchScope_SourceResourceArn = null;
            if (cmdletContext.SearchScope_SourceResourceArn != null)
            {
                requestSearchScope_searchScope_SourceResourceArn = cmdletContext.SearchScope_SourceResourceArn;
            }
            if (requestSearchScope_searchScope_SourceResourceArn != null)
            {
                request.SearchScope.SourceResourceArns = requestSearchScope_searchScope_SourceResourceArn;
                requestSearchScopeIsNull = false;
            }
            Amazon.BackupSearch.Model.BackupCreationTimeFilter requestSearchScope_searchScope_BackupResourceCreationTime = null;
            
             // populate BackupResourceCreationTime
            var requestSearchScope_searchScope_BackupResourceCreationTimeIsNull = true;
            requestSearchScope_searchScope_BackupResourceCreationTime = new Amazon.BackupSearch.Model.BackupCreationTimeFilter();
            System.DateTime? requestSearchScope_searchScope_BackupResourceCreationTime_backupResourceCreationTime_CreatedAfter = null;
            if (cmdletContext.BackupResourceCreationTime_CreatedAfter != null)
            {
                requestSearchScope_searchScope_BackupResourceCreationTime_backupResourceCreationTime_CreatedAfter = cmdletContext.BackupResourceCreationTime_CreatedAfter.Value;
            }
            if (requestSearchScope_searchScope_BackupResourceCreationTime_backupResourceCreationTime_CreatedAfter != null)
            {
                requestSearchScope_searchScope_BackupResourceCreationTime.CreatedAfter = requestSearchScope_searchScope_BackupResourceCreationTime_backupResourceCreationTime_CreatedAfter.Value;
                requestSearchScope_searchScope_BackupResourceCreationTimeIsNull = false;
            }
            System.DateTime? requestSearchScope_searchScope_BackupResourceCreationTime_backupResourceCreationTime_CreatedBefore = null;
            if (cmdletContext.BackupResourceCreationTime_CreatedBefore != null)
            {
                requestSearchScope_searchScope_BackupResourceCreationTime_backupResourceCreationTime_CreatedBefore = cmdletContext.BackupResourceCreationTime_CreatedBefore.Value;
            }
            if (requestSearchScope_searchScope_BackupResourceCreationTime_backupResourceCreationTime_CreatedBefore != null)
            {
                requestSearchScope_searchScope_BackupResourceCreationTime.CreatedBefore = requestSearchScope_searchScope_BackupResourceCreationTime_backupResourceCreationTime_CreatedBefore.Value;
                requestSearchScope_searchScope_BackupResourceCreationTimeIsNull = false;
            }
             // determine if requestSearchScope_searchScope_BackupResourceCreationTime should be set to null
            if (requestSearchScope_searchScope_BackupResourceCreationTimeIsNull)
            {
                requestSearchScope_searchScope_BackupResourceCreationTime = null;
            }
            if (requestSearchScope_searchScope_BackupResourceCreationTime != null)
            {
                request.SearchScope.BackupResourceCreationTime = requestSearchScope_searchScope_BackupResourceCreationTime;
                requestSearchScopeIsNull = false;
            }
             // determine if request.SearchScope should be set to null
            if (requestSearchScopeIsNull)
            {
                request.SearchScope = null;
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
        
        private Amazon.BackupSearch.Model.StartSearchJobResponse CallAWSServiceOperation(IAmazonBackupSearch client, Amazon.BackupSearch.Model.StartSearchJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup Search", "StartSearchJob");
            try
            {
                return client.StartSearchJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EncryptionKeyArn { get; set; }
            public List<Amazon.BackupSearch.Model.EBSItemFilter> ItemFilters_EBSItemFilter { get; set; }
            public List<Amazon.BackupSearch.Model.S3ItemFilter> ItemFilters_S3ItemFilter { get; set; }
            public System.String Name { get; set; }
            public List<System.String> SearchScope_BackupResourceArn { get; set; }
            public System.DateTime? BackupResourceCreationTime_CreatedAfter { get; set; }
            public System.DateTime? BackupResourceCreationTime_CreatedBefore { get; set; }
            public Dictionary<System.String, System.String> SearchScope_BackupResourceTag { get; set; }
            public List<System.String> SearchScope_BackupResourceType { get; set; }
            public List<System.String> SearchScope_SourceResourceArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BackupSearch.Model.StartSearchJobResponse, StartBAKSSearchJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
