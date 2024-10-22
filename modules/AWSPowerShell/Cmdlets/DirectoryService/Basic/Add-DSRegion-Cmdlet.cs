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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Adds two domain controllers in the specified Region for the specified directory.
    /// </summary>
    [Cmdlet("Add", "DSRegion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Directory Service AddRegion API operation.", Operation = new[] {"AddRegion"}, SelectReturnType = typeof(Amazon.DirectoryService.Model.AddRegionResponse))]
    [AWSCmdletOutput("None or Amazon.DirectoryService.Model.AddRegionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DirectoryService.Model.AddRegionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddDSRegionCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the directory to which you want to add Region replication.</para>
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
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter RegionName
        /// <summary>
        /// <para>
        /// <para>The name of the Region where you want to add domain controllers for replication. For
        /// example, <c>us-east-1</c>.</para>
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
        public System.String RegionName { get; set; }
        #endregion
        
        #region Parameter VPCSettings_SubnetId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the subnets for the directory servers. The two subnets must be
        /// in different Availability Zones. Directory Service creates a directory server and
        /// a DNS server in each of these subnets.</para>
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
        [Alias("VPCSettings_SubnetIds")]
        public System.String[] VPCSettings_SubnetId { get; set; }
        #endregion
        
        #region Parameter VPCSettings_VpcId
        /// <summary>
        /// <para>
        /// <para>The identifier of the VPC in which to create the directory.</para>
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
        public System.String VPCSettings_VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectoryService.Model.AddRegionResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DirectoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-DSRegion (AddRegion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectoryService.Model.AddRegionResponse, AddDSRegionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DirectoryId = this.DirectoryId;
            #if MODULAR
            if (this.DirectoryId == null && ParameterWasBound(nameof(this.DirectoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RegionName = this.RegionName;
            #if MODULAR
            if (this.RegionName == null && ParameterWasBound(nameof(this.RegionName)))
            {
                WriteWarning("You are passing $null as a value for parameter RegionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VPCSettings_SubnetId != null)
            {
                context.VPCSettings_SubnetId = new List<System.String>(this.VPCSettings_SubnetId);
            }
            #if MODULAR
            if (this.VPCSettings_SubnetId == null && ParameterWasBound(nameof(this.VPCSettings_SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter VPCSettings_SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VPCSettings_VpcId = this.VPCSettings_VpcId;
            #if MODULAR
            if (this.VPCSettings_VpcId == null && ParameterWasBound(nameof(this.VPCSettings_VpcId)))
            {
                WriteWarning("You are passing $null as a value for parameter VPCSettings_VpcId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectoryService.Model.AddRegionRequest();
            
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.RegionName != null)
            {
                request.RegionName = cmdletContext.RegionName;
            }
            
             // populate VPCSettings
            var requestVPCSettingsIsNull = true;
            request.VPCSettings = new Amazon.DirectoryService.Model.DirectoryVpcSettings();
            List<System.String> requestVPCSettings_vPCSettings_SubnetId = null;
            if (cmdletContext.VPCSettings_SubnetId != null)
            {
                requestVPCSettings_vPCSettings_SubnetId = cmdletContext.VPCSettings_SubnetId;
            }
            if (requestVPCSettings_vPCSettings_SubnetId != null)
            {
                request.VPCSettings.SubnetIds = requestVPCSettings_vPCSettings_SubnetId;
                requestVPCSettingsIsNull = false;
            }
            System.String requestVPCSettings_vPCSettings_VpcId = null;
            if (cmdletContext.VPCSettings_VpcId != null)
            {
                requestVPCSettings_vPCSettings_VpcId = cmdletContext.VPCSettings_VpcId;
            }
            if (requestVPCSettings_vPCSettings_VpcId != null)
            {
                request.VPCSettings.VpcId = requestVPCSettings_vPCSettings_VpcId;
                requestVPCSettingsIsNull = false;
            }
             // determine if request.VPCSettings should be set to null
            if (requestVPCSettingsIsNull)
            {
                request.VPCSettings = null;
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
        
        private Amazon.DirectoryService.Model.AddRegionResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.AddRegionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "AddRegion");
            try
            {
                #if DESKTOP
                return client.AddRegion(request);
                #elif CORECLR
                return client.AddRegionAsync(request).GetAwaiter().GetResult();
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
            public System.String DirectoryId { get; set; }
            public System.String RegionName { get; set; }
            public List<System.String> VPCSettings_SubnetId { get; set; }
            public System.String VPCSettings_VpcId { get; set; }
            public System.Func<Amazon.DirectoryService.Model.AddRegionResponse, AddDSRegionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
