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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Retrieves the specified pools or all pools associated with your Amazon Web Services
    /// account.
    /// 
    ///  
    /// <para>
    /// If you specify pool IDs, the output includes information for only the specified pools.
    /// If you specify filters, the output includes information for only those pools that
    /// meet the filter criteria. If you don't specify pool IDs or filters, the output includes
    /// information for all pools.
    /// </para><para>
    /// If you specify a pool ID that isn't valid, an error is returned.
    /// </para><para>
    /// A pool is a collection of phone numbers and SenderIds. A pool can include one or more
    /// phone numbers and SenderIds that are associated with your Amazon Web Services account.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SMSVPool")]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.DescribePoolsResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 DescribePools API operation.", Operation = new[] {"DescribePools"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.DescribePoolsResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.DescribePoolsResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.DescribePoolsResponse object containing multiple properties."
    )]
    public partial class GetSMSVPoolCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>An array of PoolFilter objects to filter the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.PinpointSMSVoiceV2.Model.PoolFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter PoolId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of pools to find. This is an array of strings that can be either
        /// the PoolId or PoolArn.</para><important><para>If you are using a shared AWS End User Messaging SMS and Voice resource then you must
        /// use the full Amazon Resource Name(ARN).</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PoolIds")]
        public System.String[] PoolId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per each request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to be used for the next set of paginated results. You don't need to supply
        /// a value for this field in the initial request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Owner
        /// <summary>
        /// <para>
        /// <para>Use <c>SELF</c> to filter the list of Pools to ones your account owns or use <c>SHARED</c>
        /// to filter on Pools shared with your account. The <c>Owner</c> and <c>PoolIds</c> parameters
        /// can't be used at the same time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PinpointSMSVoiceV2.Owner")]
        public Amazon.PinpointSMSVoiceV2.Owner Owner { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.DescribePoolsResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.DescribePoolsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.DescribePoolsResponse, GetSMSVPoolCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.PinpointSMSVoiceV2.Model.PoolFilter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Owner = this.Owner;
            if (this.PoolId != null)
            {
                context.PoolId = new List<System.String>(this.PoolId);
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.PinpointSMSVoiceV2.Model.DescribePoolsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Owner != null)
            {
                request.Owner = cmdletContext.Owner;
            }
            if (cmdletContext.PoolId != null)
            {
                request.PoolIds = cmdletContext.PoolId;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.DescribePoolsResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.DescribePoolsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "DescribePools");
            try
            {
                #if DESKTOP
                return client.DescribePools(request);
                #elif CORECLR
                return client.DescribePoolsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.PinpointSMSVoiceV2.Model.PoolFilter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.PinpointSMSVoiceV2.Owner Owner { get; set; }
            public List<System.String> PoolId { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.DescribePoolsResponse, GetSMSVPoolCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
