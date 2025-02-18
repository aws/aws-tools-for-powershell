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
using System.Threading;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modify the configurations of an IPAM.
    /// </summary>
    [Cmdlet("Edit", "EC2Ipam", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Ipam")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyIpam API operation.", Operation = new[] {"ModifyIpam"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyIpamResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Ipam or Amazon.EC2.Model.ModifyIpamResponse",
        "This cmdlet returns an Amazon.EC2.Model.Ipam object.",
        "The service call response (type Amazon.EC2.Model.ModifyIpamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2IpamCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AddOperatingRegion
        /// <summary>
        /// <para>
        /// <para>Choose the operating Regions for the IPAM. Operating Regions are Amazon Web Services
        /// Regions where the IPAM is allowed to manage IP address CIDRs. IPAM only discovers
        /// and monitors resources in the Amazon Web Services Regions you select as operating
        /// Regions.</para><para>For more information about operating Regions, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/create-ipam.html">Create
        /// an IPAM</a> in the <i>Amazon VPC IPAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddOperatingRegions")]
        public Amazon.EC2.Model.AddIpamOperatingRegion[] AddOperatingRegion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the IPAM you want to modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnablePrivateGua
        /// <summary>
        /// <para>
        /// <para>Enable this option to use your own GUA ranges as private IPv6 addresses. This option
        /// is disabled by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnablePrivateGua { get; set; }
        #endregion
        
        #region Parameter IpamId
        /// <summary>
        /// <para>
        /// <para>The ID of the IPAM you want to modify.</para>
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
        public System.String IpamId { get; set; }
        #endregion
        
        #region Parameter RemoveOperatingRegion
        /// <summary>
        /// <para>
        /// <para>The operating Regions to remove.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveOperatingRegions")]
        public Amazon.EC2.Model.RemoveIpamOperatingRegion[] RemoveOperatingRegion { get; set; }
        #endregion
        
        #region Parameter Tier
        /// <summary>
        /// <para>
        /// <para>IPAM is offered in a Free Tier and an Advanced Tier. For more information about the
        /// features available in each tier and the costs associated with the tiers, see <a href="http://aws.amazon.com/vpc/pricing/">Amazon
        /// VPC pricing &gt; IPAM tab</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.IpamTier")]
        public Amazon.EC2.IpamTier Tier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Ipam'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyIpamResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyIpamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Ipam";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IpamId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2Ipam (ModifyIpam)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyIpamResponse, EditEC2IpamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AddOperatingRegion != null)
            {
                context.AddOperatingRegion = new List<Amazon.EC2.Model.AddIpamOperatingRegion>(this.AddOperatingRegion);
            }
            context.Description = this.Description;
            context.EnablePrivateGua = this.EnablePrivateGua;
            context.IpamId = this.IpamId;
            #if MODULAR
            if (this.IpamId == null && ParameterWasBound(nameof(this.IpamId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RemoveOperatingRegion != null)
            {
                context.RemoveOperatingRegion = new List<Amazon.EC2.Model.RemoveIpamOperatingRegion>(this.RemoveOperatingRegion);
            }
            context.Tier = this.Tier;
            
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
            var request = new Amazon.EC2.Model.ModifyIpamRequest();
            
            if (cmdletContext.AddOperatingRegion != null)
            {
                request.AddOperatingRegions = cmdletContext.AddOperatingRegion;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnablePrivateGua != null)
            {
                request.EnablePrivateGua = cmdletContext.EnablePrivateGua.Value;
            }
            if (cmdletContext.IpamId != null)
            {
                request.IpamId = cmdletContext.IpamId;
            }
            if (cmdletContext.RemoveOperatingRegion != null)
            {
                request.RemoveOperatingRegions = cmdletContext.RemoveOperatingRegion;
            }
            if (cmdletContext.Tier != null)
            {
                request.Tier = cmdletContext.Tier;
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
        
        private Amazon.EC2.Model.ModifyIpamResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyIpamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyIpam");
            try
            {
                return client.ModifyIpamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.AddIpamOperatingRegion> AddOperatingRegion { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? EnablePrivateGua { get; set; }
            public System.String IpamId { get; set; }
            public List<Amazon.EC2.Model.RemoveIpamOperatingRegion> RemoveOperatingRegion { get; set; }
            public Amazon.EC2.IpamTier Tier { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyIpamResponse, EditEC2IpamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Ipam;
        }
        
    }
}
