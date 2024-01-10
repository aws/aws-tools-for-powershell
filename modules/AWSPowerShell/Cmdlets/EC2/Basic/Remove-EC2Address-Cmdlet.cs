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
    /// Releases the specified Elastic IP address.
    /// 
    ///  
    /// <para>
    /// [Default VPC] Releasing an Elastic IP address automatically disassociates it from
    /// any instance that it's associated with. To disassociate an Elastic IP address without
    /// releasing it, use <a>DisassociateAddress</a>.
    /// </para><para>
    /// [Nondefault VPC] You must use <a>DisassociateAddress</a> to disassociate the Elastic
    /// IP address before you can release it. Otherwise, Amazon EC2 returns an error (<c>InvalidIPAddress.InUse</c>).
    /// </para><para>
    /// After releasing an Elastic IP address, it is released to the IP address pool. Be sure
    /// to update your DNS records and any servers or devices that communicate with the address.
    /// If you attempt to release an Elastic IP address that you already released, you'll
    /// get an <c>AuthFailure</c> error if the address is already allocated to another Amazon
    /// Web Services account.
    /// </para><para>
    /// After you release an Elastic IP address, you might be able to recover it. For more
    /// information, see <a>AllocateAddress</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "EC2Address", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ReleaseAddress API operation.", Operation = new[] {"ReleaseAddress"}, SelectReturnType = typeof(Amazon.EC2.Model.ReleaseAddressResponse))]
    [AWSCmdletOutput("None or Amazon.EC2.Model.ReleaseAddressResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.EC2.Model.ReleaseAddressResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveEC2AddressCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllocationId
        /// <summary>
        /// <para>
        /// <para>The allocation ID. This parameter is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String AllocationId { get; set; }
        #endregion
        
        #region Parameter NetworkBorderGroup
        /// <summary>
        /// <para>
        /// <para>The set of Availability Zones, Local Zones, or Wavelength Zones from which Amazon
        /// Web Services advertises IP addresses.</para><para>If you provide an incorrect network border group, you receive an <c>InvalidAddress.NotFound</c>
        /// error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkBorderGroup { get; set; }
        #endregion
        
        #region Parameter PublicIp
        /// <summary>
        /// <para>
        /// <para>Deprecated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String PublicIp { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ReleaseAddressResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PublicIp parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PublicIp' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PublicIp' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PublicIp), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2Address (ReleaseAddress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ReleaseAddressResponse, RemoveEC2AddressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PublicIp;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllocationId = this.AllocationId;
            context.NetworkBorderGroup = this.NetworkBorderGroup;
            context.PublicIp = this.PublicIp;
            
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
            var request = new Amazon.EC2.Model.ReleaseAddressRequest();
            
            if (cmdletContext.AllocationId != null)
            {
                request.AllocationId = cmdletContext.AllocationId;
            }
            if (cmdletContext.NetworkBorderGroup != null)
            {
                request.NetworkBorderGroup = cmdletContext.NetworkBorderGroup;
            }
            if (cmdletContext.PublicIp != null)
            {
                request.PublicIp = cmdletContext.PublicIp;
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
        
        private Amazon.EC2.Model.ReleaseAddressResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ReleaseAddressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ReleaseAddress");
            try
            {
                #if DESKTOP
                return client.ReleaseAddress(request);
                #elif CORECLR
                return client.ReleaseAddressAsync(request).GetAwaiter().GetResult();
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
            public System.String AllocationId { get; set; }
            public System.String NetworkBorderGroup { get; set; }
            public System.String PublicIp { get; set; }
            public System.Func<Amazon.EC2.Model.ReleaseAddressResponse, RemoveEC2AddressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
