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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Provision a CIDR to an IPAM pool. You can use thsi action to provision new CIDRs to
    /// a top-level pool or to transfer a CIDR from a top-level pool to a pool within it.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="/vpc/latest/ipam/prov-cidr-ipam.html">Provision
    /// CIDRs to pools</a> in the <i>Amazon VPC IPAM User Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Register", "EC2IpamPoolCidr", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.IpamPoolCidr")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ProvisionIpamPoolCidr API operation.", Operation = new[] {"ProvisionIpamPoolCidr"}, SelectReturnType = typeof(Amazon.EC2.Model.ProvisionIpamPoolCidrResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IpamPoolCidr or Amazon.EC2.Model.ProvisionIpamPoolCidrResponse",
        "This cmdlet returns an Amazon.EC2.Model.IpamPoolCidr object.",
        "The service call response (type Amazon.EC2.Model.ProvisionIpamPoolCidrResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterEC2IpamPoolCidrCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Cidr
        /// <summary>
        /// <para>
        /// <para>The CIDR you want to assign to the IPAM pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Cidr { get; set; }
        #endregion
        
        #region Parameter IpamPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the IPAM pool to which you want to assign a CIDR.</para>
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
        public System.String IpamPoolId { get; set; }
        #endregion
        
        #region Parameter CidrAuthorizationContext_Message
        /// <summary>
        /// <para>
        /// <para>The plain-text authorization message for the prefix and account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CidrAuthorizationContext_Message { get; set; }
        #endregion
        
        #region Parameter CidrAuthorizationContext_Signature
        /// <summary>
        /// <para>
        /// <para>The signed authorization message for the prefix and account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CidrAuthorizationContext_Signature { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IpamPoolCidr'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ProvisionIpamPoolCidrResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ProvisionIpamPoolCidrResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IpamPoolCidr";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IpamPoolId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IpamPoolId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IpamPoolId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IpamPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2IpamPoolCidr (ProvisionIpamPoolCidr)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ProvisionIpamPoolCidrResponse, RegisterEC2IpamPoolCidrCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IpamPoolId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Cidr = this.Cidr;
            context.CidrAuthorizationContext_Message = this.CidrAuthorizationContext_Message;
            context.CidrAuthorizationContext_Signature = this.CidrAuthorizationContext_Signature;
            context.IpamPoolId = this.IpamPoolId;
            #if MODULAR
            if (this.IpamPoolId == null && ParameterWasBound(nameof(this.IpamPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ProvisionIpamPoolCidrRequest();
            
            if (cmdletContext.Cidr != null)
            {
                request.Cidr = cmdletContext.Cidr;
            }
            
             // populate CidrAuthorizationContext
            var requestCidrAuthorizationContextIsNull = true;
            request.CidrAuthorizationContext = new Amazon.EC2.Model.IpamCidrAuthorizationContext();
            System.String requestCidrAuthorizationContext_cidrAuthorizationContext_Message = null;
            if (cmdletContext.CidrAuthorizationContext_Message != null)
            {
                requestCidrAuthorizationContext_cidrAuthorizationContext_Message = cmdletContext.CidrAuthorizationContext_Message;
            }
            if (requestCidrAuthorizationContext_cidrAuthorizationContext_Message != null)
            {
                request.CidrAuthorizationContext.Message = requestCidrAuthorizationContext_cidrAuthorizationContext_Message;
                requestCidrAuthorizationContextIsNull = false;
            }
            System.String requestCidrAuthorizationContext_cidrAuthorizationContext_Signature = null;
            if (cmdletContext.CidrAuthorizationContext_Signature != null)
            {
                requestCidrAuthorizationContext_cidrAuthorizationContext_Signature = cmdletContext.CidrAuthorizationContext_Signature;
            }
            if (requestCidrAuthorizationContext_cidrAuthorizationContext_Signature != null)
            {
                request.CidrAuthorizationContext.Signature = requestCidrAuthorizationContext_cidrAuthorizationContext_Signature;
                requestCidrAuthorizationContextIsNull = false;
            }
             // determine if request.CidrAuthorizationContext should be set to null
            if (requestCidrAuthorizationContextIsNull)
            {
                request.CidrAuthorizationContext = null;
            }
            if (cmdletContext.IpamPoolId != null)
            {
                request.IpamPoolId = cmdletContext.IpamPoolId;
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
        
        private Amazon.EC2.Model.ProvisionIpamPoolCidrResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ProvisionIpamPoolCidrRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ProvisionIpamPoolCidr");
            try
            {
                #if DESKTOP
                return client.ProvisionIpamPoolCidr(request);
                #elif CORECLR
                return client.ProvisionIpamPoolCidrAsync(request).GetAwaiter().GetResult();
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
            public System.String Cidr { get; set; }
            public System.String CidrAuthorizationContext_Message { get; set; }
            public System.String CidrAuthorizationContext_Signature { get; set; }
            public System.String IpamPoolId { get; set; }
            public System.Func<Amazon.EC2.Model.ProvisionIpamPoolCidrResponse, RegisterEC2IpamPoolCidrCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamPoolCidr;
        }
        
    }
}
