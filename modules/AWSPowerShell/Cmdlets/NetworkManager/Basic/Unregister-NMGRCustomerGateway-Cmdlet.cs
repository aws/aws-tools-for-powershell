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
using Amazon.NetworkManager;
using Amazon.NetworkManager.Model;

namespace Amazon.PowerShell.Cmdlets.NMGR
{
    /// <summary>
    /// Disassociates a customer gateway from a device and a link.
    /// </summary>
    [Cmdlet("Unregister", "NMGRCustomerGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkManager.Model.CustomerGatewayAssociation")]
    [AWSCmdlet("Calls the AWS Network Manager DisassociateCustomerGateway API operation.", Operation = new[] {"DisassociateCustomerGateway"}, SelectReturnType = typeof(Amazon.NetworkManager.Model.DisassociateCustomerGatewayResponse))]
    [AWSCmdletOutput("Amazon.NetworkManager.Model.CustomerGatewayAssociation or Amazon.NetworkManager.Model.DisassociateCustomerGatewayResponse",
        "This cmdlet returns an Amazon.NetworkManager.Model.CustomerGatewayAssociation object.",
        "The service call response (type Amazon.NetworkManager.Model.DisassociateCustomerGatewayResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UnregisterNMGRCustomerGatewayCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        #region Parameter CustomerGatewayArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the customer gateway. For more information, see
        /// <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/list_amazonec2.html#amazonec2-resources-for-iam-policies">Resources
        /// Defined by Amazon EC2</a>.</para>
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
        public System.String CustomerGatewayArn { get; set; }
        #endregion
        
        #region Parameter GlobalNetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the global network.</para>
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
        public System.String GlobalNetworkId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CustomerGatewayAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkManager.Model.DisassociateCustomerGatewayResponse).
        /// Specifying the name of a property of type Amazon.NetworkManager.Model.DisassociateCustomerGatewayResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CustomerGatewayAssociation";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CustomerGatewayArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CustomerGatewayArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CustomerGatewayArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CustomerGatewayArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-NMGRCustomerGateway (DisassociateCustomerGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.DisassociateCustomerGatewayResponse, UnregisterNMGRCustomerGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CustomerGatewayArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CustomerGatewayArn = this.CustomerGatewayArn;
            #if MODULAR
            if (this.CustomerGatewayArn == null && ParameterWasBound(nameof(this.CustomerGatewayArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomerGatewayArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GlobalNetworkId = this.GlobalNetworkId;
            #if MODULAR
            if (this.GlobalNetworkId == null && ParameterWasBound(nameof(this.GlobalNetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalNetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkManager.Model.DisassociateCustomerGatewayRequest();
            
            if (cmdletContext.CustomerGatewayArn != null)
            {
                request.CustomerGatewayArn = cmdletContext.CustomerGatewayArn;
            }
            if (cmdletContext.GlobalNetworkId != null)
            {
                request.GlobalNetworkId = cmdletContext.GlobalNetworkId;
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
        
        private Amazon.NetworkManager.Model.DisassociateCustomerGatewayResponse CallAWSServiceOperation(IAmazonNetworkManager client, Amazon.NetworkManager.Model.DisassociateCustomerGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Manager", "DisassociateCustomerGateway");
            try
            {
                #if DESKTOP
                return client.DisassociateCustomerGateway(request);
                #elif CORECLR
                return client.DisassociateCustomerGatewayAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomerGatewayArn { get; set; }
            public System.String GlobalNetworkId { get; set; }
            public System.Func<Amazon.NetworkManager.Model.DisassociateCustomerGatewayResponse, UnregisterNMGRCustomerGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CustomerGatewayAssociation;
        }
        
    }
}
