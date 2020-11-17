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
using Amazon.GlobalAccelerator;
using Amazon.GlobalAccelerator.Model;

namespace Amazon.PowerShell.Cmdlets.GACL
{
    /// <summary>
    /// Provisions an IP address range to use with your AWS resources through bring your own
    /// IP addresses (BYOIP) and creates a corresponding address pool. After the address range
    /// is provisioned, it is ready to be advertised using <a href="https://docs.aws.amazon.com/global-accelerator/latest/api/AdvertiseByoipCidr.html">
    /// AdvertiseByoipCidr</a>.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/global-accelerator/latest/dg/using-byoip.html">Bring
    /// Your Own IP Addresses (BYOIP)</a> in the <i>AWS Global Accelerator Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "GACLByoipCidrProvision", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GlobalAccelerator.Model.ByoipCidr")]
    [AWSCmdlet("Calls the AWS Global Accelerator ProvisionByoipCidr API operation.", Operation = new[] {"ProvisionByoipCidr"}, SelectReturnType = typeof(Amazon.GlobalAccelerator.Model.ProvisionByoipCidrResponse))]
    [AWSCmdletOutput("Amazon.GlobalAccelerator.Model.ByoipCidr or Amazon.GlobalAccelerator.Model.ProvisionByoipCidrResponse",
        "This cmdlet returns an Amazon.GlobalAccelerator.Model.ByoipCidr object.",
        "The service call response (type Amazon.GlobalAccelerator.Model.ProvisionByoipCidrResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddGACLByoipCidrProvisionCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        #region Parameter Cidr
        /// <summary>
        /// <para>
        /// <para>The public IPv4 address range, in CIDR notation. The most specific IP prefix that
        /// you can specify is /24. The address range cannot overlap with another address range
        /// that you've brought to this or another Region.</para>
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
        public System.String Cidr { get; set; }
        #endregion
        
        #region Parameter CidrAuthorizationContext_Message
        /// <summary>
        /// <para>
        /// <para>The plain-text authorization message for the prefix and account.</para>
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
        public System.String CidrAuthorizationContext_Message { get; set; }
        #endregion
        
        #region Parameter CidrAuthorizationContext_Signature
        /// <summary>
        /// <para>
        /// <para>The signed authorization message for the prefix and account.</para>
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
        public System.String CidrAuthorizationContext_Signature { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ByoipCidr'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlobalAccelerator.Model.ProvisionByoipCidrResponse).
        /// Specifying the name of a property of type Amazon.GlobalAccelerator.Model.ProvisionByoipCidrResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ByoipCidr";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Cidr parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Cidr' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Cidr' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Cidr), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-GACLByoipCidrProvision (ProvisionByoipCidr)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlobalAccelerator.Model.ProvisionByoipCidrResponse, AddGACLByoipCidrProvisionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Cidr;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Cidr = this.Cidr;
            #if MODULAR
            if (this.Cidr == null && ParameterWasBound(nameof(this.Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CidrAuthorizationContext_Message = this.CidrAuthorizationContext_Message;
            #if MODULAR
            if (this.CidrAuthorizationContext_Message == null && ParameterWasBound(nameof(this.CidrAuthorizationContext_Message)))
            {
                WriteWarning("You are passing $null as a value for parameter CidrAuthorizationContext_Message which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CidrAuthorizationContext_Signature = this.CidrAuthorizationContext_Signature;
            #if MODULAR
            if (this.CidrAuthorizationContext_Signature == null && ParameterWasBound(nameof(this.CidrAuthorizationContext_Signature)))
            {
                WriteWarning("You are passing $null as a value for parameter CidrAuthorizationContext_Signature which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GlobalAccelerator.Model.ProvisionByoipCidrRequest();
            
            if (cmdletContext.Cidr != null)
            {
                request.Cidr = cmdletContext.Cidr;
            }
            
             // populate CidrAuthorizationContext
            var requestCidrAuthorizationContextIsNull = true;
            request.CidrAuthorizationContext = new Amazon.GlobalAccelerator.Model.CidrAuthorizationContext();
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
        
        private Amazon.GlobalAccelerator.Model.ProvisionByoipCidrResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.ProvisionByoipCidrRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "ProvisionByoipCidr");
            try
            {
                #if DESKTOP
                return client.ProvisionByoipCidr(request);
                #elif CORECLR
                return client.ProvisionByoipCidrAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.GlobalAccelerator.Model.ProvisionByoipCidrResponse, AddGACLByoipCidrProvisionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ByoipCidr;
        }
        
    }
}
