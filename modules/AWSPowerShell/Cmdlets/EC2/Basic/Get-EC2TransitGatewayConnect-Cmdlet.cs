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
    /// Describes one or more Connect attachments.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2TransitGatewayConnect")]
    [OutputType("Amazon.EC2.Model.TransitGatewayConnect")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeTransitGatewayConnects API operation.", Operation = new[] {"DescribeTransitGatewayConnects"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeTransitGatewayConnectsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayConnect or Amazon.EC2.Model.DescribeTransitGatewayConnectsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.TransitGatewayConnect objects.",
        "The service call response (type Amazon.EC2.Model.DescribeTransitGatewayConnectsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2TransitGatewayConnectCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters. The possible values are:</para><ul><li><para><c>options.protocol</c> - The tunnel protocol (<c>gre</c>).</para></li><li><para><c>state</c> - The state of the attachment (<c>initiating</c> | <c>initiatingRequest</c>
        /// | <c>pendingAcceptance</c> | <c>rollingBack</c> | <c>pending</c> | <c>available</c>
        /// | <c>modifying</c> | <c>deleting</c> | <c>deleted</c> | <c>failed</c> | <c>rejected</c>
        /// | <c>rejecting</c> | <c>failing</c>).</para></li><li><para><c>transit-gateway-attachment-id</c> - The ID of the Connect attachment.</para></li><li><para><c>transit-gateway-id</c> - The ID of the transit gateway.</para></li><li><para><c>transport-transit-gateway-attachment-id</c> - The ID of the transit gateway attachment
        /// from which the Connect attachment was created.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter TransitGatewayAttachmentId
        /// <summary>
        /// <para>
        /// <para>The IDs of the attachments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TransitGatewayAttachmentIds")]
        public System.String[] TransitGatewayAttachmentId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with a single call. To retrieve the remaining
        /// results, make another call with the returned <c>nextToken</c> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransitGatewayConnects'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeTransitGatewayConnectsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeTransitGatewayConnectsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransitGatewayConnects";
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeTransitGatewayConnectsResponse, GetEC2TransitGatewayConnectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.TransitGatewayAttachmentId != null)
            {
                context.TransitGatewayAttachmentId = new List<System.String>(this.TransitGatewayAttachmentId);
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
            var request = new Amazon.EC2.Model.DescribeTransitGatewayConnectsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.TransitGatewayAttachmentId != null)
            {
                request.TransitGatewayAttachmentIds = cmdletContext.TransitGatewayAttachmentId;
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
        
        private Amazon.EC2.Model.DescribeTransitGatewayConnectsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeTransitGatewayConnectsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeTransitGatewayConnects");
            try
            {
                #if DESKTOP
                return client.DescribeTransitGatewayConnects(request);
                #elif CORECLR
                return client.DescribeTransitGatewayConnectsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> TransitGatewayAttachmentId { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeTransitGatewayConnectsResponse, GetEC2TransitGatewayConnectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitGatewayConnects;
        }
        
    }
}
