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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Returns a list of inbound integrations.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RSInboundIntegration")]
    [OutputType("Amazon.Redshift.Model.InboundIntegration")]
    [AWSCmdlet("Calls the Amazon Redshift DescribeInboundIntegrations API operation.", Operation = new[] {"DescribeInboundIntegrations"}, SelectReturnType = typeof(Amazon.Redshift.Model.DescribeInboundIntegrationsResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.InboundIntegration or Amazon.Redshift.Model.DescribeInboundIntegrationsResponse",
        "This cmdlet returns a collection of Amazon.Redshift.Model.InboundIntegration objects.",
        "The service call response (type Amazon.Redshift.Model.DescribeInboundIntegrationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRSInboundIntegrationCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IntegrationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the inbound integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IntegrationArn { get; set; }
        #endregion
        
        #region Parameter TargetArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the target of an inbound integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetArn { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional parameter that specifies the starting point to return a set of response
        /// records. When the results of a <a>DescribeInboundIntegrations</a> request exceed the
        /// value specified in <c>MaxRecords</c>, Amazon Web Services returns a value in the <c>Marker</c>
        /// field of the response. You can retrieve the next set of response records by providing
        /// the returned marker value in the <c>Marker</c> parameter and retrying the request.
        /// </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number of response records to return in each call. If the number of remaining
        /// response records exceeds the specified <c>MaxRecords</c> value, a value is returned
        /// in a <c>marker</c> field of the response. You can retrieve the next set of records
        /// by retrying the command with the returned marker value. </para><para>Default: <c>100</c></para><para>Constraints: minimum 20, maximum 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRecords")]
        public System.Int32? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InboundIntegrations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.DescribeInboundIntegrationsResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.DescribeInboundIntegrationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InboundIntegrations";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
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
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.DescribeInboundIntegrationsResponse, GetRSInboundIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IntegrationArn = this.IntegrationArn;
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            context.TargetArn = this.TargetArn;
            
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
            var request = new Amazon.Redshift.Model.DescribeInboundIntegrationsRequest();
            
            if (cmdletContext.IntegrationArn != null)
            {
                request.IntegrationArn = cmdletContext.IntegrationArn;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = cmdletContext.MaxRecord.Value;
            }
            if (cmdletContext.TargetArn != null)
            {
                request.TargetArn = cmdletContext.TargetArn;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.Redshift.Model.DescribeInboundIntegrationsResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.DescribeInboundIntegrationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "DescribeInboundIntegrations");
            try
            {
                return client.DescribeInboundIntegrationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IntegrationArn { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxRecord { get; set; }
            public System.String TargetArn { get; set; }
            public System.Func<Amazon.Redshift.Model.DescribeInboundIntegrationsResponse, GetRSInboundIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InboundIntegrations;
        }
        
    }
}
