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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Gets the list of CloudFront origin access controls (OACs) in this Amazon Web Services
    /// account.
    /// 
    ///  
    /// <para>
    /// You can optionally specify the maximum number of items to receive in the response.
    /// If the total number of items in the list exceeds the maximum that you specify, or
    /// the default maximum, the response is paginated. To get the next page of items, send
    /// another request that specifies the <c>NextMarker</c> value from the current response
    /// as the <c>Marker</c> value in the next request.
    /// </para><note><para>
    /// If you're not using origin access controls for your Amazon Web Services account, the
    /// <c>ListOriginAccessControls</c> operation doesn't return the <c>Items</c> element
    /// in the response.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFOriginAccessControlList")]
    [OutputType("Amazon.CloudFront.Model.OriginAccessControlList")]
    [AWSCmdlet("Calls the Amazon CloudFront ListOriginAccessControls API operation.", Operation = new[] {"ListOriginAccessControls"}, SelectReturnType = typeof(Amazon.CloudFront.Model.ListOriginAccessControlsResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.OriginAccessControlList or Amazon.CloudFront.Model.ListOriginAccessControlsResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.OriginAccessControlList object.",
        "The service call response (type Amazon.CloudFront.Model.ListOriginAccessControlsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFOriginAccessControlListCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use this field when paginating results to indicate where to begin in your list of
        /// origin access controls. The response includes the items in the list that occur after
        /// the marker. To get the next page of the list, set this field's value to the value
        /// of <c>NextMarker</c> from the current page's response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of origin access controls that you want in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OriginAccessControlList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.ListOriginAccessControlsResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.ListOriginAccessControlsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OriginAccessControlList";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.ListOriginAccessControlsResponse, GetCFOriginAccessControlListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Marker = this.Marker;
            context.MaxItem = this.MaxItem;
            
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
            var request = new Amazon.CloudFront.Model.ListOriginAccessControlsRequest();
            
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem;
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
        
        private Amazon.CloudFront.Model.ListOriginAccessControlsResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.ListOriginAccessControlsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "ListOriginAccessControls");
            try
            {
                return client.ListOriginAccessControlsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.CloudFront.Model.ListOriginAccessControlsResponse, GetCFOriginAccessControlListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OriginAccessControlList;
        }
        
    }
}
