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
    /// Provisions an IPv4 or IPv6 address range for use with your Amazon Web Services resources
    /// through bring your own IP addresses (BYOIP) and creates a corresponding address pool.
    /// After the address range is provisioned, it is ready to be advertised using <a>AdvertiseByoipCidr</a>.
    /// 
    ///  
    /// <para>
    /// Amazon Web Services verifies that you own the address range and are authorized to
    /// advertise it. You must ensure that the address range is registered to you and that
    /// you created an RPKI ROA to authorize Amazon ASNs 16509 and 14618 to advertise the
    /// address range. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-byoip.html">Bring
    /// your own IP addresses (BYOIP)</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para><para>
    /// Provisioning an address range is an asynchronous operation, so the call returns immediately,
    /// but the address range is not ready to use until its status changes from <code>pending-provision</code>
    /// to <code>provisioned</code>. To monitor the status of an address range, use <a>DescribeByoipCidrs</a>.
    /// To allocate an Elastic IP address from your IPv4 address pool, use <a>AllocateAddress</a>
    /// with either the specific address from the address pool or the ID of the address pool.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "EC2ByoipCidr", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ByoipCidr")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ProvisionByoipCidr API operation.", Operation = new[] {"ProvisionByoipCidr"}, SelectReturnType = typeof(Amazon.EC2.Model.ProvisionByoipCidrResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ByoipCidr or Amazon.EC2.Model.ProvisionByoipCidrResponse",
        "This cmdlet returns an Amazon.EC2.Model.ByoipCidr object.",
        "The service call response (type Amazon.EC2.Model.ProvisionByoipCidrResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterEC2ByoipCidrCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Cidr
        /// <summary>
        /// <para>
        /// <para>The public IPv4 or IPv6 address range, in CIDR notation. The most specific IPv4 prefix
        /// that you can specify is /24. The most specific IPv6 prefix you can specify is /56.
        /// The address range cannot overlap with another address range that you've brought to
        /// this or another Region.</para>
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
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the address range and the address pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
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
        
        #region Parameter MultiRegion
        /// <summary>
        /// <para>
        /// <para>Reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiRegion { get; set; }
        #endregion
        
        #region Parameter NetworkBorderGroup
        /// <summary>
        /// <para>
        /// <para>If you have <a href="https://docs.aws.amazon.com/local-zones/latest/ug/how-local-zones-work.html">Local
        /// Zones</a> enabled, you can choose a network border group for Local Zones when you
        /// provision and advertise a BYOIPv4 CIDR. Choose the network border group carefully
        /// as the EIP and the Amazon Web Services resource it is associated with must reside
        /// in the same network border group.</para><para>You can provision BYOIP address ranges to and advertise them in the following Local
        /// Zone network border groups:</para><ul><li><para>us-east-1-dfw-2</para></li><li><para>us-west-2-lax-1</para></li><li><para>us-west-2-phx-2</para></li></ul><note><para>You cannot provision or advertise BYOIPv6 address ranges in Local Zones at this time.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkBorderGroup { get; set; }
        #endregion
        
        #region Parameter PoolTagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the address pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PoolTagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] PoolTagSpecification { get; set; }
        #endregion
        
        #region Parameter PubliclyAdvertisable
        /// <summary>
        /// <para>
        /// <para>(IPv6 only) Indicate whether the address range will be publicly advertised to the
        /// internet.</para><para>Default: true</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAdvertisable { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ByoipCidr'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ProvisionByoipCidrResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ProvisionByoipCidrResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Cidr), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2ByoipCidr (ProvisionByoipCidr)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ProvisionByoipCidrResponse, RegisterEC2ByoipCidrCmdlet>(Select) ??
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
            context.CidrAuthorizationContext_Signature = this.CidrAuthorizationContext_Signature;
            context.Description = this.Description;
            context.MultiRegion = this.MultiRegion;
            context.NetworkBorderGroup = this.NetworkBorderGroup;
            if (this.PoolTagSpecification != null)
            {
                context.PoolTagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.PoolTagSpecification);
            }
            context.PubliclyAdvertisable = this.PubliclyAdvertisable;
            
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
            var request = new Amazon.EC2.Model.ProvisionByoipCidrRequest();
            
            if (cmdletContext.Cidr != null)
            {
                request.Cidr = cmdletContext.Cidr;
            }
            
             // populate CidrAuthorizationContext
            var requestCidrAuthorizationContextIsNull = true;
            request.CidrAuthorizationContext = new Amazon.EC2.Model.CidrAuthorizationContext();
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
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.MultiRegion != null)
            {
                request.MultiRegion = cmdletContext.MultiRegion.Value;
            }
            if (cmdletContext.NetworkBorderGroup != null)
            {
                request.NetworkBorderGroup = cmdletContext.NetworkBorderGroup;
            }
            if (cmdletContext.PoolTagSpecification != null)
            {
                request.PoolTagSpecifications = cmdletContext.PoolTagSpecification;
            }
            if (cmdletContext.PubliclyAdvertisable != null)
            {
                request.PubliclyAdvertisable = cmdletContext.PubliclyAdvertisable.Value;
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
        
        private Amazon.EC2.Model.ProvisionByoipCidrResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ProvisionByoipCidrRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ProvisionByoipCidr");
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
            public System.String Description { get; set; }
            public System.Boolean? MultiRegion { get; set; }
            public System.String NetworkBorderGroup { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> PoolTagSpecification { get; set; }
            public System.Boolean? PubliclyAdvertisable { get; set; }
            public System.Func<Amazon.EC2.Model.ProvisionByoipCidrResponse, RegisterEC2ByoipCidrCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ByoipCidr;
        }
        
    }
}
