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
    /// Modify the configurations of an IPAM pool.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/mod-pool-ipam.html">Modify
    /// a pool</a> in the <i>Amazon VPC IPAM User Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2IpamPool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.IpamPool")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyIpamPool API operation.", Operation = new[] {"ModifyIpamPool"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyIpamPoolResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IpamPool or Amazon.EC2.Model.ModifyIpamPoolResponse",
        "This cmdlet returns an Amazon.EC2.Model.IpamPool object.",
        "The service call response (type Amazon.EC2.Model.ModifyIpamPoolResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2IpamPoolCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AddAllocationResourceTag
        /// <summary>
        /// <para>
        /// <para>Add tag allocation rules to a pool. For more information about allocation rules, see
        /// <a href="https://docs.aws.amazon.com/vpc/latest/ipam/create-top-ipam.html">Create
        /// a top-level pool</a> in the <i>Amazon VPC IPAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddAllocationResourceTags")]
        public Amazon.EC2.Model.RequestIpamResourceTag[] AddAllocationResourceTag { get; set; }
        #endregion
        
        #region Parameter AllocationDefaultNetmaskLength
        /// <summary>
        /// <para>
        /// <para>The default netmask length for allocations added to this pool. If, for example, the
        /// CIDR assigned to this pool is 10.0.0.0/8 and you enter 16 here, new allocations will
        /// default to 10.0.0.0/16.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AllocationDefaultNetmaskLength { get; set; }
        #endregion
        
        #region Parameter AllocationMaxNetmaskLength
        /// <summary>
        /// <para>
        /// <para>The maximum netmask length possible for CIDR allocations in this IPAM pool to be compliant.
        /// Possible netmask lengths for IPv4 addresses are 0 - 32. Possible netmask lengths for
        /// IPv6 addresses are 0 - 128.The maximum netmask length must be greater than the minimum
        /// netmask length.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AllocationMaxNetmaskLength { get; set; }
        #endregion
        
        #region Parameter AllocationMinNetmaskLength
        /// <summary>
        /// <para>
        /// <para>The minimum netmask length required for CIDR allocations in this IPAM pool to be compliant.
        /// Possible netmask lengths for IPv4 addresses are 0 - 32. Possible netmask lengths for
        /// IPv6 addresses are 0 - 128. The minimum netmask length must be less than the maximum
        /// netmask length.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AllocationMinNetmaskLength { get; set; }
        #endregion
        
        #region Parameter AutoImport
        /// <summary>
        /// <para>
        /// <para>If true, IPAM will continuously look for resources within the CIDR range of this pool
        /// and automatically import them as allocations into your IPAM. The CIDRs that will be
        /// allocated for these resources must not already be allocated to other resources in
        /// order for the import to succeed. IPAM will import a CIDR regardless of its compliance
        /// with the pool's allocation rules, so a resource might be imported and subsequently
        /// marked as noncompliant. If IPAM discovers multiple CIDRs that overlap, IPAM will import
        /// the largest CIDR only. If IPAM discovers multiple CIDRs with matching CIDRs, IPAM
        /// will randomly import one of them only. </para><para>A locale must be set on the pool for this feature to work.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoImport { get; set; }
        #endregion
        
        #region Parameter ClearAllocationDefaultNetmaskLength
        /// <summary>
        /// <para>
        /// <para>Clear the default netmask length allocation rule for this pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ClearAllocationDefaultNetmaskLength { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the IPAM pool you want to modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IpamPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the IPAM pool you want to modify.</para>
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
        
        #region Parameter RemoveAllocationResourceTag
        /// <summary>
        /// <para>
        /// <para>Remove tag allocation rules from a pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveAllocationResourceTags")]
        public Amazon.EC2.Model.RequestIpamResourceTag[] RemoveAllocationResourceTag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IpamPool'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyIpamPoolResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyIpamPoolResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IpamPool";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IpamPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2IpamPool (ModifyIpamPool)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyIpamPoolResponse, EditEC2IpamPoolCmdlet>(Select) ??
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
            if (this.AddAllocationResourceTag != null)
            {
                context.AddAllocationResourceTag = new List<Amazon.EC2.Model.RequestIpamResourceTag>(this.AddAllocationResourceTag);
            }
            context.AllocationDefaultNetmaskLength = this.AllocationDefaultNetmaskLength;
            context.AllocationMaxNetmaskLength = this.AllocationMaxNetmaskLength;
            context.AllocationMinNetmaskLength = this.AllocationMinNetmaskLength;
            context.AutoImport = this.AutoImport;
            context.ClearAllocationDefaultNetmaskLength = this.ClearAllocationDefaultNetmaskLength;
            context.Description = this.Description;
            context.IpamPoolId = this.IpamPoolId;
            #if MODULAR
            if (this.IpamPoolId == null && ParameterWasBound(nameof(this.IpamPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RemoveAllocationResourceTag != null)
            {
                context.RemoveAllocationResourceTag = new List<Amazon.EC2.Model.RequestIpamResourceTag>(this.RemoveAllocationResourceTag);
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
            var request = new Amazon.EC2.Model.ModifyIpamPoolRequest();
            
            if (cmdletContext.AddAllocationResourceTag != null)
            {
                request.AddAllocationResourceTags = cmdletContext.AddAllocationResourceTag;
            }
            if (cmdletContext.AllocationDefaultNetmaskLength != null)
            {
                request.AllocationDefaultNetmaskLength = cmdletContext.AllocationDefaultNetmaskLength.Value;
            }
            if (cmdletContext.AllocationMaxNetmaskLength != null)
            {
                request.AllocationMaxNetmaskLength = cmdletContext.AllocationMaxNetmaskLength.Value;
            }
            if (cmdletContext.AllocationMinNetmaskLength != null)
            {
                request.AllocationMinNetmaskLength = cmdletContext.AllocationMinNetmaskLength.Value;
            }
            if (cmdletContext.AutoImport != null)
            {
                request.AutoImport = cmdletContext.AutoImport.Value;
            }
            if (cmdletContext.ClearAllocationDefaultNetmaskLength != null)
            {
                request.ClearAllocationDefaultNetmaskLength = cmdletContext.ClearAllocationDefaultNetmaskLength.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IpamPoolId != null)
            {
                request.IpamPoolId = cmdletContext.IpamPoolId;
            }
            if (cmdletContext.RemoveAllocationResourceTag != null)
            {
                request.RemoveAllocationResourceTags = cmdletContext.RemoveAllocationResourceTag;
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
        
        private Amazon.EC2.Model.ModifyIpamPoolResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyIpamPoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyIpamPool");
            try
            {
                #if DESKTOP
                return client.ModifyIpamPool(request);
                #elif CORECLR
                return client.ModifyIpamPoolAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.RequestIpamResourceTag> AddAllocationResourceTag { get; set; }
            public System.Int32? AllocationDefaultNetmaskLength { get; set; }
            public System.Int32? AllocationMaxNetmaskLength { get; set; }
            public System.Int32? AllocationMinNetmaskLength { get; set; }
            public System.Boolean? AutoImport { get; set; }
            public System.Boolean? ClearAllocationDefaultNetmaskLength { get; set; }
            public System.String Description { get; set; }
            public System.String IpamPoolId { get; set; }
            public List<Amazon.EC2.Model.RequestIpamResourceTag> RemoveAllocationResourceTag { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyIpamPoolResponse, EditEC2IpamPoolCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamPool;
        }
        
    }
}
