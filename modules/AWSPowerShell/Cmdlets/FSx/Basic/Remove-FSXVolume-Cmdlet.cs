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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Deletes an Amazon FSx for NetApp ONTAP or Amazon FSx for OpenZFS volume.
    /// </summary>
    [Cmdlet("Remove", "FSXVolume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.FSx.Model.DeleteVolumeResponse")]
    [AWSCmdlet("Calls the Amazon FSx DeleteVolume API operation.", Operation = new[] {"DeleteVolume"}, SelectReturnType = typeof(Amazon.FSx.Model.DeleteVolumeResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.DeleteVolumeResponse",
        "This cmdlet returns an Amazon.FSx.Model.DeleteVolumeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveFSXVolumeCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
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
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_FinalBackupTags")]
        public Amazon.FSx.Model.Tag[] OntapConfiguration_FinalBackupTag { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_Option
        /// <summary>
        /// <para>
        /// <para>To delete the volume's child volumes, snapshots, and clones, use the string <code>DELETE_CHILD_VOLUMES_AND_SNAPSHOTS</code>.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VolumeId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VolumeId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VolumeId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VolumeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-FSXVolume (DeleteVolume)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.DeleteVolumeResponse, RemoveFSXVolumeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VolumeId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
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
                #if DESKTOP
                return client.DeleteVolume(request);
                #elif CORECLR
                return client.DeleteVolumeAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public List<Amazon.FSx.Model.Tag> OntapConfiguration_FinalBackupTag { get; set; }
            public System.Boolean? OntapConfiguration_SkipFinalBackup { get; set; }
            public List<System.String> OpenZFSConfiguration_Option { get; set; }
            public System.String VolumeId { get; set; }
            public System.Func<Amazon.FSx.Model.DeleteVolumeResponse, RemoveFSXVolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
