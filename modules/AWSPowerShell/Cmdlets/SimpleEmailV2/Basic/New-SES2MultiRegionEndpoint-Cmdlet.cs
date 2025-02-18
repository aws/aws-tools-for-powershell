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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Creates a multi-region endpoint (global-endpoint).
    /// 
    ///  
    /// <para>
    /// The primary region is going to be the AWS-Region where the operation is executed.
    /// The secondary region has to be provided in request's parameters. From the data flow
    /// standpoint there is no difference between primary and secondary regions - sending
    /// traffic will be split equally between the two. The primary region is the region where
    /// the resource has been created and where it can be managed. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "SES2MultiRegionEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleEmailV2.Model.CreateMultiRegionEndpointResponse")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) CreateMultiRegionEndpoint API operation.", Operation = new[] {"CreateMultiRegionEndpoint"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.CreateMultiRegionEndpointResponse))]
    [AWSCmdletOutput("Amazon.SimpleEmailV2.Model.CreateMultiRegionEndpointResponse",
        "This cmdlet returns an Amazon.SimpleEmailV2.Model.CreateMultiRegionEndpointResponse object containing multiple properties."
    )]
    public partial class NewSES2MultiRegionEndpointCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EndpointName
        /// <summary>
        /// <para>
        /// <para>The name of the multi-region endpoint (global-endpoint).</para>
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
        public System.String EndpointName { get; set; }
        #endregion
        
        #region Parameter Details_RoutesDetail
        /// <summary>
        /// <para>
        /// <para>A list of route configuration details. Must contain exactly one route configuration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Details_RoutesDetails")]
        public Amazon.SimpleEmailV2.Model.RouteDetails[] Details_RoutesDetail { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of objects that define the tags (keys and values) to associate with the multi-region
        /// endpoint (global-endpoint).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SimpleEmailV2.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.CreateMultiRegionEndpointResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmailV2.Model.CreateMultiRegionEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SES2MultiRegionEndpoint (CreateMultiRegionEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.CreateMultiRegionEndpointResponse, NewSES2MultiRegionEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Details_RoutesDetail != null)
            {
                context.Details_RoutesDetail = new List<Amazon.SimpleEmailV2.Model.RouteDetails>(this.Details_RoutesDetail);
            }
            #if MODULAR
            if (this.Details_RoutesDetail == null && ParameterWasBound(nameof(this.Details_RoutesDetail)))
            {
                WriteWarning("You are passing $null as a value for parameter Details_RoutesDetail which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointName = this.EndpointName;
            #if MODULAR
            if (this.EndpointName == null && ParameterWasBound(nameof(this.EndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SimpleEmailV2.Model.Tag>(this.Tag);
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
            // create request
            var request = new Amazon.SimpleEmailV2.Model.CreateMultiRegionEndpointRequest();
            
            
             // populate Details
            var requestDetailsIsNull = true;
            request.Details = new Amazon.SimpleEmailV2.Model.Details();
            List<Amazon.SimpleEmailV2.Model.RouteDetails> requestDetails_details_RoutesDetail = null;
            if (cmdletContext.Details_RoutesDetail != null)
            {
                requestDetails_details_RoutesDetail = cmdletContext.Details_RoutesDetail;
            }
            if (requestDetails_details_RoutesDetail != null)
            {
                request.Details.RoutesDetails = requestDetails_details_RoutesDetail;
                requestDetailsIsNull = false;
            }
             // determine if request.Details should be set to null
            if (requestDetailsIsNull)
            {
                request.Details = null;
            }
            if (cmdletContext.EndpointName != null)
            {
                request.EndpointName = cmdletContext.EndpointName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SimpleEmailV2.Model.CreateMultiRegionEndpointResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.CreateMultiRegionEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "CreateMultiRegionEndpoint");
            try
            {
                return client.CreateMultiRegionEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SimpleEmailV2.Model.RouteDetails> Details_RoutesDetail { get; set; }
            public System.String EndpointName { get; set; }
            public List<Amazon.SimpleEmailV2.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.CreateMultiRegionEndpointResponse, NewSES2MultiRegionEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
