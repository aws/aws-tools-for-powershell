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
    /// Modify the auto-placement setting of a Dedicated Host. When auto-placement is enabled,
    /// any instances that you launch with a tenancy of <c>host</c> but without a specific
    /// host ID are placed onto any available Dedicated Host in your account that has auto-placement
    /// enabled. When auto-placement is disabled, you need to provide a host ID to have the
    /// instance launch onto a specific host. If no host ID is provided, the instance is launched
    /// onto a suitable host with auto-placement enabled.
    /// 
    ///  
    /// <para>
    /// You can also use this API action to modify a Dedicated Host to support either multiple
    /// instance types in an instance family, or to support a specific instance type only.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2Host", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ModifyHostsResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyHosts API operation.", Operation = new[] {"ModifyHosts"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyHostsResponse), LegacyAlias="Edit-EC2Hosts")]
    [AWSCmdletOutput("Amazon.EC2.Model.ModifyHostsResponse",
        "This cmdlet returns an Amazon.EC2.Model.ModifyHostsResponse object containing multiple properties."
    )]
    public partial class EditEC2HostCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoPlacement
        /// <summary>
        /// <para>
        /// <para>Specify whether to enable or disable auto-placement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.AutoPlacement")]
        public Amazon.EC2.AutoPlacement AutoPlacement { get; set; }
        #endregion
        
        #region Parameter HostId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Dedicated Hosts to modify.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("HostIds")]
        public System.String[] HostId { get; set; }
        #endregion
        
        #region Parameter HostMaintenance
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable or disable host maintenance for the Dedicated Host. For
        /// more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/dedicated-hosts-maintenance.html">Host
        /// maintenance</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.HostMaintenance")]
        public Amazon.EC2.HostMaintenance HostMaintenance { get; set; }
        #endregion
        
        #region Parameter HostRecovery
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable or disable host recovery for the Dedicated Host. For more
        /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/dedicated-hosts-recovery.html">Host
        /// recovery</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.HostRecovery")]
        public Amazon.EC2.HostRecovery HostRecovery { get; set; }
        #endregion
        
        #region Parameter InstanceFamily
        /// <summary>
        /// <para>
        /// <para>Specifies the instance family to be supported by the Dedicated Host. Specify this
        /// parameter to modify a Dedicated Host to support multiple instance types within its
        /// current instance family.</para><para>If you want to modify a Dedicated Host to support a specific instance type only, omit
        /// this parameter and specify <b>InstanceType</b> instead. You cannot specify <b>InstanceFamily</b>
        /// and <b>InstanceType</b> in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceFamily { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>Specifies the instance type to be supported by the Dedicated Host. Specify this parameter
        /// to modify a Dedicated Host to support only a specific instance type.</para><para>If you want to modify a Dedicated Host to support multiple instance types in its current
        /// instance family, omit this parameter and specify <b>InstanceFamily</b> instead. You
        /// cannot specify <b>InstanceType</b> and <b>InstanceFamily</b> in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyHostsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyHostsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HostId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2Host (ModifyHosts)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyHostsResponse, EditEC2HostCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoPlacement = this.AutoPlacement;
            if (this.HostId != null)
            {
                context.HostId = new List<System.String>(this.HostId);
            }
            #if MODULAR
            if (this.HostId == null && ParameterWasBound(nameof(this.HostId)))
            {
                WriteWarning("You are passing $null as a value for parameter HostId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HostMaintenance = this.HostMaintenance;
            context.HostRecovery = this.HostRecovery;
            context.InstanceFamily = this.InstanceFamily;
            context.InstanceType = this.InstanceType;
            
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
            var request = new Amazon.EC2.Model.ModifyHostsRequest();
            
            if (cmdletContext.AutoPlacement != null)
            {
                request.AutoPlacement = cmdletContext.AutoPlacement;
            }
            if (cmdletContext.HostId != null)
            {
                request.HostIds = cmdletContext.HostId;
            }
            if (cmdletContext.HostMaintenance != null)
            {
                request.HostMaintenance = cmdletContext.HostMaintenance;
            }
            if (cmdletContext.HostRecovery != null)
            {
                request.HostRecovery = cmdletContext.HostRecovery;
            }
            if (cmdletContext.InstanceFamily != null)
            {
                request.InstanceFamily = cmdletContext.InstanceFamily;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
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
        
        private Amazon.EC2.Model.ModifyHostsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyHostsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyHosts");
            try
            {
                #if DESKTOP
                return client.ModifyHosts(request);
                #elif CORECLR
                return client.ModifyHostsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EC2.AutoPlacement AutoPlacement { get; set; }
            public List<System.String> HostId { get; set; }
            public Amazon.EC2.HostMaintenance HostMaintenance { get; set; }
            public Amazon.EC2.HostRecovery HostRecovery { get; set; }
            public System.String InstanceFamily { get; set; }
            public System.String InstanceType { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyHostsResponse, EditEC2HostCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
