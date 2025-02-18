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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Gets a list of response headers policies.
    /// 
    ///  
    /// <para>
    /// You can optionally apply a filter to get only the managed policies created by Amazon
    /// Web Services, or only the custom policies created in your Amazon Web Services account.
    /// </para><para>
    /// You can optionally specify the maximum number of items to receive in the response.
    /// If the total number of items in the list exceeds the maximum that you specify, or
    /// the default maximum, the response is paginated. To get the next page of items, send
    /// a subsequent request that specifies the <c>NextMarker</c> value from the current response
    /// as the <c>Marker</c> value in the subsequent request.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CFResponseHeadersPolicyList")]
    [OutputType("Amazon.CloudFront.Model.ResponseHeadersPolicyList")]
    [AWSCmdlet("Calls the Amazon CloudFront ListResponseHeadersPolicies API operation.", Operation = new[] {"ListResponseHeadersPolicies"}, SelectReturnType = typeof(Amazon.CloudFront.Model.ListResponseHeadersPoliciesResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.ResponseHeadersPolicyList or Amazon.CloudFront.Model.ListResponseHeadersPoliciesResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.ResponseHeadersPolicyList object.",
        "The service call response (type Amazon.CloudFront.Model.ListResponseHeadersPoliciesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFResponseHeadersPolicyListCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>A filter to get only the specified kind of response headers policies. Valid values
        /// are:</para><ul><li><para><c>managed</c> – Gets only the managed policies created by Amazon Web Services.</para></li><li><para><c>custom</c> – Gets only the custom policies created in your Amazon Web Services
        /// account.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.CloudFront.ResponseHeadersPolicyType")]
        public Amazon.CloudFront.ResponseHeadersPolicyType Type { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use this field when paginating results to indicate where to begin in your list of
        /// response headers policies. The response includes response headers policies in the
        /// list that occur after the marker. To get the next page of the list, set this field's
        /// value to the value of <c>NextMarker</c> from the current page's response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of response headers policies that you want to get in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResponseHeadersPolicyList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.ListResponseHeadersPoliciesResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.ListResponseHeadersPoliciesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResponseHeadersPolicyList";
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
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.ListResponseHeadersPoliciesResponse, GetCFResponseHeadersPolicyListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Marker = this.Marker;
            context.MaxItem = this.MaxItem;
            context.Type = this.Type;
            
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
            var request = new Amazon.CloudFront.Model.ListResponseHeadersPoliciesRequest();
            
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.CloudFront.Model.ListResponseHeadersPoliciesResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.ListResponseHeadersPoliciesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "ListResponseHeadersPolicies");
            try
            {
                return client.ListResponseHeadersPoliciesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Marker { get; set; }
            public System.String MaxItem { get; set; }
            public Amazon.CloudFront.ResponseHeadersPolicyType Type { get; set; }
            public System.Func<Amazon.CloudFront.Model.ListResponseHeadersPoliciesResponse, GetCFResponseHeadersPolicyListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResponseHeadersPolicyList;
        }
        
    }
}
