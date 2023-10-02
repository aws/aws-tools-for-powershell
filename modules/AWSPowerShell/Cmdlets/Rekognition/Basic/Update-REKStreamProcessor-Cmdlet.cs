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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Allows you to update a stream processor. You can change some settings and regions
    /// of interest and delete certain parameters.
    /// </summary>
    [Cmdlet("Update", "REKStreamProcessor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Rekognition UpdateStreamProcessor API operation.", Operation = new[] {"UpdateStreamProcessor"}, SelectReturnType = typeof(Amazon.Rekognition.Model.UpdateStreamProcessorResponse))]
    [AWSCmdletOutput("None or Amazon.Rekognition.Model.UpdateStreamProcessorResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Rekognition.Model.UpdateStreamProcessorResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateREKStreamProcessorCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectedHomeForUpdate_Label
        /// <summary>
        /// <para>
        /// <para> Specifies what you want to detect in the video, such as people, packages, or pets.
        /// The current valid labels you can include in this list are: "PERSON", "PET", "PACKAGE",
        /// and "ALL". </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SettingsForUpdate_ConnectedHomeForUpdate_Labels")]
        public System.String[] ConnectedHomeForUpdate_Label { get; set; }
        #endregion
        
        #region Parameter ConnectedHomeForUpdate_MinConfidence
        /// <summary>
        /// <para>
        /// <para> The minimum confidence required to label an object in the video. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SettingsForUpdate_ConnectedHomeForUpdate_MinConfidence")]
        public System.Single? ConnectedHomeForUpdate_MinConfidence { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> Name of the stream processor that you want to update. </para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter DataSharingPreferenceForUpdate_OptIn
        /// <summary>
        /// <para>
        /// <para> If this option is set to true, you choose to share data with Rekognition to improve
        /// model performance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DataSharingPreferenceForUpdate_OptIn { get; set; }
        #endregion
        
        #region Parameter ParametersToDelete
        /// <summary>
        /// <para>
        /// <para> A list of parameters you want to delete from the stream processor. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ParametersToDelete { get; set; }
        #endregion
        
        #region Parameter RegionsOfInterestForUpdate
        /// <summary>
        /// <para>
        /// <para> Specifies locations in the frames where Amazon Rekognition checks for objects or
        /// people. This is an optional parameter for label detection stream processors. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Rekognition.Model.RegionOfInterest[] RegionsOfInterestForUpdate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.UpdateStreamProcessorResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-REKStreamProcessor (UpdateStreamProcessor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.UpdateStreamProcessorResponse, UpdateREKStreamProcessorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DataSharingPreferenceForUpdate_OptIn = this.DataSharingPreferenceForUpdate_OptIn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ParametersToDelete != null)
            {
                context.ParametersToDelete = new List<System.String>(this.ParametersToDelete);
            }
            if (this.RegionsOfInterestForUpdate != null)
            {
                context.RegionsOfInterestForUpdate = new List<Amazon.Rekognition.Model.RegionOfInterest>(this.RegionsOfInterestForUpdate);
            }
            if (this.ConnectedHomeForUpdate_Label != null)
            {
                context.ConnectedHomeForUpdate_Label = new List<System.String>(this.ConnectedHomeForUpdate_Label);
            }
            context.ConnectedHomeForUpdate_MinConfidence = this.ConnectedHomeForUpdate_MinConfidence;
            
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
            var request = new Amazon.Rekognition.Model.UpdateStreamProcessorRequest();
            
            
             // populate DataSharingPreferenceForUpdate
            var requestDataSharingPreferenceForUpdateIsNull = true;
            request.DataSharingPreferenceForUpdate = new Amazon.Rekognition.Model.StreamProcessorDataSharingPreference();
            System.Boolean? requestDataSharingPreferenceForUpdate_dataSharingPreferenceForUpdate_OptIn = null;
            if (cmdletContext.DataSharingPreferenceForUpdate_OptIn != null)
            {
                requestDataSharingPreferenceForUpdate_dataSharingPreferenceForUpdate_OptIn = cmdletContext.DataSharingPreferenceForUpdate_OptIn.Value;
            }
            if (requestDataSharingPreferenceForUpdate_dataSharingPreferenceForUpdate_OptIn != null)
            {
                request.DataSharingPreferenceForUpdate.OptIn = requestDataSharingPreferenceForUpdate_dataSharingPreferenceForUpdate_OptIn.Value;
                requestDataSharingPreferenceForUpdateIsNull = false;
            }
             // determine if request.DataSharingPreferenceForUpdate should be set to null
            if (requestDataSharingPreferenceForUpdateIsNull)
            {
                request.DataSharingPreferenceForUpdate = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ParametersToDelete != null)
            {
                request.ParametersToDelete = cmdletContext.ParametersToDelete;
            }
            if (cmdletContext.RegionsOfInterestForUpdate != null)
            {
                request.RegionsOfInterestForUpdate = cmdletContext.RegionsOfInterestForUpdate;
            }
            
             // populate SettingsForUpdate
            var requestSettingsForUpdateIsNull = true;
            request.SettingsForUpdate = new Amazon.Rekognition.Model.StreamProcessorSettingsForUpdate();
            Amazon.Rekognition.Model.ConnectedHomeSettingsForUpdate requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate = null;
            
             // populate ConnectedHomeForUpdate
            var requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdateIsNull = true;
            requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate = new Amazon.Rekognition.Model.ConnectedHomeSettingsForUpdate();
            List<System.String> requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate_connectedHomeForUpdate_Label = null;
            if (cmdletContext.ConnectedHomeForUpdate_Label != null)
            {
                requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate_connectedHomeForUpdate_Label = cmdletContext.ConnectedHomeForUpdate_Label;
            }
            if (requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate_connectedHomeForUpdate_Label != null)
            {
                requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate.Labels = requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate_connectedHomeForUpdate_Label;
                requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdateIsNull = false;
            }
            System.Single? requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate_connectedHomeForUpdate_MinConfidence = null;
            if (cmdletContext.ConnectedHomeForUpdate_MinConfidence != null)
            {
                requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate_connectedHomeForUpdate_MinConfidence = cmdletContext.ConnectedHomeForUpdate_MinConfidence.Value;
            }
            if (requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate_connectedHomeForUpdate_MinConfidence != null)
            {
                requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate.MinConfidence = requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate_connectedHomeForUpdate_MinConfidence.Value;
                requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdateIsNull = false;
            }
             // determine if requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate should be set to null
            if (requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdateIsNull)
            {
                requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate = null;
            }
            if (requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate != null)
            {
                request.SettingsForUpdate.ConnectedHomeForUpdate = requestSettingsForUpdate_settingsForUpdate_ConnectedHomeForUpdate;
                requestSettingsForUpdateIsNull = false;
            }
             // determine if request.SettingsForUpdate should be set to null
            if (requestSettingsForUpdateIsNull)
            {
                request.SettingsForUpdate = null;
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
        
        private Amazon.Rekognition.Model.UpdateStreamProcessorResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.UpdateStreamProcessorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "UpdateStreamProcessor");
            try
            {
                #if DESKTOP
                return client.UpdateStreamProcessor(request);
                #elif CORECLR
                return client.UpdateStreamProcessorAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DataSharingPreferenceForUpdate_OptIn { get; set; }
            public System.String Name { get; set; }
            public List<System.String> ParametersToDelete { get; set; }
            public List<Amazon.Rekognition.Model.RegionOfInterest> RegionsOfInterestForUpdate { get; set; }
            public List<System.String> ConnectedHomeForUpdate_Label { get; set; }
            public System.Single? ConnectedHomeForUpdate_MinConfidence { get; set; }
            public System.Func<Amazon.Rekognition.Model.UpdateStreamProcessorResponse, UpdateREKStreamProcessorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
