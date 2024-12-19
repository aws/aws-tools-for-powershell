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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Modifies the specified streaming properties.
    /// </summary>
    [Cmdlet("Edit", "WKSStreamingProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkSpaces ModifyStreamingProperties API operation.", Operation = new[] {"ModifyStreamingProperties"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.ModifyStreamingPropertiesResponse))]
    [AWSCmdletOutput("None or Amazon.WorkSpaces.Model.ModifyStreamingPropertiesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkSpaces.Model.ModifyStreamingPropertiesResponse) be returned by specifying '-Select *'."
    )]
    public partial class EditWKSStreamingPropertyCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GlobalAccelerator_Mode
        /// <summary>
        /// <para>
        /// <para>Indicates if Global Accelerator for directory is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingProperties_GlobalAccelerator_Mode")]
        [AWSConstantClassSource("Amazon.WorkSpaces.AGAModeForDirectoryEnum")]
        public Amazon.WorkSpaces.AGAModeForDirectoryEnum GlobalAccelerator_Mode { get; set; }
        #endregion
        
        #region Parameter GlobalAccelerator_PreferredProtocol
        /// <summary>
        /// <para>
        /// <para>Indicates the preferred protocol for Global Accelerator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingProperties_GlobalAccelerator_PreferredProtocol")]
        [AWSConstantClassSource("Amazon.WorkSpaces.AGAPreferredProtocolForDirectory")]
        public Amazon.WorkSpaces.AGAPreferredProtocolForDirectory GlobalAccelerator_PreferredProtocol { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the resource.</para>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter StreamingProperties_StorageConnector
        /// <summary>
        /// <para>
        /// <para>Indicates the storage connector used </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingProperties_StorageConnectors")]
        public Amazon.WorkSpaces.Model.StorageConnector[] StreamingProperties_StorageConnector { get; set; }
        #endregion
        
        #region Parameter StreamingProperties_StreamingExperiencePreferredProtocol
        /// <summary>
        /// <para>
        /// <para>Indicates the type of preferred protocol for the streaming experience.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.StreamingExperiencePreferredProtocolEnum")]
        public Amazon.WorkSpaces.StreamingExperiencePreferredProtocolEnum StreamingProperties_StreamingExperiencePreferredProtocol { get; set; }
        #endregion
        
        #region Parameter StreamingProperties_UserSetting
        /// <summary>
        /// <para>
        /// <para>Indicates the permission settings asscoiated with the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingProperties_UserSettings")]
        public Amazon.WorkSpaces.Model.UserSetting[] StreamingProperties_UserSetting { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.ModifyStreamingPropertiesResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-WKSStreamingProperty (ModifyStreamingProperties)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.ModifyStreamingPropertiesResponse, EditWKSStreamingPropertyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GlobalAccelerator_Mode = this.GlobalAccelerator_Mode;
            context.GlobalAccelerator_PreferredProtocol = this.GlobalAccelerator_PreferredProtocol;
            if (this.StreamingProperties_StorageConnector != null)
            {
                context.StreamingProperties_StorageConnector = new List<Amazon.WorkSpaces.Model.StorageConnector>(this.StreamingProperties_StorageConnector);
            }
            context.StreamingProperties_StreamingExperiencePreferredProtocol = this.StreamingProperties_StreamingExperiencePreferredProtocol;
            if (this.StreamingProperties_UserSetting != null)
            {
                context.StreamingProperties_UserSetting = new List<Amazon.WorkSpaces.Model.UserSetting>(this.StreamingProperties_UserSetting);
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
            var request = new Amazon.WorkSpaces.Model.ModifyStreamingPropertiesRequest();
            
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            
             // populate StreamingProperties
            var requestStreamingPropertiesIsNull = true;
            request.StreamingProperties = new Amazon.WorkSpaces.Model.StreamingProperties();
            List<Amazon.WorkSpaces.Model.StorageConnector> requestStreamingProperties_streamingProperties_StorageConnector = null;
            if (cmdletContext.StreamingProperties_StorageConnector != null)
            {
                requestStreamingProperties_streamingProperties_StorageConnector = cmdletContext.StreamingProperties_StorageConnector;
            }
            if (requestStreamingProperties_streamingProperties_StorageConnector != null)
            {
                request.StreamingProperties.StorageConnectors = requestStreamingProperties_streamingProperties_StorageConnector;
                requestStreamingPropertiesIsNull = false;
            }
            Amazon.WorkSpaces.StreamingExperiencePreferredProtocolEnum requestStreamingProperties_streamingProperties_StreamingExperiencePreferredProtocol = null;
            if (cmdletContext.StreamingProperties_StreamingExperiencePreferredProtocol != null)
            {
                requestStreamingProperties_streamingProperties_StreamingExperiencePreferredProtocol = cmdletContext.StreamingProperties_StreamingExperiencePreferredProtocol;
            }
            if (requestStreamingProperties_streamingProperties_StreamingExperiencePreferredProtocol != null)
            {
                request.StreamingProperties.StreamingExperiencePreferredProtocol = requestStreamingProperties_streamingProperties_StreamingExperiencePreferredProtocol;
                requestStreamingPropertiesIsNull = false;
            }
            List<Amazon.WorkSpaces.Model.UserSetting> requestStreamingProperties_streamingProperties_UserSetting = null;
            if (cmdletContext.StreamingProperties_UserSetting != null)
            {
                requestStreamingProperties_streamingProperties_UserSetting = cmdletContext.StreamingProperties_UserSetting;
            }
            if (requestStreamingProperties_streamingProperties_UserSetting != null)
            {
                request.StreamingProperties.UserSettings = requestStreamingProperties_streamingProperties_UserSetting;
                requestStreamingPropertiesIsNull = false;
            }
            Amazon.WorkSpaces.Model.GlobalAcceleratorForDirectory requestStreamingProperties_streamingProperties_GlobalAccelerator = null;
            
             // populate GlobalAccelerator
            var requestStreamingProperties_streamingProperties_GlobalAcceleratorIsNull = true;
            requestStreamingProperties_streamingProperties_GlobalAccelerator = new Amazon.WorkSpaces.Model.GlobalAcceleratorForDirectory();
            Amazon.WorkSpaces.AGAModeForDirectoryEnum requestStreamingProperties_streamingProperties_GlobalAccelerator_globalAccelerator_Mode = null;
            if (cmdletContext.GlobalAccelerator_Mode != null)
            {
                requestStreamingProperties_streamingProperties_GlobalAccelerator_globalAccelerator_Mode = cmdletContext.GlobalAccelerator_Mode;
            }
            if (requestStreamingProperties_streamingProperties_GlobalAccelerator_globalAccelerator_Mode != null)
            {
                requestStreamingProperties_streamingProperties_GlobalAccelerator.Mode = requestStreamingProperties_streamingProperties_GlobalAccelerator_globalAccelerator_Mode;
                requestStreamingProperties_streamingProperties_GlobalAcceleratorIsNull = false;
            }
            Amazon.WorkSpaces.AGAPreferredProtocolForDirectory requestStreamingProperties_streamingProperties_GlobalAccelerator_globalAccelerator_PreferredProtocol = null;
            if (cmdletContext.GlobalAccelerator_PreferredProtocol != null)
            {
                requestStreamingProperties_streamingProperties_GlobalAccelerator_globalAccelerator_PreferredProtocol = cmdletContext.GlobalAccelerator_PreferredProtocol;
            }
            if (requestStreamingProperties_streamingProperties_GlobalAccelerator_globalAccelerator_PreferredProtocol != null)
            {
                requestStreamingProperties_streamingProperties_GlobalAccelerator.PreferredProtocol = requestStreamingProperties_streamingProperties_GlobalAccelerator_globalAccelerator_PreferredProtocol;
                requestStreamingProperties_streamingProperties_GlobalAcceleratorIsNull = false;
            }
             // determine if requestStreamingProperties_streamingProperties_GlobalAccelerator should be set to null
            if (requestStreamingProperties_streamingProperties_GlobalAcceleratorIsNull)
            {
                requestStreamingProperties_streamingProperties_GlobalAccelerator = null;
            }
            if (requestStreamingProperties_streamingProperties_GlobalAccelerator != null)
            {
                request.StreamingProperties.GlobalAccelerator = requestStreamingProperties_streamingProperties_GlobalAccelerator;
                requestStreamingPropertiesIsNull = false;
            }
             // determine if request.StreamingProperties should be set to null
            if (requestStreamingPropertiesIsNull)
            {
                request.StreamingProperties = null;
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
        
        private Amazon.WorkSpaces.Model.ModifyStreamingPropertiesResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.ModifyStreamingPropertiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "ModifyStreamingProperties");
            try
            {
                #if DESKTOP
                return client.ModifyStreamingProperties(request);
                #elif CORECLR
                return client.ModifyStreamingPropertiesAsync(request).GetAwaiter().GetResult();
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
            public System.String ResourceId { get; set; }
            public Amazon.WorkSpaces.AGAModeForDirectoryEnum GlobalAccelerator_Mode { get; set; }
            public Amazon.WorkSpaces.AGAPreferredProtocolForDirectory GlobalAccelerator_PreferredProtocol { get; set; }
            public List<Amazon.WorkSpaces.Model.StorageConnector> StreamingProperties_StorageConnector { get; set; }
            public Amazon.WorkSpaces.StreamingExperiencePreferredProtocolEnum StreamingProperties_StreamingExperiencePreferredProtocol { get; set; }
            public List<Amazon.WorkSpaces.Model.UserSetting> StreamingProperties_UserSetting { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.ModifyStreamingPropertiesResponse, EditWKSStreamingPropertyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
