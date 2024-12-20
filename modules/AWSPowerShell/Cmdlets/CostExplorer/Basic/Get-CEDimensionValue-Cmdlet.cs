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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Retrieves all available filter values for a specified filter over a period of time.
    /// You can search the dimension values for an arbitrary string.<br/><br/>In the AWS.Tools.CostExplorer module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CEDimensionValue")]
    [OutputType("Amazon.CostExplorer.Model.GetDimensionValuesResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer GetDimensionValues API operation.", Operation = new[] {"GetDimensionValues"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.GetDimensionValuesResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.GetDimensionValuesResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.GetDimensionValuesResponse object containing multiple properties."
    )]
    public partial class GetCEDimensionValueCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BillingViewArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that uniquely identifies a specific billing view. The
        /// ARN is used to specify which particular billing view you want to interact with or
        /// retrieve information from when making API calls related to Amazon Web Services Billing
        /// and Cost Management features. The BillingViewArn can be retrieved by calling the ListBillingViews
        /// API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingViewArn { get; set; }
        #endregion
        
        #region Parameter Context
        /// <summary>
        /// <para>
        /// <para>The context for the call to <c>GetDimensionValues</c>. This can be <c>RESERVATIONS</c>
        /// or <c>COST_AND_USAGE</c>. The default value is <c>COST_AND_USAGE</c>. If the context
        /// is set to <c>RESERVATIONS</c>, the resulting dimension values can be used in the <c>GetReservationUtilization</c>
        /// operation. If the context is set to <c>COST_AND_USAGE</c>, the resulting dimension
        /// values can be used in the <c>GetCostAndUsage</c> operation.</para><para>If you set the context to <c>COST_AND_USAGE</c>, you can use the following dimensions
        /// for searching:</para><ul><li><para>AZ - The Availability Zone. An example is <c>us-east-1a</c>.</para></li><li><para>BILLING_ENTITY - The Amazon Web Services seller that your account is with. Possible
        /// values are the following:</para><para>- Amazon Web Services(Amazon Web Services): The entity that sells Amazon Web Services
        /// services.</para><para>- AISPL (Amazon Internet Services Pvt. Ltd.): The local Indian entity that's an acting
        /// reseller for Amazon Web Services services in India.</para><para>- Amazon Web Services Marketplace: The entity that supports the sale of solutions
        /// that are built on Amazon Web Services by third-party software providers.</para></li><li><para>CACHE_ENGINE - The Amazon ElastiCache operating system. Examples are Windows or Linux.</para></li><li><para>DEPLOYMENT_OPTION - The scope of Amazon Relational Database Service deployments. Valid
        /// values are <c>SingleAZ</c> and <c>MultiAZ</c>.</para></li><li><para>DATABASE_ENGINE - The Amazon Relational Database Service database. Examples are Aurora
        /// or MySQL.</para></li><li><para>INSTANCE_TYPE - The type of Amazon EC2 instance. An example is <c>m4.xlarge</c>.</para></li><li><para>INSTANCE_TYPE_FAMILY - A family of instance types optimized to fit different use cases.
        /// Examples are <c>Compute Optimized</c> (for example, <c>C4</c>, <c>C5</c>, <c>C6g</c>,
        /// and <c>C7g</c>), <c>Memory Optimization</c> (for example, <c>R4</c>, <c>R5n</c>, <c>R5b</c>,
        /// and <c>R6g</c>).</para></li><li><para>INVOICING_ENTITY - The name of the entity that issues the Amazon Web Services invoice.</para></li><li><para>LEGAL_ENTITY_NAME - The name of the organization that sells you Amazon Web Services
        /// services, such as Amazon Web Services.</para></li><li><para>LINKED_ACCOUNT - The description in the attribute map that includes the full name
        /// of the member account. The value field contains the Amazon Web Services ID of the
        /// member account.</para></li><li><para>OPERATING_SYSTEM - The operating system. Examples are Windows or Linux.</para></li><li><para>OPERATION - The action performed. Examples include <c>RunInstance</c> and <c>CreateBucket</c>.</para></li><li><para>PLATFORM - The Amazon EC2 operating system. Examples are Windows or Linux.</para></li><li><para>PURCHASE_TYPE - The reservation type of the purchase that this usage is related to.
        /// Examples include On-Demand Instances and Standard Reserved Instances.</para></li><li><para>RESERVATION_ID - The unique identifier for an Amazon Web Services Reservation Instance.</para></li><li><para>SAVINGS_PLAN_ARN - The unique identifier for your Savings Plans.</para></li><li><para>SAVINGS_PLANS_TYPE - Type of Savings Plans (EC2 Instance or Compute).</para></li><li><para>SERVICE - The Amazon Web Services service such as Amazon DynamoDB.</para></li><li><para>TENANCY - The tenancy of a resource. Examples are shared or dedicated.</para></li><li><para>USAGE_TYPE - The type of usage. An example is DataTransfer-In-Bytes. The response
        /// for the <c>GetDimensionValues</c> operation includes a unit attribute. Examples include
        /// GB and Hrs.</para></li><li><para>USAGE_TYPE_GROUP - The grouping of common usage types. An example is Amazon EC2: CloudWatch
        /// – Alarms. The response for this operation includes a unit attribute.</para></li><li><para>REGION - The Amazon Web Services Region.</para></li><li><para>RECORD_TYPE - The different types of charges such as Reserved Instance (RI) fees,
        /// usage costs, tax refunds, and credits.</para></li><li><para>RESOURCE_ID - The unique identifier of the resource. ResourceId is an opt-in feature
        /// only available for last 14 days for EC2-Compute Service.</para></li></ul><para>If you set the context to <c>RESERVATIONS</c>, you can use the following dimensions
        /// for searching:</para><ul><li><para>AZ - The Availability Zone. An example is <c>us-east-1a</c>.</para></li><li><para>CACHE_ENGINE - The Amazon ElastiCache operating system. Examples are Windows or Linux.</para></li><li><para>DEPLOYMENT_OPTION - The scope of Amazon Relational Database Service deployments. Valid
        /// values are <c>SingleAZ</c> and <c>MultiAZ</c>.</para></li><li><para>INSTANCE_TYPE - The type of Amazon EC2 instance. An example is <c>m4.xlarge</c>.</para></li><li><para>LINKED_ACCOUNT - The description in the attribute map that includes the full name
        /// of the member account. The value field contains the Amazon Web Services ID of the
        /// member account.</para></li><li><para>PLATFORM - The Amazon EC2 operating system. Examples are Windows or Linux.</para></li><li><para>REGION - The Amazon Web Services Region.</para></li><li><para>SCOPE (Utilization only) - The scope of a Reserved Instance (RI). Values are regional
        /// or a single Availability Zone.</para></li><li><para>TAG (Coverage only) - The tags that are associated with a Reserved Instance (RI).</para></li><li><para>TENANCY - The tenancy of a resource. Examples are shared or dedicated.</para></li></ul><para>If you set the context to <c>SAVINGS_PLANS</c>, you can use the following dimensions
        /// for searching:</para><ul><li><para>SAVINGS_PLANS_TYPE - Type of Savings Plans (EC2 Instance or Compute)</para></li><li><para>PAYMENT_OPTION - The payment option for the given Savings Plans (for example, All
        /// Upfront)</para></li><li><para>REGION - The Amazon Web Services Region.</para></li><li><para>INSTANCE_TYPE_FAMILY - The family of instances (For example, <c>m5</c>)</para></li><li><para>LINKED_ACCOUNT - The description in the attribute map that includes the full name
        /// of the member account. The value field contains the Amazon Web Services ID of the
        /// member account.</para></li><li><para>SAVINGS_PLAN_ARN - The unique identifier for your Savings Plans.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.Context")]
        public Amazon.CostExplorer.Context Context { get; set; }
        #endregion
        
        #region Parameter Dimension
        /// <summary>
        /// <para>
        /// <para>The name of the dimension. Each <c>Dimension</c> is available for a different <c>Context</c>.
        /// For more information, see <c>Context</c>. <c>LINK_ACCOUNT_NAME</c> and <c>SERVICE_CODE</c>
        /// can only be used in <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/AAPI_CostCategoryRule.html">CostCategoryRule</a>.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostExplorer.Dimension")]
        public Amazon.CostExplorer.Dimension Dimension { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.Expression Filter { get; set; }
        #endregion
        
        #region Parameter SearchString
        /// <summary>
        /// <para>
        /// <para>The value that you want to search the filter values for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SearchString { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The value that you want to sort the data by.</para><para>The key represents cost and usage metrics. The following values are supported:</para><ul><li><para><c>BlendedCost</c></para></li><li><para><c>UnblendedCost</c></para></li><li><para><c>AmortizedCost</c></para></li><li><para><c>NetAmortizedCost</c></para></li><li><para><c>NetUnblendedCost</c></para></li><li><para><c>UsageQuantity</c></para></li><li><para><c>NormalizedUsageAmount</c></para></li></ul><para>The supported values for the <c>SortOrder</c> key are <c>ASCENDING</c> or <c>DESCENDING</c>.</para><para>When you specify a <c>SortBy</c> paramater, the context must be <c>COST_AND_USAGE</c>.
        /// Further, when using <c>SortBy</c>, <c>NextPageToken</c> and <c>SearchString</c> aren't
        /// supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.SortDefinition[] SortBy { get; set; }
        #endregion
        
        #region Parameter TimePeriod
        /// <summary>
        /// <para>
        /// <para>The start date and end date for retrieving the dimension values. The start date is
        /// inclusive, but the end date is exclusive. For example, if <c>start</c> is <c>2017-01-01</c>
        /// and <c>end</c> is <c>2017-05-01</c>, then the cost and usage data is retrieved from
        /// <c>2017-01-01</c> up to and including <c>2017-04-30</c> but not including <c>2017-05-01</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>This field is only used when SortBy is provided in the request. The maximum number
        /// of objects that are returned for this request. If MaxResults isn't specified with
        /// SortBy, the request returns 1000 results as the default value for this parameter.</para><para>For <c>GetDimensionValues</c>, MaxResults has an upper limit of 1000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextPageToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next set of results. Amazon Web Services provides the token
        /// when the response from a previous call has more results than the maximum page size.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.CostExplorer module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextPageToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextPageToken' to null for the first call then set the 'NextPageToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String NextPageToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.GetDimensionValuesResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.GetDimensionValuesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TimePeriod parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TimePeriod' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TimePeriod' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextPageToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
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
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.GetDimensionValuesResponse, GetCEDimensionValueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TimePeriod;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BillingViewArn = this.BillingViewArn;
            context.Context = this.Context;
            context.Dimension = this.Dimension;
            #if MODULAR
            if (this.Dimension == null && ParameterWasBound(nameof(this.Dimension)))
            {
                WriteWarning("You are passing $null as a value for parameter Dimension which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Filter = this.Filter;
            context.MaxResult = this.MaxResult;
            context.NextPageToken = this.NextPageToken;
            context.SearchString = this.SearchString;
            if (this.SortBy != null)
            {
                context.SortBy = new List<Amazon.CostExplorer.Model.SortDefinition>(this.SortBy);
            }
            context.TimePeriod = this.TimePeriod;
            #if MODULAR
            if (this.TimePeriod == null && ParameterWasBound(nameof(this.TimePeriod)))
            {
                WriteWarning("You are passing $null as a value for parameter TimePeriod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.CostExplorer.Model.GetDimensionValuesRequest();
            
            if (cmdletContext.BillingViewArn != null)
            {
                request.BillingViewArn = cmdletContext.BillingViewArn;
            }
            if (cmdletContext.Context != null)
            {
                request.Context = cmdletContext.Context;
            }
            if (cmdletContext.Dimension != null)
            {
                request.Dimension = cmdletContext.Dimension;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SearchString != null)
            {
                request.SearchString = cmdletContext.SearchString;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.TimePeriod != null)
            {
                request.TimePeriod = cmdletContext.TimePeriod;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextPageToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextPageToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextPageToken = _nextToken;
                
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
                    
                    _nextToken = response.NextPageToken;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CostExplorer.Model.GetDimensionValuesRequest();
            
            if (cmdletContext.BillingViewArn != null)
            {
                request.BillingViewArn = cmdletContext.BillingViewArn;
            }
            if (cmdletContext.Context != null)
            {
                request.Context = cmdletContext.Context;
            }
            if (cmdletContext.Dimension != null)
            {
                request.Dimension = cmdletContext.Dimension;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextPageToken != null)
            {
                request.NextPageToken = cmdletContext.NextPageToken;
            }
            if (cmdletContext.SearchString != null)
            {
                request.SearchString = cmdletContext.SearchString;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.TimePeriod != null)
            {
                request.TimePeriod = cmdletContext.TimePeriod;
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
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CostExplorer.Model.GetDimensionValuesResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.GetDimensionValuesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "GetDimensionValues");
            try
            {
                #if DESKTOP
                return client.GetDimensionValues(request);
                #elif CORECLR
                return client.GetDimensionValuesAsync(request).GetAwaiter().GetResult();
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
            public System.String BillingViewArn { get; set; }
            public Amazon.CostExplorer.Context Context { get; set; }
            public Amazon.CostExplorer.Dimension Dimension { get; set; }
            public Amazon.CostExplorer.Model.Expression Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextPageToken { get; set; }
            public System.String SearchString { get; set; }
            public List<Amazon.CostExplorer.Model.SortDefinition> SortBy { get; set; }
            public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
            public System.Func<Amazon.CostExplorer.Model.GetDimensionValuesResponse, GetCEDimensionValueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
