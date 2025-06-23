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
using Amazon.FSx;
using Amazon.FSx.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Deletes an Amazon FSx for NetApp ONTAP or Amazon FSx for OpenZFS volume.
    /// </summary>
    [Cmdlet("Remove", "FSXVolume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.FSx.Model.DeleteVolumeResponse")]
    [AWSCmdlet("Calls the Amazon FSx DeleteVolume API operation.", Operation = new[] {"DeleteVolume"}, SelectReturnType = typeof(Amazon.FSx.Model.DeleteVolumeResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.DeleteVolumeResponse",
        "This cmdlet returns an Amazon.FSx.Model.DeleteVolumeResponse object containing multiple properties."
    )]
    public partial class RemoveFSXVolumeCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OntapConfiguration_BypassSnaplockEnterpriseRetention
        /// <summary>
        /// <para>
        /// <para>Setting this to <c>true</c> allows a SnapLock administrator to delete an FSx for ONTAP
        /// SnapLock Enterprise volume with unexpired write once, read many (WORM) files. The
        /// IAM permission <c>fsx:BypassSnaplockEnterpriseRetention</c> is also required to delete
        /// SnapLock Enterprise volumes with unexpired WORM files. The default value is <c>false</c>.
        /// </para><para>For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/snaplock-delete-volume.html">
        /// Deleting a SnapLock volume</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OntapConfiguration_BypassSnaplockEnterpriseRetention { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_FinalBackupTag
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_FinalBackupTags")]
        public Amazon.FSx.Model.Tag[] OntapConfiguration_FinalBackupTag { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_Option
        /// <summary>
        /// <para>
        /// <para>To delete the volume's child volumes, snapshots, and clones, use the string <c>DELETE_CHILD_VOLUMES_AND_SNAPSHOTS</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_Options")]
        public System.String[] OpenZFSConfiguration_Option { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_SkipFinalBackup
        /// <summary>
        /// <para>
        /// <para>Set to true if you want to skip taking a final backup of the volume you are deleting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OntapConfiguration_SkipFinalBackup { get; set; }
        #endregion
        
        #region Parameter VolumeId
        /// <summary>
        /// <para>
        /// <para>The ID of the volume that you are deleting.</para>
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
        public System.String VolumeId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.DeleteVolumeResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.DeleteVolumeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VolumeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-FSXVolume (DeleteVolume)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.DeleteVolumeResponse, RemoveFSXVolumeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.OntapConfiguration_BypassSnaplockEnterpriseRetention = this.OntapConfiguration_BypassSnaplockEnterpriseRetention;
            if (this.OntapConfiguration_FinalBackupTag != null)
            {
                context.OntapConfiguration_FinalBackupTag = new List<Amazon.FSx.Model.Tag>(this.OntapConfiguration_FinalBackupTag);
            }
            context.OntapConfiguration_SkipFinalBackup = this.OntapConfiguration_SkipFinalBackup;
            if (this.OpenZFSConfiguration_Option != null)
            {
                context.OpenZFSConfiguration_Option = new List<System.String>(this.OpenZFSConfiguration_Option);
            }
            context.VolumeId = this.VolumeId;
            #if MODULAR
            if (this.VolumeId == null && ParameterWasBound(nameof(this.VolumeId)))
            {
                WriteWarning("You are passing $null as a value for parameter VolumeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FSx.Model.DeleteVolumeRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate OntapConfiguration
            var requestOntapConfigurationIsNull = true;
            request.OntapConfiguration = new Amazon.FSx.Model.DeleteVolumeOntapConfiguration();
            System.Boolean? requestOntapConfiguration_ontapConfiguration_BypassSnaplockEnterpriseRetention = null;
            if (cmdletContext.OntapConfiguration_BypassSnaplockEnterpriseRetention != null)
            {
                requestOntapConfiguration_ontapConfiguration_BypassSnaplockEnterpriseRetention = cmdletContext.OntapConfiguration_BypassSnaplockEnterpriseRetention.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_BypassSnaplockEnterpriseRetention != null)
            {
                request.OntapConfiguration.BypassSnaplockEnterpriseRetention = requestOntapConfiguration_ontapConfiguration_BypassSnaplockEnterpriseRetention.Value;
                requestOntapConfigurationIsNull = false;
            }
            List<Amazon.FSx.Model.Tag> requestOntapConfiguration_ontapConfiguration_FinalBackupTag = null;
            if (cmdletContext.OntapConfiguration_FinalBackupTag != null)
            {
                requestOntapConfiguration_ontapConfiguration_FinalBackupTag = cmdletContext.OntapConfiguration_FinalBackupTag;
            }
            if (requestOntapConfiguration_ontapConfiguration_FinalBackupTag != null)
            {
                request.OntapConfiguration.FinalBackupTags = requestOntapConfiguration_ontapConfiguration_FinalBackupTag;
                requestOntapConfigurationIsNull = false;
            }
            System.Boolean? requestOntapConfiguration_ontapConfiguration_SkipFinalBackup = null;
            if (cmdletContext.OntapConfiguration_SkipFinalBackup != null)
            {
                requestOntapConfiguration_ontapConfiguration_SkipFinalBackup = cmdletContext.OntapConfiguration_SkipFinalBackup.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_SkipFinalBackup != null)
            {
                request.OntapConfiguration.SkipFinalBackup = requestOntapConfiguration_ontapConfiguration_SkipFinalBackup.Value;
                requestOntapConfigurationIsNull = false;
            }
             // determine if request.OntapConfiguration should be set to null
            if (requestOntapConfigurationIsNull)
            {
                request.OntapConfiguration = null;
            }
            
             // populate OpenZFSConfiguration
            var requestOpenZFSConfigurationIsNull = true;
            request.OpenZFSConfiguration = new Amazon.FSx.Model.DeleteVolumeOpenZFSConfiguration();
            List<System.String> requestOpenZFSConfiguration_openZFSConfiguration_Option = null;
            if (cmdletContext.OpenZFSConfiguration_Option != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_Option = cmdletContext.OpenZFSConfiguration_Option;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_Option != null)
            {
                request.OpenZFSConfiguration.Options = requestOpenZFSConfiguration_openZFSConfiguration_Option;
                requestOpenZFSConfigurationIsNull = false;
            }
             // determine if request.OpenZFSConfiguration should be set to null
            if (requestOpenZFSConfigurationIsNull)
            {
                request.OpenZFSConfiguration = null;
            }
            if (cmdletContext.VolumeId != null)
            {
                request.VolumeId = cmdletContext.VolumeId;
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
        
        private Amazon.FSx.Model.DeleteVolumeResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.DeleteVolumeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "DeleteVolume");
            try
            {
                return client.DeleteVolumeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.Boolean? OntapConfiguration_BypassSnaplockEnterpriseRetention { get; set; }
            public List<Amazon.FSx.Model.Tag> OntapConfiguration_FinalBackupTag { get; set; }
            public System.Boolean? OntapConfiguration_SkipFinalBackup { get; set; }
            public List<System.String> OpenZFSConfiguration_Option { get; set; }
            public System.String VolumeId { get; set; }
            public System.Func<Amazon.FSx.Model.DeleteVolumeResponse, RemoveFSXVolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
