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
using Amazon.S3Control;
using Amazon.S3Control.Model;

namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// <note><para>
    /// This operation is not supported by directory buckets.
    /// </para></note><para>
    /// Associates an access control policy with the specified Multi-Region Access Point.
    /// Each Multi-Region Access Point can have only one policy, so a request made to this
    /// action replaces any existing policy that is associated with the specified Multi-Region
    /// Access Point.
    /// </para><para>
    /// This action will always be routed to the US West (Oregon) Region. For more information
    /// about the restrictions around working with Multi-Region Access Points, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/MultiRegionAccessPointRestrictions.html">Multi-Region
    /// Access Point restrictions and limitations</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><para>
    /// The following actions are related to <c>PutMultiRegionAccessPointPolicy</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_GetMultiRegionAccessPointPolicy.html">GetMultiRegionAccessPointPolicy</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_GetMultiRegionAccessPointPolicyStatus.html">GetMultiRegionAccessPointPolicyStatus</a></para></li></ul>
    /// </summary>
    [Cmdlet("Write", "S3CMultiRegionAccessPointPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon S3 Control PutMultiRegionAccessPointPolicy API operation.", Operation = new[] {"PutMultiRegionAccessPointPolicy"}, SelectReturnType = typeof(Amazon.S3Control.Model.PutMultiRegionAccessPointPolicyResponse))]
    [AWSCmdletOutput("System.String or Amazon.S3Control.Model.PutMultiRegionAccessPointPolicyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.S3Control.Model.PutMultiRegionAccessPointPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteS3CMultiRegionAccessPointPolicyCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID for the owner of the Multi-Region Access Point.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter Details_Name
        /// <summary>
        /// <para>
        /// <para>The name of the Multi-Region Access Point associated with the request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Details_Name { get; set; }
        #endregion
        
        #region Parameter Details_Policy
        /// <summary>
        /// <para>
        /// <para>The policy details for the <c>PutMultiRegionAccessPoint</c> request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Details_Policy { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An idempotency token used to identify the request and guarantee that requests are
        /// unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RequestTokenARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.PutMultiRegionAccessPointPolicyResponse).
        /// Specifying the name of a property of type Amazon.S3Control.Model.PutMultiRegionAccessPointPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RequestTokenARN";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "s3v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3CMultiRegionAccessPointPolicy (PutMultiRegionAccessPointPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.PutMultiRegionAccessPointPolicyResponse, WriteS3CMultiRegionAccessPointPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Details_Name = this.Details_Name;
            #if MODULAR
            if (this.Details_Name == null && ParameterWasBound(nameof(this.Details_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Details_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Details_Policy = this.Details_Policy;
            #if MODULAR
            if (this.Details_Policy == null && ParameterWasBound(nameof(this.Details_Policy)))
            {
                WriteWarning("You are passing $null as a value for parameter Details_Policy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.S3Control.Model.PutMultiRegionAccessPointPolicyRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Details
            var requestDetailsIsNull = true;
            request.Details = new Amazon.S3Control.Model.PutMultiRegionAccessPointPolicyInput();
            System.String requestDetails_details_Name = null;
            if (cmdletContext.Details_Name != null)
            {
                requestDetails_details_Name = cmdletContext.Details_Name;
            }
            if (requestDetails_details_Name != null)
            {
                request.Details.Name = requestDetails_details_Name;
                requestDetailsIsNull = false;
            }
            System.String requestDetails_details_Policy = null;
            if (cmdletContext.Details_Policy != null)
            {
                requestDetails_details_Policy = cmdletContext.Details_Policy;
            }
            if (requestDetails_details_Policy != null)
            {
                request.Details.Policy = requestDetails_details_Policy;
                requestDetailsIsNull = false;
            }
             // determine if request.Details should be set to null
            if (requestDetailsIsNull)
            {
                request.Details = null;
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
        
        private Amazon.S3Control.Model.PutMultiRegionAccessPointPolicyResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.PutMultiRegionAccessPointPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "PutMultiRegionAccessPointPolicy");
            try
            {
                #if DESKTOP
                return client.PutMultiRegionAccessPointPolicy(request);
                #elif CORECLR
                return client.PutMultiRegionAccessPointPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Details_Name { get; set; }
            public System.String Details_Policy { get; set; }
            public System.Func<Amazon.S3Control.Model.PutMultiRegionAccessPointPolicyResponse, WriteS3CMultiRegionAccessPointPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RequestTokenARN;
        }
        
    }
}
