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
using Amazon.BackupGateway;
using Amazon.BackupGateway.Model;

namespace Amazon.PowerShell.Cmdlets.BUGW
{
    /// <summary>
    /// This action sets the property mappings for the specified hypervisor. A hypervisor
    /// property mapping displays the relationship of entity properties available from the
    /// on-premises hypervisor to the properties available in Amazon Web Services.
    /// </summary>
    [Cmdlet("Write", "BUGWHypervisorPropertyMapping", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Backup Gateway PutHypervisorPropertyMappings API operation.", Operation = new[] {"PutHypervisorPropertyMappings"}, SelectReturnType = typeof(Amazon.BackupGateway.Model.PutHypervisorPropertyMappingsResponse))]
    [AWSCmdletOutput("System.String or Amazon.BackupGateway.Model.PutHypervisorPropertyMappingsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BackupGateway.Model.PutHypervisorPropertyMappingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteBUGWHypervisorPropertyMappingCmdlet : AmazonBackupGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HypervisorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the hypervisor.</para>
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
        public System.String HypervisorArn { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role.</para>
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
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter VmwareToAwsTagMapping
        /// <summary>
        /// <para>
        /// <para>This action requests the mappings of on-premises VMware tags to the Amazon Web Services
        /// tags.</para>
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
        [Alias("VmwareToAwsTagMappings")]
        public Amazon.BackupGateway.Model.VmwareToAwsTagMapping[] VmwareToAwsTagMapping { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HypervisorArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BackupGateway.Model.PutHypervisorPropertyMappingsResponse).
        /// Specifying the name of a property of type Amazon.BackupGateway.Model.PutHypervisorPropertyMappingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HypervisorArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HypervisorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-BUGWHypervisorPropertyMapping (PutHypervisorPropertyMappings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BackupGateway.Model.PutHypervisorPropertyMappingsResponse, WriteBUGWHypervisorPropertyMappingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HypervisorArn = this.HypervisorArn;
            #if MODULAR
            if (this.HypervisorArn == null && ParameterWasBound(nameof(this.HypervisorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter HypervisorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IamRoleArn = this.IamRoleArn;
            #if MODULAR
            if (this.IamRoleArn == null && ParameterWasBound(nameof(this.IamRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IamRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VmwareToAwsTagMapping != null)
            {
                context.VmwareToAwsTagMapping = new List<Amazon.BackupGateway.Model.VmwareToAwsTagMapping>(this.VmwareToAwsTagMapping);
            }
            #if MODULAR
            if (this.VmwareToAwsTagMapping == null && ParameterWasBound(nameof(this.VmwareToAwsTagMapping)))
            {
                WriteWarning("You are passing $null as a value for parameter VmwareToAwsTagMapping which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BackupGateway.Model.PutHypervisorPropertyMappingsRequest();
            
            if (cmdletContext.HypervisorArn != null)
            {
                request.HypervisorArn = cmdletContext.HypervisorArn;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.VmwareToAwsTagMapping != null)
            {
                request.VmwareToAwsTagMappings = cmdletContext.VmwareToAwsTagMapping;
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
        
        private Amazon.BackupGateway.Model.PutHypervisorPropertyMappingsResponse CallAWSServiceOperation(IAmazonBackupGateway client, Amazon.BackupGateway.Model.PutHypervisorPropertyMappingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup Gateway", "PutHypervisorPropertyMappings");
            try
            {
                #if DESKTOP
                return client.PutHypervisorPropertyMappings(request);
                #elif CORECLR
                return client.PutHypervisorPropertyMappingsAsync(request).GetAwaiter().GetResult();
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
            public System.String HypervisorArn { get; set; }
            public System.String IamRoleArn { get; set; }
            public List<Amazon.BackupGateway.Model.VmwareToAwsTagMapping> VmwareToAwsTagMapping { get; set; }
            public System.Func<Amazon.BackupGateway.Model.PutHypervisorPropertyMappingsResponse, WriteBUGWHypervisorPropertyMappingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HypervisorArn;
        }
        
    }
}
