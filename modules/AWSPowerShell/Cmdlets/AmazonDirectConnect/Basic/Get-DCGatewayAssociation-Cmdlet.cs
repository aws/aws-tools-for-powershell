/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Lists the associations between your Direct Connect gateways and virtual private gateways.
    /// You must specify a Direct Connect gateway, a virtual private gateway, or both. If
    /// you specify a Direct Connect gateway, the response contains all virtual private gateways
    /// associated with the Direct Connect gateway. If you specify a virtual private gateway,
    /// the response contains all Direct Connect gateways associated with the virtual private
    /// gateway. If you specify both, the response contains the association between the Direct
    /// Connect gateway and the virtual private gateway.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "DCGatewayAssociation")]
    [OutputType("Amazon.DirectConnect.Model.DirectConnectGatewayAssociation")]
    [AWSCmdlet("Calls the AWS Direct Connect DescribeDirectConnectGatewayAssociations API operation.", Operation = new[] {"DescribeDirectConnectGatewayAssociations"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.DirectConnectGatewayAssociation",
        "This cmdlet returns a collection of DirectConnectGatewayAssociation objects.",
        "The service call response (type Amazon.DirectConnect.Model.DescribeDirectConnectGatewayAssociationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetDCGatewayAssociationCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter AssociatedGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the associated gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AssociatedGatewayId { get; set; }
        #endregion
        
        #region Parameter AssociationId
        /// <summary>
        /// <para>
        /// <para>The ID of the Direct Connect gateway association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AssociationId { get; set; }
        #endregion
        
        #region Parameter DirectConnectGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the Direct Connect gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectConnectGatewayId { get; set; }
        #endregion
        
        #region Parameter VirtualGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual private gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VirtualGatewayId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with a single call. To retrieve the remaining
        /// results, make another call with the returned <code>nextToken</code> value.</para><para>If <code>MaxResults</code> is given a value larger than 100, only 100 results are
        /// returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token provided in the previous call to retrieve the next page.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AssociatedGatewayId = this.AssociatedGatewayId;
            context.AssociationId = this.AssociationId;
            context.DirectConnectGatewayId = this.DirectConnectGatewayId;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.VirtualGatewayId = this.VirtualGatewayId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.DirectConnect.Model.DescribeDirectConnectGatewayAssociationsRequest();
            if (cmdletContext.AssociatedGatewayId != null)
            {
                request.AssociatedGatewayId = cmdletContext.AssociatedGatewayId;
            }
            if (cmdletContext.AssociationId != null)
            {
                request.AssociationId = cmdletContext.AssociationId;
            }
            if (cmdletContext.DirectConnectGatewayId != null)
            {
                request.DirectConnectGatewayId = cmdletContext.DirectConnectGatewayId;
            }
            if (cmdletContext.VirtualGatewayId != null)
            {
                request.VirtualGatewayId = cmdletContext.VirtualGatewayId;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = ParameterWasBound("NextToken");
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (_emitLimit.HasValue)
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.DirectConnectGatewayAssociations;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.DirectConnectGatewayAssociations.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        _retrievedSoFar += _receivedThisCall;
                        if (_emitLimit.HasValue)
                        {
                            _emitLimit -= _receivedThisCall;
                        }
                    }
                    catch (Exception e)
                    {
                        if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                        {
                            output = new CmdletOutput { ErrorResponse = e };
                        }
                        else
                        {
                            break;
                        }
                    }
                    
                    ProcessOutput(output);
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
                
            }
            finally
            {
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.DirectConnect.Model.DescribeDirectConnectGatewayAssociationsResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.DescribeDirectConnectGatewayAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "DescribeDirectConnectGatewayAssociations");
            try
            {
                #if DESKTOP
                return client.DescribeDirectConnectGatewayAssociations(request);
                #elif CORECLR
                return client.DescribeDirectConnectGatewayAssociationsAsync(request).GetAwaiter().GetResult();
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
            public System.String AssociatedGatewayId { get; set; }
            public System.String AssociationId { get; set; }
            public System.String DirectConnectGatewayId { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.String VirtualGatewayId { get; set; }
        }
        
    }
}
