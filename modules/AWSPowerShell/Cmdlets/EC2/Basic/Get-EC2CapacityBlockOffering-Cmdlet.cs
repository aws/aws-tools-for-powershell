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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes Capacity Block offerings available for purchase in the Amazon Web Services
    /// Region that you're currently using. With Capacity Blocks, you can purchase a specific
    /// GPU instance type or EC2 UltraServer for a period of time.
    /// 
    ///  
    /// <para>
    /// To search for an available Capacity Block offering, you specify a reservation duration
    /// and instance count.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2CapacityBlockOffering")]
    [OutputType("Amazon.EC2.Model.CapacityBlockOffering")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeCapacityBlockOfferings API operation.", Operation = new[] {"DescribeCapacityBlockOfferings"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeCapacityBlockOfferingsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CapacityBlockOffering or Amazon.EC2.Model.DescribeCapacityBlockOfferingsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.CapacityBlockOffering objects.",
        "The service call response (type Amazon.EC2.Model.DescribeCapacityBlockOfferingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2CapacityBlockOfferingCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CapacityDurationHour
        /// <summary>
        /// <para>
        /// <para>The reservation duration for the Capacity Block, in hours. You must specify the duration
        /// in 1-day increments up 14 days, and in 7-day increments up to 182 days.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("CapacityDurationHours")]
        public System.Int32? CapacityDurationHour { get; set; }
        #endregion
        
        #region Parameter EndDateRange
        /// <summary>
        /// <para>
        /// <para>The latest end date for the Capacity Block offering.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndDateRange { get; set; }
        #endregion
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of instances for which to reserve capacity. Each Capacity Block can have
        /// up to 64 instances, and you can have up to 256 instances across Capacity Blocks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceCount { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The type of instance for which the Capacity Block offering reserves capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter StartDateRange
        /// <summary>
        /// <para>
        /// <para>The earliest start date for the Capacity Block offering.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartDateRange { get; set; }
        #endregion
        
        #region Parameter UltraserverCount
        /// <summary>
        /// <para>
        /// <para>The number of EC2 UltraServers in the offerings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UltraserverCount { get; set; }
        #endregion
        
        #region Parameter UltraserverType
        /// <summary>
        /// <para>
        /// <para>The EC2 UltraServer type of the Capacity Block offerings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UltraserverType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return for this request. To get the next page of items,
        /// make another request with the token returned in the output. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Query-Requests.html#api-pagination">Pagination</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to use to retrieve the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CapacityBlockOfferings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeCapacityBlockOfferingsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeCapacityBlockOfferingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CapacityBlockOfferings";
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeCapacityBlockOfferingsResponse, GetEC2CapacityBlockOfferingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapacityDurationHour = this.CapacityDurationHour;
            #if MODULAR
            if (this.CapacityDurationHour == null && ParameterWasBound(nameof(this.CapacityDurationHour)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityDurationHour which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndDateRange = this.EndDateRange;
            context.InstanceCount = this.InstanceCount;
            context.InstanceType = this.InstanceType;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.StartDateRange = this.StartDateRange;
            context.UltraserverCount = this.UltraserverCount;
            context.UltraserverType = this.UltraserverType;
            
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
            var request = new Amazon.EC2.Model.DescribeCapacityBlockOfferingsRequest();
            
            if (cmdletContext.CapacityDurationHour != null)
            {
                request.CapacityDurationHours = cmdletContext.CapacityDurationHour.Value;
            }
            if (cmdletContext.EndDateRange != null)
            {
                request.EndDateRange = cmdletContext.EndDateRange.Value;
            }
            if (cmdletContext.InstanceCount != null)
            {
                request.InstanceCount = cmdletContext.InstanceCount.Value;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.StartDateRange != null)
            {
                request.StartDateRange = cmdletContext.StartDateRange.Value;
            }
            if (cmdletContext.UltraserverCount != null)
            {
                request.UltraserverCount = cmdletContext.UltraserverCount.Value;
            }
            if (cmdletContext.UltraserverType != null)
            {
                request.UltraserverType = cmdletContext.UltraserverType;
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
        
        private Amazon.EC2.Model.DescribeCapacityBlockOfferingsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeCapacityBlockOfferingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeCapacityBlockOfferings");
            try
            {
                #if DESKTOP
                return client.DescribeCapacityBlockOfferings(request);
                #elif CORECLR
                return client.DescribeCapacityBlockOfferingsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? CapacityDurationHour { get; set; }
            public System.DateTime? EndDateRange { get; set; }
            public System.Int32? InstanceCount { get; set; }
            public System.String InstanceType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? StartDateRange { get; set; }
            public System.Int32? UltraserverCount { get; set; }
            public System.String UltraserverType { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeCapacityBlockOfferingsResponse, GetEC2CapacityBlockOfferingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CapacityBlockOfferings;
        }
        
    }
}
