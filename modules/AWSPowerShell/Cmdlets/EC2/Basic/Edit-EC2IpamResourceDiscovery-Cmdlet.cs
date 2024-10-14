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
    /// Modifies a resource discovery. A resource discovery is an IPAM component that enables
    /// IPAM to manage and monitor resources that belong to the owning account.
    /// </summary>
    [Cmdlet("Edit", "EC2IpamResourceDiscovery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.IpamResourceDiscovery")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyIpamResourceDiscovery API operation.", Operation = new[] {"ModifyIpamResourceDiscovery"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyIpamResourceDiscoveryResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IpamResourceDiscovery or Amazon.EC2.Model.ModifyIpamResourceDiscoveryResponse",
        "This cmdlet returns an Amazon.EC2.Model.IpamResourceDiscovery object.",
        "The service call response (type Amazon.EC2.Model.ModifyIpamResourceDiscoveryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2IpamResourceDiscoveryCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AddOperatingRegion
        /// <summary>
        /// <para>
        /// <para>Add operating Regions to the resource discovery. Operating Regions are Amazon Web
        /// Services Regions where the IPAM is allowed to manage IP address CIDRs. IPAM only discovers
        /// and monitors resources in the Amazon Web Services Regions you select as operating
        /// Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddOperatingRegions")]
        public Amazon.EC2.Model.AddIpamOperatingRegion[] AddOperatingRegion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A resource discovery description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IpamResourceDiscoveryId
        /// <summary>
        /// <para>
        /// <para>A resource discovery ID.</para>
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
        public System.String IpamResourceDiscoveryId { get; set; }
        #endregion
        
        #region Parameter RemoveOperatingRegion
        /// <summary>
        /// <para>
        /// <para>Remove operating Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveOperatingRegions")]
        public Amazon.EC2.Model.RemoveIpamOperatingRegion[] RemoveOperatingRegion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IpamResourceDiscovery'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyIpamResourceDiscoveryResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyIpamResourceDiscoveryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IpamResourceDiscovery";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IpamResourceDiscoveryId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IpamResourceDiscoveryId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IpamResourceDiscoveryId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IpamResourceDiscoveryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2IpamResourceDiscovery (ModifyIpamResourceDiscovery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyIpamResourceDiscoveryResponse, EditEC2IpamResourceDiscoveryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IpamResourceDiscoveryId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AddOperatingRegion != null)
            {
                context.AddOperatingRegion = new List<Amazon.EC2.Model.AddIpamOperatingRegion>(this.AddOperatingRegion);
            }
            context.Description = this.Description;
            context.IpamResourceDiscoveryId = this.IpamResourceDiscoveryId;
            #if MODULAR
            if (this.IpamResourceDiscoveryId == null && ParameterWasBound(nameof(this.IpamResourceDiscoveryId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamResourceDiscoveryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RemoveOperatingRegion != null)
            {
                context.RemoveOperatingRegion = new List<Amazon.EC2.Model.RemoveIpamOperatingRegion>(this.RemoveOperatingRegion);
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
            var request = new Amazon.EC2.Model.ModifyIpamResourceDiscoveryRequest();
            
            if (cmdletContext.AddOperatingRegion != null)
            {
                request.AddOperatingRegions = cmdletContext.AddOperatingRegion;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IpamResourceDiscoveryId != null)
            {
                request.IpamResourceDiscoveryId = cmdletContext.IpamResourceDiscoveryId;
            }
            if (cmdletContext.RemoveOperatingRegion != null)
            {
                request.RemoveOperatingRegions = cmdletContext.RemoveOperatingRegion;
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
        
        private Amazon.EC2.Model.ModifyIpamResourceDiscoveryResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyIpamResourceDiscoveryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyIpamResourceDiscovery");
            try
            {
                #if DESKTOP
                return client.ModifyIpamResourceDiscovery(request);
                #elif CORECLR
                return client.ModifyIpamResourceDiscoveryAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.AddIpamOperatingRegion> AddOperatingRegion { get; set; }
            public System.String Description { get; set; }
            public System.String IpamResourceDiscoveryId { get; set; }
            public List<Amazon.EC2.Model.RemoveIpamOperatingRegion> RemoveOperatingRegion { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyIpamResourceDiscoveryResponse, EditEC2IpamResourceDiscoveryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamResourceDiscovery;
        }
        
    }
}
