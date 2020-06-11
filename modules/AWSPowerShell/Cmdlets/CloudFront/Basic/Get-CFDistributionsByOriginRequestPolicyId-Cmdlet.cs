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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Gets a list of distribution IDs for distributions that have a cache behavior that’s
    /// associated with the specified origin request policy.
    /// 
    ///  
    /// <para>
    /// You can optionally specify the maximum number of items to receive in the response.
    /// If the total number of items in the list exceeds the maximum that you specify, or
    /// the default maximum, the response is paginated. To get the next page of items, send
    /// a subsequent request that specifies the <code>NextMarker</code> value from the current
    /// response as the <code>Marker</code> value in the subsequent request.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CFDistributionsByOriginRequestPolicyId")]
    [OutputType("Amazon.CloudFront.Model.DistributionIdList")]
    [AWSCmdlet("Calls the Amazon CloudFront ListDistributionsByOriginRequestPolicyId API operation.", Operation = new[] {"ListDistributionsByOriginRequestPolicyId"}, SelectReturnType = typeof(Amazon.CloudFront.Model.ListDistributionsByOriginRequestPolicyIdResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.DistributionIdList or Amazon.CloudFront.Model.ListDistributionsByOriginRequestPolicyIdResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.DistributionIdList object.",
        "The service call response (type Amazon.CloudFront.Model.ListDistributionsByOriginRequestPolicyIdResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFDistributionsByOriginRequestPolicyIdCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter OriginRequestPolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the origin request policy whose associated distribution IDs you want to
        /// list.</para>
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
        public System.String OriginRequestPolicyId { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use this field when paginating results to indicate where to begin in your list of
        /// distribution IDs. The response includes distribution IDs in the list that occur after
        /// the marker. To get the next page of the list, set this field’s value to the value
        /// of <code>NextMarker</code> from the current page’s response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of distribution IDs that you want in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DistributionIdList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.ListDistributionsByOriginRequestPolicyIdResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.ListDistributionsByOriginRequestPolicyIdResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DistributionIdList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OriginRequestPolicyId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OriginRequestPolicyId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OriginRequestPolicyId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.ListDistributionsByOriginRequestPolicyIdResponse, GetCFDistributionsByOriginRequestPolicyIdCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OriginRequestPolicyId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Marker = this.Marker;
            context.MaxItem = this.MaxItem;
            context.OriginRequestPolicyId = this.OriginRequestPolicyId;
            #if MODULAR
            if (this.OriginRequestPolicyId == null && ParameterWasBound(nameof(this.OriginRequestPolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginRequestPolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CloudFront.Model.ListDistributionsByOriginRequestPolicyIdRequest();
            
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem;
            }
            if (cmdletContext.OriginRequestPolicyId != null)
            {
                request.OriginRequestPolicyId = cmdletContext.OriginRequestPolicyId;
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
        
        private Amazon.CloudFront.Model.ListDistributionsByOriginRequestPolicyIdResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.ListDistributionsByOriginRequestPolicyIdRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "ListDistributionsByOriginRequestPolicyId");
            try
            {
                #if DESKTOP
                return client.ListDistributionsByOriginRequestPolicyId(request);
                #elif CORECLR
                return client.ListDistributionsByOriginRequestPolicyIdAsync(request).GetAwaiter().GetResult();
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
            public System.String Marker { get; set; }
            public System.String MaxItem { get; set; }
            public System.String OriginRequestPolicyId { get; set; }
            public System.Func<Amazon.CloudFront.Model.ListDistributionsByOriginRequestPolicyIdResponse, GetCFDistributionsByOriginRequestPolicyIdCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DistributionIdList;
        }
        
    }
}
