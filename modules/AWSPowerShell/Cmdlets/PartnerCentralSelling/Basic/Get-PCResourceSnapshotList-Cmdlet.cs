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
using Amazon.PartnerCentralSelling;
using Amazon.PartnerCentralSelling.Model;

namespace Amazon.PowerShell.Cmdlets.PC
{
    /// <summary>
    /// Retrieves a list of resource view snapshots based on specified criteria. This operation
    /// supports various use cases, including: 
    /// 
    ///  <ul><li><para>
    /// Fetching all snapshots associated with an engagement.
    /// </para></li><li><para>
    /// Retrieving snapshots of a specific resource type within an engagement.
    /// </para></li><li><para>
    /// Obtaining snapshots for a particular resource using a specified template.
    /// </para></li><li><para>
    /// Accessing the latest snapshot of a resource within an engagement.
    /// </para></li><li><para>
    /// Filtering snapshots by resource owner.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "PCResourceSnapshotList")]
    [OutputType("Amazon.PartnerCentralSelling.Model.ResourceSnapshotSummary")]
    [AWSCmdlet("Calls the Partner Central Selling API ListResourceSnapshots API operation.", Operation = new[] {"ListResourceSnapshots"}, SelectReturnType = typeof(Amazon.PartnerCentralSelling.Model.ListResourceSnapshotsResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralSelling.Model.ResourceSnapshotSummary or Amazon.PartnerCentralSelling.Model.ListResourceSnapshotsResponse",
        "This cmdlet returns a collection of Amazon.PartnerCentralSelling.Model.ResourceSnapshotSummary objects.",
        "The service call response (type Amazon.PartnerCentralSelling.Model.ListResourceSnapshotsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPCResourceSnapshotListCmdlet : AmazonPartnerCentralSellingClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para> Specifies the catalog related to the request. </para>
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
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter CreatedBy
        /// <summary>
        /// <para>
        /// <para>Filters the response to include only snapshots of resources owned by the specified
        /// AWS account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatedBy { get; set; }
        #endregion
        
        #region Parameter EngagementIdentifier
        /// <summary>
        /// <para>
        /// <para> The unique identifier of the engagement associated with the snapshots. </para>
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
        public System.String EngagementIdentifier { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para> Filters the response to include only snapshots of the specified resource. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter ResourceSnapshotTemplateIdentifier
        /// <summary>
        /// <para>
        /// <para>Filters the response to include only snapshots created using the specified template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceSnapshotTemplateIdentifier { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para> Filters the response to include only snapshots of the specified resource type. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.ResourceType")]
        public Amazon.PartnerCentralSelling.ResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of results to return in a single call. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The token for the next set of results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceSnapshotSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralSelling.Model.ListResourceSnapshotsResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralSelling.Model.ListResourceSnapshotsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceSnapshotSummaries";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EngagementIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EngagementIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EngagementIdentifier' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralSelling.Model.ListResourceSnapshotsResponse, GetPCResourceSnapshotListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EngagementIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CreatedBy = this.CreatedBy;
            context.EngagementIdentifier = this.EngagementIdentifier;
            #if MODULAR
            if (this.EngagementIdentifier == null && ParameterWasBound(nameof(this.EngagementIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EngagementIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ResourceIdentifier = this.ResourceIdentifier;
            context.ResourceSnapshotTemplateIdentifier = this.ResourceSnapshotTemplateIdentifier;
            context.ResourceType = this.ResourceType;
            
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
            var request = new Amazon.PartnerCentralSelling.Model.ListResourceSnapshotsRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.CreatedBy != null)
            {
                request.CreatedBy = cmdletContext.CreatedBy;
            }
            if (cmdletContext.EngagementIdentifier != null)
            {
                request.EngagementIdentifier = cmdletContext.EngagementIdentifier;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ResourceIdentifier != null)
            {
                request.ResourceIdentifier = cmdletContext.ResourceIdentifier;
            }
            if (cmdletContext.ResourceSnapshotTemplateIdentifier != null)
            {
                request.ResourceSnapshotTemplateIdentifier = cmdletContext.ResourceSnapshotTemplateIdentifier;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
        
        private Amazon.PartnerCentralSelling.Model.ListResourceSnapshotsResponse CallAWSServiceOperation(IAmazonPartnerCentralSelling client, Amazon.PartnerCentralSelling.Model.ListResourceSnapshotsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Selling API", "ListResourceSnapshots");
            try
            {
                #if DESKTOP
                return client.ListResourceSnapshots(request);
                #elif CORECLR
                return client.ListResourceSnapshotsAsync(request).GetAwaiter().GetResult();
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
            public System.String Catalog { get; set; }
            public System.String CreatedBy { get; set; }
            public System.String EngagementIdentifier { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceIdentifier { get; set; }
            public System.String ResourceSnapshotTemplateIdentifier { get; set; }
            public Amazon.PartnerCentralSelling.ResourceType ResourceType { get; set; }
            public System.Func<Amazon.PartnerCentralSelling.Model.ListResourceSnapshotsResponse, GetPCResourceSnapshotListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceSnapshotSummaries;
        }
        
    }
}
