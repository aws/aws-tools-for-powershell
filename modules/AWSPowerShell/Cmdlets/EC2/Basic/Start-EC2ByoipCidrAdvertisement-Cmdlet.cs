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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Advertises an IPv4 or IPv6 address range that is provisioned for use with your Amazon
    /// Web Services resources through bring your own IP addresses (BYOIP).
    /// 
    ///  
    /// <para>
    /// You can perform this operation at most once every 10 seconds, even if you specify
    /// different address ranges each time.
    /// </para><para>
    /// We recommend that you stop advertising the BYOIP CIDR from other locations when you
    /// advertise it from Amazon Web Services. To minimize down time, you can configure your
    /// Amazon Web Services resources to use an address from a BYOIP CIDR before it is advertised,
    /// and then simultaneously stop advertising it from the current location and start advertising
    /// it through Amazon Web Services.
    /// </para><para>
    /// It can take a few minutes before traffic to the specified addresses starts routing
    /// to Amazon Web Services because of BGP propagation delays.
    /// </para><para>
    /// To stop advertising the BYOIP CIDR, use <a>WithdrawByoipCidr</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "EC2ByoipCidrAdvertisement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ByoipCidr")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AdvertiseByoipCidr API operation.", Operation = new[] {"AdvertiseByoipCidr"}, SelectReturnType = typeof(Amazon.EC2.Model.AdvertiseByoipCidrResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ByoipCidr or Amazon.EC2.Model.AdvertiseByoipCidrResponse",
        "This cmdlet returns an Amazon.EC2.Model.ByoipCidr object.",
        "The service call response (type Amazon.EC2.Model.AdvertiseByoipCidrResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartEC2ByoipCidrAdvertisementCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Asn
        /// <summary>
        /// <para>
        /// <para>The public 2-byte or 4-byte ASN that you want to advertise.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Asn { get; set; }
        #endregion
        
        #region Parameter Cidr
        /// <summary>
        /// <para>
        /// <para>The address range, in CIDR notation. This must be the exact range that you provisioned.
        /// You can't advertise only a portion of the provisioned range.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ByoipCidr'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AdvertiseByoipCidrResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AdvertiseByoipCidrResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ByoipCidr";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EC2ByoipCidrAdvertisement (AdvertiseByoipCidr)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AdvertiseByoipCidrResponse, StartEC2ByoipCidrAdvertisementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Asn = this.Asn;
            context.Cidr = this.Cidr;
            #if MODULAR
            if (this.Cidr == null && ParameterWasBound(nameof(this.Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkBorderGroup = this.NetworkBorderGroup;
            
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
            var request = new Amazon.EC2.Model.AdvertiseByoipCidrRequest();
            
            if (cmdletContext.Asn != null)
            {
                request.Asn = cmdletContext.Asn;
            }
            if (cmdletContext.Cidr != null)
            {
                request.Cidr = cmdletContext.Cidr;
            }
            if (cmdletContext.NetworkBorderGroup != null)
            {
                request.NetworkBorderGroup = cmdletContext.NetworkBorderGroup;
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
        
        private Amazon.EC2.Model.AdvertiseByoipCidrResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AdvertiseByoipCidrRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AdvertiseByoipCidr");
            try
            {
                #if DESKTOP
                return client.AdvertiseByoipCidr(request);
                #elif CORECLR
                return client.AdvertiseByoipCidrAsync(request).GetAwaiter().GetResult();
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
            public System.String Asn { get; set; }
            public System.String Cidr { get; set; }
            public System.String NetworkBorderGroup { get; set; }
            public System.Func<Amazon.EC2.Model.AdvertiseByoipCidrResponse, StartEC2ByoipCidrAdvertisementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ByoipCidr;
        }
        
    }
}
