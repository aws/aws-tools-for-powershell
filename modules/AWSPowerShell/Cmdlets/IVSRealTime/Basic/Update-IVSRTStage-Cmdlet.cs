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
using Amazon.IVSRealTime;
using Amazon.IVSRealTime.Model;

namespace Amazon.PowerShell.Cmdlets.IVSRT
{
    /// <summary>
    /// Updates a stage’s configuration.
    /// </summary>
    [Cmdlet("Update", "IVSRTStage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IVSRealTime.Model.Stage")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service RealTime UpdateStage API operation.", Operation = new[] {"UpdateStage"}, SelectReturnType = typeof(Amazon.IVSRealTime.Model.UpdateStageResponse))]
    [AWSCmdletOutput("Amazon.IVSRealTime.Model.Stage or Amazon.IVSRealTime.Model.UpdateStageResponse",
        "This cmdlet returns an Amazon.IVSRealTime.Model.Stage object.",
        "The service call response (type Amazon.IVSRealTime.Model.UpdateStageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateIVSRTStageCmdlet : AmazonIVSRealTimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>ARN of the stage to be updated.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter AutoParticipantRecordingConfiguration_MediaType
        /// <summary>
        /// <para>
        /// <para>Types of media to be recorded. Default: <c>AUDIO_VIDEO</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoParticipantRecordingConfiguration_MediaTypes")]
        public System.String[] AutoParticipantRecordingConfiguration_MediaType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of the stage to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter AutoParticipantRecordingConfiguration_StorageConfigurationArn
        /// <summary>
        /// <para>
        /// <para>ARN of the <a>StorageConfiguration</a> resource to use for individual participant
        /// recording. Default: <c>""</c> (empty string, no storage configuration is specified).
        /// Individual participant recording cannot be started unless a storage configuration
        /// is specified, when a <a>Stage</a> is created or updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AutoParticipantRecordingConfiguration_StorageConfigurationArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Stage'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVSRealTime.Model.UpdateStageResponse).
        /// Specifying the name of a property of type Amazon.IVSRealTime.Model.UpdateStageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Stage";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Arn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IVSRTStage (UpdateStage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVSRealTime.Model.UpdateStageResponse, UpdateIVSRTStageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Arn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AutoParticipantRecordingConfiguration_MediaType != null)
            {
                context.AutoParticipantRecordingConfiguration_MediaType = new List<System.String>(this.AutoParticipantRecordingConfiguration_MediaType);
            }
            context.AutoParticipantRecordingConfiguration_StorageConfigurationArn = this.AutoParticipantRecordingConfiguration_StorageConfigurationArn;
            context.Name = this.Name;
            
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
            var request = new Amazon.IVSRealTime.Model.UpdateStageRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            
             // populate AutoParticipantRecordingConfiguration
            var requestAutoParticipantRecordingConfigurationIsNull = true;
            request.AutoParticipantRecordingConfiguration = new Amazon.IVSRealTime.Model.AutoParticipantRecordingConfiguration();
            List<System.String> requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_MediaType = null;
            if (cmdletContext.AutoParticipantRecordingConfiguration_MediaType != null)
            {
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_MediaType = cmdletContext.AutoParticipantRecordingConfiguration_MediaType;
            }
            if (requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_MediaType != null)
            {
                request.AutoParticipantRecordingConfiguration.MediaTypes = requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_MediaType;
                requestAutoParticipantRecordingConfigurationIsNull = false;
            }
            System.String requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_StorageConfigurationArn = null;
            if (cmdletContext.AutoParticipantRecordingConfiguration_StorageConfigurationArn != null)
            {
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_StorageConfigurationArn = cmdletContext.AutoParticipantRecordingConfiguration_StorageConfigurationArn;
            }
            if (requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_StorageConfigurationArn != null)
            {
                request.AutoParticipantRecordingConfiguration.StorageConfigurationArn = requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_StorageConfigurationArn;
                requestAutoParticipantRecordingConfigurationIsNull = false;
            }
             // determine if request.AutoParticipantRecordingConfiguration should be set to null
            if (requestAutoParticipantRecordingConfigurationIsNull)
            {
                request.AutoParticipantRecordingConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.IVSRealTime.Model.UpdateStageResponse CallAWSServiceOperation(IAmazonIVSRealTime client, Amazon.IVSRealTime.Model.UpdateStageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service RealTime", "UpdateStage");
            try
            {
                #if DESKTOP
                return client.UpdateStage(request);
                #elif CORECLR
                return client.UpdateStageAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public List<System.String> AutoParticipantRecordingConfiguration_MediaType { get; set; }
            public System.String AutoParticipantRecordingConfiguration_StorageConfigurationArn { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.IVSRealTime.Model.UpdateStageResponse, UpdateIVSRTStageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Stage;
        }
        
    }
}
