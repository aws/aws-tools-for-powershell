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
    /// Create a custom routing accelerator. A custom routing accelerator directs traffic
    /// to one of possibly thousands of Amazon EC2 instance destinations running in a single
    /// or multiple virtual private clouds (VPC) subnet endpoints.
    /// 
    ///  
    /// <para>
    /// Be aware that, by default, all destination EC2 instances in a VPC subnet endpoint
    /// cannot receive traffic. To enable all destinations to receive traffic, or to specify
    /// individual port mappings that can receive traffic, see the <a href="https://docs.aws.amazon.com/global-accelerator/latest/api/API_AllowCustomRoutingTraffic.html">
    /// AllowCustomRoutingTraffic</a> operation.
    /// </para><important><para>
    /// Global Accelerator is a global service that supports endpoints in multiple Amazon
    /// Web Services Regions but you must specify the US West (Oregon) Region to create, update,
    /// or otherwise work with accelerators. That is, for example, specify <c>--region us-west-2</c>
    /// on Amazon Web Services CLI commands.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "GACLCustomRoutingAccelerator", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GlobalAccelerator.Model.CustomRoutingAccelerator")]
    [AWSCmdlet("Calls the AWS Global Accelerator CreateCustomRoutingAccelerator API operation.", Operation = new[] {"CreateCustomRoutingAccelerator"}, SelectReturnType = typeof(Amazon.GlobalAccelerator.Model.CreateCustomRoutingAcceleratorResponse))]
    [AWSCmdletOutput("Amazon.GlobalAccelerator.Model.CustomRoutingAccelerator or Amazon.GlobalAccelerator.Model.CreateCustomRoutingAcceleratorResponse",
        "This cmdlet returns an Amazon.GlobalAccelerator.Model.CustomRoutingAccelerator object.",
        "The service call response (type Amazon.GlobalAccelerator.Model.CreateCustomRoutingAcceleratorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGACLCustomRoutingAcceleratorCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether an accelerator is enabled. The value is true or false. The default
        /// value is true. </para><para>If the value is set to true, an accelerator cannot be deleted. If set to false, the
        /// accelerator can be deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
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
        
        #region Parameter IpAddress
        /// <summary>
        /// <para>
        /// <para>Optionally, if you've added your own IP address pool to Global Accelerator (BYOIP),
        /// you can choose an IPv4 address from your own pool to use for the accelerator's static
        /// IPv4 address when you create an accelerator. </para><para>After you bring an address range to Amazon Web Services, it appears in your account
        /// as an address pool. When you create an accelerator, you can assign one IPv4 address
        /// from your range to it. Global Accelerator assigns you a second static IPv4 address
        /// from an Amazon IP address range. If you bring two IPv4 address ranges to Amazon Web
        /// Services, you can assign one IPv4 address from each range to your accelerator. This
        /// restriction is because Global Accelerator assigns each address range to a different
        /// network zone, for high availability.</para><para>You can specify one or two addresses, separated by a space. Do not include the /32
        /// suffix.</para><para>Note that you can't update IP addresses for an existing accelerator. To change them,
        /// you must create a new accelerator with the new addresses.</para><para>For more information, see <a href="https://docs.aws.amazon.com/global-accelerator/latest/dg/using-byoip.html">Bring
        /// your own IP addresses (BYOIP)</a> in the <i>Global Accelerator Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IpAddresses")]
        public System.String[] IpAddress { get; set; }
        #endregion
        
        #region Parameter IpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address type that an accelerator supports. For a custom routing accelerator,
        /// the value must be IPV4.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GlobalAccelerator.IpAddressType")]
        public Amazon.GlobalAccelerator.IpAddressType IpAddressType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of a custom routing accelerator. The name can have a maximum of 64 characters,
        /// must contain only alphanumeric characters or hyphens (-), and must not begin or end
        /// with a hyphen.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Create tags for an accelerator.</para><para>For more information, see <a href="https://docs.aws.amazon.com/global-accelerator/latest/dg/tagging-in-global-accelerator.html">Tagging
        /// in Global Accelerator</a> in the <i>Global Accelerator Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.GlobalAccelerator.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Accelerator'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlobalAccelerator.Model.CreateCustomRoutingAcceleratorResponse).
        /// Specifying the name of a property of type Amazon.GlobalAccelerator.Model.CreateCustomRoutingAcceleratorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Accelerator";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GACLCustomRoutingAccelerator (CreateCustomRoutingAccelerator)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlobalAccelerator.Model.CreateCustomRoutingAcceleratorResponse, NewGACLCustomRoutingAcceleratorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Enabled = this.Enabled;
            context.IdempotencyToken = this.IdempotencyToken;
            if (this.IpAddress != null)
            {
                context.IpAddress = new List<System.String>(this.IpAddress);
            }
            context.IpAddressType = this.IpAddressType;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.GlobalAccelerator.Model.Tag>(this.Tag);
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
            var request = new Amazon.GlobalAccelerator.Model.CreateCustomRoutingAcceleratorRequest();
            
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.IpAddress != null)
            {
                request.IpAddresses = cmdletContext.IpAddress;
            }
            if (cmdletContext.IpAddressType != null)
            {
                request.IpAddressType = cmdletContext.IpAddressType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.GlobalAccelerator.Model.CreateCustomRoutingAcceleratorResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.CreateCustomRoutingAcceleratorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "CreateCustomRoutingAccelerator");
            try
            {
                #if DESKTOP
                return client.CreateCustomRoutingAccelerator(request);
                #elif CORECLR
                return client.CreateCustomRoutingAcceleratorAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Enabled { get; set; }
            public System.String IdempotencyToken { get; set; }
            public List<System.String> IpAddress { get; set; }
            public Amazon.GlobalAccelerator.IpAddressType IpAddressType { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.GlobalAccelerator.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.GlobalAccelerator.Model.CreateCustomRoutingAcceleratorResponse, NewGACLCustomRoutingAcceleratorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Accelerator;
        }
        
    }
}
