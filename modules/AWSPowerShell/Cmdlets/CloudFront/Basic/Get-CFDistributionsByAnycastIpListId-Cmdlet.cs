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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Lists the distributions in your account that are associated with the specified <c>AnycastIpListId</c>.
    /// </summary>
    [Cmdlet("Get", "CFDistributionsByAnycastIpListId")]
    [OutputType("Amazon.CloudFront.Model.DistributionList")]
    [AWSCmdlet("Calls the Amazon CloudFront ListDistributionsByAnycastIpListId API operation.", Operation = new[] {"ListDistributionsByAnycastIpListId"}, SelectReturnType = typeof(Amazon.CloudFront.Model.ListDistributionsByAnycastIpListIdResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.DistributionList or Amazon.CloudFront.Model.ListDistributionsByAnycastIpListIdResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.DistributionList object.",
        "The service call response (type Amazon.CloudFront.Model.ListDistributionsByAnycastIpListIdResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFDistributionsByAnycastIpListIdCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AnycastIpListId
        /// <summary>
        /// <para>
        /// <para>The ID of the Anycast static IP list.</para>
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
        public System.String AnycastIpListId { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use this field when paginating results to indicate where to begin in your list. The
        /// response includes items in the list that occur after the marker. To get the next page
        /// of the list, set this field's value to the value of <c>NextMarker</c> from the current
        /// page's response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of distributions that you want returned in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DistributionList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.ListDistributionsByAnycastIpListIdResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.ListDistributionsByAnycastIpListIdResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DistributionList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AnycastIpListId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AnycastIpListId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AnycastIpListId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.ListDistributionsByAnycastIpListIdResponse, GetCFDistributionsByAnycastIpListIdCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AnycastIpListId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AnycastIpListId = this.AnycastIpListId;
            #if MODULAR
            if (this.AnycastIpListId == null && ParameterWasBound(nameof(this.AnycastIpListId)))
            {
                WriteWarning("You are passing $null as a value for parameter AnycastIpListId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.CloudFront.Model.ListDistributionsByAnycastIpListIdRequest();
            
            if (cmdletContext.AnycastIpListId != null)
            {
                request.AnycastIpListId = cmdletContext.AnycastIpListId;
            }
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
        
        private Amazon.CloudFront.Model.ListDistributionsByAnycastIpListIdResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.ListDistributionsByAnycastIpListIdRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "ListDistributionsByAnycastIpListId");
            try
            {
                #if DESKTOP
                return client.ListDistributionsByAnycastIpListId(request);
                #elif CORECLR
                return client.ListDistributionsByAnycastIpListIdAsync(request).GetAwaiter().GetResult();
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
            public System.String AnycastIpListId { get; set; }
            public System.String Marker { get; set; }
            public System.String MaxItem { get; set; }
            public System.Func<Amazon.CloudFront.Model.ListDistributionsByAnycastIpListIdResponse, GetCFDistributionsByAnycastIpListIdCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DistributionList;
        }
        
    }
}
