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
using Amazon.Odb;
using Amazon.Odb.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ODB
{
    /// <summary>
    /// Configures or updates the Exascale storage on an Exadata infrastructure. After you
    /// configure Exascale storage, you can create Exascale storage vaults on the infrastructure
    /// and VM clusters that use Exascale storage.
    /// </summary>
    [Cmdlet("Update", "ODBExascaleCloudExadataInfrastructure", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Odb.Model.UpdateExascaleCloudExadataInfrastructureResponse")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services UpdateExascaleCloudExadataInfrastructure API operation.", Operation = new[] {"UpdateExascaleCloudExadataInfrastructure"}, SelectReturnType = typeof(Amazon.Odb.Model.UpdateExascaleCloudExadataInfrastructureResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.UpdateExascaleCloudExadataInfrastructureResponse",
        "This cmdlet returns an Amazon.Odb.Model.UpdateExascaleCloudExadataInfrastructureResponse object containing multiple properties."
    )]
    public partial class UpdateODBExascaleCloudExadataInfrastructureCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CloudExadataInfrastructureId
        /// <summary>
        /// <para>
        /// <para>The unique identifier or Amazon Resource Name (ARN) of the Exadata infrastructure
        /// to update.</para>
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
        public System.String CloudExadataInfrastructureId { get; set; }
        #endregion
        
        #region Parameter TotalStorageSizeInGBs
        /// <summary>
        /// <para>
        /// <para>The total amount of Exascale storage, in gigabytes (GB), to configure on the Exadata
        /// infrastructure.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TotalStorageSizeInGBs { get; set; }
        #endregion
        
        #region Parameter TotalVmStorageSizeInGBs
        /// <summary>
        /// <para>
        /// <para>The total amount of Exascale storage, in gigabytes (GB), to allocate for VM storage
        /// on the Exadata infrastructure. VM clusters that store their VM file systems or VM
        /// backups in Exascale storage use this capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TotalVmStorageSizeInGBs { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.UpdateExascaleCloudExadataInfrastructureResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.UpdateExascaleCloudExadataInfrastructureResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CloudExadataInfrastructureId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ODBExascaleCloudExadataInfrastructure (UpdateExascaleCloudExadataInfrastructure)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.UpdateExascaleCloudExadataInfrastructureResponse, UpdateODBExascaleCloudExadataInfrastructureCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CloudExadataInfrastructureId = this.CloudExadataInfrastructureId;
            #if MODULAR
            if (this.CloudExadataInfrastructureId == null && ParameterWasBound(nameof(this.CloudExadataInfrastructureId)))
            {
                WriteWarning("You are passing $null as a value for parameter CloudExadataInfrastructureId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TotalStorageSizeInGBs = this.TotalStorageSizeInGBs;
            #if MODULAR
            if (this.TotalStorageSizeInGBs == null && ParameterWasBound(nameof(this.TotalStorageSizeInGBs)))
            {
                WriteWarning("You are passing $null as a value for parameter TotalStorageSizeInGBs which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TotalVmStorageSizeInGBs = this.TotalVmStorageSizeInGBs;
            
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
            var request = new Amazon.Odb.Model.UpdateExascaleCloudExadataInfrastructureRequest();
            
            if (cmdletContext.CloudExadataInfrastructureId != null)
            {
                request.CloudExadataInfrastructureId = cmdletContext.CloudExadataInfrastructureId;
            }
            if (cmdletContext.TotalStorageSizeInGBs != null)
            {
                request.TotalStorageSizeInGBs = cmdletContext.TotalStorageSizeInGBs.Value;
            }
            if (cmdletContext.TotalVmStorageSizeInGBs != null)
            {
                request.TotalVmStorageSizeInGBs = cmdletContext.TotalVmStorageSizeInGBs.Value;
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
        
        private Amazon.Odb.Model.UpdateExascaleCloudExadataInfrastructureResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.UpdateExascaleCloudExadataInfrastructureRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "UpdateExascaleCloudExadataInfrastructure");
            try
            {
                return client.UpdateExascaleCloudExadataInfrastructureAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CloudExadataInfrastructureId { get; set; }
            public System.Int32? TotalStorageSizeInGBs { get; set; }
            public System.Int32? TotalVmStorageSizeInGBs { get; set; }
            public System.Func<Amazon.Odb.Model.UpdateExascaleCloudExadataInfrastructureResponse, UpdateODBExascaleCloudExadataInfrastructureCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
