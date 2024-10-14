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
    /// Create a listener to process inbound connections from clients to a custom routing
    /// accelerator. Connections arrive to assigned static IP addresses on the port range
    /// that you specify.
    /// </summary>
    [Cmdlet("New", "GACLCustomRoutingListener", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GlobalAccelerator.Model.CustomRoutingListener")]
    [AWSCmdlet("Calls the AWS Global Accelerator CreateCustomRoutingListener API operation.", Operation = new[] {"CreateCustomRoutingListener"}, SelectReturnType = typeof(Amazon.GlobalAccelerator.Model.CreateCustomRoutingListenerResponse))]
    [AWSCmdletOutput("Amazon.GlobalAccelerator.Model.CustomRoutingListener or Amazon.GlobalAccelerator.Model.CreateCustomRoutingListenerResponse",
        "This cmdlet returns an Amazon.GlobalAccelerator.Model.CustomRoutingListener object.",
        "The service call response (type Amazon.GlobalAccelerator.Model.CreateCustomRoutingListenerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGACLCustomRoutingListenerCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceleratorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the accelerator for a custom routing listener.</para>
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
        public System.String AcceleratorArn { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency—that
        /// is, the uniqueness—of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter PortRange
        /// <summary>
        /// <para>
        /// <para>The port range to support for connections from clients to your accelerator.</para><para>Separately, you set port ranges for endpoints. For more information, see <a href="https://docs.aws.amazon.com/global-accelerator/latest/dg/about-custom-routing-endpoints.html">About
        /// endpoints for custom routing accelerators</a>.</para>
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
        [Alias("PortRanges")]
        public Amazon.GlobalAccelerator.Model.PortRange[] PortRange { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Listener'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlobalAccelerator.Model.CreateCustomRoutingListenerResponse).
        /// Specifying the name of a property of type Amazon.GlobalAccelerator.Model.CreateCustomRoutingListenerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Listener";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AcceleratorArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AcceleratorArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AcceleratorArn' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AcceleratorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GACLCustomRoutingListener (CreateCustomRoutingListener)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlobalAccelerator.Model.CreateCustomRoutingListenerResponse, NewGACLCustomRoutingListenerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AcceleratorArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AcceleratorArn = this.AcceleratorArn;
            #if MODULAR
            if (this.AcceleratorArn == null && ParameterWasBound(nameof(this.AcceleratorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AcceleratorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdempotencyToken = this.IdempotencyToken;
            if (this.PortRange != null)
            {
                context.PortRange = new List<Amazon.GlobalAccelerator.Model.PortRange>(this.PortRange);
            }
            #if MODULAR
            if (this.PortRange == null && ParameterWasBound(nameof(this.PortRange)))
            {
                WriteWarning("You are passing $null as a value for parameter PortRange which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GlobalAccelerator.Model.CreateCustomRoutingListenerRequest();
            
            if (cmdletContext.AcceleratorArn != null)
            {
                request.AcceleratorArn = cmdletContext.AcceleratorArn;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.PortRange != null)
            {
                request.PortRanges = cmdletContext.PortRange;
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
        
        private Amazon.GlobalAccelerator.Model.CreateCustomRoutingListenerResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.CreateCustomRoutingListenerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "CreateCustomRoutingListener");
            try
            {
                #if DESKTOP
                return client.CreateCustomRoutingListener(request);
                #elif CORECLR
                return client.CreateCustomRoutingListenerAsync(request).GetAwaiter().GetResult();
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
            public System.String AcceleratorArn { get; set; }
            public System.String IdempotencyToken { get; set; }
            public List<Amazon.GlobalAccelerator.Model.PortRange> PortRange { get; set; }
            public System.Func<Amazon.GlobalAccelerator.Model.CreateCustomRoutingListenerResponse, NewGACLCustomRoutingListenerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Listener;
        }
        
    }
}
