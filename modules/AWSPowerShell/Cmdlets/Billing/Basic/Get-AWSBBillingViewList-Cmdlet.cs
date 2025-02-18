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
using Amazon.Billing;
using Amazon.Billing.Model;

namespace Amazon.PowerShell.Cmdlets.AWSB
{
    /// <summary>
    /// Lists the billing views available for a given time period. 
    /// 
    ///  
    /// <para>
    /// Every Amazon Web Services account has a unique <c>PRIMARY</c> billing view that represents
    /// the billing data available by default. Accounts that use Billing Conductor also have
    /// <c>BILLING_GROUP</c> billing views representing pro forma costs associated with each
    /// created billing group.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "AWSBBillingViewList")]
    [OutputType("Amazon.Billing.Model.BillingViewListElement")]
    [AWSCmdlet("Calls the AWS Billing ListBillingViews API operation.", Operation = new[] {"ListBillingViews"}, SelectReturnType = typeof(Amazon.Billing.Model.ListBillingViewsResponse))]
    [AWSCmdletOutput("Amazon.Billing.Model.BillingViewListElement or Amazon.Billing.Model.ListBillingViewsResponse",
        "This cmdlet returns a collection of Amazon.Billing.Model.BillingViewListElement objects.",
        "The service call response (type Amazon.Billing.Model.ListBillingViewsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAWSBBillingViewListCmdlet : AmazonBillingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActiveTimeRange_ActiveAfterInclusive
        /// <summary>
        /// <para>
        /// <para>The inclusive time range start date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ActiveTimeRange_ActiveAfterInclusive { get; set; }
        #endregion
        
        #region Parameter ActiveTimeRange_ActiveBeforeInclusive
        /// <summary>
        /// <para>
        /// <para> The inclusive time range end date. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ActiveTimeRange_ActiveBeforeInclusive { get; set; }
        #endregion
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that can be used to uniquely identify the billing view.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Arns")]
        public System.String[] Arn { get; set; }
        #endregion
        
        #region Parameter BillingViewType
        /// <summary>
        /// <para>
        /// <para>The type of billing view.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BillingViewTypes")]
        public System.String[] BillingViewType { get; set; }
        #endregion
        
        #region Parameter OwnerAccountId
        /// <summary>
        /// <para>
        /// <para> The list of owners of the billing view. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnerAccountId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of billing views to retrieve. Default is 100. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that is used on subsequent calls to list billing views.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BillingViews'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Billing.Model.ListBillingViewsResponse).
        /// Specifying the name of a property of type Amazon.Billing.Model.ListBillingViewsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BillingViews";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Billing.Model.ListBillingViewsResponse, GetAWSBBillingViewListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActiveTimeRange_ActiveAfterInclusive = this.ActiveTimeRange_ActiveAfterInclusive;
            context.ActiveTimeRange_ActiveBeforeInclusive = this.ActiveTimeRange_ActiveBeforeInclusive;
            if (this.Arn != null)
            {
                context.Arn = new List<System.String>(this.Arn);
            }
            if (this.BillingViewType != null)
            {
                context.BillingViewType = new List<System.String>(this.BillingViewType);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.OwnerAccountId = this.OwnerAccountId;
            
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
            var request = new Amazon.Billing.Model.ListBillingViewsRequest();
            
            
             // populate ActiveTimeRange
            var requestActiveTimeRangeIsNull = true;
            request.ActiveTimeRange = new Amazon.Billing.Model.ActiveTimeRange();
            System.DateTime? requestActiveTimeRange_activeTimeRange_ActiveAfterInclusive = null;
            if (cmdletContext.ActiveTimeRange_ActiveAfterInclusive != null)
            {
                requestActiveTimeRange_activeTimeRange_ActiveAfterInclusive = cmdletContext.ActiveTimeRange_ActiveAfterInclusive.Value;
            }
            if (requestActiveTimeRange_activeTimeRange_ActiveAfterInclusive != null)
            {
                request.ActiveTimeRange.ActiveAfterInclusive = requestActiveTimeRange_activeTimeRange_ActiveAfterInclusive.Value;
                requestActiveTimeRangeIsNull = false;
            }
            System.DateTime? requestActiveTimeRange_activeTimeRange_ActiveBeforeInclusive = null;
            if (cmdletContext.ActiveTimeRange_ActiveBeforeInclusive != null)
            {
                requestActiveTimeRange_activeTimeRange_ActiveBeforeInclusive = cmdletContext.ActiveTimeRange_ActiveBeforeInclusive.Value;
            }
            if (requestActiveTimeRange_activeTimeRange_ActiveBeforeInclusive != null)
            {
                request.ActiveTimeRange.ActiveBeforeInclusive = requestActiveTimeRange_activeTimeRange_ActiveBeforeInclusive.Value;
                requestActiveTimeRangeIsNull = false;
            }
             // determine if request.ActiveTimeRange should be set to null
            if (requestActiveTimeRangeIsNull)
            {
                request.ActiveTimeRange = null;
            }
            if (cmdletContext.Arn != null)
            {
                request.Arns = cmdletContext.Arn;
            }
            if (cmdletContext.BillingViewType != null)
            {
                request.BillingViewTypes = cmdletContext.BillingViewType;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.OwnerAccountId != null)
            {
                request.OwnerAccountId = cmdletContext.OwnerAccountId;
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
        
        private Amazon.Billing.Model.ListBillingViewsResponse CallAWSServiceOperation(IAmazonBilling client, Amazon.Billing.Model.ListBillingViewsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Billing", "ListBillingViews");
            try
            {
                return client.ListBillingViewsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? ActiveTimeRange_ActiveAfterInclusive { get; set; }
            public System.DateTime? ActiveTimeRange_ActiveBeforeInclusive { get; set; }
            public List<System.String> Arn { get; set; }
            public List<System.String> BillingViewType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String OwnerAccountId { get; set; }
            public System.Func<Amazon.Billing.Model.ListBillingViewsResponse, GetAWSBBillingViewListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BillingViews;
        }
        
    }
}
