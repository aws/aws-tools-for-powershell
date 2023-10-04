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
using Amazon.DataZone;
using Amazon.DataZone.Model;

namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Lists Amazon DataZone subscription requests.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DZSubscriptionRequestList")]
    [OutputType("Amazon.DataZone.Model.ListSubscriptionRequestsResponse")]
    [AWSCmdlet("Calls the Amazon DataZone ListSubscriptionRequests API operation.", Operation = new[] {"ListSubscriptionRequests"}, SelectReturnType = typeof(Amazon.DataZone.Model.ListSubscriptionRequestsResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.ListSubscriptionRequestsResponse",
        "This cmdlet returns an Amazon.DataZone.Model.ListSubscriptionRequestsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDZSubscriptionRequestListCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApproverProjectId
        /// <summary>
        /// <para>
        /// <para>The identifier of the subscription request approver's project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApproverProjectId { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon DataZone domain.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter OwningProjectId
        /// <summary>
        /// <para>
        /// <para>The identifier of the project for the subscription requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwningProjectId { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>Specifies the way to sort the results of this action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.SortKey")]
        public Amazon.DataZone.SortKey SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>Specifies the sort order for the results of this action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.SortOrder")]
        public Amazon.DataZone.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Specifies the status of the subscription requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.SubscriptionRequestStatus")]
        public Amazon.DataZone.SubscriptionRequestStatus Status { get; set; }
        #endregion
        
        #region Parameter SubscribedListingId
        /// <summary>
        /// <para>
        /// <para>The identifier of the subscribed listing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubscribedListingId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of subscription requests to return in a single call to <code>ListSubscriptionRequests</code>.
        /// When the number of subscription requests to be listed is greater than the value of
        /// <code>MaxResults</code>, the response contains a <code>NextToken</code> value that
        /// you can use in a subsequent call to <code>ListSubscriptionRequests</code> to list
        /// the next set of subscription requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>When the number of subscription requests is greater than the default value for the
        /// <code>MaxResults</code> parameter, or if you explicitly specify a value for <code>MaxResults</code>
        /// that is less than the number of subscription requests, the response includes a pagination
        /// token named <code>NextToken</code>. You can specify this <code>NextToken</code> value
        /// in a subsequent call to <code>ListSubscriptionRequests</code> to list the next set
        /// of subscription requests.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.ListSubscriptionRequestsResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.ListSubscriptionRequestsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainIdentifier' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.ListSubscriptionRequestsResponse, GetDZSubscriptionRequestListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApproverProjectId = this.ApproverProjectId;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.OwningProjectId = this.OwningProjectId;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            context.Status = this.Status;
            context.SubscribedListingId = this.SubscribedListingId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.DataZone.Model.ListSubscriptionRequestsRequest();
            
            if (cmdletContext.ApproverProjectId != null)
            {
                request.ApproverProjectId = cmdletContext.ApproverProjectId;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.OwningProjectId != null)
            {
                request.OwningProjectId = cmdletContext.OwningProjectId;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.SubscribedListingId != null)
            {
                request.SubscribedListingId = cmdletContext.SubscribedListingId;
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
        
        private Amazon.DataZone.Model.ListSubscriptionRequestsResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.ListSubscriptionRequestsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "ListSubscriptionRequests");
            try
            {
                #if DESKTOP
                return client.ListSubscriptionRequests(request);
                #elif CORECLR
                return client.ListSubscriptionRequestsAsync(request).GetAwaiter().GetResult();
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
            public System.String ApproverProjectId { get; set; }
            public System.String DomainIdentifier { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String OwningProjectId { get; set; }
            public Amazon.DataZone.SortKey SortBy { get; set; }
            public Amazon.DataZone.SortOrder SortOrder { get; set; }
            public Amazon.DataZone.SubscriptionRequestStatus Status { get; set; }
            public System.String SubscribedListingId { get; set; }
            public System.Func<Amazon.DataZone.Model.ListSubscriptionRequestsResponse, GetDZSubscriptionRequestListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
