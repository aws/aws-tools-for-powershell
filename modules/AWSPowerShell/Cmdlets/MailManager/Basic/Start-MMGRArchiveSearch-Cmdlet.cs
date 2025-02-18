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
using Amazon.MailManager;
using Amazon.MailManager.Model;

namespace Amazon.PowerShell.Cmdlets.MMGR
{
    /// <summary>
    /// Initiates a search across emails in the specified archive.
    /// </summary>
    [Cmdlet("Start", "MMGRArchiveSearch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SES Mail Manager StartArchiveSearch API operation.", Operation = new[] {"StartArchiveSearch"}, SelectReturnType = typeof(Amazon.MailManager.Model.StartArchiveSearchResponse))]
    [AWSCmdletOutput("System.String or Amazon.MailManager.Model.StartArchiveSearchResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MailManager.Model.StartArchiveSearchResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartMMGRArchiveSearchCmdlet : AmazonMailManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ArchiveId
        /// <summary>
        /// <para>
        /// <para>The identifier of the archive to search emails in.</para>
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
        public System.String ArchiveId { get; set; }
        #endregion
        
        #region Parameter FromTimestamp
        /// <summary>
        /// <para>
        /// <para>The start timestamp of the range to search emails from.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? FromTimestamp { get; set; }
        #endregion
        
        #region Parameter Filters_Include
        /// <summary>
        /// <para>
        /// <para>The filter conditions for emails to include.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MailManager.Model.ArchiveFilterCondition[] Filters_Include { get; set; }
        #endregion
        
        #region Parameter ToTimestamp
        /// <summary>
        /// <para>
        /// <para>The end timestamp of the range to search emails from.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? ToTimestamp { get; set; }
        #endregion
        
        #region Parameter Filters_Unless
        /// <summary>
        /// <para>
        /// <para>The filter conditions for emails to exclude.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MailManager.Model.ArchiveFilterCondition[] Filters_Unless { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of search results to return.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SearchId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MailManager.Model.StartArchiveSearchResponse).
        /// Specifying the name of a property of type Amazon.MailManager.Model.StartArchiveSearchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SearchId";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ArchiveId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-MMGRArchiveSearch (StartArchiveSearch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MailManager.Model.StartArchiveSearchResponse, StartMMGRArchiveSearchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ArchiveId = this.ArchiveId;
            #if MODULAR
            if (this.ArchiveId == null && ParameterWasBound(nameof(this.ArchiveId)))
            {
                WriteWarning("You are passing $null as a value for parameter ArchiveId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Filters_Include != null)
            {
                context.Filters_Include = new List<Amazon.MailManager.Model.ArchiveFilterCondition>(this.Filters_Include);
            }
            if (this.Filters_Unless != null)
            {
                context.Filters_Unless = new List<Amazon.MailManager.Model.ArchiveFilterCondition>(this.Filters_Unless);
            }
            context.FromTimestamp = this.FromTimestamp;
            #if MODULAR
            if (this.FromTimestamp == null && ParameterWasBound(nameof(this.FromTimestamp)))
            {
                WriteWarning("You are passing $null as a value for parameter FromTimestamp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            #if MODULAR
            if (this.MaxResult == null && ParameterWasBound(nameof(this.MaxResult)))
            {
                WriteWarning("You are passing $null as a value for parameter MaxResult which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ToTimestamp = this.ToTimestamp;
            #if MODULAR
            if (this.ToTimestamp == null && ParameterWasBound(nameof(this.ToTimestamp)))
            {
                WriteWarning("You are passing $null as a value for parameter ToTimestamp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MailManager.Model.StartArchiveSearchRequest();
            
            if (cmdletContext.ArchiveId != null)
            {
                request.ArchiveId = cmdletContext.ArchiveId;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.MailManager.Model.ArchiveFilters();
            List<Amazon.MailManager.Model.ArchiveFilterCondition> requestFilters_filters_Include = null;
            if (cmdletContext.Filters_Include != null)
            {
                requestFilters_filters_Include = cmdletContext.Filters_Include;
            }
            if (requestFilters_filters_Include != null)
            {
                request.Filters.Include = requestFilters_filters_Include;
                requestFiltersIsNull = false;
            }
            List<Amazon.MailManager.Model.ArchiveFilterCondition> requestFilters_filters_Unless = null;
            if (cmdletContext.Filters_Unless != null)
            {
                requestFilters_filters_Unless = cmdletContext.Filters_Unless;
            }
            if (requestFilters_filters_Unless != null)
            {
                request.Filters.Unless = requestFilters_filters_Unless;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.FromTimestamp != null)
            {
                request.FromTimestamp = cmdletContext.FromTimestamp.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ToTimestamp != null)
            {
                request.ToTimestamp = cmdletContext.ToTimestamp.Value;
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
        
        private Amazon.MailManager.Model.StartArchiveSearchResponse CallAWSServiceOperation(IAmazonMailManager client, Amazon.MailManager.Model.StartArchiveSearchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SES Mail Manager", "StartArchiveSearch");
            try
            {
                return client.StartArchiveSearchAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ArchiveId { get; set; }
            public List<Amazon.MailManager.Model.ArchiveFilterCondition> Filters_Include { get; set; }
            public List<Amazon.MailManager.Model.ArchiveFilterCondition> Filters_Unless { get; set; }
            public System.DateTime? FromTimestamp { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.DateTime? ToTimestamp { get; set; }
            public System.Func<Amazon.MailManager.Model.StartArchiveSearchResponse, StartMMGRArchiveSearchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SearchId;
        }
        
    }
}
