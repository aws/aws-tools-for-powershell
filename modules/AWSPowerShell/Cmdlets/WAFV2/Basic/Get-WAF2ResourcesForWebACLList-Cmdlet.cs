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
using Amazon.WAFV2;
using Amazon.WAFV2.Model;

namespace Amazon.PowerShell.Cmdlets.WAF2
{
    /// <summary>
    /// Retrieves an array of the Amazon Resource Names (ARNs) for the regional resources
    /// that are associated with the specified web ACL. 
    /// 
    ///  
    /// <para>
    /// For Amazon CloudFront, don't use this call. Instead, use the CloudFront call <c>ListDistributionsByWebACLId</c>.
    /// For information, see <a href="https://docs.aws.amazon.com/cloudfront/latest/APIReference/API_ListDistributionsByWebACLId.html">ListDistributionsByWebACLId</a>
    /// in the <i>Amazon CloudFront API Reference</i>. 
    /// </para><para><b>Required permissions for customer-managed IAM policies</b></para><para>
    /// This call requires permissions that are specific to the protected resource type. For
    /// details, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/security_iam_service-with-iam.html#security_iam_action-ListResourcesForWebACL">Permissions
    /// for ListResourcesForWebACL</a> in the <i>WAF Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "WAF2ResourcesForWebACLList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS WAF V2 ListResourcesForWebACL API operation.", Operation = new[] {"ListResourcesForWebACL"}, SelectReturnType = typeof(Amazon.WAFV2.Model.ListResourcesForWebACLResponse))]
    [AWSCmdletOutput("System.String or Amazon.WAFV2.Model.ListResourcesForWebACLResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.WAFV2.Model.ListResourcesForWebACLResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetWAF2ResourcesForWebACLListCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>Used for web ACLs that are scoped for regional applications. A regional application
        /// can be an Application Load Balancer (ALB), an Amazon API Gateway REST API, an AppSync
        /// GraphQL API, an Amazon Cognito user pool, an App Runner service, or an Amazon Web
        /// Services Verified Access instance. </para><note><para>If you don't provide a resource type, the call uses the resource type <c>APPLICATION_LOAD_BALANCER</c>.
        /// </para></note><para>Default: <c>APPLICATION_LOAD_BALANCER</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WAFV2.ResourceType")]
        public Amazon.WAFV2.ResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter WebACLArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the web ACL.</para>
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
        public System.String WebACLArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceArns'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.ListResourcesForWebACLResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.ListResourcesForWebACLResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceArns";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WebACLArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WebACLArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WebACLArn' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.ListResourcesForWebACLResponse, GetWAF2ResourcesForWebACLListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WebACLArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ResourceType = this.ResourceType;
            context.WebACLArn = this.WebACLArn;
            #if MODULAR
            if (this.WebACLArn == null && ParameterWasBound(nameof(this.WebACLArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WebACLArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAFV2.Model.ListResourcesForWebACLRequest();
            
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            if (cmdletContext.WebACLArn != null)
            {
                request.WebACLArn = cmdletContext.WebACLArn;
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
        
        private Amazon.WAFV2.Model.ListResourcesForWebACLResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.ListResourcesForWebACLRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF V2", "ListResourcesForWebACL");
            try
            {
                #if DESKTOP
                return client.ListResourcesForWebACL(request);
                #elif CORECLR
                return client.ListResourcesForWebACLAsync(request).GetAwaiter().GetResult();
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
            public Amazon.WAFV2.ResourceType ResourceType { get; set; }
            public System.String WebACLArn { get; set; }
            public System.Func<Amazon.WAFV2.Model.ListResourcesForWebACLResponse, GetWAF2ResourcesForWebACLListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceArns;
        }
        
    }
}
